namespace WinFwk.UITools.Messages
{
    partial class MessageBusLogModule
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pgObject = new System.Windows.Forms.PropertyGrid();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.dlvMessages = new WinFwk.UITools.DefaultListView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dlvMessages)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dlvMessages);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pgObject);
            this.splitContainer1.Panel2.Controls.Add(this.propertyGrid1);
            this.splitContainer1.Size = new System.Drawing.Size(645, 386);
            this.splitContainer1.SplitterDistance = 215;
            this.splitContainer1.TabIndex = 0;
            // 
            // pgObject
            // 
            this.pgObject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgObject.Location = new System.Drawing.Point(0, 0);
            this.pgObject.Name = "pgObject";
            this.pgObject.Size = new System.Drawing.Size(426, 386);
            this.pgObject.TabIndex = 1;
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Location = new System.Drawing.Point(106, 87);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(130, 130);
            this.propertyGrid1.TabIndex = 0;
            // 
            // dlvMessages
            // 
            this.dlvMessages.CellEditUseWholeCell = false;
            this.dlvMessages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dlvMessages.FullRowSelect = true;
            this.dlvMessages.HideSelection = false;
            this.dlvMessages.Location = new System.Drawing.Point(0, 0);
            this.dlvMessages.Name = "dlvMessages";
            this.dlvMessages.ShowGroups = false;
            this.dlvMessages.ShowImagesOnSubItems = true;
            this.dlvMessages.Size = new System.Drawing.Size(215, 386);
            this.dlvMessages.TabIndex = 0;
            this.dlvMessages.UseCompatibleStateImageBehavior = false;
            this.dlvMessages.View = System.Windows.Forms.View.Details;
            this.dlvMessages.VirtualMode = true;
            // 
            // MessageBusLogModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "MessageBusLogModule";
            this.Size = new System.Drawing.Size(645, 386);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dlvMessages)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PropertyGrid pgObject;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private DefaultListView dlvMessages;
    }
}
