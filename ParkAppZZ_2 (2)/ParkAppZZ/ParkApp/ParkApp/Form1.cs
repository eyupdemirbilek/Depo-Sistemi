using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace ParkApp
{
    public partial class Form1 : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'iauParkDataSet.Table_1' table. You can move, or remove it, as needed.
            this.table_1TableAdapter.Fill(this.iauParkDataSet.Table_1);

        }
        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=localhost;Initial Catalog=IauPark;User ID=sa;Password=ab12AB34";
            string username = txtUser.Text;
            string password = txtPass.Text;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT COUNT(*) FROM Table_2 WHERE Username = @username AND Password = @password";
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);

                    int count = Convert.ToInt32(command.ExecuteScalar());

                    if (count == 1)
                    {
                        MessageBox.Show("Giriş başarılı!");
                        Form2 form2 = new Form2();
                        form2.Show();
                    }
                    else
                    {
                        MessageBox.Show("Giriş başarısız. Lütfen tekrar deneyin.");
                    }
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}



