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
    public partial class Type : Form
    {
        public Type()
        {
            InitializeComponent();
        }

        private void Type_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = true;
            string connectionString = "Server=NAN-PC\\MSSQLSERVER01;Database=IMS;Integrated Security=True";

            string sqlCmd = "SELECT * FROM [dbo].[Type] ";
            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCmd, conn);


            DataSet types = new DataSet();

            sqlDataAdapter.Fill(types, "Type");

            dataGridView1.DataSource = types.Tables[0];

            conn.Close();

        }


        private void newBtn_Click(object sender, EventArgs e)
        {
            var typeNew = new TypeNew();
            var dialogResult = typeNew.ShowDialog();

            if (dialogResult == DialogResult.Cancel)
            {
                MessageBox.Show(@"User clicked cancel!");
            }
            if (dialogResult == DialogResult.OK)
            {
                MessageBox.Show(@"New Type created!");
            }
            FormReLoad();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            //selected row--to see which row user has picked to delete
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                //if (!row.IsNewRow)
                //{
                //    dataGridView1.Rows.Remove(row);
                //}
                //MessageBox.Show("Selected rows Deleted");

                ////read the row Id
                int typeId = (int)row.Cells["Id"].Value;

                ////delete the row with this Id from Database
                string connectionString = "Server=NAN-PC\\MSSQLSERVER01;Database=IMS;Integrated Security=True;";

                SqlConnection conn = new SqlConnection(connectionString);

                conn.Open();

                string cmdText = "DELETE FROM [IMS].[dbo].[Type] WHERE Id = @Id ;";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@Id", typeId);

                cmd.ExecuteNonQuery();

                conn.Close();

                MessageBox.Show("Selected rows Deleted!");


            }

            FormReLoad();

        }
        private void FormReLoad()
        {
            dataGridView1.AutoGenerateColumns = true;
            string connectionString = "Server=NAN-PC\\MSSQLSERVER01;Database=IMS;Integrated Security=True";

            string sqlCmd = "SELECT * FROM [dbo].[Type] ";
            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCmd, conn);


            DataSet types = new DataSet();

            sqlDataAdapter.Fill(types, "Type");

            dataGridView1.DataSource = types.Tables[0];

            conn.Close();
        }
        private void saveBtn_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.)
            {
                //if (!row.IsNewRow)
                //{
                //    dataGridView1.Rows.Remove(row);
                //}
                //MessageBox.Show("Selected rows Deleted");

                ////read the row Id
                int typeId = (int)row.Cells["Id"].Value;

                ////delete the row with this Id from Database
                string connectionString = "Server=NAN-PC\\MSSQLSERVER01;Database=IMS;Integrated Security=True;";

                SqlConnection conn = new SqlConnection(connectionString);

                conn.Open();

                string cmdText = "UPDATE [IMS].[dbo].[Type] SET Name = @name, Description = @description  WHERE Id = @Id ;";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@Id", typeId);
                cmd.Parameters.AddWithValue("@name", row.   );
                cmd.Parameters.AddWithValue("@description", row.Cells);
                cmd.ExecuteNonQuery();

                conn.Close();

                MessageBox.Show("Selected rows Deleted!");

            }
        }

}
