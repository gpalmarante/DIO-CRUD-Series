using cadastrodeseries.Classes;
using System;

namespace cadastrodeseries
{
    class Program
    {
        static serieRepositorio repositorio = new serieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();
            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
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
                        VizualizarSerie();
                        break;
                    case "c":
                        Console.Clear();
                        break;
                    
                    default:
                        throw new ArgumentOutOfRangeException();

                }

                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por utilizar nossos servicos.");
            Console.ReadLine();
        }
        private static void ListarSeries()
        {
            Console.WriteLine("listar series");

            var lista = repositorio.lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma serie cadastrada.");
                return;
            }
            foreach (var serie in lista)
            {
                var excluido = serie.retornExcluido();
                Console.WriteLine("#ID {0} : - {1} {2}", serie.retornaId(), serie.retornaTitulo(),(excluido ? "Excluido" : ""));
            }
        }
        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova serie");
            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("digite o genero entre as opcoes acima");
            int entradaGenero = int.Parse(Console.ReadLine());
            Console.WriteLine("digite o titulo da serie");
            string entradaTitulo = Console.ReadLine();
            Console.WriteLine("digite o ano de inicio");
            int entradaAno = int.Parse(Console.ReadLine());
            Console.WriteLine("digite a descricao da serie");
            string entradaDescricao = Console.ReadLine();
            Serie novaSerie = new Serie(id: repositorio.ProximoId(),           
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorio.Insere(novaSerie);
        }
        private static void AtualizarSerie()
        {
            Console.WriteLine("digite o id da serie");
            int indiceSerie = int.Parse(Console.ReadLine());
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("digite o genero entre as opcoes acima");
            int entradaGenero = int.Parse(Console.ReadLine());
            Console.WriteLine("digite o titulo da serie");
            string entradaTitulo = Console.ReadLine();
            Console.WriteLine("digite o ano de inicio");
            int entradaAno = int.Parse(Console.ReadLine());
            Console.WriteLine("digite a descricao da serie");
            string entradaDescricao = Console.ReadLine();
            Serie novaSerie = new Serie(id: indiceSerie,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorio.Atualiza(indiceSerie, novaSerie);
        }
        private static void ExcluirSerie()
        {
            Console.WriteLine("Digite o id da serie: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            repositorio.Exclui(indiceSerie);
        }
        private static void VizualizarSerie()
        {
            Console.WriteLine("Digite o id da serie: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);

            Console.WriteLine(serie);

        }

            private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Escolha de series!");
            Console.WriteLine("Informe a opcao desejada:");

            Console.WriteLine("1 - Listar series");
            Console.WriteLine("2 - Inserir nova serie");
            Console.WriteLine("3 - Alterar serie");
            Console.WriteLine("4 - Excluir serie");
            Console.WriteLine("5 - Visualizar serie");
            Console.WriteLine("C - Limpa tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();
            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
