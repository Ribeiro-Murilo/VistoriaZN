using VistoriaZN.Entidades;

namespace VistoriaZN.Metodos
{
    public static class Metodos
    {
        static readonly string caminhoArquivoFornecedor = @"D:\base_de_dados_Fornecedor.csv";
        static readonly string caminhoArquivoVistoria = @"D:\base_de_dados_Vistoria.csv";

        public static bool ToBool(this string value)
        {
            if (bool.TryParse(value, out bool result))
            {
                return result;
            }
            if (value == "1" || value.Equals("sim", StringComparison.OrdinalIgnoreCase) || value.Equals("yes", StringComparison.OrdinalIgnoreCase) || value.Equals("True", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            if (value == "0" || value.Equals("não", StringComparison.OrdinalIgnoreCase) || value.Equals("no", StringComparison.OrdinalIgnoreCase) || value.Equals("False", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }
            return true;
        }

        public static int ToInt(this string value)
        {
            if (int.TryParse(value, out int result))
            {
                return result;
            }
            return 0;
        }

        public static void criarArmazenamento()
        {
            string[] iniciarFornecedor = {
                "Id;Nome;Telefone,Ativo",
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

        #region Parceiro
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
                            Telefone = colunas[2],
                            Ativo = colunas[3].ToBool()
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

        public static List<Fornecedor> GetListFornecedor(bool ativos)
        {
            try
            {
                string[] linhas = File.ReadAllLines(caminhoArquivoFornecedor);

                List<Fornecedor> fornecedores = new List<Fornecedor>();

                for (int i = 1; i < linhas.Length; i++)
                {
                    string linha = linhas[i];
                    string[] colunas = linha.Split(';');

                    if (colunas[3].ToBool() == ativos)
                    {
                        fornecedores.Add(new Fornecedor(colunas[0].ToInt(), colunas[1], colunas[2], colunas[3].ToBool()));
                    }
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

        public static void AdicionarParceiro(Fornecedor parceiro)
        {
            parceiro.Id = ObterProximoID(caminhoArquivoFornecedor);
            using (StreamWriter sw = new StreamWriter(caminhoArquivoFornecedor, append: true))
            {
                string linha = $"{parceiro.Id};{parceiro.Nome};{parceiro.Telefone};{parceiro.Ativo}";
                sw.WriteLine(linha);
            }
        }

        public static void AtualizarParceiro(Fornecedor parceiro)
        {
            try
            {
                string[] linhas = File.ReadAllLines(caminhoArquivoFornecedor);
                bool encontrou = false;

                for (int i = 1; i < linhas.Length; i++)
                {
                    string linha = linhas[i];
                    string[] colunas = linha.Split(';');

                    if (int.Parse(colunas[0]) == parceiro.Id)
                    {
                        linhas[i] = $"{parceiro.Id};{parceiro.Nome};{parceiro.Telefone};{parceiro.Ativo}";
                        encontrou = true;
                        break;
                    }
                }

                if (encontrou)
                {
                    File.WriteAllLines(caminhoArquivoFornecedor, linhas);

                    MessageBox.Show(
                        $"Registro atualizado com sucesso!",
                        "Sucesso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
                else
                {
                    MessageBox.Show(
                        $"Registro não encontrado.",
                        "Erro",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Erro ao atualizar registro: {ex.Message}",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
        #endregion

        #region Vistoria
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

        public static void AdicionarVistoria(Vistoria vistoria)
        {
            vistoria.Id = ObterProximoID(caminhoArquivoVistoria);
            using (StreamWriter sw = new StreamWriter(caminhoArquivoFornecedor, append: true))
            {
                string linha = $"{vistoria.Id};{vistoria.Nome};{vistoria.Fornecedor};{vistoria.FornecedorId};{vistoria.Valor};{vistoria.Placa};{vistoria.Modelo};{vistoria.DtRealizado};{vistoria.DtPago}";
                sw.WriteLine(linha);
            }
        }
        #endregion

        private static int ObterProximoID(string caminho)
        {
            if (!File.Exists(caminho) || new FileInfo(caminho).Length == 0)
            {
                return 1;
            }
            var linhas = File.ReadAllLines(caminho);
            var ultimaLinha = linhas.LastOrDefault(l => !string.IsNullOrWhiteSpace(l));

            if (ultimaLinha == null)
            {
                return 1;
            }
            var campos = ultimaLinha.Split(';');
            if (int.TryParse(campos[0], out int ultimoID))
            {
                return ultimoID + 1;
            }
            return 1;
        }
    }
}
