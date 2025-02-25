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

                if (int.TryParse(Console.ReadLine(), out opcao))
                {
                    opcao -= 1; // Ajustando para índice do array
                    if (opcao >= 0 && opcao <= 2)
                    {
                        break; // Opção válida
                    }
                }

                Console.Clear();
                Console.WriteLine("Opção inválida!");
                Thread.Sleep(1000);
                Console.Clear();
            }

            double quantidade = 0;
            // pegando quantidade em kg
            while (true)
            {
                Console.Write("Digite a quantidade (kg): ");
                if (double.TryParse(Console.ReadLine(), out quantidade) && quantidade >= 0)
                {
                    break; // Quantidade válida
                }

                Console.Clear();
                Console.WriteLine("Apenas números positivos!");
                Thread.Sleep(1000);
                Console.Clear();
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