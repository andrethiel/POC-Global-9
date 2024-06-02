using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC.Dados.Models
{
    public class Relatorio
    {
        public DateTime? DataDe { get; private set; }
        public DateTime? DataAte { get; private set; }
        public int FornecedorId { get; private set; }
        public int MaterialId { get; private set; }
        public string TipoOperacao { get; private set; }
        public string CodigoMaterial { get; private set; }
        public DateTime Data { get; set; }
        public decimal Quantidade { get; set; }
        public decimal Valor { get; set; }
        public Relatorio()
        {
            
        }
        public Relatorio(string dataDe, string dataAte, int fornecedor, int material, string tipoOperacao)
        {
            this.DataDe = Convert.ToDateTime(dataDe);
            this.DataAte = Convert.ToDateTime(dataAte);
            this.FornecedorId = fornecedor;
            this.MaterialId = material;
            this.TipoOperacao = tipoOperacao;
        }
    }
}
