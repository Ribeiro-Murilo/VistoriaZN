using System.Drawing;

namespace VistoriaZN.Entidades
{
    public class Vistoria
    {
        public Vistoria() {}
        public Vistoria(int Id, string Nome, Fornecedor? Fornecedor, int? FornecedorId, int Valor, string Placa, string Modelo, DateTime DtRealizado, DateTime? DtPago)
        {
            this.Id = Id;
            this.Nome = Nome;
            this.Fornecedor = Fornecedor;
            this.FornecedorId = FornecedorId;
            this.Valor = Valor;
            this.Placa = Placa;
            this.Modelo = Modelo;
            this.DtRealizado = DtRealizado ;
            this.DtPago = DtPago;
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public Fornecedor? Fornecedor { get; set; }
        public int? FornecedorId { get; set; }
        public int Valor { get; set; }
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public DateTime DtRealizado { get; set; }
        public DateTime? DtPago { get; set; }
    }
}
