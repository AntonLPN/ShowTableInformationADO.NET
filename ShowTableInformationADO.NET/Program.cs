using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//шаблон строки подключения
//Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = Library; Integrated Security = SSPI;


namespace ShowTableInformationADO.NET
{
    class Program
    {

        static void Main(string[] args)
        {
            using (SqlConnection sqlConnection=new SqlConnection())
            {
                sqlConnection.ConnectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = Library; Integrated Security = SSPI;";
                SqlCommand command = new SqlCommand();
                SqlDataReader reader = null;

                try
                {
                    if (sqlConnection!=null)
                    {
                        sqlConnection.Open();
                        command.Connection = sqlConnection;

                        command.CommandText = "select *from Books";

                        reader = command.ExecuteReader();
                  
                        while (reader.Read())
                        {
                            Console.WriteLine(reader.GetInt32(1) + "  " + reader.GetString(2) + "   " + reader.GetInt32(3) + "  " + reader.GetInt32(4));
                        }


                    }



                }
                finally
                {
                    if (sqlConnection!=null)
                    {
                        sqlConnection.Close();
                    }
                }



            }



        }

    }
    
}
