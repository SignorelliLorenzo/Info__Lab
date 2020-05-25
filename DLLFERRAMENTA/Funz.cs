using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Info_Lab
{
    class Funz
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

            public static void ordinacategoria(attrezzo[] eleattrezzi, int n)
            {
                attrezzo temporaneo = default(attrezzo);
                int x = default(int);
                int y = default(int);

                while (x < n)
                {
                    y = x + 1;

                    while (y < n)
                    {
                        if (string.Compare(eleattrezzi[x].categoria, eleattrezzi[y].categoria) > 0)
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
            public static void ordinaquantità(attrezzo[] eleattrezzi, int n)
            {
                attrezzo temporaneo = default(attrezzo);
                int x = default(int);
                int y = default(int);

                while (x < n)
                {
                    y = x + 1;

                    while (y < n)
                    {
                        if (eleattrezzi[x].quantità > eleattrezzi[y].quantità)
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

            public static bool cancellacodice(attrezzo[] eleattrezzi, ref int n, string codicescelto, int quantità)
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
        }
    }
}

