namespace DesafioNewCentury.desafios
{
    internal class ReajusteSalarial
    {
        public void calcular()
        {
            // Usando List para declarar os valores limite e porcentuais 
            List<double> salarioLimite = new List<double> { 280.00, 700.00, 1500.00, double.MaxValue };
            List<double> percent = new List<double> { 0.20, 0.15, 0.10, 0.05 };

            double salario = 0;
            while(true)
            {
                Console.Write("Digite o salário atual do colaborador: ");
                try
                {
                    salario = double.Parse(Console.ReadLine());
                    if(salario < 0 )
                    {
                        Console.Clear();
                        Console.Write("Apenas número positivo!");
                        Thread.Sleep(1000);
                        Console.Clear();
                        continue;
                    }
                    break;
                }
                catch
                {
                    Console.Clear();
                    Console.Write("Apenas números por favor!");
                    Thread.Sleep(1000);
                    Console.Clear();
                    continue;
                }
            }

            

            // encontrando o indice
            int indicePercent = salarioLimite.FindIndex(limite => salario <= limite);
            double percentual = percent[indicePercent];

            // calculando salario com aumento
            double aumento = salario * percentual;
            double novoSalario = salario + aumento;


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
