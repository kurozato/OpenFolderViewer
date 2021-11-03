
namespace BlackSugar.View
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pnlSide = new System.Windows.Forms.Panel();
            this.picDropAria = new System.Windows.Forms.PictureBox();
            this.lblLogo = new System.Windows.Forms.Label();
            this.lineSide = new System.Windows.Forms.Panel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.linePins = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblPins = new System.Windows.Forms.Label();
            this.lblCurrent = new System.Windows.Forms.Label();
            this.lineCurrent = new System.Windows.Forms.Panel();
            this.lstFolder = new System.Windows.Forms.ListView();
            this.pnlSide.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDropAria)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSide
            // 
            this.pnlSide.AllowDrop = true;
            this.pnlSide.Controls.Add(this.picDropAria);
            this.pnlSide.Controls.Add(this.lblLogo);
            this.pnlSide.Location = new System.Drawing.Point(0, 0);
            this.pnlSide.Name = "pnlSide";
            this.pnlSide.Size = new System.Drawing.Size(100, 500);
            this.pnlSide.TabIndex = 0;
            // 
            // picDropAria
            // 
            this.picDropAria.Location = new System.Drawing.Point(0, 320);
            this.picDropAria.Name = "picDropAria";
            this.picDropAria.Size = new System.Drawing.Size(100, 150);
            this.picDropAria.TabIndex = 7;
            this.picDropAria.TabStop = false;
            // 
            // lblLogo
            // 
            this.lblLogo.AutoSize = true;
            this.lblLogo.Font = new System.Drawing.Font("Bahnschrift SemiBold", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblLogo.Location = new System.Drawing.Point(21, 20);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(56, 34);
            this.lblLogo.TabIndex = 7;
            this.lblLogo.Text = "Ofv";
            // 
            // lineSide
            // 
            this.lineSide.Location = new System.Drawing.Point(100, 0);
            this.lineSide.Name = "lineSide";
            this.lineSide.Size = new System.Drawing.Size(1, 500);
            this.lineSide.TabIndex = 1;
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.txtFilter);
            this.pnlHeader.Controls.Add(this.linePins);
            this.pnlHeader.Controls.Add(this.btnClose);
            this.pnlHeader.Controls.Add(this.lblPins);
            this.pnlHeader.Controls.Add(this.lblCurrent);
            this.pnlHeader.Controls.Add(this.lineCurrent);
            this.pnlHeader.Location = new System.Drawing.Point(101, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(799, 80);
            this.pnlHeader.TabIndex = 2;
            // 
            // txtFilter
            // 
            this.txtFilter.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFilter.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtFilter.Location = new System.Drawing.Point(554, 0);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.PlaceholderText = "Quick Search";
            this.txtFilter.Size = new System.Drawing.Size(210, 20);
            this.txtFilter.TabIndex = 7;
            // 
            // linePins
            // 
            this.linePins.Location = new System.Drawing.Point(707, 60);
            this.linePins.Name = "linePins";
            this.linePins.Size = new System.Drawing.Size(50, 2);
            this.linePins.TabIndex = 4;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(770, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(30, 30);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "✕";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // lblPins
            // 
            this.lblPins.AutoSize = true;
            this.lblPins.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPins.Location = new System.Drawing.Point(716, 34);
            this.lblPins.Name = "lblPins";
            this.lblPins.Size = new System.Drawing.Size(33, 14);
            this.lblPins.TabIndex = 5;
            this.lblPins.Text = "Pins";
            // 
            // lblCurrent
            // 
            this.lblCurrent.AutoSize = true;
            this.lblCurrent.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCurrent.Location = new System.Drawing.Point(616, 34);
            this.lblCurrent.Name = "lblCurrent";
            this.lblCurrent.Size = new System.Drawing.Size(55, 14);
            this.lblCurrent.TabIndex = 4;
            this.lblCurrent.Text = "Current";
            // 
            // lineCurrent
            // 
            this.lineCurrent.Location = new System.Drawing.Point(618, 60);
            this.lineCurrent.Name = "lineCurrent";
            this.lineCurrent.Size = new System.Drawing.Size(50, 2);
            this.lineCurrent.TabIndex = 3;
            // 
            // lstFolder
            // 
            this.lstFolder.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstFolder.HideSelection = false;
            this.lstFolder.Location = new System.Drawing.Point(103, 86);
            this.lstFolder.Name = "lstFolder";
            this.lstFolder.Size = new System.Drawing.Size(797, 414);
            this.lstFolder.TabIndex = 3;
            this.lstFolder.UseCompatibleStateImageBehavior = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(900, 500);
            this.Controls.Add(this.lstFolder);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.lineSide);
            this.Controls.Add(this.pnlSide);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Ofv";
            this.pnlSide.ResumeLayout(false);
            this.pnlSide.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDropAria)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSide;
        private System.Windows.Forms.Panel lineSide;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblPins;
        private System.Windows.Forms.Label lblCurrent;
        private System.Windows.Forms.Panel lineCurrent;
        private System.Windows.Forms.ListView lstFolder;
        private System.Windows.Forms.Panel linePins;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.PictureBox picDropAria;
        private System.Windows.Forms.TextBox txtFilter;
    }
}