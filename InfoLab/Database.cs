using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using dllferramenta;


namespace Online
{
    //public struct attrezzo
    //{
    //    public string codice;
    //    public string categoria;
    //    public string marca;
    //    public string modello;
    //    public decimal prezzo;
    //    public int quantità;
    //    public DateTime data;
    //}
    class Database
    {
        public static bool salva(funzioni.attrezzo[] elep, int n)
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

                    var inserimento = new MySqlCommand("INSERT INTO Ferramenta (Codice,Categoria,marca,Modello,Prezzo,quantità,data) VALUES(@a,@b,@c,@d,@e,@f,@g)", conn);
                    inserimento.Parameters.AddWithValue("@a", elep[x].codice);
                    inserimento.Parameters.AddWithValue("@b", elep[x].categoria);
                    inserimento.Parameters.AddWithValue("@c", elep[x].marca);
                    inserimento.Parameters.AddWithValue("@d", elep[x].modello);
                    inserimento.Parameters.AddWithValue("@e", elep[x].prezzo.ToString());
                    inserimento.Parameters.AddWithValue("@f", elep[x].quantità.ToString());
                    inserimento.Parameters.AddWithValue("@g", elep[x].data.ToString());
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
        public static bool carica(funzioni.attrezzo[] elep, ref int n)
        {
            n = 0;
            string supersecretpass = "X6!GZ9Pz}N9&8oECRZCYqrM,XXM2+ZwcYgkHIW";

            try
            {

                var conn = new MySqlConnection($"Server=85.10.205.173;port=3306;Uid=ad_pass;Pwd={supersecretpass};Database=passfolder1;Connection Timeout=30;old guids=true;");
                conn.Open();
                var cmd = new MySqlCommand("select * from Ferramenta", conn);
                MySqlDataReader dr = default(MySqlDataReader);
                dr = cmd.ExecuteReader();
                while (dr.Read() == true)
                {
                    elep[n].codice = dr["Codice"] as string;
                    elep[n].categoria = dr["Categoria"] as string;
                    elep[n].marca = dr["marca"] as string;
                    elep[n].modello = dr["Modello"] as string;
                    elep[n].prezzo = decimal.Parse(dr["Prezzo"] as string);
                    elep[n].quantità = int.Parse(dr["quantità"] as string);
                    elep[n].data = DateTime.Parse(dr["data"] as string);
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
