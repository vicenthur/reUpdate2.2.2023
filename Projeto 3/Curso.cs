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
    class Curso : Produto, IEstoque
    {
        public string autor;
        private int vagas;

        public Curso(string nome, float preço,string autor)
        {
            this.nome = nome;
            this.Preço = preço;
            this.autor = autor;
        }

        public void AdicionarSAIDA()
        {
            Console.WriteLine($"deseja tirar quantas vagas do produto{nome}");
            Console.WriteLine("digite a Qtd que voce quer tirar ");
            int entrada = int.Parse(Console.ReadLine());
            // estoque = estoque + entrada;
            vagas -= entrada;
            Console.WriteLine("Saida registrada");
            Console.ReadLine();

        }

        public void AdicionarEntrada()
        {
            Console.WriteLine($"adicionar vagas no curso {nome}");
            Console.WriteLine("digite a Qtd que voce quer");
            int entrada = int.Parse(Console.ReadLine());
            // estoque = estoque + entrada;
            vagas = +entrada;
            Console.WriteLine("Entrada registrada");
            Console.ReadLine();
        }

        public void Exibir()
        {
            Console.WriteLine($"Nome:   {nome}");
            Console.WriteLine($"Autor:  {autor}");
            Console.WriteLine($"Preço:  {Preço}");
            Console.WriteLine($"Vagas Restantes:  {vagas}");
            Console.WriteLine("=============================");
        }
    }
}
