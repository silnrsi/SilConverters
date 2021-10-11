﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Xml.Linq;

namespace SILConvertersWordML
{
    // a different implementation based on Linq rather than XPath
    public abstract class LinqDocument : DocXmlDocument
    {
        protected LinqDocument()
            : base(new MapIteratorListLinq())
        {

        }

        protected XDocument XDocument { get; set; }

        protected XElement DocumentRoot
        {
            get
            {
                if ((XDocument == null) || (XDocument.Root == null))
                    throw new ApplicationException(
                        "Document wasn't initialized properly. If this error continues, then send an email to silconverters_support@sil.org with the steps to reproduce this error (including the document)");
                return XDocument.Root;
            }
        }

        private Dictionary<string, StyleClass> _styles;
        protected Dictionary<string, StyleClass> Styles
        {
            get { return _styles ?? (_styles = ListStyles(DocumentRoot).ToDictionary(s => s.Id, s => s)); }
        }

        // map for fontName => List of XElements of the runs associated with that font THAT HAVE CUSTOM FORMATTING
        protected Dictionary<string, List<XElement>> MapCustomFontNameToListOfRuns =
            new Dictionary<string, List<XElement>>();

        // map for fontName => List of XElements of the runs associated with that font THAT ARE BASED ON NON-CUSTOM FORMATTING 
        //  (i.e. the font name associated with the associated style formatting)
        protected Dictionary<string, List<XElement>> MapStyleFontNameToListOfRuns =
            new Dictionary<string, List<XElement>>();

        // map for the styleId => a) styleName and b) List of XElements of the runs associated with that styleId
        protected Dictionary<string, Tuple<string, List<XElement>>> MapStyleIdToListOfRuns =
            new Dictionary<string, Tuple<string, List<XElement>>>();

        #region Overrides of DocXmlDocument

        protected override string GetXmlFileSuffix
        {
            get { return FontsStylesForm.cstrLeftXmlFileSuffixAfterLinqTransform; }
        }

        public override bool ConvertDocumentByFontNameAndStyle(Dictionary<string, Font> mapName2Font,
                                                               Func<string, DataIterator, string, Font, bool, bool> convertDoc)
        {
            // mapFontNames2Iterator, has one iterator for each unique font (across all docs). If there's
            //  only one doc, then it's already loaded. But if there's more than one doc, then we have to treat each 
            //  one as if by itself (which unfortunately means empty the collection and requery)
            // UPDATE (2021-10-08): even for one, we need to resent it, bkz it's possible the user clicked thru some samples
            //  so it wouldn't start at the beginning
            // if (!Program.IsOnlyOneDoc)
            {
                MapIteratorList = new MapIteratorListLinq();
                InitializeIteratorsCustomFontNames();
                InitializeIteratorsFontsFromStyles();
            }

            var bModified = false;
            var map2Iterator = MyMapIteratorList.MapCustomFontName2Iterator;
            foreach (var strFontName in map2Iterator.Keys)
            {
                Debug.Assert(mapName2Font.ContainsKey(strFontName));
                var fontTarget = mapName2Font[strFontName];

                var mapItem = map2Iterator.FirstOrDefault(kvp => kvp.Key == strFontName);
                bModified |= convertDoc(strFontName, mapItem.Value, strFontName, fontTarget, false);

                // update the font name as well if it changed...
                if (strFontName == fontTarget.Name)
                    continue;

                ReplaceCustomFontName(mapItem, fontTarget.Name);
                ReplaceFontElementNames(strFontName, fontTarget.Name);
            }

            map2Iterator = MyMapIteratorList.MapStyleFontName2Iterator;
            foreach (var strFontName in map2Iterator.Keys)
            {
                Debug.Assert(mapName2Font.ContainsKey(strFontName));
                var fontTarget = mapName2Font[strFontName];

                var mapItem = map2Iterator.FirstOrDefault(kvp => kvp.Key == strFontName);
                bModified |= convertDoc(strFontName, mapItem.Value, strFontName, fontTarget, false);

                // update the font name as well if it changed...
                if (strFontName == fontTarget.Name)
                    continue;

                ReplaceStyleFontName(mapItem, fontTarget.Name);
                ReplaceFontElementNames(strFontName, fontTarget.Name);
            }
            return bModified;
        }

        private void ReplaceStyleFontName(KeyValuePair<string, DataIterator> mapItem, string strFontNameTarget)
        {
            var strFontNameSource = mapItem.Key;
            foreach (var styleClass in Styles.Values
                                             .Where(sc => sc.HasFontFormatting && 
                                                          sc.FontNames.Contains(strFontNameSource)))
            {
                ReplaceStyleFontName(styleClass, strFontNameSource, strFontNameTarget);
            }

            // since we might have things like this:
            /*
                <w:r wsp:rsidR="00A66D4F">
                    <w:rPr>
                        <w:rStyle w:val="PageNumber" />
                        <wx:font wx:val="A_steve A_steve SILDoulosL" />             <=========== ... change these bits
                    </w:rPr>
                    <w:instrText>PAGE  </w:instrText>
                </w:r>
             */
            // to keep this simple, just replace any attribute of any element whose value is the source font name 
            //  with the new font name
            var listOfRuns = ((LinqDataIterator)mapItem.Value).ListOfRuns;
            listOfRuns.ForEach(run => UpdateAllChildElementAttributesValue(GetRunFormattingParent(run), strFontNameSource, strFontNameTarget));

            // for Word, this also includes the style formatting at the paragraph level (where there is no text involved)
            ReplaceFontNameAtParagraphLevel(strFontNameSource, strFontNameTarget);
        }

        private void ReplaceCustomFontName(KeyValuePair<string, DataIterator> mapItem, string strFontNameTarget)
        {
            var strFontNameSource = mapItem.Key;
            var listOfRuns = ((LinqDataIterator) mapItem.Value).ListOfRuns;

            // to keep this simple, just replace any attribute of any element whose value is the source font name 
            //  with the new font name
            listOfRuns.ForEach(run => UpdateAllChildElementAttributesValue(GetRunFormattingParent(run), strFontNameSource, strFontNameTarget));

            // for Word, this also includes the custom formatting at the paragraph level (where there is no text involved)
            ReplaceFontNameAtParagraphLevel(strFontNameSource, strFontNameTarget);
        }

        protected static IEnumerable<string> GetAllAttributeValues(XElement elem)
        {
            return elem.Attributes().Select(attr => attr.Value);
        }

        protected static void UpdateAllChildElementAttributesValue(XContainer elemParent, string strOldValue, string strNewValue)
        {
            if (elemParent == null)
                return; // nothing to do here... move along...

            foreach (var attr in elemParent.Elements()
                                           .Attributes()
                                           .Where(attr => attr.Value == strOldValue))
            {
                attr.Value = strNewValue;
            }
        }

        protected static void UpdateAllChildElementAttributesValue(XContainer elemParent, XName xNameOfChild, string strOldValue, string strNewValue)
        {
            if (elemParent == null)
                return; // nothing to do here... move along...

            var child = elemParent.Element(xNameOfChild);
            if (child == null)
                return;

            foreach (var attr in child.Attributes().Where(attr => attr.Value == strOldValue))
                attr.Value = strNewValue;
        }

        public override bool ConvertDocumentByStylesOnly(Dictionary<string, Font> mapName2Font,
                                                         Func<string, DataIterator, string, Font, bool, bool> convertDoc)
        {
            // mapFontNames2Iterator, has one iterator for each unique font (across all docs). If there's
            //  only one doc, then it's already loaded. But if there's more than one doc, then we have to treat each 
            //  one as if by itself (which unfortunately means empty the collection and requery)
            if (!Program.IsOnlyOneDoc)
            {
                MapIteratorList = new MapIteratorListLinq();
                InitializeIteratorsStyleName();
            }

            var bModified = false;
            var map2Iterator = MyMapIteratorList.MapStyleName2Iterator;
            foreach (var strStyleId in map2Iterator.Keys
                                                   .Where(sn => Program.m_aForm.IsConverterDefined(sn)))
            {
                Debug.Assert(mapName2Font.ContainsKey(strStyleId));
                var fontTarget = mapName2Font[strStyleId];

                var mapItem = map2Iterator.FirstOrDefault(kvp => kvp.Key == strStyleId);
                bModified |= convertDoc(strStyleId, mapItem.Value, strStyleId, fontTarget, false);

                // update the font name as well if it changed...
                if (Styles[strStyleId].FontNames.Contains(fontTarget.Name))
                    continue;

                ReplaceStyleFontName(mapItem, fontTarget.Name);
            }

            return bModified;
        }

        public override bool ConvertDocumentByFontNameOnly(Dictionary<string, Font> mapName2Font,
                                                           Func<string, DataIterator, string, Font, bool, bool>
                                                               convertDoc)
        {
            // mapFontNames2Iterator, has one iterator for each unique font (across all docs). If there's
            //  only one doc, then it's already loaded. But if there's more than one doc, then we have to treat each 
            //  one as if by itself (which unfortunately means empty the collection and requery)
            if (!Program.IsOnlyOneDoc)
            {
                MapIteratorList = new MapIteratorListLinq();
                InitializeIteratorsCustomFontNames();
            }

            var bModified = false;
            var map2Iterator = MyMapIteratorList.MapCustomFontName2Iterator;
            foreach (var strFontName in map2Iterator.Keys)
            {
                Debug.Assert(mapName2Font.ContainsKey(strFontName));
                var fontTarget = mapName2Font[strFontName];

                var mapItem = map2Iterator.FirstOrDefault(kvp => kvp.Key == strFontName);
                bModified |= convertDoc(strFontName, mapItem.Value, strFontName, fontTarget, false);

                // update the font name as well if it changed...
                if (strFontName == fontTarget.Name)
                    continue;

                ReplaceCustomFontName(mapItem, fontTarget.Name);
                ReplaceFontElementNames(strFontName, fontTarget.Name);
            }

            return bModified;
        }

        public override void Save(string strXmlOutputFilename)
        {
            XDocument.Save(strXmlOutputFilename);
        }

        #endregion

        protected virtual void HarvestFontsAndStylesUsedInAllText()
        {
            // go through all the runs in the document that a) have text and b) find out what font as associated with it
            // to start with, get all the 'paragraphs' that have some text associated with it
            foreach (var paragraph in Paragraphs)
            {
                HarvestFontAndOrStyleFromParagraph(paragraph);
            }
        }

        protected virtual void HarvestFontAndOrStyleFromParagraph(XElement paragraph)
        {
            foreach (var run in Runs(paragraph))
            {
                HarvestCustomFontAndOrStyleFromRun(run, paragraph);
            }
        }

        protected virtual void HarvestCustomFontAndOrStyleFromRun(XElement run, XElement paragraph)
        {
            // there are four types of ways in which a font is associated with some text:
            //  1) Custom formatting on the run (i.e. w:rFonts and/or wx:font within the run's w:rPr) 
            //     (I think wx:font/@wx:val actually indicates the font being used an rFonts gives the possibilities for which range)
            //  2) Style formatting override on the run (i.e. w:rStyle within the run's w:rPr)
            //  3) Default Paragraph Style formatting override
            //  4) Default document formatting

            // there's *always* a style associated with a run. If it's not in the 'run', 
            //  look in the paragraph. If it's not in the paragraph, then it's 'Normal'
            //  also, get the font associated with that style, which 
            string strFontName, strStyleId, strStyleName;
            GetMostRelevantStyleFormat(run, paragraph, out strStyleId, out strStyleName, out strFontName);
            AddRunToStyleNameList(strStyleId, strStyleName, run);

            // but if there's custom formatting, that overrules everything 
            //  (we put CustomFont vs. style-based font runs in a different map)
            var mapToListOfRuns = (CheckForCustomFontFormatting(run, ref strFontName))
                                      ? MapCustomFontNameToListOfRuns
                                      : MapStyleFontNameToListOfRuns;

            AddRunToFontNameList(strFontName, run, mapToListOfRuns);
        }

        private static void AddRunToFontNameList(string strFontName, XElement run,
                                                 Dictionary<string, List<XElement>> mapToListOfRuns)
        {
            List<XElement> listOfRunsForFontName;
            if (!mapToListOfRuns.TryGetValue(strFontName, out listOfRunsForFontName))
            {
                listOfRunsForFontName = new List<XElement>();
                mapToListOfRuns.Add(strFontName, listOfRunsForFontName);
            }
            listOfRunsForFontName.Add(run);
        }

        private void AddRunToStyleNameList(string strStyleId, string strStyleName, XElement run)
        {
            Tuple<string, List<XElement>> tupleForStyleNameAndListOfRunsForStyleId;
            if (!MapStyleIdToListOfRuns.TryGetValue(strStyleId, out tupleForStyleNameAndListOfRunsForStyleId))
            {
                tupleForStyleNameAndListOfRunsForStyleId = Tuple.Create(strStyleName, new List<XElement>());
                MapStyleIdToListOfRuns.Add(strStyleId, tupleForStyleNameAndListOfRunsForStyleId);
            }
            tupleForStyleNameAndListOfRunsForStyleId.Item2.Add(run);
        }

        protected static string GetElementAttributeValue(XElement elemParent, XName xNameElement, XName xNameAttribute)
        {
            var elem = elemParent.Element(xNameElement);
            return GetAttributeValue(elem, xNameAttribute);
        }

        protected static void SetElementAttributeValue(XElement elemParent, XName xNameElement, XName xNameAttribute, string strValue)
        {
            var elem = elemParent.Element(xNameElement);
            SetAttributeValue(elem, xNameAttribute, strValue);
        }

        protected static string GetDescendantAttributeValue(XElement elemParent, XName xNameElement,
                                                            XName xNameAttribute)
        {
            var elem = elemParent.Descendants(xNameElement).FirstOrDefault();
            return GetAttributeValue(elem, xNameAttribute);
        }

        protected static string GetAttributeValue(XElement elem, XName xNameAttribute)
        {
            if (elem != null)
            {
                var attr = elem.Attribute(xNameAttribute);
                if (attr != null)
                    return attr.Value;
            }
            return null;
        }

        protected static void SetAttributeValue(XElement elem, XName xNameAttribute, string strValue)
        {
            var attr = elem.Attribute(xNameAttribute);
            if (attr != null)
                attr.Value = strValue;
        }

        protected static XElement GetElement(XElement elem, XName xName)
        {
            return elem.Element(xName);
        }

        protected MapIteratorListLinq MyMapIteratorList
        {
            get { return MapIteratorList as MapIteratorListLinq; }
        }

        public override void InitializeIteratorsCustomFontNames(List<string> lstInGrid,
                                                               Action<string, DataIterator> displayInGrid)
        {
            if (!MyMapIteratorList.IsInitializedCustomFontName)
                InitializeIteratorsCustomFontNames();
    
            // put a clone in the grid
            foreach (var kvp in MyMapIteratorList.MapCustomFontName2Iterator
                .Where(kvp => !lstInGrid.Contains(kvp.Key)))
            {
                displayInGrid(kvp.Key, kvp.Value);
                lstInGrid.Add(kvp.Key);
            }
        }

        private void InitializeIteratorsCustomFontNames()
        {
            // initialize the MapFontNames2Iterator
            foreach (var kvp in MapCustomFontNameToListOfRuns)
            {
                var iterator = new LinqDataIterator
                                   {
                                       LinqDocument = this,
                                       ListOfRuns = kvp.Value
                                   };
                MyMapIteratorList.MapCustomFontName2Iterator.Add(kvp.Key, iterator);
            }
        }

        public override void InitializeIteratorsFontsFromStyles(List<string> lstInGrid,
                                                                Action<string, DataIterator> displayInGrid)
        {
            if (!MyMapIteratorList.IsInitializedFontsFromStyles)
                InitializeIteratorsFontsFromStyles();
    
            // put a clone in the grid
            foreach (var kvp in MyMapIteratorList.MapStyleFontName2Iterator
                .Where(kvp => !lstInGrid.Contains(kvp.Key)))
            {
                displayInGrid(kvp.Key, kvp.Value);
                lstInGrid.Add(kvp.Key);
            }
        }

        private void InitializeIteratorsFontsFromStyles()
        {
            // initialize the MapFontNames2Iterator
            foreach (var kvp in MapStyleFontNameToListOfRuns)
            {
                var iterator = new LinqDataIterator
                                   {
                                       LinqDocument = this,
                                       ListOfRuns = kvp.Value
                                   };
                MyMapIteratorList.MapStyleFontName2Iterator.Add(kvp.Key, iterator);
            }
        }

        public override void InitializeIteratorsStyleName(List<string> lstInGrid,
                                                          Action<string, DataIterator> displayInGrid)
        {
            if (!MyMapIteratorList.IsInitializedStyleName)
                InitializeIteratorsStyleName();
    
            // put them in the grid
            foreach (var kvp in MyMapIteratorList.MapStyleName2Iterator
                .Where(kvp => !lstInGrid.Contains(kvp.Key)))
            {
                displayInGrid(kvp.Key, kvp.Value);
                lstInGrid.Add(kvp.Key);
            }
        }

        private void InitializeIteratorsStyleName()
        {
            // initialize the MapFontNames2Iterator
            foreach (var kvp in MapStyleIdToListOfRuns)
            {
                var iterator = new LinqDataIterator
                                   {
                                       LinqDocument = this,
                                       ListOfRuns = kvp.Value.Item2
                                   };
                MyMapIteratorList.MapStyleName2Iterator.Add(kvp.Value.Item1, iterator);
            }
        }

        protected abstract List<StyleClass> ListStyles(XElement documentRoot);
        protected abstract IEnumerable<XElement> Paragraphs { get; }
        protected abstract XContainer FontsListRoot { get; }
        protected abstract IEnumerable<XElement> Runs(XElement paragraph);
        protected abstract XElement GetRunFormattingParent(XElement run);
        protected abstract void ReplaceStyleFontName(StyleClass styleClass, string strFontNameOld, string strFontNameNew);
        protected abstract void ReplaceFontNameAtParagraphLevel(string strFontNameOld, string strFontNameNew);
        protected abstract void ReplaceFontElementNames(string strFontNameOld, string strFontNameNew);


        protected abstract void GetMostRelevantStyleFormat(XElement run, XElement paragraph, out string strStyleId,
                                                           out string strStyleName, out string strFontName);

        protected abstract bool CheckForCustomFontFormatting(XElement run, ref string strFontName);
        public abstract string GetTextFromRun(XElement run);
        internal abstract void SetTextOfRun(XElement xElement, string str);
    }

    public class MapIteratorListLinq : MapIteratorList
    {
        public MapIteratorListLinq()
        {
            ResetMaps();
        }

        public IteratorMap MapCustomFontName2Iterator;
                           // for "Custom Font only" and with the next for "Style and Custom Formatting"

        public IteratorMap MapStyleFontName2Iterator; // for "Style and Custom Formatting" (with the previous)
        public IteratorMap MapStyleName2Iterator; // for "Style-only" formatting

        #region Overrides of MapIteratorList

        public override bool IsInitializedCustomFontName
        {
            get { return (MapCustomFontName2Iterator.Count > 0); }
        }

        public override bool IsInitializedFontsFromStyles
        {
            get { return (MapStyleFontName2Iterator.Count > 0); }
        }

        public override bool IsInitializedStyleName
        {
            get { return (MapStyleName2Iterator.Count > 0); }
        }

        public override sealed void ResetMaps()
        {
            MapCustomFontName2Iterator = new IteratorMap();
            MapStyleFontName2Iterator = new IteratorMap();
            MapStyleName2Iterator = new IteratorMap();
        }

        #endregion
    }
}