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

            do
            {
                if (contador % 2 == 0)
                {
                    Inserir(Jogador1, Matriz);
                    ImprimirJogo(Matriz);
                    acabou = VerificaStatus(Matriz, Jogador1);
                }
                else
                {
                    Inserir(Jogador2, Matriz);
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

        static void Inserir(string Jogador, string[,] Matriz)
        {
            int Linha;
            int Coluna;
            int jogador;

            if (Jogador == "X")
            {
                jogador = 1;
            }
            else
            {
                jogador = 2;
            }

            bool Ocupado = true;
            do
            {
                Console.WriteLine("Vez do " + jogador + "º jogador:");
                Console.Write("Digite a linha: ");
                Linha = int.Parse(Console.ReadLine());
                Console.Write("Digite a Coluna: ");
                Coluna = int.Parse(Console.ReadLine());

                Ocupado = VerificaPos((Linha - 1), (Coluna - 1), Matriz);

                for (int l = 0; l < Matriz.Length; l++)
                {
                    for (int c = 0; c < Matriz.Length; c++)
                    {
                        if (!Ocupado && l == Linha && c == Coluna)
                        {
                            Matriz[Linha - 1, Coluna - 1] = Jogador;
                        }
                    }
                }
            } while (Ocupado);
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
                    Console.Write("\t | " + Matriz[l, c] + " | ");
                }
                Console.WriteLine();
            }
        }
        static int VerificaStatus(string[,] Matriz, string Jogador)
        {
            int jogador;
            bool continuar = false;
            int diagonal1 = 0;
            int diagonal2 = 0;

            if (Jogador == "X")
            {
                jogador = 1;
            }
            else
            {
                jogador = 2;
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
                    return jogador;
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
                    return jogador;
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
                    return jogador;
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
                    return jogador;
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