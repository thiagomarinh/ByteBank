using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace ByteBank_1
{
	class Programa
	{
		static void ShowMenu()
		{
			Console.WriteLine("\n" +
				"----------- BEM VINDO AO BYTE BANK -----------\n");
            Console.WriteLine("[1] - Adicionar nova conta");
            Console.WriteLine("[2] - Deletar uma conta");
            Console.WriteLine("[3] - Detalhes da conta");
            Console.WriteLine("[4] - Listar todas as contas");
            Console.WriteLine("[5] - Mostre o quantias total amazenada no ByteBank");
			Console.WriteLine("[6] - Atualizar Dados da conta: ");
            Console.WriteLine("[0] - Para sair do programa");
            Console.Write("\nDigite a opção desejada: ");
			
        }

		static void AdicionarConta(List<string> cpfs, List<string> titulares, List<string> senhas, List<string> telefone, List<double> saldos) 
		{
			Console.Write("Digite o CPF: ");
			cpfs.Add(Console.ReadLine());
			Console.Write("Digite o nome: ");
			titulares.Add(Console.ReadLine());
			Console.Write("Digite a senha: ");
			senhas.Add(Console.ReadLine());
			Console.Write("Digite seu Telefone para contato: ");
			telefone.Add(Console.ReadLine());
			Console.Write("Digite o saldo: ");
			saldos.Add(double.Parse(Console.ReadLine()));
		}

		static void DeletarConta(List<string> cpfs, List<string> titulares, List<string> senhas,List<string> telefone, List<double> saldo)
		{
			Console.Write("Qual o cpf da conta que quer deletar: ");
			string cpfParaDeletar = Console.ReadLine();

            // predicate usado para achar o index na lista CPF, diz se: achar o elemento c tal que o conteudo de c seja igual a cpfParaDeletar, retorna -1 caso False e 0 caso True
            int indexParaDeletar = cpfs.FindIndex(c => c == cpfParaDeletar);

			if (indexParaDeletar == -1)
			{
				Console.WriteLine(":( CPFnão encontrado na base de dados");
			}

			cpfs.RemoveAt(indexParaDeletar);
			titulares.RemoveAt(indexParaDeletar);
			senhas.RemoveAt(indexParaDeletar);
			telefone.RemoveAt(indexParaDeletar);
			saldo.RemoveAt(indexParaDeletar);

			Console.WriteLine("Usuario deletado com sucesso!!!");
		}

		static void DetalhesDaConta(List<string> cpfs, List<string> titulares, List<double> saldos, List<string> telefone)
		{
			Console.Write("Digite o CPF para detalhar a conta: ");
			string cpfParaDetalharConta = Console.ReadLine();

			int indexDetalhe = cpfs.FindIndex(c => c == cpfParaDetalharConta);

			if (indexDetalhe == -1)
			{
				Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("Cpf do usuario não encontrado!!!\n");
                Console.ResetColor();
            }

            Console.Write($"\nUsuario: {titulares[indexDetalhe]}  ||  Saldo: {saldos[indexDetalhe]} R$ ||  Telefone: {telefone[indexDetalhe]}\n");
		}
		
		static void	ListarTodasAsContas(List<string> cpfs, List<string> titulares, List<double> saldos)
		{
			for (int i = 0; i < cpfs.Count; i++)
			{
				Console.WriteLine($"\nUsuario: {titulares[i]} | CPF: {cpfs[i]} | Saldo: {saldos[i]}");
			}
		}

        static void TotalArmazenadoNoBanco(List<double> saldos)
        {
            // metodo Enumerable.Aggregate() soma todos os conteudos de uma lista, como no exemplo abaixo
            double soma = saldos.Aggregate((total, next) => total + next);
            Console.WriteLine($"\nTtoal armezanado no ByteBank é {soma}\n");
        }

		static void ManipularConta(List<string> cpfs, List<double> saldos, List<string> senhas, List<string> telefone)
		{
			Console.Write("Para alterar dados da sua conta digite o CPF: ");
			string cpfParaManipular = Console.ReadLine();

			int indexParaManipular = cpfs.FindIndex(c => c == cpfParaManipular);

			Console.WriteLine("[1] - Para alterar a senha");
			Console.WriteLine("[2] - Para alterar o telefone");
			Console.WriteLine("[3] - Para alterar seu nome: ");
			
            Console.Write("O que gostaria de alterar? : ");
			int alterarDado = int.Parse(Console.ReadLine());

			switch (alterarDado)
			{
				case 1:
					Console.Write("Digite sua nova senha: ");
					string novaSenha = Console.ReadLine();
					senhas.Insert(indexParaManipular, novaSenha);
                    Console.WriteLine("Senha Atualizada com sucesso!!!");
                    break;
				case 2:
					Console.Write("Digite seu novo telefone: ");
					string novoTelefone = Console.ReadLine();
					telefone.Insert(indexParaManipular, novoTelefone);
					Console.WriteLine("Telefone Atualizado com sucesso!!!");
					break;
				case 3:
                    
                    break;

            }

		}

        public static void Main(string[] args)
		{

			List<string> titulares = new List<string>();
			List<string> cpfs = new List<string>();
			List<string> senhas = new List<string>();
			List<double> saldos = new List<double>();
			List<string> telefone = new List<string>();

			int option;

			Console.BackgroundColor = ConsoleColor.Yellow;
			Console.ForegroundColor = ConsoleColor.Black;
			Console.Clear();

            do
			{
				ShowMenu();
				option = int.Parse(Console.ReadLine());
				Console.Clear();

				switch (option)
				{
					case 0:
						Console.WriteLine("Programa encerrando");
						break;
					case 1:
						AdicionarConta(cpfs, titulares, senhas, telefone, saldos);
						break;
					case 2:
						DeletarConta(cpfs, titulares, senhas, telefone, saldos);
						break;
					case 3:
						DetalhesDaConta(cpfs, titulares, saldos, telefone);
						break;
					case 4:
						ListarTodasAsContas(cpfs, titulares, saldos);
						break;
					case 5:
						TotalArmazenadoNoBanco(saldos);
						break;
					case 6:
						ManipularConta(cpfs, saldos, senhas, telefone);
						break;
				}
				
			} while (option != 0);
		}
	}
}