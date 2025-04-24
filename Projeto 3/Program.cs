using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;

namespace Projeto_3
{
    class Program
    {


        static List<IEstoque> produtoss = new List<IEstoque>();
        enum Menu { Listar = 1, Adicionar, Remover, Entrada, Saida, Sair }
        static void Main(string[] args)
        {
            carregar();
            bool Escolheusair = false;
            while (Escolheusair == false)
            {
                Console.WriteLine("Sistema de Estoque");
                Console.WriteLine("1- Listar\n2- Adicionar\n3- Remover\n4- Entrada\n5- Saida\n6- Sair");
                String opStr = Console.ReadLine();
                int opInt = int.Parse(opStr);
                Menu escolha = (Menu)opInt;
                if (opInt < 7 && opInt > 0)
                {
                    switch (escolha)
                    {
                        case Menu.Listar:
                            Listagem();
                            break;
                        case Menu.Adicionar:
                            Cadastro();
                            break;
                        case Menu.Remover:
                            remover();
                            break;
                        case Menu.Entrada:
                            Entrada();
                            break;
                        case Menu.Saida:
                            Saida();
                            break;
                        case Menu.Sair:
                            Escolheusair = true;

                            break;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("                   FECHANDO O PROGAMA              ");
                    Console.ReadLine();
                    Escolheusair = true;
                }
                Console.Clear();
            }
        }
        static void Listagem()
        {
            Console.WriteLine("lista de produtos");
            int i = 0;
            foreach (IEstoque produto in produtoss)
            {
                Console.WriteLine($"Id:   {i}");
                produto.Exibir();
                i++;
            }
            Console.ReadLine();
        }
        static void Cadastro()
        {
            Console.Clear();
            Console.WriteLine("cadastro de Produto");
            Console.WriteLine("1- Produto Fisico\n2- Ebook\n3- Curso");
            int esco = int.Parse(Console.ReadLine());
            if (esco > 0 && esco <= 3)
            {
                switch (esco)
                {
                    case 1:
                        CadastrarPDF();
                        break;
                    case 2:
                        CadastrarEbook();
                        break;
                    case 3:
                        Curso();
                        break;
                }

            }
            else
            {
                Console.Clear();
                Console.WriteLine("Retornando ao Menu");
                Console.ReadLine();
            }
        }
        static void CadastrarPDF()
        {
            Console.Clear();
            Console.WriteLine("Cadastrando Produto Fisico");
            Console.WriteLine("Nome:  ");
            string nome = Console.ReadLine();
            Console.WriteLine("Preço:  ");
            float preço = float.Parse(Console.ReadLine());
            Console.WriteLine("Qual o Frete Fixo do Produto");
            float frete = float.Parse(Console.ReadLine());
            ProdutoFisico pf = new ProdutoFisico(nome, preço, frete);
            produtoss.Add(pf);
            Salvar();
        }
        static void CadastrarEbook()
        {
            Console.Clear();
            Console.WriteLine("Cadastrando Ebook");
            Console.WriteLine("Nome:  ");
            string nome = Console.ReadLine();
            Console.WriteLine("Preço:  ");
            float preço = float.Parse(Console.ReadLine());
            Console.WriteLine("Qual o Autor:  ");
            string autor = Console.ReadLine();
            Ebook eb = new Ebook(nome, preço, autor);
            produtoss.Add(eb);
            Salvar();
        }
        static void Curso()
        {
            Console.Clear();
            Console.WriteLine("Cadastrando Curso");
            Console.WriteLine("Nome:  ");
            string nome = Console.ReadLine();
            Console.WriteLine("Preço:  ");
            float preço = float.Parse(Console.ReadLine());
            Console.WriteLine("Qual o Autor:  ");
            string autor = Console.ReadLine();
            Curso cs = new Curso(nome, preço, autor);
            produtoss.Add(cs);
            Salvar();
        }
        static void Salvar()
        {
            FileStream stream = new FileStream("Salvar.ar", FileMode.OpenOrCreate);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(stream, produtoss);
            stream.Close();
        }
        static void carregar()
        {
            FileStream stream = new FileStream("Salvar.ar", FileMode.OpenOrCreate);
            BinaryFormatter bf = new BinaryFormatter();
            try
            {
                produtoss = (List<IEstoque>)bf.Deserialize(stream);

                if (produtoss == null)
                {

                    produtoss = new List<IEstoque>();
                }
            }
            catch (Exception e)
            {
            }

            stream.Close();
        }
        static void remover()
        {
            Listagem();
            Console.WriteLine("Qual Produto Gostaria de Remover:  \n--Digite o ID dele--");
            int id = int.Parse(Console.ReadLine());
            if (id >= 0 && id <= produtoss.Count)
            {
                produtoss.RemoveAt(id);
                Salvar();
            }
        }
        static void Entrada()
        {
            Listagem();
            Console.WriteLine("Qual Produto Gostaria de dar entrada:  \n--Digite o ID dele--");
            int id = int.Parse(Console.ReadLine());
            if (id >= 0 && id < produtoss.Count)
            {
                produtoss[id].AdicionarEntrada();
                Salvar();
            }
        }
        static void Saida()
        {
            Listagem();
            Console.WriteLine("Qual Produto Gostaria de dar baixa:  \n--Digite o ID dele--");
            int id = int.Parse(Console.ReadLine());
            if (id >= 0 && id < produtoss.Count)
            {
                produtoss[id].AdicionarSAIDA();
                Salvar();
            }
        }
    } 
}
