namespace GraphRed2
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.borderColor = new System.Windows.Forms.ComboBox();
            this.Clear = new System.Windows.Forms.Button();
            this.thick = new System.Windows.Forms.ComboBox();
            this.Triangle_Button = new System.Windows.Forms.Button();
            this.Ellipse_Button = new System.Windows.Forms.Button();
            this.Rectangle_Button = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BorderCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Moving = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Moving);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.BorderCheckBox);
            this.groupBox1.Controls.Add(this.borderColor);
            this.groupBox1.Controls.Add(this.Clear);
            this.groupBox1.Controls.Add(this.thick);
            this.groupBox1.Controls.Add(this.Triangle_Button);
            this.groupBox1.Controls.Add(this.Ellipse_Button);
            this.groupBox1.Controls.Add(this.Rectangle_Button);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(222, 556);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // borderColor
            // 
            this.borderColor.FormattingEnabled = true;
            this.borderColor.Items.AddRange(new object[] {
            "Чёрный",
            "Белый",
            "Красный",
            "Оранжевый",
            "Желтый",
            "Зеленый",
            "Голубой",
            "Синий",
            "Фиолетовый",
            "Розовый"});
            this.borderColor.Location = new System.Drawing.Point(73, 314);
            this.borderColor.Name = "borderColor";
            this.borderColor.Size = new System.Drawing.Size(121, 24);
            this.borderColor.TabIndex = 3;
            this.borderColor.Text = "Чёрный";
            // 
            // Clear
            // 
            this.Clear.Location = new System.Drawing.Point(51, 380);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(121, 23);
            this.Clear.TabIndex = 2;
            this.Clear.Text = "Стереть всё";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.button1_Click);
            // 
            // thick
            // 
            this.thick.FormattingEnabled = true;
            this.thick.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.thick.Location = new System.Drawing.Point(39, 246);
            this.thick.Name = "thick";
            this.thick.Size = new System.Drawing.Size(63, 24);
            this.thick.TabIndex = 2;
            this.thick.Text = "2";
            this.thick.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // Triangle_Button
            // 
            this.Triangle_Button.Location = new System.Drawing.Point(24, 171);
            this.Triangle_Button.Name = "Triangle_Button";
            this.Triangle_Button.Size = new System.Drawing.Size(170, 69);
            this.Triangle_Button.TabIndex = 1;
            this.Triangle_Button.Text = "Triangle";
            this.Triangle_Button.UseVisualStyleBackColor = true;
            this.Triangle_Button.Click += new System.EventHandler(this.Triangle_Button_Click);
            // 
            // Ellipse_Button
            // 
            this.Ellipse_Button.Location = new System.Drawing.Point(24, 96);
            this.Ellipse_Button.Name = "Ellipse_Button";
            this.Ellipse_Button.Size = new System.Drawing.Size(170, 69);
            this.Ellipse_Button.TabIndex = 1;
            this.Ellipse_Button.Text = "Ellipse";
            this.Ellipse_Button.UseVisualStyleBackColor = true;
            this.Ellipse_Button.Click += new System.EventHandler(this.Ellipse_Button_Click);
            // 
            // Rectangle_Button
            // 
            this.Rectangle_Button.Location = new System.Drawing.Point(24, 21);
            this.Rectangle_Button.Name = "Rectangle_Button";
            this.Rectangle_Button.Size = new System.Drawing.Size(170, 69);
            this.Rectangle_Button.TabIndex = 0;
            this.Rectangle_Button.Text = "Rectangle";
            this.Rectangle_Button.UseVisualStyleBackColor = true;
            this.Rectangle_Button.Click += new System.EventHandler(this.Rectangle_Button_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(249, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(639, 556);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // BorderCheckBox
            // 
            this.BorderCheckBox.AutoSize = true;
            this.BorderCheckBox.Location = new System.Drawing.Point(42, 318);
            this.BorderCheckBox.Name = "BorderCheckBox";
            this.BorderCheckBox.Size = new System.Drawing.Size(18, 17);
            this.BorderCheckBox.TabIndex = 4;
            this.BorderCheckBox.UseVisualStyleBackColor = true;
            this.BorderCheckBox.CheckedChanged += new System.EventHandler(this.BorderCheckBox_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 284);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Изменить цвет границ";
            // 
            // Moving
            // 
            this.Moving.AutoSize = true;
            this.Moving.Location = new System.Drawing.Point(42, 344);
            this.Moving.Name = "Moving";
            this.Moving.Size = new System.Drawing.Size(121, 20);
            this.Moving.TabIndex = 6;
            this.Moving.Text = "Перемещение";
            this.Moving.UseVisualStyleBackColor = true;
            this.Moving.CheckedChanged += new System.EventHandler(this.Moving_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 580);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Triangle_Button;
        private System.Windows.Forms.Button Ellipse_Button;
        private System.Windows.Forms.Button Rectangle_Button;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox thick;
        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.ComboBox borderColor;
        private System.Windows.Forms.CheckBox BorderCheckBox;
        private System.Windows.Forms.CheckBox Moving;
        private System.Windows.Forms.Label label1;
    }
}

