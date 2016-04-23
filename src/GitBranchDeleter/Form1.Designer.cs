namespace GitBranchDeleter
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxFolderPath = new System.Windows.Forms.TextBox();
            this.buttonBrowser = new System.Windows.Forms.Button();
            this.buttonFetchBranches = new System.Windows.Forms.Button();
            this.treeViewBranches = new System.Windows.Forms.TreeView();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.listBoxUpdates = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // textBoxFolderPath
            // 
            this.textBoxFolderPath.Location = new System.Drawing.Point(12, 12);
            this.textBoxFolderPath.Name = "textBoxFolderPath";
            this.textBoxFolderPath.Size = new System.Drawing.Size(284, 20);
            this.textBoxFolderPath.TabIndex = 0;
            // 
            // buttonBrowser
            // 
            this.buttonBrowser.Location = new System.Drawing.Point(302, 10);
            this.buttonBrowser.Name = "buttonBrowser";
            this.buttonBrowser.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowser.TabIndex = 1;
            this.buttonBrowser.Text = "Browse";
            this.buttonBrowser.UseVisualStyleBackColor = true;
            this.buttonBrowser.Click += new System.EventHandler(this.buttonBrowser_Click);
            // 
            // buttonFetchBranches
            // 
            this.buttonFetchBranches.Location = new System.Drawing.Point(139, 38);
            this.buttonFetchBranches.Name = "buttonFetchBranches";
            this.buttonFetchBranches.Size = new System.Drawing.Size(113, 23);
            this.buttonFetchBranches.TabIndex = 2;
            this.buttonFetchBranches.Text = "Fetch Branches";
            this.buttonFetchBranches.UseVisualStyleBackColor = true;
            this.buttonFetchBranches.Click += new System.EventHandler(this.buttonFetchBranches_Click);
            // 
            // treeViewBranches
            // 
            this.treeViewBranches.CheckBoxes = true;
            this.treeViewBranches.Location = new System.Drawing.Point(12, 67);
            this.treeViewBranches.Name = "treeViewBranches";
            this.treeViewBranches.Size = new System.Drawing.Size(365, 234);
            this.treeViewBranches.TabIndex = 3;
            this.treeViewBranches.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeViewBranches_AfterCheck);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(137, 307);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(117, 23);
            this.buttonDelete.TabIndex = 4;
            this.buttonDelete.Text = "Delete Branches";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // listBoxUpdates
            // 
            this.listBoxUpdates.FormattingEnabled = true;
            this.listBoxUpdates.Location = new System.Drawing.Point(12, 336);
            this.listBoxUpdates.Name = "listBoxUpdates";
            this.listBoxUpdates.Size = new System.Drawing.Size(365, 160);
            this.listBoxUpdates.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 516);
            this.Controls.Add(this.listBoxUpdates);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.treeViewBranches);
            this.Controls.Add(this.buttonFetchBranches);
            this.Controls.Add(this.buttonBrowser);
            this.Controls.Add(this.textBoxFolderPath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Git Branch Deleter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxFolderPath;
        private System.Windows.Forms.Button buttonBrowser;
        private System.Windows.Forms.Button buttonFetchBranches;
        private System.Windows.Forms.TreeView treeViewBranches;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.ListBox listBoxUpdates;
    }
}

