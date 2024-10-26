using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkApp.parkclass
{
    class Class1
    {
        public int ParkOrder { get; set; }
        public string Name { get; set; }

        public string Surname { get; set; }

        public string ID { get; set; }
        public string Plate { get; set; }
        public string Brand { get; set; }

        public string Model { get; set; }
        public string Number { get; set; }

        public string Block { get; set; }
        public string Location { get; set; }
        public string Indoor { get; set; }
        
        public string Outdoor { get; set; }

        public string LPG { get; set; }

        static string myconnstrng = ConfigurationManager.ConnectionStrings["ParkApp.Properties.Settings.IauParkConnectionString"].ConnectionString;


        public DataTable Select()
        {

            SqlConnection conn = new SqlConnection(myconnstrng);

            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT * FROM Table_1";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
            return dt;

        }

        public bool Insert(Class1 std)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                string sql = "INSERT INTO Table_1 (Name, Surname, ID, Plate, Brand, Model, Number, Location, Block, LPG) VALUES (@Name, @Surname, @ID, @Plate, @Brand, @Model, @Number, @Location, @Block, @LPG)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Name", std.Name);
                cmd.Parameters.AddWithValue("@Surname", std.Surname);
                cmd.Parameters.AddWithValue("@ID", std.ID);
                cmd.Parameters.AddWithValue("@Plate", std.Plate);
                cmd.Parameters.AddWithValue("@Brand", std.Brand);
                cmd.Parameters.AddWithValue("@Model", std.Model);
                cmd.Parameters.AddWithValue("Block", std.Block);
                cmd.Parameters.AddWithValue("@Number", std.Number);
                cmd.Parameters.AddWithValue("@Location", std.Location);
                cmd.Parameters.AddWithValue("@LPG", std.LPG);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    isSuccess = true;

                }
                else
                {
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();

            }
            return isSuccess;
        }

        public bool Update(Class1 std)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                conn.Open();
                string sql = "UPDATE Table_1 SET Name =@Name, Surname = @Surname, ID = @ID, Plate= @Plate, Brand = @Brand, Model = @Model, Number = @Number, Location = @Location, Block = @Block, LPG= @LPG WHERE ParkOrder=@porder";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Name", std.Name);
                cmd.Parameters.AddWithValue("@Surname", std.Surname);
                cmd.Parameters.AddWithValue("@ID", std.ID);
                cmd.Parameters.AddWithValue("@Plate", std.Plate);
                cmd.Parameters.AddWithValue("@Brand", std.Brand);
                cmd.Parameters.AddWithValue("@Model", std.Model);
                cmd.Parameters.AddWithValue("@Number", std.Number);
                cmd.Parameters.AddWithValue("@porder", std.ParkOrder);
                cmd.Parameters.AddWithValue("@Location", std.Location);
                cmd.Parameters.AddWithValue("@Block", std.Block);
                cmd.Parameters.AddWithValue("@LPG", std.LPG);
                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    isSuccess = true;

                }
                else
                {
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();

            }
            return isSuccess;


        }
        public bool Delete(Class1 std)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);
            //try
            //{
                string sql = "DELETE FROM Table_1 WHERE ParkOrder = @porder";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@porder", std.ParkOrder);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    isSuccess = true;

                }
                else
                {
                    isSuccess = false;
                }
            /*}
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();

            }*/
            return isSuccess;


        }
    }
}
