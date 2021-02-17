using System;

namespace Exercice_Class1
{
    internal class Veiculo
    {
        public long Renavam { get; set; }
        public string Chassi { get; set; }
        public string Placa { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Cor { get; set; }
        public DateTime Ano { get; set; }

        public Veiculo()
        {
            Chassi = "CHASSI";
            Placa = "PLACA";
            Marca = "MARCA";
            Modelo = "MODELO";
            Cor = "COR";
        }

        public override string ToString()
        {
            return ($"Renavan: {Renavam:D12},\n" +
                    $"Chassi: {Chassi}, \n" +
                    $"Placa: {Placa}, \n" +
                    $"Marca: {Marca}, \n" +
                    $"Modelo: {Modelo}, \n" +
                    $"Cor: {Cor}, \n" +
                    $"Ano: {Ano.ToString("yyyy")} \n"); 
        }
    }
}