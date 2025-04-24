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
    abstract class Produto
    {
        public string nome;
        public float Preço;
    }
}
