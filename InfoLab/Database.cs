using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace Online
{
    
    class Database
    {
        public struct attrezzo  
        {
            public string codice;
            public string categoria;
            public string marca;
            public string modello;
            public decimal prezzo;
            public int quantità;
            public DateTime data;
        }
        public static bool salva(attrezzo[] elep, int n)
        {
            string supersecretpass = "X6!GZ9Pz}N9&8oECRZCYqrM,XXM2+ZwcYgkHIW";

            try
            {
                int x = 0;
                var conn = new MySqlConnection($"Server=85.10.205.173;port=3306;Uid=ad_pass;Pwd={supersecretpass};Database=passfolder1;Connection Timeout=30;old guids=true;");
                conn.Open();
                var reset = new MySqlCommand("DELETE FROM Ferramenta", conn);
                int el = reset.ExecuteNonQuery();
                reset.Dispose();

                while (x < n)
                {

                    var inserimento = new MySqlCommand("INSERT INTO Ferramenta (isbn,titolo,autore,editore,prezzo,materia,classe,quantita) VALUES(@a,@b,@c,@d,@e,@f,@g,@h)", conn);
                    inserimento.Parameters.AddWithValue("@a", elep[x].codice);
                    inserimento.Parameters.AddWithValue("@b", elep[x].categoria);
                    inserimento.Parameters.AddWithValue("@c", elep[x].marca);
                    inserimento.Parameters.AddWithValue("@d", elep[x].modello);
                    inserimento.Parameters.AddWithValue("@e", elep[x].prezzo);
                    inserimento.Parameters.AddWithValue("@f", elep[x].quantità);
                    inserimento.Parameters.AddWithValue("@g", elep[x].data);
                    int nr = inserimento.ExecuteNonQuery();
                    inserimento.Dispose();
                    x++;
                }

                conn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool carica(attrezzo[] elep, ref int n)
        {
            string supersecretpass = "X6!GZ9Pz}N9&8oECRZCYqrM,XXM2+ZwcYgkHIW";

            try
            {

                var conn = new MySqlConnection($"Server=85.10.205.173;port=3306;Uid=ad_pass;Pwd={supersecretpass};Database=passfolder1;Connection Timeout=30;old guids=true;");
                conn.Open();
                var cmd = new MySqlCommand("select * from Ferramenta", conn);
                MySqlDataReader dr = default;
                dr = cmd.ExecuteReader();
                while (dr.Read() == true)
                {
                    elep[n].codice = dr["isbn"] as string;
                    elep[n].categoria = dr["titolo"] as string;
                    elep[n].marca = dr["autore"] as string;
                    elep[n].modello = dr["editore"] as string;
                    elep[n].prezzo = decimal.Parse(dr["prezzo"] as string);
                    elep[n].quantità = int.Parse(dr["materia"] as string);
                    elep[n].data = DateTime.Parse(dr["classe"] as string);
                    n++;
                }
                dr.Close();
                dr.Dispose();
                cmd.Dispose();
                conn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
