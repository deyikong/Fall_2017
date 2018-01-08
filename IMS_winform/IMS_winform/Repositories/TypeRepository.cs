using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS_winform.Repositories
{
    class TypeRepository
    {
        public void Create(Models.Type type)
        {
            string connectionString = "Server=localhost;Database=IMS;Integrated Security=True;";

            string cmdText =
                "INSERT INTO [dbo].[Type] (Name, Description) VALUES (@name, @description);";

            //1 Create a connection
            SqlConnection conn = new SqlConnection(connectionString);

            //2 Open the connection
            conn.Open();

            //3 Create sqlCommand Object
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            cmd.Parameters.AddWithValue("@name", type.Name);
            cmd.Parameters.AddWithValue("@description", type.Description);

            //4 Execute Command
            cmd.ExecuteNonQuery();

            //5 close connection
            conn.Close();

        }
        public void Update()
        {

        }
        public void Delete(int id)
        {
            string connectionString = "Server=localhost;Database=IMS;Integrated Security=True;";

            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();

            string cmdText = "DELETE FROM [IMS].[dbo].[Type] WHERE Id = @Id ;";
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            cmd.Parameters.AddWithValue("@Id", id);

            cmd.ExecuteNonQuery();

            conn.Close();
        }
        //public List<Type> Select()
        //{

        //}
    }
}
