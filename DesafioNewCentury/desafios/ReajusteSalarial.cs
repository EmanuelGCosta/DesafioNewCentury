namespace DesafioNewCentury.desafios
{
    internal class ReajusteSalarial
    {
        public void Calcular()
        {
            // Usando List para declarar os valores limite e porcentuais 
            List<double> salarioLimite = new List<double> { 280.00, 700.00, 1500.00, double.MaxValue };
            List<double> percent = new List<double> { 0.20, 0.15, 0.10, 0.05 };

            double salario = 0;
            while (true)
            {
                Console.Write("Digite o salário atual do colaborador: ");
                if (double.TryParse(Console.ReadLine(), out salario) && salario >= 0)
                {
                    break; // Sai do loop se o salário for válido
                }

                Console.Clear();
                Console.WriteLine("Apenas números positivos, por favor!");
                Thread.Sleep(1000);
                Console.Clear();
            }

            // Encontrando o índice
            int indicePercent = salarioLimite.FindIndex(limite => salario <= limite);
            double percentual = percent[indicePercent];

            // Calculando salário com aumento
            double aumento = salario * percentual;
            double novoSalario = salario + aumento;

            // Exibindo resultados
            Console.WriteLine("\n\n\n--------- Resultado ---------");
            Console.WriteLine($"Salário antes do reajuste: R$ {salario:F2}");
            Console.WriteLine($"Percentual do aumento: {percentual * 100}%");
            Console.WriteLine($"Valor do aumento: R$ {aumento:F2}");
            Console.WriteLine($"Novo salário: R$ {novoSalario:F2}");
            Console.WriteLine("------------------------------\n\n\n");
            Console.WriteLine("Pressione qualquer tecla para continuar");
            Console.ReadKey();
        }
    }
}