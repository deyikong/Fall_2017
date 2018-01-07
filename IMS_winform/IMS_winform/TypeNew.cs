using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMS_winform
{
    public partial class TypeNew : Form
    {
        public TypeNew()
        {
            InitializeComponent();
        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=NAN-PC\\MSSQLSERVER01;Database=IMS;Integrated Security=True;";

            string cmdText =
                "INSERT INTO [dbo].[Type] (Name, Description) VALUES (@type, @description);";

            //1 Create a connection
            SqlConnection conn = new SqlConnection(connectionString);

            //2 Open the connection
            conn.Open();

            //3 Create sqlCommand Object
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            cmd.Parameters.AddWithValue("@type", textBoxName.Text);
            cmd.Parameters.AddWithValue("@description", textBoxDes.Text);
            
            //4 Execute Command
            cmd.ExecuteNonQuery();

            //5 close connection
            conn.Close();

            MessageBox.Show("Success!");
        }

    }
}
