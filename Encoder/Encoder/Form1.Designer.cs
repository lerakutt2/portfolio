namespace Encoder
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
            this.UserText = new System.Windows.Forms.RichTextBox();
            this.Codes = new System.Windows.Forms.ListBox();
            this.Add = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.Manual = new System.Windows.Forms.ListBox();
            this.Encrypt = new System.Windows.Forms.Button();
            this.Encrypted = new System.Windows.Forms.RichTextBox();
            this.Decrypt = new System.Windows.Forms.Button();
            this.Key = new System.Windows.Forms.RichTextBox();
            this.Unencrypted = new System.Windows.Forms.RichTextBox();
            this.Up = new System.Windows.Forms.Button();
            this.Down = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // UserText
            // 
            this.UserText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UserText.Location = new System.Drawing.Point(14, 14);
            this.UserText.Name = "UserText";
            this.UserText.Size = new System.Drawing.Size(666, 96);
            this.UserText.TabIndex = 0;
            this.UserText.Text = "";
            // 
            // Codes
            // 
            this.Codes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Codes.FormattingEnabled = true;
            this.Codes.ItemHeight = 25;
            this.Codes.Items.AddRange(new object[] {
            "Increment (+1)",
            "Decrement (-1)",
            "Zero (0)",
            "Negative (255-code)"});
            this.Codes.Location = new System.Drawing.Point(13, 116);
            this.Codes.Name = "Codes";
            this.Codes.Size = new System.Drawing.Size(209, 179);
            this.Codes.TabIndex = 1;
            // 
            // Add
            // 
            this.Add.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Add.Location = new System.Drawing.Point(251, 165);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(62, 38);
            this.Add.TabIndex = 2;
            this.Add.Text = "+";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // Delete
            // 
            this.Delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Delete.Location = new System.Drawing.Point(251, 209);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(62, 36);
            this.Delete.TabIndex = 3;
            this.Delete.Text = "-";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // Manual
            // 
            this.Manual.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Manual.FormattingEnabled = true;
            this.Manual.ItemHeight = 25;
            this.Manual.Location = new System.Drawing.Point(352, 116);
            this.Manual.Name = "Manual";
            this.Manual.Size = new System.Drawing.Size(215, 179);
            this.Manual.TabIndex = 4;
            // 
            // Encrypt
            // 
            this.Encrypt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Encrypt.Location = new System.Drawing.Point(13, 301);
            this.Encrypt.Name = "Encrypt";
            this.Encrypt.Size = new System.Drawing.Size(666, 41);
            this.Encrypt.TabIndex = 5;
            this.Encrypt.Text = "Шифровать";
            this.Encrypt.UseVisualStyleBackColor = true;
            this.Encrypt.Click += new System.EventHandler(this.Encrypt_Click);
            // 
            // Encrypted
            // 
            this.Encrypted.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Encrypted.Location = new System.Drawing.Point(13, 348);
            this.Encrypted.Name = "Encrypted";
            this.Encrypted.Size = new System.Drawing.Size(666, 96);
            this.Encrypted.TabIndex = 6;
            this.Encrypted.Text = "";
            // 
            // Decrypt
            // 
            this.Decrypt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Decrypt.Location = new System.Drawing.Point(13, 519);
            this.Decrypt.Name = "Decrypt";
            this.Decrypt.Size = new System.Drawing.Size(667, 41);
            this.Decrypt.TabIndex = 7;
            this.Decrypt.Text = "Расшифровать";
            this.Decrypt.UseVisualStyleBackColor = true;
            this.Decrypt.Click += new System.EventHandler(this.Decrypt_Click);
            // 
            // Key
            // 
            this.Key.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Key.Location = new System.Drawing.Point(14, 475);
            this.Key.Name = "Key";
            this.Key.Size = new System.Drawing.Size(666, 38);
            this.Key.TabIndex = 8;
            this.Key.Text = "";
            // 
            // Unencrypted
            // 
            this.Unencrypted.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Unencrypted.Location = new System.Drawing.Point(14, 566);
            this.Unencrypted.Name = "Unencrypted";
            this.Unencrypted.Size = new System.Drawing.Size(666, 109);
            this.Unencrypted.TabIndex = 9;
            this.Unencrypted.Text = "";
            // 
            // Up
            // 
            this.Up.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Up.Location = new System.Drawing.Point(594, 165);
            this.Up.Name = "Up";
            this.Up.Size = new System.Drawing.Size(81, 38);
            this.Up.TabIndex = 10;
            this.Up.Text = "Up";
            this.Up.UseVisualStyleBackColor = true;
            this.Up.Click += new System.EventHandler(this.Up_Click);
            // 
            // Down
            // 
            this.Down.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Down.Location = new System.Drawing.Point(594, 209);
            this.Down.Name = "Down";
            this.Down.Size = new System.Drawing.Size(81, 36);
            this.Down.TabIndex = 11;
            this.Down.Text = "Down";
            this.Down.UseVisualStyleBackColor = true;
            this.Down.Click += new System.EventHandler(this.Down_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(253, 450);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 22);
            this.label1.TabIndex = 12;
            this.label1.Text = "Ключ к расшифровке";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 687);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Down);
            this.Controls.Add(this.Up);
            this.Controls.Add(this.Unencrypted);
            this.Controls.Add(this.Key);
            this.Controls.Add(this.Decrypt);
            this.Controls.Add(this.Encrypted);
            this.Controls.Add(this.Encrypt);
            this.Controls.Add(this.Manual);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.Codes);
            this.Controls.Add(this.UserText);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox UserText;
        private System.Windows.Forms.ListBox Codes;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.ListBox Manual;
        private System.Windows.Forms.Button Encrypt;
        private System.Windows.Forms.RichTextBox Encrypted;
        private System.Windows.Forms.Button Decrypt;
        private System.Windows.Forms.RichTextBox Key;
        private System.Windows.Forms.RichTextBox Unencrypted;
        private System.Windows.Forms.Button Up;
        private System.Windows.Forms.Button Down;
        private System.Windows.Forms.Label label1;
    }
}

