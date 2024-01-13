using Projeto32.Models;

bool menuConfirma = true;
bool menuConta = true;
Conta conta1 = new Conta(); // instanciando a classe vazia

Console.Clear();
Console.WriteLine("======== Sistema bancário ========\n");

// este loop serve exclusivamente para que o usuário modifique seus dados de cadastro caso haja a necessidade
while(menuConfirma == true){
    Console.Clear();
    conta1.CadastrarConta(); // cadastrando a conta
    Console.WriteLine("\nCadastro realizado com sucesso!");

    Thread.Sleep(2000);
    Console.Clear();

    conta1.ExibirDados(); // exibindo os dados da conta

    Console.WriteLine("\nConfirmar dados?"); // solicitando a confirmação dos dados atravé de um menu
    Console.WriteLine("1 - Sim");
    Console.WriteLine("2 - Não, desejo refazer");
    Console.Write("\nOpção: ");            
    switch(Console.ReadLine()){
        case "1":
            Console.WriteLine("\nDados confirmados!"); 
            Thread.Sleep(2000);
            menuConfirma = false; // caso confirme, o menu será encerrado
            break;
        case "2":
            break; // se a resposta for não, o cadastro será realizado de novo (loop se reinicia)
        default:
            Console.WriteLine("\nErro!\n");
            Environment.Exit(0);
            break;
    }
}

while(menuConta == true){ // criação de menu para saque e depóstio
    Console.Clear();
    Console.WriteLine($"Usuário: {conta1.nome}");
    Console.WriteLine($"Saldo: {conta1.saldo:C}\n");
    Console.WriteLine("1 - Sacar");
    Console.WriteLine("2 - Depositar");
    Console.WriteLine("3 - Encerrar");
    
    Console.Write("\nOpção: ");
    switch(Console.ReadLine()){
        case "1":
            conta1.Sacar();
            break;
        case "2":
            conta1.Depositar();
            break;
        case "3":
            menuConta = false;
            break;
        default:
            Console.WriteLine("\nOpção inválida!");
            Thread.Sleep(2000);
            break;
    }
}
Console.WriteLine("\nPrograma encerrado.\n");
