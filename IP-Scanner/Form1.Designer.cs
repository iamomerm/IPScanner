namespace IPScanner
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
            this.RTB = new System.Windows.Forms.RichTextBox();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.ActionBtn = new System.Windows.Forms.Button();
            this.FromLabel = new System.Windows.Forms.Label();
            this.ToLabel = new System.Windows.Forms.Label();
            this.SourceText = new System.Windows.Forms.MaskedTextBox();
            this.DestText = new System.Windows.Forms.MaskedTextBox();
            this.RangeLabel = new System.Windows.Forms.Label();
            this.TimeOutLabel = new System.Windows.Forms.Label();
            this.TimeOutText = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // RTB
            // 
            this.RTB.BackColor = System.Drawing.Color.White;
            this.RTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RTB.Location = new System.Drawing.Point(18, 87);
            this.RTB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RTB.Name = "RTB";
            this.RTB.Size = new System.Drawing.Size(314, 238);
            this.RTB.TabIndex = 7;
            this.RTB.Text = "";
            this.RTB.TextChanged += new System.EventHandler(this.RTBTextChange);
            // 
            // ExitBtn
            // 
            this.ExitBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ExitBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ExitBtn.FlatAppearance.BorderSize = 0;
            this.ExitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitBtn.Location = new System.Drawing.Point(227, 342);
            this.ExitBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(105, 33);
            this.ExitBtn.TabIndex = 6;
            this.ExitBtn.Text = "Exit";
            this.ExitBtn.UseVisualStyleBackColor = true;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtnClick);
            // 
            // ActionBtn
            // 
            this.ActionBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(255)))));
            this.ActionBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ActionBtn.FlatAppearance.BorderSize = 0;
            this.ActionBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ActionBtn.ForeColor = System.Drawing.Color.White;
            this.ActionBtn.Location = new System.Drawing.Point(116, 342);
            this.ActionBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ActionBtn.Name = "ActionBtn";
            this.ActionBtn.Size = new System.Drawing.Size(105, 33);
            this.ActionBtn.TabIndex = 5;
            this.ActionBtn.Text = "Scan";
            this.ActionBtn.UseVisualStyleBackColor = false;
            this.ActionBtn.Click += new System.EventHandler(this.ActionBtnClick);
            // 
            // FromLabel
            // 
            this.FromLabel.AutoSize = true;
            this.FromLabel.Location = new System.Drawing.Point(15, 35);
            this.FromLabel.Name = "FromLabel";
            this.FromLabel.Size = new System.Drawing.Size(35, 15);
            this.FromLabel.TabIndex = 4;
            this.FromLabel.Text = "From";
            // 
            // ToLabel
            // 
            this.ToLabel.AutoSize = true;
            this.ToLabel.Location = new System.Drawing.Point(199, 36);
            this.ToLabel.Name = "ToLabel";
            this.ToLabel.Size = new System.Drawing.Size(19, 15);
            this.ToLabel.TabIndex = 2;
            this.ToLabel.Text = "To";
            // 
            // SourceText
            // 
            this.SourceText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SourceText.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.SourceText.Location = new System.Drawing.Point(75, 36);
            this.SourceText.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SourceText.Mask = "000.000.000.000";
            this.SourceText.Name = "SourceText";
            this.SourceText.PromptChar = '#';
            this.SourceText.Size = new System.Drawing.Size(104, 16);
            this.SourceText.TabIndex = 1;
            this.SourceText.Text = "192168100100";
            this.SourceText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // DestText
            // 
            this.DestText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DestText.Location = new System.Drawing.Point(227, 36);
            this.DestText.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DestText.Mask = "000.000.000.000";
            this.DestText.Name = "DestText";
            this.DestText.PromptChar = '#';
            this.DestText.Size = new System.Drawing.Size(105, 16);
            this.DestText.TabIndex = 0;
            this.DestText.Text = "192168100200";
            this.DestText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // RangeLabel
            // 
            this.RangeLabel.AutoSize = true;
            this.RangeLabel.Location = new System.Drawing.Point(15, 8);
            this.RangeLabel.Name = "RangeLabel";
            this.RangeLabel.Size = new System.Drawing.Size(102, 15);
            this.RangeLabel.TabIndex = 3;
            this.RangeLabel.Text = "IP-Scanner Range";
            // 
            // TimeOutLabel
            // 
            this.TimeOutLabel.AutoSize = true;
            this.TimeOutLabel.Location = new System.Drawing.Point(15, 62);
            this.TimeOutLabel.Name = "TimeOutLabel";
            this.TimeOutLabel.Size = new System.Drawing.Size(51, 15);
            this.TimeOutLabel.TabIndex = 9;
            this.TimeOutLabel.Text = "Timeout";
            // 
            // TimeOutText
            // 
            this.TimeOutText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TimeOutText.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.TimeOutText.Location = new System.Drawing.Point(75, 63);
            this.TimeOutText.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TimeOutText.Mask = "0000";
            this.TimeOutText.Name = "TimeOutText";
            this.TimeOutText.PromptChar = '#';
            this.TimeOutText.Size = new System.Drawing.Size(104, 16);
            this.TimeOutText.TabIndex = 8;
            this.TimeOutText.Text = "1000";
            this.TimeOutText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(349, 390);
            this.Controls.Add(this.TimeOutText);
            this.Controls.Add(this.TimeOutLabel);
            this.Controls.Add(this.DestText);
            this.Controls.Add(this.SourceText);
            this.Controls.Add(this.ToLabel);
            this.Controls.Add(this.RangeLabel);
            this.Controls.Add(this.FromLabel);
            this.Controls.Add(this.ActionBtn);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.RTB);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.Text = "IPv4 Scanner";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox RTB;
        private System.Windows.Forms.Button ExitBtn;
        private System.Windows.Forms.Button ActionBtn;
        private System.Windows.Forms.Label FromLabel;
        private System.Windows.Forms.Label ToLabel;
        private System.Windows.Forms.MaskedTextBox SourceText;
        private System.Windows.Forms.MaskedTextBox DestText;
        private System.Windows.Forms.Label RangeLabel;
        private System.Windows.Forms.Label TimeOutLabel;
        private System.Windows.Forms.MaskedTextBox TimeOutText;
    }
}

