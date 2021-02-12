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
                }
                else
                {
                    Inserir(Jogador2, Matriz);
                }

                ImprimirJogo(Matriz);

                contador++;
            } while (situacaoJogo == true);

            Console.WriteLine("PRESS ANY KEY TO CONTINUE...");
            Console.ReadKey();
        }

        static void Inserir(string jogador, string[,] Matriz)
        {
            int[] vet = new int[2];

            /*
            String [] resp = new string [2];
            Console.Write("Digite a linha e a coluna: " + (resp[0] = Console.ReadLine()) + ", " + (resp[1] = Console.ReadLine()));
            vet[0] = int.Parse(resp[0]);
            vet[1] = int.Parse(resp[1]);*/

            int Linha;
            int Coluna;

            bool Ocupado = true;
            do
            {
                Console.Write("Digite a linha: ");
                Linha = int.Parse(Console.ReadLine());
                Console.Write("Digite a Coluna: ");
                Coluna = int.Parse(Console.ReadLine());

                Ocupado = VerificaPos((Linha - 1), (Coluna - 1), Matriz);
                
                for (int l = 0; l < Matriz.Length; l++)
                {
                    for (int c = 0; c < Matriz.Length; c++)
                    {
                        if (!Ocupado && l == vet[0] && c == vet[1])
                        {
                            Matriz[Linha - 1, Coluna - 1] = jogador;
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
        static void VerificaStatus(string [,] Matriz)
        {

        }
    }
}

/*	•Variaveis
        1.string[3, 3] Matriz;
        2.int Jogador1, Jogador2;
            2.1.int Linha, Coluna;
        3.bool situacaoJogo = true;
    •Função ImprimirJogo()
    {
        
    }    
    •Função bool VerificaPos()
    {
        if(Pos=="Null")
        return true;
        else
        return false;
    }
    •Função int VerificaStatus(string [,]Matriz)
    {
        return {0,1,2};
    }
*/