using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto32.Models{
    public class Conta : Pessoa{
        private int _id;
        private string _tipo;
        private decimal _saldo;
        private string _senha;

        public int id { get => _id; set => _id = value;}
        public string tipo { get => _tipo; set => _tipo = value;}
        public decimal saldo { get => _saldo; set => _saldo = value;}

        [PasswordPropertyText(true)] // isto indica que uma propriedade poderá ser mascarada através de um conjunto de caraceres, como asteriscos
        public string senha { get => "******"; set => _senha = value; } // "******" é a forma como a propriedade pública "senha" será representada

        public Conta(){} // criando um constructor vazio

        public void CadastrarConta(){ // método para cadastro
            Console.WriteLine("CADASTRO\n");
            Console.Write("Nome: ");
            nome = Console.ReadLine();
            Console.Write("Data de nascimento: ");
            dataNascimento = Console.ReadLine();
            Console.Write("Gênero (M ou F): ");
            genero = Console.ReadLine(); 
            Console.Write("CPF: ");
            cpf = Console.ReadLine();

            Console.Write("\nID da conta: ");
            id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Tipo da conta: ");
            tipo = Console.ReadLine();
            Console.Write("Saldo: ");
            saldo = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Senha: ");
            senha = Console.ReadLine();
        }

        public void ExibirDados(){ // método para exibir os dados de cadastro
            Console.WriteLine($"Nome:                {nome}");
            Console.WriteLine($"Data de nascimento:  {dataNascimento}");
            Console.WriteLine($"Gênero:              {genero}");
            Console.WriteLine($"CPF:                 {cpf}");
            Console.WriteLine($"ID da conta:         {id}");
            Console.WriteLine($"Tipo da Conta:       {tipo}");
            Console.WriteLine($"Saldo:               {saldo:C}");
            Console.WriteLine($"Senha:               {senha}");
            Thread.Sleep(2000);
        }

        public void Sacar(){ // método de saque
            Console.Clear();
            decimal valorSaque = 0;
            string confirmaSenha = string.Empty; // variável para confirmação de senha

            Console.Write("Insira a senha do usuário: ");
            confirmaSenha = Console.ReadLine();
            Console.Clear();

            // se o valor de "confirmaSenha" bater com o da propriedade privada "_senha", o saque poderá ser realizado.
            // A comparação deve ser feita com "_senha" e não com "senha", pois o valor da última possui apenas asteriscos
            if(confirmaSenha == _senha){
                Console.Write("Valor a sacar: ");
                valorSaque = Convert.ToDecimal(Console.ReadLine());

                // se o valor do saldo for maior que o valor do saque, a operação será bem-sucedida
                if(saldo >= valorSaque){
                    saldo -= valorSaque; // saldo recebe o saldo atual menos o valor de saque
                    Console.WriteLine("\nSaque realizado com êxito!");
                    Thread.Sleep(2000);
                }
                else{
                    Console.WriteLine("\nValor de saque maior que saldo disponível!");
                    Thread.Sleep(2000);
                }
            }
            else{
                Console.WriteLine("Senha incorreta!");
                Thread.Sleep(2000);
            }            
        }

        public void Depositar(){ // método de depósito
            Console.Clear();
            decimal valorDeposito = 0;
            string confirmaSenha = string.Empty; // // variável para confirmação de senha

            Console.Write("Insira a senha do usuário: ");
            confirmaSenha = Console.ReadLine();
            Console.Clear();

            // o algoritmo da confirmação de senha se repete no depósito
            if(confirmaSenha == _senha){
                Console.Write("Valor a depositar: ");
                valorDeposito = Convert.ToDecimal(Console.ReadLine());
                saldo += valorDeposito; // saldo recebe o saldo atual mais o valor de despósito
                Console.WriteLine("\nDepósito realizado com êxito!");
                Thread.Sleep(2000);
            }
            else{
                Console.WriteLine("Senha incorreta!");
                Thread.Sleep(2000);
            }            
        }
    }
}