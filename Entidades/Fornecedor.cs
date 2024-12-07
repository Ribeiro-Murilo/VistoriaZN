namespace VistoriaZN.Entidades
{
    public class Fornecedor
    {
        public Fornecedor() { }
        public Fornecedor(int Id, string Nome, string Telefone, bool ativo)
        {
            this.Id = Id;
            this.Nome = Nome;
            this.Telefone = Telefone;
            this.Ativo = ativo;
        }
        public Fornecedor(string Nome, string Telefone)
        {
            this.Nome = Nome;
            this.Telefone = Telefone;
            this.Ativo = true;
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public bool Ativo { get; set; }
    }
}
