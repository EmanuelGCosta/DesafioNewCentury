namespace DesafioNewCentury.desafios
{
    internal class Mercado
    {
        public void ProcessarVenda()
        {
            // declarando carnes em um array e precos em uma matriz bidimensional
            string[] carnes = { "File Duplo", "Alcatra", "Picanha" };
            double[,] precos = { { 4.90, 5.80 }, { 5.90, 6.80 }, { 6.90, 7.80 } };

            int opcao = 0;
            while (true)
            {
                Console.WriteLine("1 - Filé Duplo\n2 - Alcatra\n3 - Picanha");
                Console.Write("Escolha o tipo de carne: ");

                
                try
                {
                    opcao = int.Parse(Console.ReadLine()) - 1;
                    if (opcao < 0 || opcao > 2)
                    {
                        Console.Clear();
                        Console.WriteLine("Opção inválida!");
                        Thread.Sleep(1000);
                        Console.Clear();
                        continue;
                    }
                    break;
                }
                catch
                {
                    Console.Clear();
                    Console.Write("Apenas número!");
                    Thread.Sleep(1000);
                    Console.Clear();
                }
            }

            double quantidade = 0;
            // pegando quantidade em kg
            while (true)
            {
                // repetindo while pois são só dois, se fosse vários com certeza faria uma funçao para tratar as entradas
                Console.Write("Digite a quantidade (kg): ");
                try
                {
                    quantidade = double.Parse(Console.ReadLine());
                    if (quantidade < 0)
                    {
                        Console.WriteLine("Apenas número positivo!");
                        Thread.Sleep(1000);
                        Console.Clear();
                        continue;
                    }
                    break;
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("Apenas números!");
                    Thread.Sleep(1000);
                    Console.Clear();
                    continue;
                }
            }


            // definindo qual sera o preco final da carne
            double precoKg = quantidade <= 5 ? precos[opcao, 0] : precos[opcao, 1];

            // aplicando preco total
            double total = quantidade * precoKg;

            Console.Write("Pagamento com Cartão Tabajara? (S/N): ");
            bool cartaoTabajara = Console.ReadLine().Trim().ToUpper() == "S";

            // aplicando desconto caso o usuario use o cartao tabajara
            double desconto = cartaoTabajara ? total * 0.05 : 0;
            double valorFinal = total - desconto;

            // cupom fiscal
            Console.WriteLine("\n------ CUPOM FISCAL ------");
            Console.WriteLine($"Tipo de carne: {carnes[opcao]}");
            Console.WriteLine($"Quantidade: {quantidade} kg");
            Console.WriteLine($"Preço por kg: R$ {precoKg:F2}");
            Console.WriteLine($"Preço total: R$ {total:F2}");
            Console.WriteLine($"Tipo de pagamento: {(cartaoTabajara ? "Cartão Tabajara" : "Outro")}");
            Console.WriteLine($"Desconto: R$ {desconto:F2}");
            Console.WriteLine($"Valor a pagar: R$ {valorFinal:F2}");
            Console.WriteLine("\n\nPressione qualquer tecla para continuar");
            Console.ReadKey();
        }
    }
}
