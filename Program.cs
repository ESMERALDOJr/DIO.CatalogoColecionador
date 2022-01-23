using System;

namespace DIO.CatalogoColecionador
{
    class Program
    {
        static CatalogoRepositorio repositorio = new CatalogoRepositorio();
        static void Main(string[] args)
        {
            string opcaoColecionador = ObterOpcaoColecionador();

            while (opcaoColecionador.ToUpper() != "X")
            {
                switch (opcaoColecionador)
                {
                    case "1":
                        ListarCatalogos();
                        break;
                    case "2":
                        InserirCatalogo();
                        break;
                    case "3":
                        AtualizarCatalogo();
                        break;
                    case "4":
                        Visualizarcatalogo();
                        break;
                    case "5":
                        ExcluirCatalogo();                        
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoColecionador = ObterOpcaoColecionador();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }

        private static void ExcluirCatalogo()
        {
            Console.Write("Digite o id da miniatura: ");
            int indiceCatalogo = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceCatalogo);
        }

        private static void Visualizarcatalogo()
        {
            Console.Write("Digite o id da miniatura: ");
            int indiceCatalogo = int.Parse(Console.ReadLine());

            var catalogo = repositorio.RetornaPorId(indiceCatalogo);

            Console.WriteLine(catalogo);
        }

        private static void AtualizarCatalogo()
        {
            Console.Write("Digite o id da miniatura: ");
            int indiceCatalogo = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Marca)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Marca), i));
            }
            Console.Write("informe o fabricante entre as opções acima: ");
            int entradaMarca = int.Parse(Console.ReadLine());

            Console.Write("Informe o modelo da miniatura: ");
            string entradaModelo = Console.ReadLine();

            Console.Write("informe o código da miniatura: ");
            int entradaCod_Miniatura = int.Parse(Console.ReadLine());

            Console.Write("Informe a descrição da miniatura: ");
            string entradaDescricao = Console.ReadLine();

            Catalogo atualizaCatalogo = new Catalogo(id: indiceCatalogo,
                                        marca: (Marca)entradaMarca,
                                        modelo: entradaModelo,
                                        cod_miniatura: entradaCod_Miniatura,
                                        descricao: entradaDescricao);

            repositorio.Atualiza(indiceCatalogo, atualizaCatalogo);
        }
        private static void ListarCatalogos()
        {
            Console.WriteLine("Listar miniaturas");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma miniatura cadastrada.");
                return;
            }

            foreach (var catalogo in lista)
            {
                var excluido = catalogo.retornaExcluido();

                Console.WriteLine("#ID {0}: - {1} {2}", catalogo.retornaId(), catalogo.retornaModelo(), (excluido ? "*Excluído*" : ""));
            }
        }

        private static void InserirCatalogo()
        {
            Console.WriteLine("Inserir nova miniatura");
            
            foreach (int i in Enum.GetValues(typeof(Marca)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Marca), i));
            }
            Console.Write("Informe o fabricante entre as opções acima: ");
            int entradaMarca = int.Parse(Console.ReadLine());

            Console.Write("Informe o modelo da miniatura: ");
            string entradaModelo = Console.ReadLine();

            Console.Write("Informe o código da miniatura: ");
            int entradaCod_Miniatura = int.Parse(Console.ReadLine());

            Console.Write("Informe a descrição da miniatura: ");
            string entradaDescricao = Console.ReadLine();

            Catalogo novaMiniatura = new Catalogo(id: repositorio.ProximoId(),
                                        marca: (Marca)entradaMarca,
                                        modelo: entradaModelo,
                                        cod_miniatura: entradaCod_Miniatura,
                                        descricao: entradaDescricao);

            repositorio.Insere(novaMiniatura);
        }

        private static string ObterOpcaoColecionador()
        {
            Console.WriteLine();
            Console.WriteLine("catalogo de miniaturas liberado!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar miniaturas");
            Console.WriteLine("2- Inserir nova miniatura");
            Console.WriteLine("3- Atualizar miniatura");
            Console.WriteLine("4- Visualizar miniatura");
            Console.WriteLine("5- Excluir miniatura");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoColecionador = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoColecionador;
        }
    }
}