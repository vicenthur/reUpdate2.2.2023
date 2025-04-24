using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Projeto_3
{
    [System.Serializable]
    class ProdutoFisico : Produto, IEstoque
    {
        public float Frete;
        private int Estoque;

        public ProdutoFisico(string Nome, float Preço, float Frete)
        { 
            this.nome = Nome;
            this.Preço = Preço;
            this.Frete = Frete;          
        }

        public void AdicionarSAIDA ()
        {
            Console.WriteLine($"tirar entrada no estoque do produto{nome}");
            Console.WriteLine("digite a Qtd que voce quer tirar entrada");
            int entrada = int.Parse(Console.ReadLine());
            // estoque = estoque + entrada;
            Estoque -= entrada;
            Console.WriteLine("Saida registrada");
            Console.ReadLine();
        }

        public void AdicionarEntrada()
        {
            Console.WriteLine($"adicionar entrada no estoque do produto{nome}");
            Console.WriteLine("digite a Qtd que voce quer da entrada");
            int entrada = int.Parse( Console.ReadLine() );  
            // estoque = estoque + entrada;
            Estoque =+ entrada;
            Console.WriteLine("Entrada registrada");
            Console.ReadLine();
        }

        public void Exibir()
        {
            Console.WriteLine($"Nome:   {nome}");
            Console.WriteLine($"Valor do Frete:  {Frete}");
            Console.WriteLine($"Preço:  {Preço}");
            Console.WriteLine($"Quantos temos:  {Estoque}");
            Console.WriteLine("=============================");
        }
    }
}
