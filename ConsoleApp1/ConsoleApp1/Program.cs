using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] Matriz = new string[3, 3];
            string Jogador1 = "X";
            string Jogador2 = "O";
            int contador = 0;
            bool situacaoJogo = true;
            int acabou;

            for (int l = 0; l < Matriz.GetLength(0); l++)
            {
                for (int c = 0; c < Matriz.GetLength(1); c++)
                {
                    Matriz[l, c] = "-";
                }
            }

            Console.Write("Digite o nome do primeiro jogador: ");
            string nome1 = Console.ReadLine();
            Console.Write("Digite o nome do segundo jogador: ");
            string nome2 = Console.ReadLine();

            do
            {
                if (contador % 2 == 0)
                {
                    Inserir(Jogador1, Matriz, nome1);
                    ImprimirJogo(Matriz);
                    acabou = VerificaStatus(Matriz, Jogador1);
                }
                else
                {
                    Inserir(Jogador2, Matriz, nome2);
                    ImprimirJogo(Matriz);
                    acabou = VerificaStatus(Matriz, Jogador1);
                }

                if (acabou == 0)
                {
                    Console.WriteLine("Empatou !");
                    situacaoJogo = false;
                }
                else if (acabou == 1)
                {
                    Console.WriteLine("Jogador 1 ganhou !");
                    situacaoJogo = false;
                }
                else if (acabou == 2)
                {
                    Console.WriteLine("Jogador 2 ganhou !");
                    situacaoJogo = false;
                }

                contador++;
            } while (situacaoJogo == true);

            Console.WriteLine("PRESS ANY KEY TO CONTINUE...");
            Console.ReadKey();
        }

        static void Inserir(string Jogador, string[,] Matriz, string nome)
        {
            int linha;
            int coluna;

            bool ocupado;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Vez do jogador " + nome);
                Console.Write("Digite a linha: ");
                linha = int.Parse(Console.ReadLine());
                Console.Write("Digite a Coluna: ");
                coluna = int.Parse(Console.ReadLine());

                ocupado = VerificaPos((linha - 1), (coluna - 1), Matriz);

                for (int l = 0; l < Matriz.GetLength(0); l++)
                {
                    for (int c = 0; c < Matriz.GetLength(1); c++)
                    {
                        if (!ocupado && l == linha && c == coluna)
                        {
                            Matriz[linha - 1, coluna - 1] = Jogador;
                        }
                    }
                }
            } while (ocupado);
        }

        static bool VerificaPos(int linha, int coluna, string[,] Matriz)
        {
            if (Matriz[linha, coluna] == "-")
            {
                return false;
            }
            else
            {
                Console.WriteLine("Posição inválidia ou ocupada !");
                Console.WriteLine();
                return true;
            }
        }

        static void ImprimirJogo(string[,] Matriz)
        {
            for (int l = 0; l < Matriz.GetLength(0); l++)
            {
                Console.WriteLine("\t");
                for (int c = 0; c < Matriz.GetLength(1); c++)
                {
                    if (c == 0)
                    {
                        Console.Write("\t  " + Matriz[l, c]);
                    }
                    else
                    {
                        Console.Write("  |  " + Matriz[l, c]);
                    }
                    
                }
                Console.WriteLine();
                if (l<2)
                {
                    Console.Write("\t-----------------");
                }
            }
        }
        static int VerificaStatus(string[,] Matriz, string Jogador)
        {
            
            bool continuar = false;
            int diagonal1 = 0;
            int diagonal2 = 0;

            int situacaoJogo;
            if (Jogador == "X")
            {
                situacaoJogo = 1;
            }
            else
            {
                situacaoJogo = 2;
            }

            //retorna ganhador coluna igual
            for (int c = 0; c < Matriz.GetLength(1); c++)
            {
                int contador = 0;
                for (int l = 0; l < Matriz.GetLength(0); l++)
                {
                    if (Matriz[l, c] == Jogador)
                    {
                        contador++;
                    }
                }
                if (contador == 3)
                {
                    return situacaoJogo;
                }
            }
            //retorna ganhador linha igual
            for (int l = 0; l < Matriz.GetLength(0); l++)
            {
                int contador = 0;
                for (int c = 0; c < Matriz.GetLength(1); c++)
                {
                    if (Matriz[l, c] == Jogador)
                    {
                        contador++;
                    }
                }
                if (contador == 3)
                {
                    return situacaoJogo;
                }
            }

            //retorna ganhador diagonal principal

            for (int l = 0; l < Matriz.GetLength(0); l++)
            {
                if (Matriz[l, l] == Jogador)
                {
                    diagonal1++;
                }

                if (diagonal1 == 3)
                {
                    return situacaoJogo;
                }
            }

            //retorna ganhador diagonal secundária
            for (int l = 0, c = Matriz.GetLength(1)-1; l < Matriz.GetLength(0); l++, c--)
            {
                if (Matriz[l, c] == Jogador)
                {
                    diagonal2++;
                }

                if (diagonal2 == 3)
                {
                    return situacaoJogo;
                }
            }

            //Verifica se há posições para continuar o jogo.
            for (int l = 0; l < Matriz.GetLength(0); l++)
            {
                for (int c = 0; c < Matriz.GetLength(1); c++)
                {
                    if (Matriz[l, c] == "-")
                    {
                        continuar = true;
                    }
                }
            }
            //retorna se o jogo irá continuar ou se empatou !
            if (!continuar)
            {
                return 0;
            }
            else
            {
                return 3;
            }
        }
    }
}