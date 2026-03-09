using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core
{
    public static class Services
    {
        private static string connStr = "server=localhost;user=root;database=operett_db;password=''";

        public static List<Operett> GetAll()
        {
            List<Operett> lista = new List<Operett>();
            using (var conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string sql = @"SELECT alkoto.nev, kapcsolat.alkotoid, kapcsolat.muid, kapcsolat.tipus, 
                               mu.cim, mu.eredeti, mu.szinhaz, mu.felvonas, mu.kep, mu.ev 
                               FROM kapcsolat 
                               INNER JOIN alkoto ON kapcsolat.alkotoid = alkoto.id 
                               INNER JOIN mu ON kapcsolat.muid = mu.id;";

                using (var cmd = new MySqlCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Operett(
                            reader["nev"].ToString(),
                            reader["alkotoid"].ToString(),
                            reader["muid"].ToString(),
                            reader["tipus"].ToString(),
                            reader["cim"].ToString(),
                            reader["eredeti"].ToString(),
                            reader["szinhaz"].ToString(),
                            reader["felvonas"].ToString(),
                            reader["kep"].ToString(),
                            reader["ev"].ToString()
                        ));
                    }
                }
            }
            return lista;
        }

        // 4. Metódus: eldönti, hogy egy operett több mint 3 felvonásos-e
        public static bool TobbMintHaromFelvonasos(Operett operett)
        {
            return operett.Felvonas > 3;
        }
    }
}
