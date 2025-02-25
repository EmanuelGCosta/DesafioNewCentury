using DesafioNewCentury.desafios;

class Program
{
    static void Main()
    {
        void ExibirBoasVindas(bool error)
        {
            if (error)
            {
                Console.Clear();
                Console.WriteLine("Apenas números de 1 a 4, por favor!");
                Thread.Sleep(1500);
            }
            Console.Clear();
            Console.WriteLine("-----Desafio New Century----- ");
            Console.WriteLine("1 - Reajuste Salárial");
            Console.WriteLine("2 - Resultado da Enquete");
            Console.WriteLine("3 - Processar Salário dos Vendedores");
            Console.WriteLine("4 - Promoção Mercado");
            Console.WriteLine("0 - Sair");
            Console.Write("Digite o número desejado: ");
        }
        bool error = false;
        int result = 0;
        while (true)
        {
            ExibirBoasVindas(error);
            error = false;

            string input = Console.ReadLine();
            if (!int.TryParse(input, out result))
            {
                error = true;
                continue;
            }

            if (result == 0) break;
            if (result < 1 || result > 4)
            {
                error = true;
                continue;
            }

            Console.Clear();
            switch (result)
            {
                case 1:
                    ReajusteSalarial reajusteSalarial = new ReajusteSalarial();
                    reajusteSalarial.Calcular();
                    break;

                case 2:
                    ResultadoEnquete resultadoEnquete = new ResultadoEnquete();
                    resultadoEnquete.ColetarVotos();
                    break;

                case 3:
                    SalarioVendedores salarioVendedores = new SalarioVendedores();
                    salarioVendedores.ProcessarSalarios();
                    break;

                case 4:
                    Mercado mercado = new Mercado();
                    mercado.ProcessarVenda();
                    break;
            }
        }
    }
}
