using System;

namespace Exercice_Class1
{
    internal class Proprietario
    {
        public long CPF { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataCompra { get; set; }
        public Veiculo veiculo { get; set; }

        public Proprietario()
        {
            Nome = "NOME";
            Endereco = "ENDEREÇO";
        }

        public override string ToString()
        {
            return ($"CPF: {CPF:D11},\n" +
                    $"Nome: {Nome}, \n" +
                    $"Endereco: {Endereco}, \n" +
                    $"Data de nascimento: {DataNascimento.ToString("dd/MM/yyyy")}, \n" +
                    $"Data da compra: {DataCompra.ToString("MM/yyyy")} \n\n" +
                    $"Veiculo:\n{veiculo}");
        }
    }
}