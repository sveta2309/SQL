using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using NUnit.Framework;

namespace SQL
{
    public class TestSQL
    {
        [Test]
        public static void Main()
        {

            string connString = @"Server =SVETA228\SQLEXPRESS; Database = Shop; Trusted_Connection = True;";

            int ID = 0;




            using (SqlConnection conn = new SqlConnection(connString))
            {


                string query = @"SELECT id
                                     FROM Persons where age>25
                                     ";

                SqlCommand cmd = new SqlCommand(query, conn);


                conn.Open();


                SqlDataReader dr = cmd.ExecuteReader();




                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ID = dr.GetInt32(0);

                    }
                }
                if (ID == 3)
                {
                    Assert.Pass();
                }




                dr.Close();

                conn.Close();
            }




        }

    }
}
