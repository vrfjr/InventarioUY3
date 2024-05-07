using System;

class Program
{
    static void Main(string[] args)
    {
        // Criar uma instância do repositório de equipamentos
        var repositorio = new RepositorioEquipamento();

        // Loop principal do menu
        while (true)
        {
            // Exibir menu
            Console.WriteLine("==== Menu ====");
            Console.WriteLine("1. Adicionar Equipamento");
            Console.WriteLine("2. Remover Equipamento");
            Console.WriteLine("3. Atualizar Equipamento");
            Console.WriteLine("4. Listar Equipamentos");
            Console.WriteLine("5. Sair");
            Console.Write("Escolha uma opção: ");

            // Ler opção do usuário
            int opcao;
            if (!int.TryParse(Console.ReadLine(), out opcao))
            {
                Console.WriteLine("Opção inválida. Por favor, escolha um número de 1 a 5.");
                continue;
            }

            // Executar ação com base na opção escolhida
            switch (opcao)
            {
                case 1:
                    AdicionarEquipamento(repositorio);
                    break;
                case 2:
                    RemoverEquipamento(repositorio);
                    break;
                case 3:
                    AtualizarEquipamento(repositorio);
                    break;
                case 4:
                    ListarEquipamentos(repositorio);
                    break;
                case 5:
                    Console.WriteLine("Saindo...");
                    return;
                default:
                    Console.WriteLine("Opção inválida. Por favor, escolha um número de 1 a 5.");
                    break;
            }
        }
    }

    static void AdicionarEquipamento(IRepositorioEquipamento repositorio)
    {
        Console.WriteLine("Adicionando Equipamento...");
        Console.Write("Nome do Equipamento: ");
        string nome = Console.ReadLine();
        Console.Write("Número do Patrimônio (formato UXXXX): ");
        string numeroPatrimonio = Console.ReadLine();

        Equipamento equipamento = new Equipamento(nome, numeroPatrimonio);
        repositorio.AdicionarEquipamento(equipamento);
        Console.WriteLine("Equipamento adicionado com sucesso!");
    }

    static void RemoverEquipamento(IRepositorioEquipamento repositorio)
    {
        Console.WriteLine("Removendo Equipamento...");
        Console.Write("ID do Equipamento a ser removido: ");
        int id;
        if (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("ID inválido. Operação cancelada.");
            return;
        }

        repositorio.RemoverEquipamento(id);
        Console.WriteLine("Equipamento removido com sucesso!");
    }

    static void AtualizarEquipamento(IRepositorioEquipamento repositorio)
    {
        Console.WriteLine("Atualizando Equipamento...");
        Console.Write("ID do Equipamento a ser atualizado: ");
        int id;
        if (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("ID inválido. Operação cancelada.");
            return;
        }

        Console.Write("Novo Nome do Equipamento: ");
        string novoNome = Console.ReadLine();
        Console.Write("Novo Número do Patrimônio (formato UXXXX): ");
        string novoNumeroPatrimonio = Console.ReadLine();

        Equipamento equipamento = new Equipamento(novoNome, novoNumeroPatrimonio);
        equipamento.Id = id;
        repositorio.AtualizarEquipamento(equipamento);
        Console.WriteLine("Equipamento atualizado com sucesso!");
    }

    static void ListarEquipamentos(IRepositorioEquipamento repositorio)
    {
        Console.WriteLine("Listando Equipamentos...");
        var equipamentos = repositorio.ListarEquipamentos();
        foreach (var equipamento in equipamentos)
        {
            Console.WriteLine($"ID: {equipamento.Id}, Nome: {equipamento.Nome}, Número Patrimônio: {equipamento.NumeroPatrimonio}");
        }
    }
}
