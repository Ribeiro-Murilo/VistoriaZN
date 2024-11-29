namespace VistoriaZN.Entidades
{
    public class Fornecedor
    {
        public Fornecedor() { }
        public Fornecedor(int Id, string Nome, string Telefone)
        {
            this.Id = Id;
            this.Nome = Nome;
            this.Telefone = Telefone;
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
    }
}
