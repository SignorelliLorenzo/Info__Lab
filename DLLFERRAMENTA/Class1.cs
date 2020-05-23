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
                    found = true;
                    eleattrezzi[x] = eleattrezzi[n - 1];
                    n = n - 1;
                }
                x = x + 1;
            }
            if (!found)
            {
                found = false;
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
        public static attrezzo prezzominimocategoria(attrezzo[] eleattrezzi, int n, string catecercata)
        {
            int x = default(int);
            decimal prezzomin = default(decimal);
            attrezzo attrezzomin = default(attrezzo);

            while (x < n)
            {
                if (string.Compare(catecercata, eleattrezzi[x].categoria) == 0)
                {
                    prezzomin = eleattrezzi[x].prezzo;
                    attrezzomin = eleattrezzi[x];
                    break;
                }
                x = x + 1;
            }

            while (x < n)
            {
                if (string.Compare(catecercata, eleattrezzi[x].categoria) == 0)
                {

                    if (eleattrezzi[x].prezzo < prezzomin)
                    {
                        prezzomin = eleattrezzi[x].prezzo;
                        attrezzomin = eleattrezzi[x];
                    }

                }
                x = x + 1;
            }
            return attrezzomin;
        }
        public static attrezzo prezzomassimocategoria(attrezzo[] eleattrezzi, int n, string catecercata)
        {
            int x = default(int);
            decimal prezzomax = default(decimal);
            attrezzo attrezzomax = default(attrezzo);

            while (x < n)
            {
                if (string.Compare(catecercata, eleattrezzi[x].categoria) == 0)
                {
                    prezzomax = eleattrezzi[x].prezzo;
                    attrezzomax = eleattrezzi[x];
                    break;
                }
                x = x + 1;
            }

            while (x < n)
            {
                if (string.Compare(catecercata, eleattrezzi[x].categoria) == 0)
                {

                    if (eleattrezzi[x].prezzo > prezzomax)
                    {
                        prezzomax = eleattrezzi[x].prezzo;
                        attrezzomax = eleattrezzi[x];
                    }

                }
                x = x + 1;
            }
            return attrezzomax;
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

        public static void ordinacodice(attrezzo[] eleattrezzi, int n)
        {
            attrezzo temporaneo = default(attrezzo);
            int x = default(int);
            int y = default(int);

            while (x < n)
            {
                y = x + 1;

                while (y < n)
                {
                    if (string.Compare(eleattrezzi[x].codice, eleattrezzi[y].codice) > 0)
                    {
                        temporaneo = eleattrezzi[x];
                        eleattrezzi[x] = eleattrezzi[y];
                        eleattrezzi[y] = temporaneo;
                    }
                    y = y + 1;
                }
                x = x + 1;
            }
        }

        public static void ordinaprezzo(attrezzo[] eleattrezzi, int n)
        {
            attrezzo temporaneo = default(attrezzo);
            int x = default(int);
            int y = default(int);

            while (x < n)
            {
                y = x + 1;

                while (y < n)
                {
                    if (eleattrezzi[x].prezzo > eleattrezzi[y].prezzo)
                    {
                        temporaneo = eleattrezzi[x];
                        eleattrezzi[x] = eleattrezzi[y];
                        eleattrezzi[y] = temporaneo;
                    }
                    y = y + 1;
                }
                x = x + 1;
            }
        }
        public static void ordinadata(attrezzo[] eleattrezzi, int n)
        {
            attrezzo temporaneo = default(attrezzo);
            int x = default(int);
            int y = default(int);

            while (x < n)
            {
                y = x + 1;

                while (y < n)
                {
                    if (eleattrezzi[x].data > eleattrezzi[y].data)
                    {
                        temporaneo = eleattrezzi[x];
                        eleattrezzi[x] = eleattrezzi[y];
                        eleattrezzi[y] = temporaneo;
                    }
                    y = y + 1;
                }
                x = x + 1;
            }
        }
    }
}








            