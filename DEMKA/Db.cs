using DEMKA;
using Npgsql;
using System.Collections.Generic;
using System.Configuration;



public static class Db
{
    private static string connStr = "Host=localhost;Port=5432;Username=postgres;Password=123;Database=demo";
    public static string ConnectionString => connStr;

    public static List<Partner> GetPartners()
    {
        var partners = new List<Partner>();

        using (var conn = new NpgsqlConnection(connStr))
        {
            conn.Open();

            string query = @"
            SELECT p.""Id"", p.""Type"", p.""Name"", p.""Director"", p.""Phone"", p.""Rating"", SUM(pp.quantity) AS quantity
            FROM partners p
            LEFT JOIN parthnerproducts pp ON p.""Id"" = pp.partnerid
            GROUP BY p.""Id"", p.""Type"", p.""Name"", p.""Director"", p.""Phone"", p.""Rating""
            ORDER BY p.""Name"";
            ";


            using (var cmd = new NpgsqlCommand(query, conn))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    partners.Add(new Partner
                    {
                        Id = reader.GetInt32(0),
                        Type = reader.GetString(1),
                        Name = reader.GetString(2),
                        Director = reader.GetString(3),
                        Phone = reader.GetString(4),
                        Rating = reader.GetInt32(5),
                        Quantity = reader.IsDBNull(6) ? 0: reader.GetInt32(6)
                    });
                }
            }
        }

        return partners;
    }
}
