﻿

class Program
{
	static void Main()
	{
		while (true)
		{
			Console.Clear();
			Console.WriteLine("=== MENU ===");
			Console.WriteLine("1 - Somatório (Questão 1)");
			Console.WriteLine("2 - Fibonacci (Questão 2)");
			Console.WriteLine("3 - Análise de Faturamento (Questão 3)");
			Console.WriteLine("4 - Percentual por Estado (Questão 4)");
			Console.WriteLine("5 - Inverter String (Questão 5)");
			Console.WriteLine("0 - Sair");
			Console.Write("Escolha uma opção: ");

			string opcao = Console.ReadLine();

			switch (opcao)
			{
				case "1":
					Questao1();
					break;
				case "2":
					Questao2();
					break;
				case "3":
					Questao3();
					break;
				case "4":
					Questao4();
					break;
				case "5":
					Questao5();
					break;
				case "0":
					Console.WriteLine("Saindo...");
					return;
				default:
					Console.WriteLine("Opção inválida! Pressione qualquer tecla para tentar novamente.");
					Console.ReadKey();
					break;
			}
		}
	}

	static void Questao1()
	{
		Console.Clear();
		int INDICE = 13, SOMA = 0, K = 0;

		while (K < INDICE)
		{
			K = K + 1;
			SOMA = SOMA + K;
		}

		Console.WriteLine($"Resultado da soma: {SOMA}");
		Console.ReadKey();
	}

	static void Questao2()
	{
		Console.Clear();
		Console.Write("Digite um número para verificar se está na sequência de Fibonacci: ");
		int numero = int.Parse(Console.ReadLine());
		int a = 0, b = 1, temp;

		while (b < numero)
		{
			temp = a;
			a = b;
			b = temp + b;
		}

		if (b == numero || numero == 0)
			Console.WriteLine($"O número {numero} pertence à sequência de Fibonacci.");
		else
			Console.WriteLine($"O número {numero} NÃO pertence à sequência de Fibonacci.");

		Console.ReadKey();
	}

	static void Questao3()
	{
		Console.Clear();

		// Vetor de faturamento diário (exemplo com 30 dias)
		double[] faturamentoDiario = {
		31490.7866, 37277.9400, 37708.4303, 0.0000, 0.0000,
		17934.2269, 0.0000, 6965.1262, 24390.9374, 14279.6481,
		0.0000, 0.0000, 39807.6622, 27261.6304, 39775.6434,
		29797.6232, 17216.5017, 0.0000, 0.0000, 12974.2000,
		28490.9861, 8748.0937, 8889.0023, 17767.5583, 0.0000,
		0.0000, 3071.3283, 48275.2994, 10299.6761, 39874.1073
	};

		// Remover dias sem faturamento (valores 0)
		var faturamentoValido = faturamentoDiario.Where(f => f > 0).ToArray();

		if (faturamentoValido.Length == 0)
		{
			Console.WriteLine("Não há dados de faturamento disponíveis.");
			Console.ReadKey();
			return;
		}

		// Cálculo do menor e maior faturamento
		double menorFaturamento = faturamentoValido.Min();
		double maiorFaturamento = faturamentoValido.Max();

		// Cálculo da média mensal considerando apenas os dias com faturamento
		double mediaMensal = faturamentoValido.Average();

		// Contagem dos dias com faturamento acima da média
		int diasAcimaDaMedia = faturamentoValido.Count(f => f > mediaMensal);

		// Exibir resultados
		Console.WriteLine($"Menor faturamento do mês: {menorFaturamento:C}");
		Console.WriteLine($"Maior faturamento do mês: {maiorFaturamento:C}");
		Console.WriteLine($"Número de dias com faturamento acima da média: {diasAcimaDaMedia}");

		Console.ReadKey();
	}
	 
	static void Questao4()
	{
		Console.Clear();
		var faturamentos = new Dictionary<string, double>
		{
			{"SP", 67836.43},
			{"RJ", 36678.66},
			{"MG", 29229.88},
			{"ES", 27165.48},
			{"Outros", 19849.53}
		};

		double total = faturamentos.Values.Sum();

		foreach (var estado in faturamentos)
		{
			double percentual = (estado.Value / total) * 100;
			Console.WriteLine($"{estado.Key}: {percentual:F2}%");
		}

		Console.ReadKey();
	}

	static void Questao5()
	{
		Console.Clear();
		Console.Write("Digite uma string para inverter: ");
		string texto = Console.ReadLine();
		string invertido = "";

		for (int i = texto.Length - 1; i >= 0; i--)
		{
			invertido += texto[i];
		}

		Console.WriteLine($"Invertida: {invertido}");
		Console.ReadKey();
	}
}

class Faturamento
{
	public int dia { get; set; }
	public double valor { get; set; }
}
