namespace BoosterBoxer
{
    partial class frm_viewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_viewer));
            this.lbxCards = new System.Windows.Forms.ListBox();
            this.lblName = new System.Windows.Forms.Label();
            this.rtbDesc = new System.Windows.Forms.RichTextBox();
            this.lblAtk = new System.Windows.Forms.Label();
            this.lblDef = new System.Windows.Forms.Label();
            this.lblRarity = new System.Windows.Forms.Label();
            this.btnSort = new System.Windows.Forms.Button();
            this.btnSortRarity = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbxCards
            // 
            this.lbxCards.FormattingEnabled = true;
            this.lbxCards.Location = new System.Drawing.Point(13, 13);
            this.lbxCards.Name = "lbxCards";
            this.lbxCards.Size = new System.Drawing.Size(283, 303);
            this.lbxCards.TabIndex = 0;
            this.lbxCards.SelectedIndexChanged += new System.EventHandler(this.lbxCards_SelectedIndexChanged);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(303, 13);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "label1";
            // 
            // rtbDesc
            // 
            this.rtbDesc.Location = new System.Drawing.Point(306, 30);
            this.rtbDesc.Name = "rtbDesc";
            this.rtbDesc.ReadOnly = true;
            this.rtbDesc.Size = new System.Drawing.Size(152, 101);
            this.rtbDesc.TabIndex = 2;
            this.rtbDesc.Text = "";
            // 
            // lblAtk
            // 
            this.lblAtk.AutoSize = true;
            this.lblAtk.Location = new System.Drawing.Point(303, 134);
            this.lblAtk.Name = "lblAtk";
            this.lblAtk.Size = new System.Drawing.Size(35, 13);
            this.lblAtk.TabIndex = 3;
            this.lblAtk.Text = "label1";
            // 
            // lblDef
            // 
            this.lblDef.AutoSize = true;
            this.lblDef.Location = new System.Drawing.Point(303, 147);
            this.lblDef.Name = "lblDef";
            this.lblDef.Size = new System.Drawing.Size(35, 13);
            this.lblDef.TabIndex = 4;
            this.lblDef.Text = "label1";
            // 
            // lblRarity
            // 
            this.lblRarity.AutoSize = true;
            this.lblRarity.Location = new System.Drawing.Point(303, 160);
            this.lblRarity.Name = "lblRarity";
            this.lblRarity.Size = new System.Drawing.Size(35, 13);
            this.lblRarity.TabIndex = 5;
            this.lblRarity.Text = "label1";
            // 
            // btnSort
            // 
            this.btnSort.Location = new System.Drawing.Point(306, 177);
            this.btnSort.Name = "btnSort";
            this.btnSort.Size = new System.Drawing.Size(152, 23);
            this.btnSort.TabIndex = 6;
            this.btnSort.Text = "Sort by ID";
            this.btnSort.UseVisualStyleBackColor = true;
            this.btnSort.Click += new System.EventHandler(this.btnSort_Click);
            // 
            // btnSortRarity
            // 
            this.btnSortRarity.Location = new System.Drawing.Point(306, 206);
            this.btnSortRarity.Name = "btnSortRarity";
            this.btnSortRarity.Size = new System.Drawing.Size(152, 23);
            this.btnSortRarity.TabIndex = 7;
            this.btnSortRarity.Text = "Sort by Rarity";
            this.btnSortRarity.UseVisualStyleBackColor = true;
            this.btnSortRarity.Click += new System.EventHandler(this.btnSortRarity_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(306, 235);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(152, 23);
            this.btnExport.TabIndex = 8;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(306, 264);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(152, 23);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frm_viewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 331);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnSortRarity);
            this.Controls.Add(this.btnSort);
            this.Controls.Add(this.lblRarity);
            this.Controls.Add(this.lblDef);
            this.Controls.Add(this.lblAtk);
            this.Controls.Add(this.rtbDesc);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lbxCards);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frm_viewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BoosterBoxer Results";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbxCards;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.RichTextBox rtbDesc;
        private System.Windows.Forms.Label lblAtk;
        private System.Windows.Forms.Label lblDef;
        private System.Windows.Forms.Label lblRarity;
        private System.Windows.Forms.Button btnSort;
        private System.Windows.Forms.Button btnSortRarity;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnClose;
    }
}