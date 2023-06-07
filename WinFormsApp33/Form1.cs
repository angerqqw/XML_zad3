using System.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WinFormsApp33
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == " ")
            {
                MessageBox.Show("Çàïîëíèòå âñå ïîëÿ.", "Îøèáêà.");
            }
            else
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = textBox1.Text;
                dataGridView1.Rows[n].Cells[1].Value = numericUpDown1.Value;
                dataGridView1.Rows[n].Cells[2].Value = comboBox1.Text;
                dataGridView1.Rows[n].Cells[3].Value = numericUpDown2.Value;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int n = dataGridView1.SelectedRows[0].Index;
                dataGridView1.Rows[n].Cells[0].Value = textBox1.Text;
                dataGridView1.Rows[n].Cells[1].Value = numericUpDown1.Value;
                dataGridView1.Rows[n].Cells[2].Value = comboBox1.Text;
                dataGridView1.Rows[n].Cells[3].Value = numericUpDown2.Value;
            }
            else
            {
                MessageBox.Show("Âûáåðèòå ñòðîêó äëÿ ðåäàêòèðîâàíèÿ.", "Îøèáêà.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
            }
            else
            {
                MessageBox.Show("Âûáåðèòå ñòðîêó äëÿ óäàëåíèÿ.", "Îøèáêà.");
            }
        }
        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            int n = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[1].Value);
            numericUpDown1.Value = n;
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                dt.TableName = "Employee";
                dt.Columns.Add("Name");
                dt.Columns.Add("Age");
                dt.Columns.Add("Programmer");
                dt.Columns.Add("Experience");
                ds.Tables.Add(dt);
                foreach (DataGridViewRow r in dataGridView1.Rows)
                {
                    DataRow row = ds.Tables["Employee"].NewRow();
                    row["Name"] = r.Cells[0].Value;
                    row["Age"] = r.Cells[1].Value;
                    row["Programmer"] = r.Cells[2].Value;
                    row["Experience"] = r.Cells[3].Value;
                    ds.Tables["Employee"].Rows.Add(row);
                    ds.WriteXml("C:\\Important\\XML.xml");
                    MessageBox.Show("XML ôàéë óñïåøíî ñîõðàí¸í.", "Âûïîëíåíî.");
                }
            }
            catch
            {
                MessageBox.Show("Íåâîçìîæíî ñîõðàíèòü XML ôàéë.", "Îøèáêà.");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Rows.Clear();
            }
            else
            {
                MessageBox.Show("Òàáëèöà ïóñòàÿ.", "Îøèáêà.");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count < 0)
            {
                MessageBox.Show("Î÷èñòèòå ïîëå ïåðåä çàãðóçêîé íîâîãî ôàéëà.", "Îøèáêà.");
            }
            else
            {
                if (File.Exists("C:\\Important\\XML.xml"))
                {
                    DataSet ds = new DataSet();
                    ds.ReadXml("C:\\Important\\XML.xml");

                    foreach (DataRow item in ds.Tables["Employee"].Rows)
                    {
                        int n = dataGridView1.Rows.Add();
                        dataGridView1.Rows[n].Cells[0].Value = item["Name"];
                        dataGridView1.Rows[n].Cells[1].Value = item["Age"];
                        dataGridView1.Rows[n].Cells[2].Value = item["Programmer"];
                        dataGridView1.Rows[n].Cells[3].Value = item["Experience"];
                    }
                }
                else
                {
                    MessageBox.Show("XML ôàéë íå íàéäåí.", "Îøèáêà.");
                }
            }
        }
    }
}
