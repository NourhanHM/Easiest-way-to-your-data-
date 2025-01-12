using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Text;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace isa
{
    public partial class display : Form
    {
        private BinaryReader reader;
        private string filePath;
        public display()
        {
            InitializeComponent();
        }

        private ulong HashFunction(int key)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(key.ToString()));
                return BitConverter.ToUInt64(hashedBytes, 0);
            }
        }

        private void DisplayRecord()
        {
            try
            {
                if (reader == null)
                {
                    filePath = Path.Combine(@"F:\", textBox1.Text);
                    reader = new BinaryReader(new FileStream(filePath, FileMode.Open));
                    Info.count = 0; // Increment the total record count
                    Info.rec_size = 9;

                }

                if (reader.BaseStream.Position == reader.BaseStream.Length)
                {
                    MessageBox.Show("End of file reached.");
                    reader.Close();
                    reader = null;
                    return;
                }

                while (reader.BaseStream.Position < reader.BaseStream.Length)
                {
                    int id = reader.ReadInt32();
                    ulong hashedKey = reader.ReadUInt64();
                    byte[] firstNameBytes = reader.ReadBytes(64);
                    string firstName = Encoding.UTF8.GetString(firstNameBytes).TrimEnd('\0');
                    byte[] lastNameBytes = reader.ReadBytes(64);
                    string lastName = Encoding.UTF8.GetString(lastNameBytes).TrimEnd('\0');
                    int birthYear = reader.ReadInt32();

                    textBox2.Text = id.ToString();
                    textBox3.Text = firstName;
                    textBox4.Text = lastName;
                    textBox5.Text = birthYear.ToString();
                    Info.count++; // Increment the total record count
                    Info.rec_size = Info.count * 144;

                    textBox6.Text = Info.rec_size.ToString();
                    textBox7.Text = Info.count.ToString();
                    return; // Exit the method after reading the first record

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            DisplayRecord();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (reader != null)
            {
                reader.Close();
                reader = null;
            }

            this.Hide();
            new Form1().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
