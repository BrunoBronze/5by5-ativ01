
namespace Exercice_Class2
{
    class Conta
    {
        public int Agencia { get; set; }

        public int Numero { get; set; }

        public double Saldo { get; set; }

        public bool Deposito(double valor)
        {
            Saldo += valor;
            return true;
        }

        public bool Saque(double valor)
        {
            bool repetir;
            do
            {
                if (valor <= Saldo)
                {
                    Saldo -= valor;
                    return true;
                }
                else
                {
                    System.Console.WriteLine("Saldo insuficiente !!");
                    System.Console.Write("Deseja tenta novamente(S/N)? ");
                    string resp = System.Console.ReadLine().ToUpper();
                    if (resp == "S")
                    {
                        System.Console.Write("Digite o novo valor para tentar novamente: R$");
                        valor = double.Parse(System.Console.ReadLine());
                        repetir = true;
                    }
                    else
                    {
                        System.Console.WriteLine("##### Cancelando a operação ######\n");
                        repetir = false;
                    }
                }
            } while (repetir);

            return false;
        }

        public void Transferencia(Cliente cliente, int numero)
        {
            if (numero == cliente.conta.Numero)
            {
                System.Console.Write("\nDigite o valor que deseja transferir: ");
                double valor = double.Parse(System.Console.ReadLine());
                bool sacou = Saque(valor);
                if (sacou)
                {
                    cliente.conta.Deposito(valor);
                    System.Console.WriteLine("Deposito realizado !\n" +
                                             $"Saldo: {Saldo}");
                }
            }
            else
            {
                System.Console.WriteLine("Conta não encontrada !");
            }
        }
    }
}
