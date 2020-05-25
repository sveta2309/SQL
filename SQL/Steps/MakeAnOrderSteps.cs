using System;
using TechTalk.SpecFlow;
using System.Data.SqlClient;
using NUnit.Framework;

namespace SQL.Steps
{
    [Binding]
    public class MakeAnOrderSteps
    {
        public int amount = WhenIGetInfoAboutUserSvetaKovalovaFromTableOrders();
        [When(@"I get info about user \[Sveta Kovalova] from table Orders")]
        public static int WhenIGetInfoAboutUserSvetaKovalovaFromTableOrders()
        {
            string connString = @"Server =SVETA228\SQLEXPRESS; Database = Shop; Trusted_Connection = True;";
            int amount = 0;


            using (SqlConnection conn = new SqlConnection(connString))
            {


                string query = @"SELECT Amount
                                     FROM Orders where id=(SELECT id from Persons where FirstName like 'Sveta')
                                     ";

                SqlCommand cmd = new SqlCommand(query, conn);


                conn.Open();


                SqlDataReader dr = cmd.ExecuteReader();


                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        amount = dr.GetInt32(0);
                    }

                }


                dr.Close();

                conn.Close();
                return amount;
            }
        }

        [Then(@"user amount in DB is equal to 220")]
        public void ThenTheAmountShouldBe()
        {
            Assert.AreEqual(220, amount);
        }
    }
}
