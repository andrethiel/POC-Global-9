using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC.Dados.Models
{
    public class Estoque
    {
        public int Id { get; private set; }
        public DateTime Data { get; private set; }
        public int FornecedorId { get; private set; }
        public int MaterialId { get; private set; }
        public decimal Quantidade { get; private set; }
        public decimal Valor { get; private set; }
        public string TipoOperacao { get; private set; }
        public string ForncedorCNPJ { get; set; }
        public string NomeMaterial { get; set; }
        public string CodigoMaterial { get; set; }

        public Estoque()
        {
            
        }

        public Estoque(int id, string data, int fornecedor, int material, string quantidade, float valor, string operacao)
        {
            this.Id = id;
            this.Data = Convert.ToDateTime(data);
            this.FornecedorId = fornecedor;
            this.MaterialId = material;
            this.Quantidade = Convert.ToDecimal(quantidade);
            this.Valor = Convert.ToDecimal(valor);
            this.TipoOperacao = operacao;
        }
    }
}
