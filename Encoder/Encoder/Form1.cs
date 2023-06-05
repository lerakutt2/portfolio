using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Encoder
{
    public partial class Form1 : Form
    {
        List<Encryptor> keyList = new List<Encryptor>();
        DecryptProcessor decryptProcessor;

        public Form1()
        {
            InitializeComponent();
        }

        char IncrementSymbolCode(char symbolCode)
        {
            decryptProcessor = new IncrementDecrypt();
            return decryptProcessor.Process(symbolCode);
        }

        char DecrementSymbolCode(char symbolCode)
        {
            decryptProcessor = new DecrementDecrypt();
            return decryptProcessor.Process(symbolCode);
        }

        char ZeroSymbolCode(char symbolCode)
        {
            decryptProcessor = new ZeroDecrypt();
            return decryptProcessor.Process(symbolCode);
        }

        char NegativeSymbolCode(char symbolCode)
        {
            decryptProcessor = new NegativeDecrypt();
            return decryptProcessor.Process(symbolCode);
        }

        void FillEncryptors()
        {
            keyList.Clear();
            foreach (string encoder in Manual.Items)
            {
                if (encoder == Codes.Items[0].ToString())
                    keyList.Add(new Encryptor(IncrementSymbolCode, "I"));
                else if (encoder == Codes.Items[1].ToString())
                    keyList.Add(new Encryptor(DecrementSymbolCode, "D"));
                else if (encoder == Codes.Items[2].ToString())
                    keyList.Add(new Encryptor(ZeroSymbolCode, "Z"));
                else if (encoder == Codes.Items[3].ToString())
                    keyList.Add(new Encryptor(NegativeSymbolCode, "N"));
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            if (Codes.SelectedItem != null)
            { 
                Manual.Items.Add(Codes.SelectedItem.ToString()); 
            }
            else
            {
                MessageBox.Show("Выделите элемент для его добавления"); 
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (Manual.SelectedItem != null)
            { 
                Manual.Items.RemoveAt(Manual.SelectedIndex); 
            }
            else
            { 
                MessageBox.Show("Выделите элемент для его удаления"); 
            }
        }

        bool TextIsCorrect(string text)
        {
            foreach(char c in text)
            {
                int i = Convert.ToInt32(c);
                if (!(i >= 65 && i <= 90 || i >= 48 && i <= 57 || i >= 97 && i <= 122)) { return false; }
            }
            return true;
        }

        private void Encrypt_Click(object sender, EventArgs e)
        {
            if (TextIsCorrect(UserText.Text))
            {
                FillEncryptors();

                Encrypted.Clear();
                Key.Clear();

                int i = 0;
                foreach (char symbol in UserText.Text)
                {
                    char newSymbol = symbol;
                    newSymbol = keyList[i].Encrypt(newSymbol);
                    Encrypted.Text += newSymbol;

                    if (i == keyList.Count - 1) i = 0;
                    else i++;
                }

                foreach (Encryptor ecryptor in keyList)
                {
                    Key.Text += ecryptor.key;
                }
            }
            else
            {
                MessageBox.Show("Текст для шифрования может включать только латинские буквы и цифры");
            }
        }

        private void Decrypt_Click(object sender, EventArgs e)
        {
            Decryptor decryptor = new Decryptor();
            Unencrypted.Text = decryptor.Decrypt(Key.Text, Encrypted.Text);
        }

        private void Up_Click(object sender, EventArgs e)
        {
            if (Manual.SelectedItem != null)
            {
                if (Manual.SelectedIndex != 0)
                {
                    object temp = Manual.Items[Manual.SelectedIndex];
                    Manual.Items[Manual.SelectedIndex] = Manual.Items[Manual.SelectedIndex - 1];
                    Manual.Items[Manual.SelectedIndex - 1] = temp;
                }
                else
                {
                    MessageBox.Show("Нельзя переместить данный элемент вверх");
                }
            }
            else
            { 
                MessageBox.Show("Выберите элемент для перемещения");
            }
        }

        private void Down_Click(object sender, EventArgs e)
        {
            if (Manual.SelectedItem != null)
            {
                if (Manual.SelectedIndex != Manual.Items.Count - 1)
                {
                    object temp = Manual.Items[Manual.SelectedIndex];
                    Manual.Items[Manual.SelectedIndex] = Manual.Items[Manual.SelectedIndex + 1];
                    Manual.Items[Manual.SelectedIndex + 1] = temp;
                }
                else
                {
                    MessageBox.Show("Нельзя переместить данный элемент вниз");
                }
            }
            else
            {
                MessageBox.Show("Выберите элемент для перемещения");
            }
        }
    }
}
