using System;
using Dig.One.Classes;
using Dig.One.Enums;
using Dig.One.Interfaces;
using System.Linq;

namespace Dig.One
{
    class Program
    {
        private static readonly IRepositorio<Series> seriesRepos = new SerieRepositorio();
        private static readonly Genero generos;
        static void Main(string[] args)
        {
            Console.WriteLine("DIG.ONE");
            var opcaoSelecionada = ObterOpcaoUsuario();
            separador();
            while (!opcaoSelecionada.ToUpper().Equals("X")) {
                switch (opcaoSelecionada.ToUpper()) {
                    case "1":
                        listarSeries();
                        break;
                    case "2":
                        inserirSerie();
                        break;
                    case "3":
                        break;
                    case "4":
                        excluirSerie();
                        break;
                    case "5":
                        visualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Selecione uma opção válida!");
                        break;
                }
                novaLinha();
                separador();
                opcaoSelecionada = ObterOpcaoUsuario();
            }
        }

        public static string ObterOpcaoAvanade() {
            Console.WriteLine("ME CONTRATA AVANADE!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1 - Contratado!");
            Console.WriteLine("2 - Claro que sim!");
            Console.WriteLine("3 - Pra ontem!");
            Console.WriteLine("4 - Todas acima!");
            string opcaoSelecionada = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoSelecionada;
        }

        public static string ObterOpcaoUsuario() {
            Console.WriteLine("DIG.ONE Series ao seu dispor!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1 - Listar Series");
            Console.WriteLine("2 - Inserir nova serie");
            Console.WriteLine("3 - Atualizar serie");
            Console.WriteLine("4 - Excluir serie");
            Console.WriteLine("5 - Visualizar serie");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");

            string opcaoSelecionada = Console.ReadLine();
            Console.WriteLine();
            return opcaoSelecionada;
        }

        public static void listarSeries() {
            novaLinha();
            separador();
            Console.WriteLine(TituloAcao("LISTA DE SERIES"));
            var series = seriesRepos.Lista();

            if (series.Count == 0)
                Console.WriteLine("Nenhuma Serie encontrada!");

            foreach (var serie in series) {
                Console.WriteLine(serie.ToString());
                separador();
            }
        }

        public static void inserirSerie() {
            Console.WriteLine(TituloAcao("NOVA SERIE"));

            novaLinha();
            separador();
            Console.WriteLine("Informe um número para o gênero desejado!");
            novaLinha();
            listarGeneros();
            separador();

            Console.Write("Gênero: ");
            var genero = Console.ReadLine();
            novaLinha();
            Console.Write("Titulo: ");
            var titulo = Console.ReadLine();
            novaLinha();
            Console.Write("Descrição: ");
            var descricao = Console.ReadLine();
            novaLinha();
            Console.Write("Ano: ");
            var ano = Console.ReadLine();
            novaLinha();
            Console.WriteLine("Salvando...");
            Series novaSerie = new Series(seriesRepos.ProximoId(), (Genero)Int32.Parse(genero), titulo, descricao, Int32.Parse(ano));
            seriesRepos.Insere(novaSerie);
            Console.WriteLine("Salvo com sucesso!");
            separador();
        }

        public static void excluirSerie() {
            Console.WriteLine(TituloAcao("EXCLUIR SERIE"));
            novaLinha();
            separador();

            Console.Write("Informe o ID:");
            int opcaoSelecionada = Int32.Parse(Console.ReadLine());
            seriesRepos.Excluir(opcaoSelecionada);
            separador();
            Console.WriteLine();
        }

        public static void visualizarSerie() {

            Console.WriteLine(TituloAcao("Visualizar Série"));
            novaLinha();
            separador();
           
            Console.WriteLine("informe o ID da Série");
            int OpaoSelecionada = Int32.Parse(Console.ReadLine());
            Series serie = seriesRepos.RetornaPorId(OpaoSelecionada);
            Console.WriteLine(serie.ToString());
        }

        public static void atualizaSerie()
        {
            Console.WriteLine(TituloAcao("ATUALIZA SERIE"));

            Console.Write("Informe o ID da serie: ");
            var idSerie = Int32.Parse(Console.ReadLine());
            novaLinha();

            Series serie = seriesRepos.RetornaPorId(idSerie);
            Console.WriteLine(serie.ToString());

            novaLinha();
            separador();
            Console.WriteLine("Informe um número para o gênero desejado!");
            novaLinha();
            listarGeneros();
            separador();

            Console.Write("Gênero: ");
            var genero = Console.ReadLine();
            novaLinha();
            Console.Write("Titulo: ");
            var titulo = Console.ReadLine();
            novaLinha();
            Console.Write("Descrição: ");
            var descricao = Console.ReadLine();
            novaLinha();
            Console.Write("Ano: ");
            var ano = Console.ReadLine();
            novaLinha();
            Console.WriteLine("Salvando...");
            Series novaSerie = new Series(seriesRepos.ProximoId(), (Genero)Int32.Parse(genero), titulo, descricao, Int32.Parse(ano));
            seriesRepos.Atualiza(idSerie, novaSerie);
            Console.WriteLine("Salvo com sucesso!");
            separador();
        }

        public static string TituloAcao(string titulo){
            return  $"############ {titulo.ToUpper()} #############";
        }

        public static void separador(){
            Console.WriteLine("----------------");
        }
        public static void novaLinha(){
            Console.WriteLine();
        }
        public static void listarGeneros(){
            var enums = Enum.GetValues(typeof(Genero));
            for(var i = 1; i < enums.Length; i++)
            {
                Console.WriteLine($" {i} - {Enum.GetName(typeof(Genero), i)}");  
            }
        }
    }
}
