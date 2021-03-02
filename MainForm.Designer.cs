
namespace YahooQuotesLive
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSubscribeToSymbol = new System.Windows.Forms.Button();
            this.tbxYahooSymbol = new System.Windows.Forms.TextBox();
            this.lblYahooSymbol = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSubscribeToSymbol
            // 
            this.btnSubscribeToSymbol.Location = new System.Drawing.Point(263, 21);
            this.btnSubscribeToSymbol.Name = "btnSubscribeToSymbol";
            this.btnSubscribeToSymbol.Size = new System.Drawing.Size(169, 29);
            this.btnSubscribeToSymbol.TabIndex = 0;
            this.btnSubscribeToSymbol.Text = "Subsribe to quotes";
            this.btnSubscribeToSymbol.UseVisualStyleBackColor = true;
            this.btnSubscribeToSymbol.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbxYahooSymbol
            // 
            this.tbxYahooSymbol.Location = new System.Drawing.Point(121, 23);
            this.tbxYahooSymbol.Name = "tbxYahooSymbol";
            this.tbxYahooSymbol.Size = new System.Drawing.Size(125, 27);
            this.tbxYahooSymbol.TabIndex = 2;
            // 
            // lblYahooSymbol
            // 
            this.lblYahooSymbol.AutoSize = true;
            this.lblYahooSymbol.Location = new System.Drawing.Point(12, 26);
            this.lblYahooSymbol.Name = "lblYahooSymbol";
            this.lblYahooSymbol.Size = new System.Drawing.Size(103, 20);
            this.lblYahooSymbol.TabIndex = 3;
            this.lblYahooSymbol.Text = "Yahoo symbol";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 458);
            this.Controls.Add(this.lblYahooSymbol);
            this.Controls.Add(this.tbxYahooSymbol);
            this.Controls.Add(this.btnSubscribeToSymbol);
            this.Name = "MainForm";
            this.Text = "Yahoo live quote displayer";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSubscribeToSymbol;
        private System.Windows.Forms.TextBox tbxYahooSymbol;
        private System.Windows.Forms.Label lblYahooSymbol;
    }
}

