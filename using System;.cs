using System;
using System.IO;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Menu Principal");
            Console.WriteLine("1- Criar pasta");
            Console.WriteLine("2- Criar arquivo");
            Console.WriteLine("3- Deletar Pasta");
            Console.WriteLine("4- Deletar Arquivos");
            Console.WriteLine("5- Sair");
            Console.Write("Escolha uma opÃ§Ã£o: ");
            
            switch (Console.ReadLine())
            {
                case "1": GerenciarPasta(); break;
                case "2": GerenciarArquivo(); break;
                case "3": DeletarPasta(); break;
                case "4": DeletarArquivo(); break;
                case "5": return;
                default: Console.WriteLine("OpÃ§Ã£o invÃ¡lida!"); break;
            }
        }
    }

    static void GerenciarPasta()
    {
        Console.Clear();
        Console.WriteLine("Menu Criar Pasta");
        Console.WriteLine("1- Exibir pastas existentes");
        Console.WriteLine("2- Criar pasta");
        Console.WriteLine("3- Editar nome da pasta");
        Console.WriteLine("4- Voltar");
        Console.Write("Escolha uma opÃ§Ã£o: ");

        switch (Console.ReadLine())
        {
            case "1": ListarPastas(); break;
            case "2": CriarPasta(); break;
            case "3": RenomearPasta(); break;
            case "4": return;
            default: Console.WriteLine("OpÃ§Ã£o invÃ¡lida!"); break;
        }
    }

    static void GerenciarArquivo()
    {
        Console.Clear();
        Console.WriteLine("Menu Criar Arquivo");
        Console.WriteLine("1- Exibir arquivos existentes");
        Console.WriteLine("2- Criar arquivo");
        Console.WriteLine("3- Editar nome do arquivo");
        Console.WriteLine("4- Adicionar texto ao arquivo");
        Console.WriteLine("5- Voltar");
        Console.Write("Escolha uma opÃ§Ã£o: ");

        switch (Console.ReadLine())
        {
            case "1": ListarArquivos(); break;
            case "2": CriarArquivo(); break;
            case "3": RenomearArquivo(); break;
            case "4": AdicionarTexto(); break;
            case "5": return;
            default: Console.WriteLine("OpÃ§Ã£o invÃ¡lida!"); break;
        }
    }

    static void CriarPasta()
    {
        Console.Write("Digite o nome da pasta: ");
        string nomePasta = Console.ReadLine();

        if (!Directory.Exists(nomePasta))
        {
            Directory.CreateDirectory(nomePasta);
            Console.WriteLine("Pasta criada com sucesso!");
        }
        else
        {
            Console.WriteLine("A pasta jÃ¡ existe!");
        }
        Console.ReadKey();
    }

    static void CriarArquivo()
    {
        Console.Write("Digite o nome do arquivo (com extensÃ£o .txt): ");
        string nomeArquivo = Console.ReadLine();
        
        if (!File.Exists(nomeArquivo))
        {
            Console.Write("Digite o conteÃºdo do arquivo: ");
            string conteudo = Console.ReadLine();
            File.WriteAllText(nomeArquivo, conteudo);
            Console.WriteLine("Arquivo criado com sucesso!");
        }
        else
        {
            Console.WriteLine("O arquivo jÃ¡ existe!");
        }
        Console.ReadKey();
    }

    static void ListarPastas()
    {
        string[] pastas = Directory.GetDirectories(Directory.GetCurrentDirectory());
        foreach (string pasta in pastas)
        {
            Console.WriteLine(pasta);
        }
        Console.ReadKey();
    }

    static void ListarArquivos()
    {
        string[] arquivos = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.txt");
        foreach (string arquivo in arquivos)
        {
            Console.WriteLine(arquivo);
        }
        Console.ReadKey();
    }

    static void RenomearPasta()
    {
        Console.Write("Digite o nome da pasta atual: ");
        string pastaAtual = Console.ReadLine();
        
        if (Directory.Exists(pastaAtual))
        {
            Console.Write("Digite o novo nome da pasta: ");
            string novaPasta = Console.ReadLine();
            Directory.Move(pastaAtual, novaPasta);
            Console.WriteLine("Pasta renomeada com sucesso!");
        }
        else
        {
            Console.WriteLine("Pasta nÃ£o encontrada!");
        }
        Console.ReadKey();
    }

    static void RenomearArquivo()
    {
        Console.Write("Digite o nome do arquivo atual: ");
        string arquivoAtual = Console.ReadLine();

        if (File.Exists(arquivoAtual))
        {
            Console.Write("Digite o novo nome do arquivo: ");
            string novoArquivo = Console.ReadLine();
            File.Move(arquivoAtual, novoArquivo);
            Console.WriteLine("Arquivo renomeado com sucesso!");
        }
        else
        {
            Console.WriteLine("Arquivo nÃ£o encontrado!");
        }
        Console.ReadKey();
    }

    static void AdicionarTexto()
    {
        Console.Write("Digite o nome do arquivo: ");
        string nomeArquivo = Console.ReadLine();

        if (File.Exists(nomeArquivo))
        {
            Console.Write("Digite o texto a ser adicionado: ");
            string texto = Console.ReadLine();
            File.AppendAllText(nomeArquivo, texto + Environment.NewLine);
            Console.WriteLine("Texto adicionado com sucesso!");
        }
        else
        {
            Console.WriteLine("Arquivo nÃ£o encontrado!");
        }
        Console.ReadKey();
    }

    static void DeletarPasta()
    {
        Console.Write("Digite o nome da pasta a ser deletada: ");
        string nomePasta = Console.ReadLine();
        
        if (Directory.Exists(nomePasta))
        {
            Directory.Delete(nomePasta, true);
            Console.WriteLine("Pasta deletada com sucesso!");
        }
        else
        {
            Console.WriteLine("Pasta nÃ£o encontrada!");
        }
        Console.ReadKey();
    }

    static void DeletarArquivo()
    {
        Console.Write("Digite o nome do arquivo a ser deletado: ");
        string nomeArquivo = Console.ReadLine();
        
        if (File.Exists(nomeArquivo))
        {
            File.Delete(nomeArquivo);
            Console.WriteLine("Arquivo deletado com sucesso!");
        }
        else
        {
            Console.WriteLine("Arquivo nÃ£o encontrado!");
        }
        Console.ReadKey();
    }
}