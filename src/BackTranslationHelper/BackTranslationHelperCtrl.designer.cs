﻿
namespace BackTranslationHelper
{
    partial class BackTranslationHelperCtrl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeEncConverterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addEncConverterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fontsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sourceTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.targetTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoSaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hideColumn1LabelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.labelTargetTextExisting = new System.Windows.Forms.Label();
            this.labelPossibleTargetTranslation1 = new System.Windows.Forms.Label();
            this.buttonFillTargetTextOption1 = new System.Windows.Forms.Button();
            this.textBoxTargetBackTranslation = new System.Windows.Forms.TextBox();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonWriteTextToTarget = new System.Windows.Forms.Button();
            this.buttonCopyToClipboard = new System.Windows.Forms.Button();
            this.buttonNextSection = new System.Windows.Forms.Button();
            this.labelPossibleTargetTranslation2 = new System.Windows.Forms.Label();
            this.labelPossibleTargetTranslation3 = new System.Windows.Forms.Label();
            this.buttonFillTargetTextOption2 = new System.Windows.Forms.Button();
            this.buttonFillTargetTextOption3 = new System.Windows.Forms.Button();
            this.labelForSourceData = new System.Windows.Forms.Label();
            this.labelForExistingTargetData = new System.Windows.Forms.Label();
            this.labelForTargetDataOptions = new System.Windows.Forms.Label();
            this.labelForTargetTranslation = new System.Windows.Forms.Label();
            this.labelSourceData = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(69, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeEncConverterToolStripMenuItem,
            this.addEncConverterToolStripMenuItem,
            this.fontsToolStripMenuItem,
            this.autoSaveToolStripMenuItem,
            this.hideColumn1LabelsToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "&Settings";
            // 
            // changeEncConverterToolStripMenuItem
            // 
            this.changeEncConverterToolStripMenuItem.Name = "changeEncConverterToolStripMenuItem";
            this.changeEncConverterToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.changeEncConverterToolStripMenuItem.Text = "Change &Translator/EncConverter";
            this.changeEncConverterToolStripMenuItem.ToolTipText = "Click to switch to a different Translator/EncConverter used to generate the trans" +
    "lated draft of the source text (e.g. Bing Translator)";
            this.changeEncConverterToolStripMenuItem.Click += new System.EventHandler(this.changeEncConverterToolStripMenuItem_Click);
            // 
            // addEncConverterToolStripMenuItem
            // 
            this.addEncConverterToolStripMenuItem.Name = "addEncConverterToolStripMenuItem";
            this.addEncConverterToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.addEncConverterToolStripMenuItem.Text = "&Add Translator/EncConverter";
            this.addEncConverterToolStripMenuItem.ToolTipText = "Click to add an additional Translator/EncConverter to give multiple options for t" +
    "he translated draft of the source text (e.g. DeepL Translator)";
            this.addEncConverterToolStripMenuItem.Click += new System.EventHandler(this.addEncConverterToolStripMenuItem_Click);
            // 
            // fontsToolStripMenuItem
            // 
            this.fontsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sourceTextToolStripMenuItem,
            this.targetTextToolStripMenuItem});
            this.fontsToolStripMenuItem.Name = "fontsToolStripMenuItem";
            this.fontsToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.fontsToolStripMenuItem.Text = "&Fonts";
            // 
            // sourceTextToolStripMenuItem
            // 
            this.sourceTextToolStripMenuItem.Name = "sourceTextToolStripMenuItem";
            this.sourceTextToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.sourceTextToolStripMenuItem.Text = "&Source text";
            // 
            // targetTextToolStripMenuItem
            // 
            this.targetTextToolStripMenuItem.Name = "targetTextToolStripMenuItem";
            this.targetTextToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.targetTextToolStripMenuItem.Text = "&Target text";
            // 
            // autoSaveToolStripMenuItem
            // 
            this.autoSaveToolStripMenuItem.Checked = true;
            this.autoSaveToolStripMenuItem.CheckOnClick = true;
            this.autoSaveToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoSaveToolStripMenuItem.Name = "autoSaveToolStripMenuItem";
            this.autoSaveToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.autoSaveToolStripMenuItem.Text = "&Auto-Save";
            this.autoSaveToolStripMenuItem.ToolTipText = "If this is checked, then the translated text changes will be saved when clicking " +
    "the \'Next\' button";
            // 
            // hideColumn1LabelsToolStripMenuItem
            // 
            this.hideColumn1LabelsToolStripMenuItem.CheckOnClick = true;
            this.hideColumn1LabelsToolStripMenuItem.Name = "hideColumn1LabelsToolStripMenuItem";
            this.hideColumn1LabelsToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.hideColumn1LabelsToolStripMenuItem.Text = "&Hide column1 labels";
            this.hideColumn1LabelsToolStripMenuItem.ToolTipText = "Check this menu item to hide the column 1 labels to make more room for the transl" +
    "ated text options";
            this.hideColumn1LabelsToolStripMenuItem.CheckStateChanged += new System.EventHandler(this.hideColumn1LabelsToolStripMenuItem_CheckStateChanged);
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel.AutoSize = true;
            this.tableLayoutPanel.ColumnCount = 6;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.44444F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.55556F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel.Controls.Add(this.labelTargetTextExisting, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.labelPossibleTargetTranslation1, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.buttonFillTargetTextOption1, 5, 2);
            this.tableLayoutPanel.Controls.Add(this.textBoxTargetBackTranslation, 1, 5);
            this.tableLayoutPanel.Controls.Add(this.buttonClose, 1, 6);
            this.tableLayoutPanel.Controls.Add(this.buttonWriteTextToTarget, 2, 6);
            this.tableLayoutPanel.Controls.Add(this.buttonCopyToClipboard, 3, 6);
            this.tableLayoutPanel.Controls.Add(this.buttonNextSection, 4, 6);
            this.tableLayoutPanel.Controls.Add(this.labelPossibleTargetTranslation2, 1, 3);
            this.tableLayoutPanel.Controls.Add(this.labelPossibleTargetTranslation3, 1, 4);
            this.tableLayoutPanel.Controls.Add(this.buttonFillTargetTextOption2, 5, 3);
            this.tableLayoutPanel.Controls.Add(this.buttonFillTargetTextOption3, 5, 4);
            this.tableLayoutPanel.Controls.Add(this.labelForExistingTargetData, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.labelForTargetDataOptions, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.labelForTargetTranslation, 0, 5);
            this.tableLayoutPanel.Controls.Add(this.labelSourceData, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.labelForSourceData, 0, 0);
            this.tableLayoutPanel.Location = new System.Drawing.Point(3, 27);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 7;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(712, 481);
            this.tableLayoutPanel.TabIndex = 1;
            // 
            // labelTargetTextExisting
            // 
            this.labelTargetTextExisting.AutoSize = true;
            this.labelTargetTextExisting.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tableLayoutPanel.SetColumnSpan(this.labelTargetTextExisting, 5);
            this.labelTargetTextExisting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTargetTextExisting.Location = new System.Drawing.Point(144, 24);
            this.labelTargetTextExisting.Margin = new System.Windows.Forms.Padding(3);
            this.labelTargetTextExisting.Name = "labelTargetTextExisting";
            this.labelTargetTextExisting.Size = new System.Drawing.Size(565, 15);
            this.labelTargetTextExisting.TabIndex = 5;
            this.labelTargetTextExisting.Text = "Existing Target Text";
            // 
            // labelPossibleTargetTranslation1
            // 
            this.labelPossibleTargetTranslation1.AutoSize = true;
            this.labelPossibleTargetTranslation1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tableLayoutPanel.SetColumnSpan(this.labelPossibleTargetTranslation1, 4);
            this.labelPossibleTargetTranslation1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPossibleTargetTranslation1.Location = new System.Drawing.Point(144, 45);
            this.labelPossibleTargetTranslation1.Margin = new System.Windows.Forms.Padding(3);
            this.labelPossibleTargetTranslation1.Name = "labelPossibleTargetTranslation1";
            this.labelPossibleTargetTranslation1.Size = new System.Drawing.Size(535, 23);
            this.labelPossibleTargetTranslation1.TabIndex = 7;
            this.labelPossibleTargetTranslation1.Text = "Target Text Options 1";
            // 
            // buttonFillTargetTextOption1
            // 
            this.buttonFillTargetTextOption1.Image = global::BackTranslationHelper.Properties.Resources.FillDownHS;
            this.buttonFillTargetTextOption1.Location = new System.Drawing.Point(685, 45);
            this.buttonFillTargetTextOption1.Name = "buttonFillTargetTextOption1";
            this.buttonFillTargetTextOption1.Size = new System.Drawing.Size(23, 23);
            this.buttonFillTargetTextOption1.TabIndex = 8;
            this.toolTip.SetToolTip(this.buttonFillTargetTextOption1, "Click on this button to transfer this translated text to the editable text box be" +
        "low (e.g. if this is the better option to start with).");
            this.buttonFillTargetTextOption1.UseVisualStyleBackColor = true;
            this.buttonFillTargetTextOption1.Click += new System.EventHandler(this.buttonFillTargetTextOption1_Click);
            // 
            // textBoxTargetBackTranslation
            // 
            this.tableLayoutPanel.SetColumnSpan(this.textBoxTargetBackTranslation, 5);
            this.textBoxTargetBackTranslation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxTargetBackTranslation.Location = new System.Drawing.Point(144, 132);
            this.textBoxTargetBackTranslation.Multiline = true;
            this.textBoxTargetBackTranslation.Name = "textBoxTargetBackTranslation";
            this.textBoxTargetBackTranslation.Size = new System.Drawing.Size(565, 317);
            this.textBoxTargetBackTranslation.TabIndex = 1;
            this.textBoxTargetBackTranslation.Enter += new System.EventHandler(this.textBoxTargetBackTranslation_Enter);
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonClose.Location = new System.Drawing.Point(218, 455);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 6;
            this.buttonClose.Text = "Close";
            this.toolTip.SetToolTip(this.buttonClose, "Click to close this dialog");
            this.buttonClose.UseVisualStyleBackColor = true;
            // 
            // buttonWriteTextToTarget
            // 
            this.buttonWriteTextToTarget.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonWriteTextToTarget.Location = new System.Drawing.Point(299, 455);
            this.buttonWriteTextToTarget.Name = "buttonWriteTextToTarget";
            this.buttonWriteTextToTarget.Size = new System.Drawing.Size(104, 23);
            this.buttonWriteTextToTarget.TabIndex = 2;
            this.buttonWriteTextToTarget.Text = "&Save Changes";
            this.toolTip.SetToolTip(this.buttonWriteTextToTarget, "Click to save/write out the changes to the translated text");
            this.buttonWriteTextToTarget.UseVisualStyleBackColor = true;
            this.buttonWriteTextToTarget.Click += new System.EventHandler(this.buttonWriteTextToTarget_Click);
            // 
            // buttonCopyToClipboard
            // 
            this.buttonCopyToClipboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCopyToClipboard.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCopyToClipboard.Location = new System.Drawing.Point(409, 455);
            this.buttonCopyToClipboard.Name = "buttonCopyToClipboard";
            this.buttonCopyToClipboard.Size = new System.Drawing.Size(75, 23);
            this.buttonCopyToClipboard.TabIndex = 3;
            this.buttonCopyToClipboard.Text = "&Copy";
            this.toolTip.SetToolTip(this.buttonCopyToClipboard, "Click to copy the translated text to the clipboard");
            this.buttonCopyToClipboard.UseVisualStyleBackColor = true;
            this.buttonCopyToClipboard.Click += new System.EventHandler(this.buttonCopyToClipboard_Click);
            // 
            // buttonNextSection
            // 
            this.buttonNextSection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonNextSection.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonNextSection.Location = new System.Drawing.Point(490, 455);
            this.buttonNextSection.Name = "buttonNextSection";
            this.buttonNextSection.Size = new System.Drawing.Size(75, 23);
            this.buttonNextSection.TabIndex = 3;
            this.buttonNextSection.Text = "&Next";
            this.buttonNextSection.UseVisualStyleBackColor = true;
            this.buttonNextSection.Click += new System.EventHandler(this.buttonNextSection_Click);
            // 
            // labelPossibleTargetTranslation2
            // 
            this.labelPossibleTargetTranslation2.AutoSize = true;
            this.labelPossibleTargetTranslation2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tableLayoutPanel.SetColumnSpan(this.labelPossibleTargetTranslation2, 4);
            this.labelPossibleTargetTranslation2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPossibleTargetTranslation2.Location = new System.Drawing.Point(144, 74);
            this.labelPossibleTargetTranslation2.Margin = new System.Windows.Forms.Padding(3);
            this.labelPossibleTargetTranslation2.Name = "labelPossibleTargetTranslation2";
            this.labelPossibleTargetTranslation2.Size = new System.Drawing.Size(535, 23);
            this.labelPossibleTargetTranslation2.TabIndex = 7;
            this.labelPossibleTargetTranslation2.Text = "Target Text Options 2";
            // 
            // labelPossibleTargetTranslation3
            // 
            this.labelPossibleTargetTranslation3.AutoSize = true;
            this.labelPossibleTargetTranslation3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tableLayoutPanel.SetColumnSpan(this.labelPossibleTargetTranslation3, 4);
            this.labelPossibleTargetTranslation3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPossibleTargetTranslation3.Location = new System.Drawing.Point(144, 103);
            this.labelPossibleTargetTranslation3.Margin = new System.Windows.Forms.Padding(3);
            this.labelPossibleTargetTranslation3.Name = "labelPossibleTargetTranslation3";
            this.labelPossibleTargetTranslation3.Size = new System.Drawing.Size(535, 23);
            this.labelPossibleTargetTranslation3.TabIndex = 7;
            this.labelPossibleTargetTranslation3.Text = "Target Text Options 3";
            // 
            // buttonFillTargetTextOption2
            // 
            this.buttonFillTargetTextOption2.Image = global::BackTranslationHelper.Properties.Resources.FillDownHS;
            this.buttonFillTargetTextOption2.Location = new System.Drawing.Point(685, 74);
            this.buttonFillTargetTextOption2.Name = "buttonFillTargetTextOption2";
            this.buttonFillTargetTextOption2.Size = new System.Drawing.Size(23, 23);
            this.buttonFillTargetTextOption2.TabIndex = 8;
            this.buttonFillTargetTextOption2.UseVisualStyleBackColor = true;
            this.buttonFillTargetTextOption2.Click += new System.EventHandler(this.buttonFillTargetTextOption2_Click);
            // 
            // buttonFillTargetTextOption3
            // 
            this.buttonFillTargetTextOption3.Image = global::BackTranslationHelper.Properties.Resources.FillDownHS;
            this.buttonFillTargetTextOption3.Location = new System.Drawing.Point(685, 103);
            this.buttonFillTargetTextOption3.Name = "buttonFillTargetTextOption3";
            this.buttonFillTargetTextOption3.Size = new System.Drawing.Size(23, 23);
            this.buttonFillTargetTextOption3.TabIndex = 8;
            this.buttonFillTargetTextOption3.UseVisualStyleBackColor = true;
            this.buttonFillTargetTextOption3.Click += new System.EventHandler(this.buttonFillTargetTextOption3_Click);
            // 
            // labelForSourceData
            // 
            this.labelForSourceData.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelForSourceData.AutoSize = true;
            this.labelForSourceData.Location = new System.Drawing.Point(70, 4);
            this.labelForSourceData.Name = "labelForSourceData";
            this.labelForSourceData.Size = new System.Drawing.Size(68, 13);
            this.labelForSourceData.TabIndex = 9;
            this.labelForSourceData.Text = "Source Text:";
            // 
            // labelForExistingTargetData
            // 
            this.labelForExistingTargetData.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelForExistingTargetData.AutoSize = true;
            this.labelForExistingTargetData.Location = new System.Drawing.Point(36, 25);
            this.labelForExistingTargetData.Name = "labelForExistingTargetData";
            this.labelForExistingTargetData.Size = new System.Drawing.Size(102, 13);
            this.labelForExistingTargetData.TabIndex = 9;
            this.labelForExistingTargetData.Text = "Current Target Text:";
            // 
            // labelForTargetDataOptions
            // 
            this.labelForTargetDataOptions.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelForTargetDataOptions.AutoSize = true;
            this.labelForTargetDataOptions.Location = new System.Drawing.Point(3, 50);
            this.labelForTargetDataOptions.Name = "labelForTargetDataOptions";
            this.labelForTargetDataOptions.Size = new System.Drawing.Size(135, 13);
            this.labelForTargetDataOptions.TabIndex = 9;
            this.labelForTargetDataOptions.Text = "Target Translation Options:";
            // 
            // labelForTargetTranslation
            // 
            this.labelForTargetTranslation.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelForTargetTranslation.AutoSize = true;
            this.labelForTargetTranslation.Location = new System.Drawing.Point(42, 284);
            this.labelForTargetTranslation.Name = "labelForTargetTranslation";
            this.labelForTargetTranslation.Size = new System.Drawing.Size(96, 13);
            this.labelForTargetTranslation.TabIndex = 9;
            this.labelForTargetTranslation.Text = "Target Translation:";
            // 
            // labelSourceData
            // 
            this.labelSourceData.AutoSize = true;
            this.labelSourceData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tableLayoutPanel.SetColumnSpan(this.labelSourceData, 5);
            this.labelSourceData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSourceData.Location = new System.Drawing.Point(144, 3);
            this.labelSourceData.Margin = new System.Windows.Forms.Padding(3);
            this.labelSourceData.Name = "labelSourceData";
            this.labelSourceData.Size = new System.Drawing.Size(565, 15);
            this.labelSourceData.TabIndex = 7;
            this.labelSourceData.Text = "SourceData";
            // 
            // BackTranslationHelperCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.tableLayoutPanel);
            this.Controls.Add(this.menuStrip);
            this.Name = "BackTranslationHelperCtrl";
            this.Size = new System.Drawing.Size(718, 511);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.TextBox textBoxTargetBackTranslation;
        private System.Windows.Forms.Button buttonCopyToClipboard;
        private System.Windows.Forms.Button buttonWriteTextToTarget;
        private System.Windows.Forms.Label labelTargetTextExisting;
        private System.Windows.Forms.Button buttonNextSection;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeEncConverterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fontsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sourceTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem targetTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoSaveToolStripMenuItem;
        private System.Windows.Forms.Label labelPossibleTargetTranslation1;
        private System.Windows.Forms.Button buttonFillTargetTextOption1;
        private System.Windows.Forms.ToolStripMenuItem addEncConverterToolStripMenuItem;
        private System.Windows.Forms.Label labelPossibleTargetTranslation2;
        private System.Windows.Forms.Label labelPossibleTargetTranslation3;
        private System.Windows.Forms.Button buttonFillTargetTextOption2;
        private System.Windows.Forms.Button buttonFillTargetTextOption3;
        private System.Windows.Forms.Label labelForSourceData;
        private System.Windows.Forms.Label labelForExistingTargetData;
        private System.Windows.Forms.Label labelForTargetDataOptions;
        private System.Windows.Forms.Label labelForTargetTranslation;
        private System.Windows.Forms.ToolStripMenuItem hideColumn1LabelsToolStripMenuItem;
        private System.Windows.Forms.Label labelSourceData;
    }
}
