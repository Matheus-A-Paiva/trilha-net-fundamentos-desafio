using System.Globalization;
namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public bool AdicionarVeiculo(string veiculo)
        {

            if (veiculo.Length == 8)
            {
                if (!veiculos.Contains(veiculo))
                {
                    veiculos.Add(veiculo);
                    Console.WriteLine("Veículo adicionado!");
                    return true;
                }
                else
                {
                    Console.WriteLine("Placa de veículo já existente.");
                    return false;
                }
                
            }
            else
            {
                Console.WriteLine("Padrão de placa inválida. Digite uma placa de veículo válida (Ex: XYZ-1234).");
                return false;
            }
        }

        public bool RemoverVeiculo(string placa)
        {
            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                int horas = Convert.ToInt32(Console.ReadLine());
                decimal valorTotal = (precoPorHora * horas) + precoInicial;

                veiculos.Remove(placa);

                Console.WriteLine($"O veículo {placa.ToUpper()} foi removido em {DateTime.Now} e o preço total foi de: {valorTotal.ToString("C")}");
                return true;
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
                return false;
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                // TODO: Realizar um laço de repetição, exibindo os veículos estacionados
                // *IMPLEMENTE AQUI*
                foreach (string item in veiculos)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
