using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data.SqlClient;
using AzureFunctions.Models;

namespace AzureFunctions
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            //string connectionString = "Server=tcp:server-test-01.database.windows.net,1433;Initial Catalog=DigitalBooks;Persist Security Info=False;User ID=Priyanga;Password=Password01;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            string connectionString = "Data Source=CTSDOTNET912;Initial Catalog=DigitalBooks;User ID=sa;Password=pass@word1;TrustServerCertificate=True;";
            string query = "Select * from [dbo].[Subscription] sub inner join [dbo].[Book] b on sub.bookid= b.bookid inner join [dbo].[User] u on sub.userid= u.userid";
            List<Subscription> subscriptions = new List<Subscription>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader;
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Subscription subscription = new Subscription() { SubscriptionId = (int)reader[0], BookId = (int)reader[1],
                            Title = reader[2].ToString(),
                            EmailId = reader[3].ToString(),
                            SubscriptionActive = reader[4].ToString(),
                            UserId = (int)reader[5],
                            Author = reader[6].ToString()
                        };
                        subscriptions.Add(subscription);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            var strResult = JsonConvert.SerializeObject(subscriptions);
            return new OkObjectResult(strResult);
        }
    }
}
