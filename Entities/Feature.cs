using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace webapi.Entities
{
    public class Feature
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime InpDate { get; set; }

        public string connectionString = "Server=localhost;Database=postgres;User ID=postgres;Password=postgres;";

        public bool InsertFeature()
        {
            Feature feature = new Feature();
            feature.Id = Id;
            feature.Name = Name;
            feature.InpDate = InpDate;


            using (var connection = new SqlConnection(connectionString))
            using (var command = connection.CreateCommand())
            {
                connection.Open();

                command.CommandText = "INSERT INTO attributes (id,name,inpDate) " +
                                      "VALUES (@ID, @name, @inpDate)";
                command.Parameters.AddWithValue("@ID", Id);
                command.Parameters.AddWithValue("@name", Name);
                command.Parameters.AddWithValue("@inpDate", InpDate);
                command.ExecuteNonQuery();
            }
            return true;
        }
    }


}
