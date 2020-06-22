using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teste_aula_13.Model
{
    public class Empregado
    {
        public int Matricula { get; set; }

        public String Nome { get; set; }

        public String Endereco { get; set; }

        public float Salario { get; set; }

        public int Coddep { get; set; }

        public String Cargo { get; set; }

        public override string ToString()
        {
            return "Empregado{" +
                   "matricula=" + Matricula +
                   ", nome='" + Nome + '\'' +
                   ", endereco='" + Endereco + '\'' +
                   ", salario=" + Salario +
                   ", coddep=" + Coddep +
                   ", cargo='" + Cargo + '\'' +
                   '}';
        }
    }
}
