using System;
using System.Collections.Generic;

namespace Bank
{
    class Program
        
    {
        static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args)
        {
          //  Conta minhaConta = new Conta(TipoConta.PessoaFisica,0,0,"Rita Gallinari");
          //  Console.WriteLine(minhaConta.ToString());
          string opcaoUsuario = ObterOpcaoUsuario();

          while (opcaoUsuario.ToUpper() !="X")
          {
              switch (opcaoUsuario)
              {
                  case "1":
                    ListContas();
                    break ;
                  case "2":
                    InserirConta();
                    break;
                  case "3":
                  transferir();
                  break;
                  case "4":
                  Sacar();
                  break;
                  case "5":
                  Depositar();
                  break;
                  case "C":
                  Console.Clear();
                  break;

                  default:
                  throw new ArgumentOutOfRangeException();
              }
              opcaoUsuario = ObterOpcaoUsuario();

          }
          Console.WriteLine ("Obrigado por usar nossos serviços.");
          Console.ReadLine();

        }

        private static void transferir()
        {
            Console.WriteLine("Digite o número da conta origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());
           
            Console.WriteLine("Digite o número da conta Destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser Transferido: ");
            double valorTransferido = double.Parse(Console.ReadLine());

            listContas[indiceContaOrigem].Transferir(valorTransferido, listContas[indiceContaDestino]);

        }

        private static void Depositar()
        {
            Console.WriteLine("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser Depositado: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listContas[indiceConta].Depositar(valorDeposito);

        }

        private static void Sacar()
        {
            Console.WriteLine("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser sacado: ");
            double valorSaque = double.Parse(Console.ReadLine());

            listContas[indiceConta].Sacar(valorSaque);

            //throw new NotImplementedException();
        }

        private static void ListContas( )
        {
            Console.WriteLine("Listar Contas");
            if (listContas.Count == 0)
            {
                Console.WriteLine("Nenuma conta cadastrada. ");
                return;
            }
            for (int i = 0; i < listContas.Count; i++)
            {
                Conta conta = listContas[i];
                Console.WriteLine("# {0} - ", i);
                Console.WriteLine(conta);

            }
       
            //throw new NotImplementedException();
        }

        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova Conta");

            Console.WriteLine ("Digite 1 para Conta pessoa Física ou 2 para Jurídica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o nome do Cliente: ");
            string entradaNome = Console.ReadLine();

            Console.WriteLine("Digite o Saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Crédito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                saldo: entradaSaldo,
                credito: entradaCredito,
                nome: entradaNome);

            listContas.Add(novaConta);
        }

        private static string ObterOpcaoUsuario()
        {
           Console.WriteLine();
           Console.WriteLine("Dio Bank a seu dispor !!!");
           Console.WriteLine("1 - Listar Contas");
           Console.WriteLine("2 - Inserir nova Conta");
           Console.WriteLine("3 - Transferir");
           Console.WriteLine("4 - Sacar");
           Console.WriteLine("5 - Depositar");
           Console.WriteLine("C - Limpar Tela");
           Console.WriteLine("X - Sair");
           string opcaoUsuario = Console.ReadLine().ToUpper();
           Console.WriteLine();
           return opcaoUsuario;
        }
 
    }
}
