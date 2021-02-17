using System;
using System.Globalization;

namespace Exercice_Class1
{
    class Program
    {
        static void Main(string[] args)
        {
            Proprietario proprietario = new Proprietario();
            proprietario.veiculo = new Veiculo();

            string op;

            do
            {
                Console.WriteLine("##### MENU #####\n" +
                                  "1 - Cadastre um veiculo\n" +
                                  "2 - Imprimir dados\n" +
                                  "3 - Terminar o programa\n");

                Console.Write("Escolha: ");
                op = Console.ReadLine();
                switch (op)
                {
                    case "1":
                        Console.Clear();
                        //VEICULO (RENAVAN, CHASSIS, PLACA, MARCA, MODELO, COR , ANO)
                        Console.Write("\nDigite o número do RENAVAM: ");
                        proprietario.veiculo.Renavam = long.Parse(Console.ReadLine());

                        Console.Write("Digite o chassi: ");
                        proprietario.veiculo.Chassi = Console.ReadLine();

                        Console.Write("Digite a placa: ");
                        proprietario.veiculo.Placa = Console.ReadLine();

                        Console.Write("Digite a marca: ");
                        proprietario.veiculo.Marca = Console.ReadLine();

                        Console.Write("Digite o modelo: ");
                        proprietario.veiculo.Modelo = Console.ReadLine();

                        Console.Write("Digite a cor: ");
                        proprietario.veiculo.Cor = Console.ReadLine();

                        Console.Write("Digite o ano: ");
                        proprietario.veiculo.Ano = DateTime.ParseExact(Console.ReadLine(), "yyyy", CultureInfo.InvariantCulture);

                        //PROPRIETARIO(CPF, NOME, ENDEREÇO, DATA NASCIMENTO, DATA_COMPRA)

                        Console.Write("\nDigite seu CPF: ");
                        proprietario.CPF = long.Parse(Console.ReadLine());

                        Console.Write("Digite seu nome: ");
                        proprietario.Nome = Console.ReadLine();

                        Console.Write("Digite seu endereço: ");
                        proprietario.Endereco = Console.ReadLine();

                        Console.Write("Digite a data de nascimento: ");
                        proprietario.DataNascimento = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

                        Console.Write("Digite a data da compra: ");
                        proprietario.DataCompra = DateTime.ParseExact(Console.ReadLine(), "MM/yyyy", CultureInfo.InvariantCulture);

                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("\n"+proprietario);
                        break;
                    case "3":
                        Console.WriteLine("\n##### FINALIZANDO #####");
                        break;
                    default:
                        break;
                }

                

            } while (op != "3");

            Console.Write("PRESS ANY KEY TO CONTINUE...");
            Console.ReadKey();
        }
    }
}
