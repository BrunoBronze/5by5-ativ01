using System;

namespace JogoVelha2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] matriz = new string[3, 3];
            int jogada = 1;
            int jogador;
            int status;
            int linha = 0;
            int coluna = 0;
            bool selecionaJogador = true;
            bool ganhador = false;
            bool disponivel;

            for (int l = 0; l < matriz.GetLength(0); l++)
            {
                for (int c = 0; c < matriz.GetLength(1); c++)
                {
                    matriz[l, c] = " ";
                }
            }

            Console.WriteLine("########## Jogo da Velha ##########");

            ImprimirPosicoes(matriz);

            while (!ganhador)
            {
                if (selecionaJogador == true)
                {
                    jogador = 1;
                }
                else
                {
                    jogador = 2;
                }

                LerPosicao(ref linha, ref coluna, jogador);
                disponivel = PosicaoDisponivel(matriz, linha, coluna);

                if (disponivel)
                {
                    //insere jogada !
                    if (jogador == 1)
                    {
                        matriz[linha, coluna] = "X";
                    }
                    else
                    {
                        matriz[linha, coluna] = "O";
                    }

                    Console.Clear();
                    ImprimirPosicoes(matriz);
                    if (jogada > 4)
                    {
                        status = VerificaStatus(matriz, jogada, jogador);

                        if (status == 0)
                        {
                            Console.WriteLine("\nDeu velha!");
                            ganhador = true;
                        }
                        else if (status == 1)
                        {
                            Console.WriteLine("\njogador 1 ganhou !");
                            ganhador = true;
                        }
                        else if (status == 2)
                        {
                            Console.WriteLine("\njogador 2 ganhou !");
                            ganhador = true;
                        }
                    }
                    selecionaJogador = !selecionaJogador;
                    jogada++;
                }
            }

            Console.Write("PRESS ANY KEY TO CONTINUE...");
            Console.ReadKey();
        }

        static void ImprimirPosicoes(string[,] matriz)
        {
            for (int l = 0; l < matriz.GetLength(0); l++)
            {
                Console.WriteLine();
                for (int c = 0; c < matriz.GetLength(1); c++)
                {
                    if (c == 0)
                    {
                        Console.Write("\t   " + matriz[l, c]);
                    }
                    else
                    {
                        Console.Write("  |  " + matriz[l, c]);
                    }
                }
                Console.WriteLine();
                if (l < 2)
                {
                    Console.Write("\t-------------------");
                }
            }
            return;
        }

        static void LerPosicao(ref int linha, ref int coluna, int jogador)
        {
            string l;
            string c;
            bool correto = false;

            Console.WriteLine();

            Console.WriteLine("Vez do jogador " + jogador);
            do
            {
                Console.Write("Digite a linha: ");
                l = Console.ReadLine();

                if (int.TryParse(l, out linha))
                {
                    if (linha > 0 && linha < 4)
                    {
                        linha -= 1;
                        correto = true;
                    }
                    else
                    {
                        Console.WriteLine("Digite um número entre 1 e 3");
                    }
                }
                else
                {
                    Console.WriteLine("Digite apenas números inteiros entre 1 e 3");
                }
            } while (!correto);

            correto = false;

            do
            {
                Console.Write("Digite a coluna: ");
                c = Console.ReadLine();

                if (int.TryParse(c, out coluna))
                {
                    if (coluna > 0 && coluna < 4)
                    {
                        coluna -= 1;
                        correto = true;
                    }
                    else
                    {
                        Console.WriteLine("Digite um número entre 1 e 3");
                    }
                }
                else
                {
                    Console.WriteLine("Digite apenas um número inteiro entre 1 e 3");
                }
            } while (!correto);
        }

        static bool PosicaoDisponivel(string[,] matriz, int linha, int coluna)
        {
            if (matriz[linha, coluna] == " ")
            {
                return true;
            }
            else
            {
                Console.WriteLine("\nPosição indisponível !");
                return false;
            }
        }

        static int VerificaStatus(string[,] matriz, int jogada, int jogador)
        {
            int diagonal1 = 0;
            int diagonal2 = 0;

            //verificar linhas
            for (int l = 0; l < matriz.GetLength(0); l++)
            {
                int contador = 0;
                for (int c = 0; c < matriz.GetLength(1) - 1; c++)
                {
                    if (matriz[l, c] != " " && matriz[l, c] == matriz[l, c + 1])
                    {
                        contador++;
                    }
                }
                if (contador == 2)
                {
                    return jogador;
                }
            }

            //verifica colunas
            for (int c = 0; c < matriz.GetLength(1); c++)
            {
                int contador = 0;
                for (int l = 0; l < matriz.GetLength(0) - 1; l++)
                {
                    if (matriz[l, c] != " " && matriz[l, c] == matriz[l + 1, c])
                    {
                        contador++;
                    }

                }
                if (contador == 2)
                {
                    return jogador;
                }
            }

            //verifica diagonal principal
            for (int l = 0; l < matriz.GetLength(0) - 1; l++)
            {
                if (matriz[l, l] != " " && matriz[l, l] == matriz[l + 1, l + 1])
                {
                    diagonal1++;
                }
            }
            if (diagonal1 == 2)
            {
                return jogador;
            }

            //verifica diagonal secundária
            for (int l = 0, c = matriz.GetLength(1) - 1; l < matriz.GetLength(0) - 1; l++, c--)
            {
                if (matriz[l, c] != " " && matriz[l, c] == matriz[l + 1, c - 1])
                {
                    diagonal2++;
                }
            }
            if (diagonal2 == 2)
            {
                return jogador;
            }

            //verifica empate ou se irá continuar
            if (jogada == 9)
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

//fazer as funções retornarem na main e depois chamar outro método se necessário
//funções/métodos deve ter apenas uma responsabilidade, sem chamar outros métodos.
//CUIDADO TRY CATCH, consome muito recurso !
//
//
//####################################################################################
//
//                                O que é um Framework?
//
//conjunto de métodos armazenadas em um pacote para ajudar em uma determinada situação.