﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioNewCentury.desafios
{
    internal class SalarioVendedores
    {
        private List<int> contadores = new List<int>(new int[9]); // inicializando lista com 9 posiçoes com valores zerados

        public void ProcessarSalarios()
        {
            List<double> vendasBrutas = new List<double> { }; // inicializando lista vazia para pegar o salario bruto de todos os vendedores
            int vendas = 0;
            while (true)
            {
                Console.Clear();
                Console.Write("Digite o valor bruto das vendas dos vendedores (0 para sair): ");

                try
                {
                    vendas = int.Parse(Console.ReadLine());

                    if (vendas == 0) break; // 0 para sair do loop
                    else if (vendas < 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Digite um valor válido!");
                        Thread.Sleep(1000);
                        continue;
                    }
                    else
                    {
                        vendasBrutas.Add(vendas); // adicionando os salarios na lista
                    }

                }
                catch
                {
                    Console.Clear();
                    Console.Write("Apenas números por favor!");
                    Thread.Sleep(1000);
                    continue;
                }


            }
            foreach (double venda in vendasBrutas)
            {
                double salario = 200 + (0.09 * venda); // calculando salario
                // formula simples para retornar o indice dos intervalos de valores, sem passar do 8 (1000 ou mais)
                int indice = Math.Min((int)(salario - 200) / 100, 8); 
                contadores[indice]++;
            }
            ExibirResultados();
        }

        public void ExibirResultados()
        {
            // intervalos que vou usar para sincronizar com os indices acima
            string[] intervalos = { "$200 - $299", "$300 - $399", "$400 - $499", "$500 - $599", "$600 - $699",
                                    "$700 - $799", "$800 - $899", "$900 - $999", "$1000 ou mais" };

            Console.WriteLine("Faixa Salarial | Número de Vendedores");
            Console.WriteLine("------------------------------------");

            for (int i = 0; i < contadores.Count; i++)
            {
                Console.WriteLine($"{intervalos[i],-14} | {contadores[i], 5}");
            }
            Console.WriteLine("\n\nPressione qualquer tecla para continuar");
            Console.ReadKey();
        }

    }
}
