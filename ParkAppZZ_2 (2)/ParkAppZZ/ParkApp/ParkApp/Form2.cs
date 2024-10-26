using ParkApp.parkclass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkApp
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        Class1 std = new Class1();
        int porder;

        public string LPG { get; private set; }

        private void label6_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'iauParkDataSet.Table_1' table. You can move, or remove it, as needed.
            this.table_1TableAdapter.Fill(this.iauParkDataSet.Table_1);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            std.ParkOrder = porder;
            std.Name = textBox1.Text;
            std.Surname = textBox2.Text;
            std.ID = textBox3.Text;
            std.Plate = textBox4.Text;
            std.Brand = textBox5.Text;
            std.Model = textBox6.Text;
            std.Number = textBox7.Text;
            std.Block = comboBox1.Text;
            string LPG = "";

            if (checkBox1.Checked)
            {
                LPG += checkBox1.Text + " ";

            }

            string Location = "";
            if (rdbIndoor.Checked == true)
            {
                Location = "Indoor";
            }

            if (rdbOutdoor.Checked == true)
            {
                Location = "Outdoor";
            }
            std.LPG = LPG;
            std.Location = Location;
            bool success = std.Insert(std);
            if (success == true)
            {
                MessageBox.Show("Inserted Successfully");
                Clear();
            }
            else
            {
                MessageBox.Show("Failed");
            }

            DataTable dt = std.Select();
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            std.ParkOrder = porder;
            std.Name = textBox1.Text;
            std.Surname = textBox2.Text;
            std.ID = textBox3.Text;
            std.Plate = textBox4.Text;
            std.Brand = textBox5.Text;
            std.Model = textBox6.Text;
            std.Number = textBox7.Text;
            std.Block = comboBox1.Text;
            string LPG = "";

            if (checkBox1.Checked)
            {
                LPG += checkBox1.Text + " ";

            }

            string Location = "";
            std.LPG = LPG;
            
            if (rdbIndoor.Checked)
                Location = rdbIndoor + "" + rdbIndoor.Text;
            else if (rdbOutdoor.Checked)
                Location = rdbOutdoor + " " + rdbOutdoor.Text;
            
            std.Location = Location;
            
            bool success = std.Delete(std);
            if (success)
            {
                MessageBox.Show("Record has been deleted");

                DataTable dt = std.Select();
                dataGridView1.DataSource = dt;
                Clear();
            }
            else
            {
                MessageBox.Show("Failed ,Try again");


            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            std.ParkOrder = porder;
            std.Name = textBox1.Text;
            std.Surname = textBox2.Text;
            std.ID = textBox3.Text;
            std.Plate = textBox4.Text;
            std.Brand = textBox5.Text;
            std.Model = textBox6.Text;
            std.Number = textBox7.Text;
            std.Block = comboBox1.Text;
            string LPG = "";

            if (checkBox1.Checked)
            {
                LPG += checkBox1.Text + " ";

            }

            string Location = "";
            if (rdbIndoor.Checked == true)
            {
                Location = "Indoor";
            }

            if (rdbOutdoor.Checked == true)
            {
                Location = "Outdoor";
            }
            std.LPG = LPG;
            std.Location = Location;

            bool success = std.Update(std);
            if (success == true)
            {
                MessageBox.Show("Updated Successfully");
                DataTable dt = std.Select();
                dataGridView1.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Failed");
            }

         
        }
        public void Clear()
        {
            textBox1.Text = "";
            textBox2.Clear();
            textBox3.Text = String.Empty;
            textBox4.Text = String.Empty;
            textBox5.Text = String.Empty;
            textBox6.Text = String.Empty;
            textBox7.Text = String.Empty;
            comboBox1.Text = String.Empty;
            if (rdbIndoor.Checked == true)
            {
                rdbIndoor.Checked = false;
            }
            if (rdbOutdoor.Checked == true)
            {
                rdbOutdoor.Checked = false;
            }
            if (checkBox1.Checked == true)
            {
                checkBox1.Checked = false;
            }
        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowindex = e.RowIndex;
            
            textBox1.Text = dataGridView1.Rows[rowindex].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[rowindex].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[rowindex].Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.Rows[rowindex].Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.Rows[rowindex].Cells[5].Value.ToString();
            textBox6.Text = dataGridView1.Rows[rowindex].Cells[6].Value.ToString();
            textBox7.Text = dataGridView1.Rows[rowindex].Cells[7].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[rowindex].Cells[9].Value.ToString();
            string Location = dataGridView1.Rows[rowindex].Cells[8].Value.ToString();
            rdbIndoor.Checked = Location.Equals("Indoor");
            rdbOutdoor.Checked = Location.Equals("Outdoor");
            string LPG =dataGridView1.Rows[rowindex].Cells[10].Value.ToString();
            checkBox1.Checked = LPG.Contains("LPG");

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowindex = e.RowIndex;
            porder = Convert.ToInt32(dataGridView1.Rows[rowindex].Cells[0].Value);
            textBox1.Text = dataGridView1.Rows[rowindex].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[rowindex].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[rowindex].Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.Rows[rowindex].Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.Rows[rowindex].Cells[5].Value.ToString();
            textBox6.Text = dataGridView1.Rows[rowindex].Cells[6].Value.ToString();
            textBox7.Text = dataGridView1.Rows[rowindex].Cells[7].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[rowindex].Cells[9].Value.ToString();
            string Location = dataGridView1.Rows[rowindex].Cells[8].Value.ToString();
            rdbIndoor.Checked = Location.Equals("Indoor");
            rdbOutdoor.Checked = Location.Equals("Outdoor");
            string LPG = dataGridView1.Rows[rowindex].Cells[10].Value.ToString();
            checkBox1.Checked = LPG.Contains("LPG");
        }

        private void Form2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }
    }
}
            