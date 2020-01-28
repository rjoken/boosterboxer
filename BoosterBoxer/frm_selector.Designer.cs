namespace BoosterBoxer
{
    partial class frm_selector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_selector));
            this.lbxSets = new System.Windows.Forms.ListBox();
            this.lblHowMany = new System.Windows.Forms.Label();
            this.nudPacksToOpen = new System.Windows.Forms.NumericUpDown();
            this.lblNoCards = new System.Windows.Forms.Label();
            this.btnOpen = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudPacksToOpen)).BeginInit();
            this.SuspendLayout();
            // 
            // lbxSets
            // 
            this.lbxSets.FormattingEnabled = true;
            this.lbxSets.Location = new System.Drawing.Point(12, 11);
            this.lbxSets.Name = "lbxSets";
            this.lbxSets.Size = new System.Drawing.Size(262, 316);
            this.lbxSets.TabIndex = 0;
            this.lbxSets.SelectedIndexChanged += new System.EventHandler(this.lbxSets_SelectedIndexChanged);
            // 
            // lblHowMany
            // 
            this.lblHowMany.AutoSize = true;
            this.lblHowMany.Location = new System.Drawing.Point(280, 11);
            this.lblHowMany.Name = "lblHowMany";
            this.lblHowMany.Size = new System.Drawing.Size(88, 13);
            this.lblHowMany.TabIndex = 1;
            this.lblHowMany.Text = "# packs to open:";
            // 
            // nudPacksToOpen
            // 
            this.nudPacksToOpen.Location = new System.Drawing.Point(281, 28);
            this.nudPacksToOpen.Name = "nudPacksToOpen";
            this.nudPacksToOpen.Size = new System.Drawing.Size(99, 20);
            this.nudPacksToOpen.TabIndex = 2;
            this.nudPacksToOpen.Value = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.nudPacksToOpen.ValueChanged += new System.EventHandler(this.nudPacksToOpen_ValueChanged);
            // 
            // lblNoCards
            // 
            this.lblNoCards.AutoSize = true;
            this.lblNoCards.Location = new System.Drawing.Point(278, 51);
            this.lblNoCards.Name = "lblNoCards";
            this.lblNoCards.Size = new System.Drawing.Size(35, 13);
            this.lblNoCards.TabIndex = 3;
            this.lblNoCards.Text = "label1";
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(281, 89);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(99, 23);
            this.btnOpen.TabIndex = 4;
            this.btnOpen.Text = "Open!";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // frm_selector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 333);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.lblNoCards);
            this.Controls.Add(this.nudPacksToOpen);
            this.Controls.Add(this.lblHowMany);
            this.Controls.Add(this.lbxSets);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frm_selector";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BoosterBoxer";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudPacksToOpen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbxSets;
        private System.Windows.Forms.Label lblHowMany;
        private System.Windows.Forms.NumericUpDown nudPacksToOpen;
        private System.Windows.Forms.Label lblNoCards;
        private System.Windows.Forms.Button btnOpen;
    }
}

