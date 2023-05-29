using System;

namespace ProjetVictor_2048
{
    class Program
    {
        static void Main(string[] args)
        {
            bool recommencer = true;
            int[,] matrice = new int[4, 4];
            while (recommencer)
            {
                Matrice(matrice);
                Console.WriteLine("Entrez la direction (z, q, s, d): ");
                char direction = Console.ReadKey().KeyChar;
                BougerNombre(matrice, direction);
                AdditionnerNombre(matrice, direction);
            }

        }

        static void Matrice(int[,] matrice)
        {
            Random random = new Random();
            int nombreAleatoire = random.Next(0, 2) == 0 ? 2 : 4;
            int ligneAleatoire, colonneAleatoire;

            do
            {
                ligneAleatoire = random.Next(0, 4);
                colonneAleatoire = random.Next(0, 4);
            }
            while (matrice[ligneAleatoire, colonneAleatoire] != 0);

            matrice[ligneAleatoire, colonneAleatoire] = nombreAleatoire;
            Console.Clear();
            Console.WriteLine("Matrice :");
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (matrice[i, j] == TrouverMax(matrice))
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    else if (matrice[i, j] != 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.ResetColor();
                    }
                    Console.Write(String.Format("{0,4}", matrice[i, j]) + "");
                }
                Console.WriteLine();
            }
            Console.ResetColor();
        }

        static int TrouverMax(int[,] matrice)
        {
            int max = matrice[0, 0];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (matrice[i, j] > max)
                    {
                        max = matrice[i, j];
                    }
                }
            }
            return max;
        }

        static void BougerNombre(int[,] matrice, char direction)
        {
            {
                if (direction == 'q')
                {
                    for (int i = 0; i < 4; i++)
                    {
                        int k = 0;
                        for (int j = 0; j < 4; j++)
                        {
                            if (matrice[i, j] != 0)
                            {
                                matrice[i, k] = matrice[i, j];
                                if (j != k)
                                {
                                    matrice[i, j] = 0;
                                }
                                k++;
                            }
                        }
                    }
                }
                else if (direction == 'd')
                {
                    for (int i = 0; i < 4; i++)
                    {
                        int k = 3;
                        for (int j = 3; j >= 0; j--)
                        {
                            if (matrice[i, j] != 0)
                            {
                                matrice[i, k] = matrice[i, j];
                                if (j != k)
                                {
                                    matrice[i, j] = 0;
                                }
                                k--;
                            }
                        }
                    }
                }
                else if (direction == 'z')
                {
                    for (int j = 0; j < 4; j++)
                    {
                        int k = 0;
                        for (int i = 0; i < 4; i++)
                        {
                            if (matrice[i, j] != 0)
                            {
                                matrice[k, j] = matrice[i, j];
                                if (i != k)
                                {
                                    matrice[i, j] = 0;
                                }
                                k++;
                            }
                        }
                    }
                }
                else if (direction == 's')
                {
                    for (int j = 0; j < 4; j++)
                    {
                        int k = 3;
                        for (int i = 3; i >= 0; i--)
                        {
                            if (matrice[i, j] != 0)
                            {
                                matrice[k, j] = matrice[i, j];
                                if (i != k)
                                {
                                    matrice[i, j] = 0;
                                }
                                k--;
                            }
                        }
                    }
                }
            }
        }

        static void AdditionnerNombre(int[,] matrice, char direction)
        {
            if (direction == 'q')
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (matrice[i, j] == matrice[i, j + 1])
                        {
                            matrice[i, j] *= 2;
                            matrice[i, j + 1] = 0;
                        }
                    }
                }
            }
            else if (direction == 'd')
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 3; j > 0; j--)
                    {
                        if (matrice[i, j] == matrice[i, j - 1])
                        {
                            matrice[i, j] *= 2;
                            matrice[i, j - 1] = 0;
                        }
                    }
                }
            }
            else if (direction == 'z')
            {
                for (int j = 0; j < 4; j++)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (matrice[i, j] == matrice[i + 1, j])
                        {
                            matrice[i, j] *= 2;
                            matrice[i + 1, j] = 0;
                        }
                    }
                }
            }
            else if (direction == 's')
            {
                for (int j = 0; j < 4; j++)
                {
                    for (int i = 3; i > 0; i--)
                    {
                        if (matrice[i, j] == matrice[i - 1, j])
                        {
                            matrice[i, j] *= 2;
                            matrice[i - 1, j] = 0;
                        }
                    }
                }
            }
        }
    }
}


