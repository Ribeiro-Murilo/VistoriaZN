using VistoriaZN.Entidades;

namespace VistoriaZN.Metodos
{
    public static class Metodos
    {
        static readonly string caminhoArquivoFornecedor = @"D:\base_de_dados_Fornecedor.csv";
        static readonly string caminhoArquivoVistoria = @"D:\base_de_dados_Vistoria.csv";

        public static void criarArmazenamento()
        {
            string[] iniciarFornecedor = {
                "Id;Nome;Telefone",
            };
            string[] iniciarVistoria = {
                "Id;Nome;FornecedorId;Valor;Placa;Modelo"
            };
            try
            {
                if (!File.Exists(caminhoArquivoFornecedor))
                {
                    File.WriteAllLines(caminhoArquivoFornecedor, iniciarFornecedor);
                }
                if (!File.Exists(caminhoArquivoVistoria))
                {
                    File.WriteAllLines(caminhoArquivoVistoria, iniciarVistoria);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao criar o arquivo CSV: {ex.Message}");
            }
        }

        public static Fornecedor GetFornecedor(int Id)
        {
            try
            {
                string[] linhas = File.ReadAllLines(caminhoArquivoFornecedor);

                for (int i = 1; i < linhas.Length; i++)
                {
                    string linha = linhas[i];
                    string[] colunas = linha.Split(';');

                    if (int.Parse(colunas[0]) == Id)
                    {
                        return new Fornecedor
                        {
                            Id = int.Parse(colunas[0]),
                            Nome = colunas[1],
                            Telefone = colunas[3]
                        };
                    }
                }
                MessageBox.Show(
                    $"Não encontrado",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return new Fornecedor();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Arquivo não encontrado no caminho: {caminhoArquivoFornecedor} ||| {ex}",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return new Fornecedor();
            }
        }

        public static List<Fornecedor> GetListFornecedor()
        {
            try
            {
                string[] linhas = File.ReadAllLines(caminhoArquivoFornecedor);

                List<Fornecedor> fornecedores = new List<Fornecedor>();

                for (int i = 1; i < linhas.Length; i++)
                {
                    string linha = linhas[i];
                    string[] colunas = linha.Split(';');

                    Fornecedor fornecedor = new Fornecedor(int.Parse(colunas[0]), colunas[1], colunas[3]);

                    fornecedores.Add(fornecedor);
                }
                return fornecedores;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"{caminhoArquivoFornecedor} ||||||||| " + ex,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return new List<Fornecedor>();
            }
        }
        
        public static Vistoria GetVistoria(int Id)
        {
            try
            {
                string[] linhas = File.ReadAllLines(caminhoArquivoVistoria);

                for (int i = 1; i < linhas.Length; i++)
                {
                    string linha = linhas[i];
                    string[] colunas = linha.Split(';');

                    if (int.Parse(colunas[0]) == Id)
                    {
                        DateTime DtRealizado;
                        DateTime DtPago;

                        DateTime.TryParse(colunas[7], out DtRealizado);
                        DateTime.TryParse(colunas[8], out DtPago);

                        return new Vistoria(
                            int.Parse(colunas[0]),
                            colunas[1],
                            GetFornecedor(int.Parse(colunas[3])),
                            int.Parse(colunas[2]),
                            int.Parse(colunas[4]),
                            colunas[5],
                            colunas[6],
                            DtRealizado,
                            DtPago
                        );
                    }
                }
                MessageBox.Show(
                    $"Não encontrado",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return new Vistoria();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Arquivo não encontrado no caminho: {caminhoArquivoFornecedor} ||| {ex}",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return new Vistoria();
            }
        }

        public static List<Vistoria> GetListVistoria(int fornecedorId)
        {
            try
            {
                string[] linhas = File.ReadAllLines(caminhoArquivoFornecedor);

                List<Vistoria> Vistorias = new List<Vistoria>();

                for (int i = 1; i < linhas.Length; i++)
                {
                    string linha = linhas[i];
                    string[] colunas = linha.Split(';');

                    DateTime DtRealizado;
                    DateTime DtPago;

                    DateTime.TryParse(colunas[7], out DtRealizado);
                    DateTime.TryParse(colunas[8], out DtPago);

                    Vistoria vistoria = new Vistoria(
                        int.Parse(colunas[0]),
                        colunas[1],
                        GetFornecedor(int.Parse(colunas[3])),
                        int.Parse(colunas[2]),
                        int.Parse(colunas[4]),
                        colunas[5],
                        colunas[6],
                        DtRealizado,
                        DtPago
                    );

                    Vistorias.Add(vistoria);
                }
                return Vistorias;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"{caminhoArquivoFornecedor} ||||||||| " + ex,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return new List<Vistoria>();
            }
        }
        
        public static List<Vistoria> GetListVistoriaMes()
        {
            DateTime Hj = DateTime.Now;
            try
            {
                string[] linhas = File.ReadAllLines(caminhoArquivoFornecedor);

                List<Vistoria> Vistorias = new List<Vistoria>();

                for (int i = 1; i < linhas.Length; i++)
                {
                    string linha = linhas[i];
                    string[] colunas = linha.Split(';');

                    DateTime DtRealizado;
                    DateTime DtPago;

                    DateTime.TryParse(colunas[7], out DtRealizado);
                    DateTime.TryParse(colunas[8], out DtPago);

                    Vistoria vistoria = new Vistoria(
                        int.Parse(colunas[0]),
                        colunas[1],
                        GetFornecedor(int.Parse(colunas[3])),
                        int.Parse(colunas[2]),
                        int.Parse(colunas[4]),
                        colunas[5],
                        colunas[6],
                        DtRealizado,
                        DtPago
                    );

                    if (vistoria.DtRealizado.Month == Hj.Month && vistoria.DtRealizado.Year == Hj.Year)
                    {
                        Vistorias.Add(vistoria);
                    }
                }
                return Vistorias;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"{caminhoArquivoFornecedor} ||||||||| " + ex,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return new List<Vistoria>();
            }
        }

        public static List<Vistoria> GetListVistoriaMesFornecedor(int fornecedorId)
        {
            return GetListVistoriaMes().Where(o=> o.FornecedorId.HasValue && o.FornecedorId == fornecedorId).ToList();
        }
    }
}
