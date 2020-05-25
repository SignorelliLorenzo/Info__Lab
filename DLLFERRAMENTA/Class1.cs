using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoLab
{
    public class funzioni
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

        public static bool cancellacodice(attrezzo[] eleattrezzi, ref int n, string codicescelto)
        {
            int x = default(int);
            bool found = default(bool);

            while (x < n && !found)
            {
                if (string.Compare(eleattrezzi[x].codice, codicescelto) == 0)
                {
                    if (eleattrezzi[x].quantità < quantità)
                    {
                        found = false;
                        return found;
                    }

                    found = true;
                    eleattrezzi[x].quantità = eleattrezzi[x].quantità - quantità;
                    eleattrezzi[x] = eleattrezzi[n - 1];
                    n = n - 1;
                }
                x = x + 1;
            }
            return found;
        }

        public static int ricerca(attrezzo[] eleattrezzi, int n, string codicescelto)
        {
            int x = default(int);
            int pos = -1;

            while (x < n)
            {
                if (string.Compare(eleattrezzi[x].codice, codicescelto) == 0)
                {
                    pos = x;
                }
                x = x + 1;
            }
            return pos;
        }

        public static attrezzo prezzominimo(attrezzo[] eleattrezzi, int n)
        {
            int x = default(int);
            decimal prezzominimo = default(decimal);
            attrezzo attrezzomin = default(attrezzo);
            prezzominimo = eleattrezzi[0].prezzo;
            attrezzomin = eleattrezzi[0];

            while (x < n)
            {
                if (eleattrezzi[x].prezzo < prezzominimo)
                {
                    prezzominimo = eleattrezzi[x].prezzo;
                    attrezzomin = eleattrezzi[x];
                }
                x = x + 1;
            }
            return attrezzomin;
        }

        public static attrezzo prezzomassimo(attrezzo[] eleattrezzi, int n)
        {
            int x = default(int);
            decimal prezzomassimo = default(decimal);
            attrezzo attrezzomax = default(attrezzo);
            prezzomassimo = eleattrezzi[0].prezzo;
            attrezzomax = eleattrezzi[0];

            while (x < n)
            {
                if (eleattrezzi[x].prezzo > prezzomassimo)
                {
                    prezzomassimo = eleattrezzi[x].prezzo;
                    attrezzomax = eleattrezzi[x];
                }
                x = x + 1;
            }
            return attrezzomax;
        }

        public static decimal mediaprezzi(attrezzo[] eleattrezzi, int n)
        {
            int x = default(int);
            decimal totale = default(decimal);
            decimal med = default(decimal);

            while (x < n)
            {
                totale = totale + eleattrezzi[x].prezzo;
                x = x + 1;
            }
            med = totale / n;
            return med;
        }
        
        public static bool cancellacategoria(attrezzo[] eleattrezzi, ref int n, string categoriascelta, ref int npc)
        {
            int x = default(int);
            bool found = default(bool);

            while (x < n)
            {
                if (string.Compare(eleattrezzi[x].categoria, categoriascelta) == 0)
                {
                    found = true;
                    eleattrezzi[x] = eleattrezzi[n - 1];
                    n = n - 1;
                    x = x - 1;
                    npc = npc + 1;
                }
                x = x + 1;
            }
            if (!found)
            {
                found = false;
            }
            return found;
        }
    }
}








            