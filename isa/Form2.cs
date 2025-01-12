using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace isa
{
    public partial class Form2 : Form
    {
        private string filePath;
        private BinaryReader reader;
        private BinaryWriter writer;
        private bool isRecordFound;
        public Form2()
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

        private void SearchRecord(int id)
        {
            isRecordFound = false;

            try
            {
                filePath = Path.Combine(@"F:\", textBox1.Text);
                using (BinaryReader reader = new BinaryReader(new FileStream(filePath, FileMode.Open)))
                {
                    while (reader.BaseStream.Position < reader.BaseStream.Length)
                    {
                        int recordId = reader.ReadInt32();
                        ulong hashedKey = reader.ReadUInt64();
                        byte[] nameBytes = reader.ReadBytes(64);
                        byte[] lastNameBytes = reader.ReadBytes(64);
                        int birthYear = reader.ReadInt32();

                        string name = Encoding.UTF8.GetString(nameBytes).TrimEnd('\0');
                        string lastName = Encoding.UTF8.GetString(lastNameBytes).TrimEnd('\0');

                        if (hashedKey == HashFunction(id))
                        {
                            textBox2.Text = recordId.ToString();
                            textBox3.Text = name;
                            textBox4.Text = lastName;
                            textBox5.Text = birthYear.ToString();
                            isRecordFound = true;
                            break;
                        }
                    }
                }

                if (!isRecordFound)
                {
                    MessageBox.Show("Record not found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }




        private void UpdateRecord(int id, ulong hashedKey, string name, string lastName, int birthYear)
        {
            if (!isRecordFound)
            {
                MessageBox.Show("Please search for a record first.");
                return;
            }

            try
            {
                // Create a temporary file to write the modified records
                string tempFilePath = Path.Combine(Path.GetDirectoryName(filePath), "temp.dat");
                using (FileStream tempFileStream = new FileStream(tempFilePath, FileMode.Create))
                {
                    using (BinaryWriter tempWriter = new BinaryWriter(tempFileStream))
                    {
                        using (BinaryReader tempReader = new BinaryReader(new FileStream(filePath, FileMode.Open)))
                        {
                            while (tempReader.BaseStream.Position < tempReader.BaseStream.Length)
                            {
                                int recordId = tempReader.ReadInt32();
                                ulong recordHashedKey = tempReader.ReadUInt64();
                                byte[] nameBytes = tempReader.ReadBytes(64);
                                byte[] lastNameBytes = tempReader.ReadBytes(64);
                                int birthYearValue = tempReader.ReadInt32();

                                if (recordId == id)
                                {
                                    // Update the record with the new values
                                    tempWriter.Write(recordId);
                                    tempWriter.Write(hashedKey);
                                    tempWriter.Write(Encoding.UTF8.GetBytes(name.PadRight(64, '\0')));
                                    tempWriter.Write(Encoding.UTF8.GetBytes(lastName.PadRight(64, '\0')));
                                    tempWriter.Write(birthYear);
                                }
                                else
                                {
                                    // Write the existing record as is
                                    tempWriter.Write(recordId);
                                    tempWriter.Write(recordHashedKey);
                                    tempWriter.Write(nameBytes);
                                    tempWriter.Write(lastNameBytes);
                                    tempWriter.Write(birthYearValue);
                                }
                            }
                        }
                    }
                }

                // Replace the original file with the modified file
                File.Delete(filePath);
                File.Move(tempFilePath, filePath);

                MessageBox.Show("Record updated successfully!");
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void DeleteRecord(int id)
        {
            if (!isRecordFound)
            {
                MessageBox.Show("Please search for a record first.");
                return;
            }

            try
            {
                // Create a temporary file to write the modified records
                string tempFilePath = Path.Combine(Path.GetDirectoryName(filePath), "temp.dat");
                using (FileStream tempFileStream = new FileStream(tempFilePath, FileMode.Create))
                {
                    using (BinaryWriter tempWriter = new BinaryWriter(tempFileStream))
                    {
                        using (BinaryReader tempReader = new BinaryReader(new FileStream(filePath, FileMode.Open)))
                        {
                            while (tempReader.BaseStream.Position < tempReader.BaseStream.Length)
                            {
                                int recordId = tempReader.ReadInt32();
                                ulong recordHashedKey = tempReader.ReadUInt64();
                                byte[] nameBytes = tempReader.ReadBytes(64);
                                byte[] lastNameBytes = tempReader.ReadBytes(64);
                                int birthYearValue = tempReader.ReadInt32();

                                if (recordId == id)
                                {
                                    // Skip the record to be deleted
                                    continue;
                                }

                                // Write the existing record as is
                                tempWriter.Write(recordId);
                                tempWriter.Write(recordHashedKey);
                                tempWriter.Write(nameBytes);
                                tempWriter.Write(lastNameBytes);
                                tempWriter.Write(birthYearValue);
                            }
                        }
                    }
                }

                // Replace the original file with the modified file
                File.Delete(filePath);
                File.Move(tempFilePath, filePath);

                MessageBox.Show("Record deleted successfully!");
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void ResetForm()
        {
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
            textBox5.Text = string.Empty;
            isRecordFound = false;
        }


        private void button2_Click(object sender, EventArgs e)
        {

            int id;
            if (!int.TryParse(textBox2.Text, out id))
            {
                MessageBox.Show("Please enter a valid integer ID.");
                return;
            }

            ulong hashedKey;
            if (!isRecordFound)
            {
                MessageBox.Show("Please search for a record first.");
                return;
            }
            else
            {
                hashedKey = HashFunction(id);
            }

            string name = textBox3.Text;
            string lastName = textBox4.Text;
            int birthYear;
            if (!int.TryParse(textBox5.Text, out birthYear))
            {
                MessageBox.Show("Please enter a valid integer birth year.");
                return;
            }

            UpdateRecord(id, hashedKey, name, lastName, birthYear);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id;

            if (!int.TryParse(textBox2.Text, out id))
            {
                MessageBox.Show("Please enter a valid integer ID.");
                return;
            }

            SearchRecord(id);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id;
            if (!int.TryParse(textBox2.Text, out id))
            {
                MessageBox.Show("Please enter a valid integer ID.");
                return;
            }

            ulong hashedKey;
            if (!isRecordFound)
            {
                MessageBox.Show("Please search for a record first.");
                return;
            }
            else
            {
                hashedKey = HashFunction(id);
            }

            DeleteRecord(id);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form1().Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
