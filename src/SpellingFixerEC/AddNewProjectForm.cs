﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpellingFixerEC
{
    public partial class AddNewProjectForm : Form
    {
        public AddNewProjectForm(string addlPunctuation)
        {
            InitializeComponent();

            if (!String.IsNullOrEmpty(addlPunctuation))
            {
                textBoxAddlPunctuation.Text = DecodePunctuationForCC(addlPunctuation);
            }
        }

        public string NewProjectName
        {
            get { return textBoxName.Text; }
            set { textBoxName.Text = value; }
        }

        public string WordBoundaryDelimiter
        {
            get { return textBoxWordBoundaryDelimiter.Text; }
            set { textBoxWordBoundaryDelimiter.Text = value; }
        }

        public Font SelectedFont
        {
            get { return fontDialog.Font; }
            set 
            { 
                fontDialog.Font = value;
                labelFontChosen.Text = $"{fontDialog.Font.Name}, with size: {fontDialog.Font.Size}";
            }
        }

        public bool IsRightToLeft
        {
            get { return checkBoxRtL.Checked; }
            set { checkBoxRtL.Checked = value; }
        }

        public bool UserDefinedPunctuation { get; set; }

        public string GetAddlPunctuation(bool encoded)
        {
            var addlPunctuation = textBoxAddlPunctuation.Text;
            if (encoded)
            {
                addlPunctuation = EncodePunctuationForCC(addlPunctuation);
            }
            return addlPunctuation;
        }

        private void ButtonChooseFont_Click(object sender, EventArgs e)
        {
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxWordBoundaryDelimiter.Font = textBoxAddlPunctuation.Font = SelectedFont = fontDialog.Font;                
            }
        }

        private void ButtonOk_Click(object sender, EventArgs e)
        {
        }

        private string EncodePunctuationForCC(string strPunctuation)
        {
            string strRet = null;

            if (UserDefinedPunctuation)
                return strPunctuation;

            else if (!String.IsNullOrEmpty(strPunctuation))
            {
                string[] astrChars = strPunctuation.Split(new char[] { ' ' });
                foreach (string strChar in astrChars)
                {
                    if (SpellingFixerEC.GetDefaultPunctuation.IndexOf(strChar) != -1)
                    {
                        MessageBox.Show(String.Format("There's no need to add the {0} character as Additional Punctuation because it's there by default,\r\nas are these: {1}",
                            strChar, DecodePunctuationForCCEx(SpellingFixerEC.GetDefaultPunctuation)), SpellingFixerEC.cstrCaption);
                        return null;
                    }
                    strRet += '\'' + strChar + "\' ";
                }
                if (!String.IsNullOrEmpty(strRet))
                    strRet = strRet.Substring(0, strRet.Length - 1);

                return SpellingFixerEC.GetDefaultPunctuation + ' ' + strRet;
            }

            return SpellingFixerEC.GetDefaultPunctuation;
        }

        private string DecodePunctuationForCC(string strPunctuation)
        {
            if (String.IsNullOrEmpty(strPunctuation))
                return null;

            else
            {
                // initialize it so that *we* take care of delimiting the punctuation
                UserDefinedPunctuation = false;

                // the first chunk of this should be the fixed punctuation
                int nIndex = strPunctuation.IndexOf(SpellingFixerEC.GetDefaultPunctuation);
                if ((nIndex == 0) && (strPunctuation.Length <= SpellingFixerEC.GetDefaultPunctuation.Length))
                {
                    // if this is all there is, then the 'decoded' string is nothing.
                    return null;
                }
                else
                {
                    // pre-v3
                    nIndex = strPunctuation.IndexOf(SpellingFixerEC.cstrDefaultPunctuationAndWhitespace);
                    if (nIndex == 0)
                    {
                        // if this is all there is, then the 'decoded' string is nothing.
                        int nLength = SpellingFixerEC.cstrDefaultPunctuationAndWhitespace.Length;
                        if (strPunctuation.Length <= nLength)
                            return null;

                        // otherwise, process only the extra
                        strPunctuation = strPunctuation.Substring(nLength);
                        if (strPunctuation.IndexOf(SpellingFixerEC.cstrV3DefaultPunctuationAndWhitespaceAdds) == 0)
                        {
                            nLength = SpellingFixerEC.cstrV3DefaultPunctuationAndWhitespaceAdds.Length;
                            if (strPunctuation.Length <= nLength)
                                return null;
                            strPunctuation = strPunctuation.Substring(nLength + 1);
                        }
                        else
                            strPunctuation = strPunctuation.Substring(1);
                    }
                    else
                    {
                        UserDefinedPunctuation = true;
                        return strPunctuation;  // in this case, the user is responsible for delimiting the string him/herself
                    }
                }
            }

            return DecodePunctuationForCCEx(strPunctuation);
        }

        private string DecodePunctuationForCCEx(string strPunctuation)
        {
            string strRet = null;
            string[] astrDelimitedChars = strPunctuation.Split(new char[] { ' ' });

            // each string should be in the form 'X', where X is the punctuation
            foreach (string strDelimitedChar in astrDelimitedChars)
            {
                if ((strDelimitedChar.IndexOfAny(new char[] { '\'', '\"' }) != -1)
                    && (strDelimitedChar.Length > 2))
                    strRet += strDelimitedChar.Substring(1, strDelimitedChar.Length - 2);
                else
                    strRet += strDelimitedChar;

                strRet += ' ';
            }

            if (!String.IsNullOrEmpty(strRet))
                strRet = strRet.Substring(0, strRet.Length - 1);

            return strRet;
        }

        private void AddNewProjectForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (WordBoundaryDelimiter.Contains('"'))
            {
                MessageBox.Show("Can't use the double-quote character for the word boundary delimiter",
                                SpellingFixerEC.cstrCaption);
                e.Cancel = true;
                return;
            }

            if (String.IsNullOrEmpty(NewProjectName))
            {
                MessageBox.Show("You must define a name for this converter (e.g. 'Hindi fixes')",
                                SpellingFixerEC.cstrCaption);
                e.Cancel = true;
                return;
            }

            if (String.IsNullOrEmpty(labelFontChosen.Text))
            {
                if (MessageBox.Show("Did you want to select a font to use when displaying Find-Replace pairs?",
                                    SpellingFixerEC.cstrCaption, MessageBoxButtons.YesNo)
                    == DialogResult.Yes)
                {
                    e.Cancel = true;
                    return;
                }
            }
        }
    }
}
