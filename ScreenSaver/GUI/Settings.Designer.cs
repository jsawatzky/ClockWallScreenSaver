namespace ClockWallScreenSaver.GUI
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.hour12 = new System.Windows.Forms.RadioButton();
            this.hour24 = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.background = new System.Windows.Forms.Button();
            this.clock = new System.Windows.Forms.Button();
            this.hand = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.defaul = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(268, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Clock Wall Screensaver";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(69, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "By: Jacob Sawatzky";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Time Format:";
            // 
            // hour12
            // 
            this.hour12.AutoSize = true;
            this.hour12.Location = new System.Drawing.Point(112, 75);
            this.hour12.Name = "hour12";
            this.hour12.Size = new System.Drawing.Size(63, 17);
            this.hour12.TabIndex = 3;
            this.hour12.TabStop = true;
            this.hour12.Text = "12 Hour";
            this.hour12.UseVisualStyleBackColor = true;
            // 
            // hour24
            // 
            this.hour24.AutoSize = true;
            this.hour24.Location = new System.Drawing.Point(192, 75);
            this.hour24.Name = "hour24";
            this.hour24.Size = new System.Drawing.Size(63, 17);
            this.hour24.TabIndex = 4;
            this.hour24.TabStop = true;
            this.hour24.Text = "24 Hour";
            this.hour24.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Background Color";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Clock Back Color";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 160);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Clock Hand Color";
            // 
            // background
            // 
            this.background.Location = new System.Drawing.Point(112, 102);
            this.background.Name = "background";
            this.background.Size = new System.Drawing.Size(75, 23);
            this.background.TabIndex = 8;
            this.background.UseVisualStyleBackColor = true;
            this.background.Click += new System.EventHandler(this.background_Click);
            // 
            // clock
            // 
            this.clock.Location = new System.Drawing.Point(112, 128);
            this.clock.Name = "clock";
            this.clock.Size = new System.Drawing.Size(75, 23);
            this.clock.TabIndex = 9;
            this.clock.UseVisualStyleBackColor = true;
            this.clock.Click += new System.EventHandler(this.clock_Click);
            // 
            // hand
            // 
            this.hand.Location = new System.Drawing.Point(112, 155);
            this.hand.Name = "hand";
            this.hand.Size = new System.Drawing.Size(75, 23);
            this.hand.TabIndex = 10;
            this.hand.UseVisualStyleBackColor = true;
            this.hand.Click += new System.EventHandler(this.hand_Click);
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(72, 226);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(75, 23);
            this.save.TabIndex = 11;
            this.save.Text = "Save";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(155, 226);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 12;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // defaul
            // 
            this.defaul.Location = new System.Drawing.Point(112, 197);
            this.defaul.Name = "defaul";
            this.defaul.Size = new System.Drawing.Size(75, 23);
            this.defaul.TabIndex = 13;
            this.defaul.Text = "Set Default";
            this.defaul.UseVisualStyleBackColor = true;
            this.defaul.Click += new System.EventHandler(this.defaul_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 261);
            this.Controls.Add(this.defaul);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.save);
            this.Controls.Add(this.hand);
            this.Controls.Add(this.clock);
            this.Controls.Add(this.background);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.hour24);
            this.Controls.Add(this.hour12);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Settings";
            this.Text = "Clock Wall Screensaver";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton hour12;
        private System.Windows.Forms.RadioButton hour24;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button background;
        private System.Windows.Forms.Button clock;
        private System.Windows.Forms.Button hand;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Button defaul;
    }
}