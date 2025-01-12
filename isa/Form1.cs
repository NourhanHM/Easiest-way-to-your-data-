using System.Text;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace isa
{
    public partial class Form1 : Form
    {
        private BinaryReader reader;
        public Form1()
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

        private void SaveRecord(string fileName, int id, string firstName, string lastName, int birthYear)
        {
            string filePath = Path.Combine(@"F:\", fileName);

            bool fileExists = File.Exists(filePath);

            if (fileExists)
            {
                int existingRecordCount = 0;
                int existingRecordSize = 0;

                using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                using (BinaryReader reader = new BinaryReader(fileStream))
                {
                    while (reader.BaseStream.Position < reader.BaseStream.Length)
                    {
                        // Read the existing records
                        reader.ReadInt32(); // Skip ID
                        reader.ReadUInt64(); // Skip HashedKey
                        reader.ReadBytes(64); // Skip FirstName
                        reader.ReadBytes(64); // Skip LastName
                        reader.ReadInt32(); // Skip BirthYear

                        existingRecordCount++;
                        existingRecordSize += 144; // Assuming each record is 144 bytes
                    }
                }

                Info.count = existingRecordCount;
                Info.rec_size = existingRecordSize;
            }

            ulong hashedKey = HashFunction(id);
            using (FileStream fileStream = new FileStream(filePath, FileMode.Append))
            using (BinaryWriter writer = new BinaryWriter(fileStream))
            {
                writer.Write(id);
                writer.Write(hashedKey);
                writer.Write(Encoding.UTF8.GetBytes(firstName.PadRight(64, '\0')));
                writer.Write(Encoding.UTF8.GetBytes(lastName.PadRight(64, '\0')));
                writer.Write(birthYear);

                Info.count++; // Increment the total record count
                Info.rec_size = Info.count * 144; // Recalculate the total record size
            }

            textBox6.Text = Info.rec_size.ToString();
            textBox7.Text = Info.count.ToString();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string filePath = textBox1.Text; // Assuming textBox1 contains the file name
            if (string.IsNullOrEmpty(filePath))
            {
                MessageBox.Show("Please enter the file name.");
                return;
            }
            int id;
            if (!int.TryParse(textBox2.Text, out id))
            {
                MessageBox.Show("Please enter a valid integer ID.");
                return;
            }

            string firstName = textBox3.Text;
            string lastName = textBox4.Text;
            int birthYear;
            if (!int.TryParse(textBox5.Text, out birthYear))
            {
                MessageBox.Show("Please enter a valid integer Birth Year.");
                return;
            }

            SaveRecord(filePath, id, firstName, lastName, birthYear);
            MessageBox.Show("Record saved successfully!");


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new display().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form2().Show();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }


}
