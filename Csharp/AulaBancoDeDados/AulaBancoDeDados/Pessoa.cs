using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulaBancoDeDados
{
    class Pessoa
    {
        private int id = 0;
        public string nomeCompleto { get; set; }
        public string endereco { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string telefone { get; set; }
        public char sexo { get; set; }
        public string nascimento { get; set; }
        public bool fumante  { get; set; }
        public string propriedades { get; set; }
        public List<string> posses { get; set; }

        public Pessoa(string nc, string end, string b,string c, string tel, char s, string nasc, bool fum, List<string> lista)
        {
            nomeCompleto = nc;
            endereco = end;
            bairro = b;
            cidade = c;
            telefone = tel;
            sexo = s;
            nascimento = nasc;
            fumante = fum;
            posses = lista;
        }

        public Pessoa(int indice, string nc, string end, string b, string c, string tel, char s, string nasc, bool fum, List<string> lista)
        {
            id = indice;
            nomeCompleto = nc;
            endereco = end;
            bairro = b;
            cidade = c;
            telefone = tel;
            sexo = s;
            nascimento = nasc;
            fumante = fum;
            posses = lista;
        }
    }
}
