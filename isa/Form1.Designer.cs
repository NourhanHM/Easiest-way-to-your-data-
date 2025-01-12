namespace isa
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            button1 = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            button2 = new Button();
            button3 = new Button();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            textBox6 = new TextBox();
            textBox7 = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label7 = new Label();
            label1 = new Label();
            label8 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(489, 370);
            button1.Name = "button1";
            button1.Size = new Size(120, 29);
            button1.TabIndex = 0;
            button1.Text = "SaveRecord";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(242, 130);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(242, 183);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 2;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(238, 216);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(125, 27);
            textBox3.TabIndex = 3;
            // 
            // button2
            // 
            button2.Location = new Point(92, 370);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 4;
            button2.Text = "Display";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(306, 370);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 5;
            button3.Text = "Edit";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(238, 249);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(125, 27);
            textBox4.TabIndex = 6;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(238, 282);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(125, 27);
            textBox5.TabIndex = 7;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(504, 183);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(125, 27);
            textBox6.TabIndex = 8;
            textBox6.TextChanged += textBox6_TextChanged;
            // 
            // textBox7
            // 
            textBox7.Location = new Point(504, 232);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(125, 27);
            textBox7.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(153, 130);
            label6.Name = "label6";
            label6.Size = new Size(60, 20);
            label6.TabIndex = 19;
            label6.Text = "FilePath";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(153, 289);
            label5.Name = "label5";
            label5.Size = new Size(68, 20);
            label5.TabIndex = 18;
            label5.Text = "birthYear";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(153, 252);
            label4.Name = "label4";
            label4.Size = new Size(79, 20);
            label4.TabIndex = 17;
            label4.Text = "Last Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(153, 216);
            label3.Name = "label3";
            label3.Size = new Size(49, 20);
            label3.TabIndex = 16;
            label3.Text = "Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(153, 183);
            label2.Name = "label2";
            label2.Size = new Size(24, 20);
            label2.TabIndex = 15;
            label2.Text = "ID";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(419, 224);
            label7.Name = "label7";
            label7.Size = new Size(72, 20);
            label7.TabIndex = 23;
            label7.Text = "rec_count";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(419, 186);
            label1.Name = "label1";
            label1.Size = new Size(60, 20);
            label1.TabIndex = 22;
            label1.Text = "rec_size";
            // 
            // label8
            // 
            label8.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(194, 9);
            label8.Name = "label8";
            label8.Size = new Size(382, 42);
            label8.TabIndex = 30;
            label8.Text = "Easiest way to your data!";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            label8.Click += label8_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label1);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(textBox7);
            Controls.Add(textBox6);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private Button button2;
        private Button button3;
        private TextBox textBox4;
        private TextBox textBox5;
        private TextBox textBox6;
        private TextBox textBox7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label7;
        private Label label1;
        private Label label8;
    }
}
