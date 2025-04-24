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
    class Ebook : Produto, IEstoque
    {
        public string autor;
        private int vendas;

        public Ebook(string nome, float preço, string autor)
        {
            this.nome = nome;
            this.Preço = preço;
            this.autor = autor;
        }

        public void AdicionarSAIDA()
        {
            Console.WriteLine($"deseja Adcionar quantas vendas ao produto{nome}");
            Console.WriteLine("digite a Qtd que voce quer colocar ");
            int entrada = int.Parse(Console.ReadLine());
            // estoque = estoque + entrada;
            vendas += entrada;
            Console.WriteLine("Saida registrada");
            Console.ReadLine();
        }

        public void AdicionarEntrada()
        {
            Console.WriteLine("não é possivel pq é um produto Digital");
            Console.ReadLine();
        }

        public void Exibir()
        {
            Console.WriteLine($"Nome:   {nome}");
            Console.WriteLine($"Autor:  {autor}");
            Console.WriteLine($"Preço:  {Preço}");
            Console.WriteLine($"Vedas:  {vendas}");
            Console.WriteLine("=============================");
        }
    }
}
