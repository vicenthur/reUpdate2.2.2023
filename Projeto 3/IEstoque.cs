using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Projeto_3
{
    
    interface IEstoque
    {
        void Exibir();
        void AdicionarEntrada();
        void AdicionarSAIDA();
    }
}
