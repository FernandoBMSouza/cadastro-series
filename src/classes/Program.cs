using System;
using Cadastro_Series.src.Enum;

namespace Cadastro_Series.src.Classes
{
    class Program
    {
        static SerieRepositorio repositorioSerie = new SerieRepositorio();
        static FilmeRepositorio repositorioFilme = new FilmeRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while(opcaoUsuario.ToUpper() != "X")
            {
                switch(opcaoUsuario)
                {
                    case "1":
                        MenuSeries();
                        break;
                    case "2":
                        MenuFilmes();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                
                opcaoUsuario = ObterOpcaoUsuario();
            }

            System.Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }

        private static string ObterOpcaoUsuario()
        {
            System.Console.WriteLine();
            System.Console.WriteLine("DIO Séries e Filmes a seu dispor!!!");
            System.Console.WriteLine("Qual menu deseja acessar:");

            System.Console.WriteLine("1- Séries");
            System.Console.WriteLine("2- Filmes");
            System.Console.WriteLine("C- Limpar Tela");
            System.Console.WriteLine("X- Sair");
            System.Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            System.Console.WriteLine();
            return opcaoUsuario;
        }

        #region Serie
        private static void MenuSeries()
        {
            string opcaoUsuarioSerie = ObterOpcaoUsuarioSerie();

            while(opcaoUsuarioSerie.ToUpper() != "X")
            {
                switch(opcaoUsuarioSerie)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuarioSerie = ObterOpcaoUsuarioSerie();
            }
        }
        private static void ListarSeries()
        {
            System.Console.WriteLine("Listar séries");

            var lista = repositorioSerie.Lista();

            if(lista.Count == 0)
            {
                System.Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }

            foreach(var serie in lista)
            {
                var excluido = serie.retornaExcluido();
                System.Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
            }
        }
        private static void InserirSerie()
        {
            System.Console.WriteLine("Inserir nova série");

            foreach(int i in Enum.Genero.GetValues(typeof(Genero)))
            {
                System.Console.WriteLine("{0} - {1}", i, Enum.Genero.GetName(typeof(Genero), i));
            }
            System.Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            System.Console.WriteLine("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorioSerie.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            repositorioSerie.Insere(novaSerie);
        }
        private static void AtualizarSerie()
        {
            System.Console.WriteLine("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach(int i in Enum.Genero.GetValues(typeof(Genero)))
            {
                System.Console.WriteLine("{0} - {1}", i, Enum.Genero.GetName(typeof(Genero), i));
            }

            System.Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            System.Console.WriteLine("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: indiceSerie,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorioSerie.Atualiza(indiceSerie, atualizaSerie);
        }
        private static void ExcluirSerie()
        {
            System.Console.WriteLine("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorioSerie.Exclui(indiceSerie);
        }
        private static void VisualizarSerie()
        {
            System.Console.WriteLine("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorioSerie.RetornaPorId(indiceSerie);

            System.Console.WriteLine(serie);
        }
        private static string ObterOpcaoUsuarioSerie()
        {
            System.Console.WriteLine();
            System.Console.WriteLine("DIO Séries a seu dispor!!!");
            System.Console.WriteLine("Informe a opção desejada:");

            System.Console.WriteLine("1- Listar séries");
            System.Console.WriteLine("2- Inserir nova série");
            System.Console.WriteLine("3- Atualizar série");
            System.Console.WriteLine("4- Excluir série");
            System.Console.WriteLine("5- Visualizar série");
            System.Console.WriteLine("C- Limpar Tela");
            System.Console.WriteLine("X- Sair");
            System.Console.WriteLine();

            string opcaoUsuarioSerie = Console.ReadLine().ToUpper();
            System.Console.WriteLine();
            return opcaoUsuarioSerie;
        }
        #endregion
        
        #region Filme
         private static void MenuFilmes()
        {
            string opcaoUsuarioFilme = ObterOpcaoUsuarioFilme();

            while(opcaoUsuarioFilme.ToUpper() != "X")
            {
                switch(opcaoUsuarioFilme)
                {
                    case "1":
                        ListarFilmes();
                        break;
                    case "2":
                        InserirFilme();
                        break;
                    case "3":
                        AtualizarFilme();
                        break;
                    case "4":
                        ExcluirFilme();
                        break;
                    case "5":
                        VisualizarFilme();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuarioFilme = ObterOpcaoUsuarioFilme();
            }
        }
        private static void ListarFilmes()
        {
            System.Console.WriteLine("Listar filmes");

            var lista = repositorioFilme.Lista();

            if(lista.Count == 0)
            {
                System.Console.WriteLine("Nenhum filme cadastrado.");
                return;
            }

            foreach(var filme in lista)
            {
                var excluido = filme.retornaExcluido();
                System.Console.WriteLine("#ID {0}: - {1} {2}", filme.retornaId(), filme.retornaTitulo(), (excluido ? "*Excluído*" : ""));
            }
        }
        private static void InserirFilme()
        {
            System.Console.WriteLine("Inserir novo Filme");

            foreach(int i in Enum.Genero.GetValues(typeof(Genero)))
            {
                System.Console.WriteLine("{0} - {1}", i, Enum.Genero.GetName(typeof(Genero), i));
            }
            System.Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite o Título do Filme: ");
            string entradaTitulo = Console.ReadLine();

            System.Console.WriteLine("Digite o Ano de Início do Filme: ");
            int entradaAno = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite a Descrição do Filme: ");
            string entradaDescricao = Console.ReadLine();

            Filme novoFilme = new Filme(id: repositorioFilme.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            repositorioFilme.Insere(novoFilme);
        }
        private static void AtualizarFilme()
        {
            System.Console.WriteLine("Digite o id do filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());

            foreach(int i in Enum.Genero.GetValues(typeof(Genero)))
            {
                System.Console.WriteLine("{0} - {1}", i, Enum.Genero.GetName(typeof(Genero), i));
            }

            System.Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite o Título do Filme: ");
            string entradaTitulo = Console.ReadLine();

            System.Console.WriteLine("Digite o Ano de Início do Filme: ");
            int entradaAno = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite a Descrição do Filme: ");
            string entradaDescricao = Console.ReadLine();

            Filme atualizaFilme = new Filme(id: indiceFilme,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorioFilme.Atualiza(indiceFilme, atualizaFilme);
        }
        private static void ExcluirFilme()
        {
            System.Console.WriteLine("Digite o id do Filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());

            repositorioFilme.Exclui(indiceFilme);
        }
        private static void VisualizarFilme()
        {
            System.Console.WriteLine("Digite o id do filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());

            var filme = repositorioFilme.RetornaPorId(indiceFilme);

            System.Console.WriteLine(filme);
        }
        private static string ObterOpcaoUsuarioFilme()
        {
            System.Console.WriteLine();
            System.Console.WriteLine("DIO Filmes a seu dispor!!!");
            System.Console.WriteLine("Informe a opção desejada:");

            System.Console.WriteLine("1- Listar filmes");
            System.Console.WriteLine("2- Inserir novo filme");
            System.Console.WriteLine("3- Atualizar filme");
            System.Console.WriteLine("4- Excluir filme");
            System.Console.WriteLine("5- Visualizar filme");
            System.Console.WriteLine("C- Limpar Tela");
            System.Console.WriteLine("X- Sair");
            System.Console.WriteLine();

            string opcaoUsuarioFilme = Console.ReadLine().ToUpper();
            System.Console.WriteLine();
            return opcaoUsuarioFilme;
        }
        #endregion
    }
}