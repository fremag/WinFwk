﻿namespace WinFwk.UITools
{
    partial class LogModule
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.dlvLogMessages = new DefaultListView();
            this.colTimeStamp = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colLogLevel = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colText = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colException = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            ((System.ComponentModel.ISupportInitialize)(this.dlvLogMessages)).BeginInit();
            this.SuspendLayout();
            // 
            // dlvLogMessages
            // 
            this.dlvLogMessages.AllColumns.Add(this.colTimeStamp);
            this.dlvLogMessages.AllColumns.Add(this.colLogLevel);
            this.dlvLogMessages.AllColumns.Add(this.colText);
            this.dlvLogMessages.AllColumns.Add(this.colException);
            this.dlvLogMessages.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colTimeStamp,
            this.colLogLevel,
            this.colText,
            this.colException});
            this.dlvLogMessages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dlvLogMessages.FullRowSelect = true;
            this.dlvLogMessages.HideSelection = false;
            this.dlvLogMessages.Location = new System.Drawing.Point(0, 0);
            this.dlvLogMessages.Name = "dlvLogMessages";
            this.dlvLogMessages.ShowGroups = false;
            this.dlvLogMessages.Size = new System.Drawing.Size(861, 357);
            this.dlvLogMessages.TabIndex = 0;
            this.dlvLogMessages.UseCellFormatEvents = true;
            this.dlvLogMessages.UseCompatibleStateImageBehavior = false;
            this.dlvLogMessages.View = System.Windows.Forms.View.Details;
            this.dlvLogMessages.VirtualMode = true;
            this.dlvLogMessages.FormatCell += new System.EventHandler<BrightIdeasSoftware.FormatCellEventArgs>(this.fdlvLogMessages_FormatCell);
            // 
            // colTimeStamp
            // 
            this.colTimeStamp.AspectToStringFormat = "{0:HH:mm:ss}";
            this.colTimeStamp.Text = "Time";
            this.colTimeStamp.Width = 150;
            // 
            // colLogLevel
            // 
            this.colLogLevel.AspectToStringFormat = "{0}";
            this.colLogLevel.Text = "Level";
            // 
            // colText
            // 
            this.colText.Text = "Text";
            this.colText.Width = 500;
            // 
            // colException
            // 
            this.colException.Text = "Exception";
            this.colException.Width = 127;
            // 
            // LogModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dlvLogMessages);
            this.Name = "LogModule";
            this.Size = new System.Drawing.Size(861, 357);
            ((System.ComponentModel.ISupportInitialize)(this.dlvLogMessages)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DefaultListView dlvLogMessages;
        private BrightIdeasSoftware.OLVColumn colTimeStamp;
        private BrightIdeasSoftware.OLVColumn colLogLevel;
        private BrightIdeasSoftware.OLVColumn colText;
        private BrightIdeasSoftware.OLVColumn colException;
    }
}
