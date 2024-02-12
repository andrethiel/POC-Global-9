using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC.Dados.Models
{
    public class Fornecedor
    {
        public int ID { get; private set; }
        public string CNPJ { get; private set; }
        public string RazaoSocial { get; private set; }

        public Fornecedor()
        {
            
        }

        public Fornecedor(int id, string cnpj, string razaoSocial)
        {
            ID = id;
            CNPJ = cnpj;
            RazaoSocial = razaoSocial;
        }
    }
}
