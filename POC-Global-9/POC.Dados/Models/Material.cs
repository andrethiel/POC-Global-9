using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC.Dados.Models
{
    public class Material
    {
        public int Id { get; private set; }
        public string Codigo { get; private set; }
        public string NomeMaterial { get; private set; }
        public string UnidadeMedida { get; private set; }

        public Material()
        {
            
        }

        public Material(int id, string codigo, string nome, string unidade)
        {
            this.Id = id;
            this.Codigo = codigo;
            this.NomeMaterial = nome;
            this.UnidadeMedida = unidade;
        }
    }
}
