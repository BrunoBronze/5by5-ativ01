using System;

namespace Exercice_Class2
{
    class Program
    {
        static void Main(string[] args)
        {
            string op;
            Cliente cliente = new Cliente();
            cliente.conta = new Conta();

            Cliente felipe = new Cliente
            {
                Nome = "Felipe",
                CPF = 12345678910,
                Endereco = "Rua Humaitá, 1844",
                conta = new Conta
                {
                    Agencia = 1122,
                    Numero = 1,
                    Saldo = 0
                }
            };

            do
            {
                Console.WriteLine("###### MENU #####\n" +
                                  "1 - Criar conta\n" +
                                  "2 - Depósito\n" +
                                  "3 - Saque\n" +
                                  "4 - Transferência bancária\n" +
                                  "5 - Saldo\n" +
                                  "6 - Terminar programa\n");

                op = Console.ReadLine();

                if (cliente.CPF == 0 && op !="1" && op != "6")
                {
                    Console.WriteLine("Crie uma conta primeiro");
                }
                else
                {
                    switch (op)
                    {
                        case "1":
                            Console.Write("\nDigite seu Nome: ");
                            cliente.Nome = Console.ReadLine();

                            Console.Write("Digite seu CPF: ");
                            cliente.CPF = long.Parse(Console.ReadLine());

                            Console.Write("Digite seu endereço: ");
                            cliente.Endereco = Console.ReadLine();

                            Console.Write("Digite sua agencia: ");
                            cliente.conta.Agencia = int.Parse(Console.ReadLine());

                            Console.Write("Digite o numero da sua conta: ");
                            cliente.conta.Numero = int.Parse(Console.ReadLine());
                            Console.WriteLine();
                            break;

                        case "2":
                            Console.Write("\nDigite o valor do deposito: ");
                            double valor = double.Parse(Console.ReadLine());
                            bool depositou = cliente.conta.Deposito(valor);

                            if (depositou)
                            {
                                System.Console.WriteLine($"R$ {valor:F2} foi depositado !\n");
                            }
                            break;

                        case "3":
                            bool sacou;
                            Console.Write("\nDigite o valor do saque: ");
                            valor = double.Parse(Console.ReadLine());
                            sacou = cliente.conta.Saque(valor);

                            if (sacou)
                            {
                                System.Console.WriteLine($"R$ {valor:F2} foram sacados !\n" +
                                                         $"Saldo: R${cliente:F2}\n");
                            }
                            break;

                        case "4":
                            Console.Write("Digite o numero da conta que deseja transferir: ");
                            int numero = int.Parse(Console.ReadLine());

                            cliente.conta.Transferencia(felipe, numero);

                            break;

                        case "5":
                            Console.WriteLine($"Saldo: R$ {cliente.conta.Saldo:F2}");
                            break;

                        case "6":
                            Console.WriteLine("\n##### FINALIZANDO #####");
                            break;

                        default:
                            break;
                    }
                }
            } while (op != "6");

            Console.Write("PRESS ANY KEY TO CONTINUE...");
            Console.ReadKey();
        }
    }
}
