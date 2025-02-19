namespace DesafioNewCentury.desafios
{
    internal class ResultadoEnquete
    {
        Dictionary<int, int> votos = new Dictionary<int, int>
        {
            {1, 0},
            {2, 0},
            {3, 0},
            {4, 0},
            {5, 0},
            {6, 0},
        };

        string[] sistemas = { "", "Windows Server", "Unix", "Linux", "Netware", "Mac OS", "Outro" };

        public void ExibirOpcoes(bool error)
        {
            if (error)
            {
                Console.Clear();
                Console.Write("Opção inválida! Digite um número entre 1 e 6: ");
                Thread.Sleep(1500);
            }
            Console.Clear();
            Console.WriteLine("Qual o melhor Sistema Operacional para uso em servidores?");
            for (int i = 1; i < sistemas.Length; i++)
            {
                Console.WriteLine($"{i} - {sistemas[i]}");
            }
            Console.Write("Digite os votos (0 para encerrar): ");
        }

        public void ColetarVotos()
        {
            bool error = false;
            int voto = 0;
            while (true)
            {
                ExibirOpcoes(error);
                error = false;

                try
                {
                    voto = int.Parse(Console.ReadLine());

                    if (voto == 0) break; // encerra while
                    if (voto < 1 || voto > 6)
                    {
                        error = true;
                        continue;
                    }
                }
                catch
                {
                    error = true;
                    continue;
                }

                votos[voto]++; // aumenta valor da chave escolhida
            }
            ExibirResultado();
        }

        public void ExibirResultado()
        {
            int totalVotos = 0;
            for (int i = 1; i <= sistemas.Length-1; i++) totalVotos += votos[i];

            if (totalVotos == 0)
            {   
                Console.Clear();
                Console.WriteLine("Nenhum voto foi registrado.");
                Console.WriteLine("\n\nPressione qualquer tecla para continuar");
                Console.ReadKey();
                return;
            }

            Console.Clear() ;
            Console.WriteLine("\nSistema Operacional | Votos | %");
            Console.WriteLine("----------------------------------");

            int maisVotado = 1;
            for (int i = 1; i <= 6; i++)
            {
                // pegando porcentual de votos
                double percentual = votos[i] / (double)totalVotos * 100;
                Console.WriteLine($"{sistemas[i],-19} | {votos[i], -5} | {percentual:F2}%");

                if (votos[i] > votos[maisVotado])
                    maisVotado = i;
            }

            Console.WriteLine("----------------------------------");
            Console.WriteLine($"Total {totalVotos}");

            double percentualVencedor = votos[maisVotado] / (double)totalVotos * 100;
            Console.WriteLine($"\nSistema Operacional com mais votos: {sistemas[maisVotado]}\nVotos: {votos[maisVotado]} \nPercentual: {percentualVencedor:F2}%");
            Console.WriteLine("\n\nPressione qualquer tecla para continuar");
            Console.ReadKey();
        }
        
    }
}

