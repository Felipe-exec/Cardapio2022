using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cardápio_Hamburgueria_Online
{
    class Cardapio
    {
        string nome, acompanhamento;
        float valor;

        public string Nome { get => nome; set => nome = value; }
        public string Acompanhamento { get => acompanhamento; set => acompanhamento = value; }
        public float Valor { get => valor; set => valor = value; }
    }
}
