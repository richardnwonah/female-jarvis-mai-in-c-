namespace WindowsVoiceApp1
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
         this.textBox1.Location = new System.Drawing.Point(117, 26);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(153, 20);
			this.textBox1.TabIndex = 3;
            // 
				// label2
			// 
			this.label2.AutoSize = true;
			this.label2.ForeColor = System.Drawing.Color.White;
			this.label2.Location = new System.Drawing.Point(114, 98);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(150, 13);
			this.label2.TabIndex = 6;
			this.label2.Text = "click the 🔊 button to activate ";
			// 
				// label4
			// 
			this.label4.AutoSize = true;
				this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.label4.Location = new System.Drawing.Point(130, 50);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(299, 108);
			this.label4.TabIndex = 0;
			this.label4.Text = "👩";
			this.label4.Visible = false;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.ForeColor = System.Drawing.Color.Red;
			this.label3.Location = new System.Drawing.Point(12, 9);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(67, 13);
			this.label3.TabIndex = 7;
			this.label3.Text = "Not Running";
			// 
			// label3
			// 
			this.label1.AutoSize = true;
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label3";
			this.label1.Size = new System.Drawing.Size(67, 13);
			this.label1.TabIndex = 7;
			this.label1.Text = "Running...";
			this.label1.Visible = false;
			// 

            // buttonStart
			// 
			this.buttonStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonStart.Font = new System.Drawing.Font("MS Reference Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonStart.ForeColor = System.Drawing.Color.Green;
			this.buttonStart.Location = new System.Drawing.Point(12, 154);
			this.buttonStart.Name = "buttonStart";
			this.buttonStart.Size = new System.Drawing.Size(53, 44);
			this.buttonStart.TabIndex = 1;
			this.buttonStart.Text = "🔊";
			this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonStop
            // 
       this.buttonStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonStop.Font = new System.Drawing.Font("MS Reference Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonStop.ForeColor = System.Drawing.Color.Red;
			this.buttonStop.Location = new System.Drawing.Point(313, 154);
			this.buttonStop.Margin = new System.Windows.Forms.Padding(0);
			this.buttonStop.Name = "buttonStop";
			this.buttonStop.Size = new System.Drawing.Size(51, 44);
			this.buttonStop.TabIndex = 2;
			this.buttonStop.Text = "🔇";
			this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
			
            // Form1
            // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			this.ClientSize = new System.Drawing.Size(373, 210);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.buttonStop);
			this.Controls.Add(this.buttonStart);
			this.Name = "Form1";
			this.Text = "Form1";
		this.Cursor = System.Windows.Forms.Cursors.Hand;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.Opacity = 0.8D;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "👱Mia A";
			this.TransparencyKey = System.Drawing.Color.Silver;
	
			this.ResumeLayout(false);
			this.PerformLayout();
        }

        #endregion

		private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonStop;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label4;
    }
}

