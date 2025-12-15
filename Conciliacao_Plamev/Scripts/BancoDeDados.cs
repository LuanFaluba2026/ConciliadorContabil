using DocumentFormat.OpenXml.Office.Word;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conciliacao_Plamev.Scripts
{
    public class BancoDeDados
    {
        private static SQLiteConnection? sqliteConnection;

        public static string _empresa;
        public static string empresa {
            get { return Directory.GetFiles(Form1.dbPath).FirstOrDefault(x => x.Contains(_empresa, StringComparison.OrdinalIgnoreCase) && !x.Contains("BACKUP")) ?? ""; }
            set { _empresa = value; }
        }
        private static SQLiteConnection DbConnection()
        {
            sqliteConnection = new SQLiteConnection($"Data Source={empresa}; Version=3");
            sqliteConnection.Open();
            return sqliteConnection;
        }
        public static void CriarBancoSQlite(string tipo = "Fornecedor")
        {
            try
            {
                string combinedPath = Path.Combine(Form1.dbPath,$"{_empresa}_{tipo}.sqlite");
                if (!File.Exists(combinedPath))
                    SQLiteConnection.CreateFile(combinedPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void ExcluirBancoSQlite(string empresa)
        {
            try
            {
                string combinedPath = Path.Combine(Form1.dbPath, empresa + ".sqlite");
                if (File.Exists(combinedPath))
                    File.Delete(combinedPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void CriarTabelaSQLite()
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS Movimento (idx INTEGER NOT NULL, codigoForn TEXT NOT NULL, dataMov TEXT NOT NULL, historico TEXT, valorDebito REAL, valorCredito REAL, numNota TEXT, dataEncerramento TEXT, PRIMARY KEY (idx, dataMov, historico));";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS CadastroContas (codigo TEXT NOT NULL, contaAnalitica TEXT, nomeFornecedor TEXT NOT NULL, PRIMARY KEY(codigo));";
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void AddMovimento(Movimento mov)
        {
            try
            {
                int quantidadeDB = BancoDeDados.GetMovimentos().Count + 1;
                using (var cmd = DbConnection().CreateCommand())
                {
                    Debug.WriteLine($"{mov.codigoForn} | {mov.dataMov} | {mov.historico} | {mov.notaRef} | {mov.credito} | {mov.debito}");

                    cmd.CommandText = "INSERT OR IGNORE INTO Movimento(idx, codigoForn, dataMov, historico, valorDebito, valorCredito, numNota, dataEncerramento) SELECT IFNULL(MAX(idx), 0) + 1, @codigoForn, @dataMov, @historico, @valorDebito, @valorCredito, @numNota, @dataEncerramento FROM Movimento";
                    cmd.Parameters.AddWithValue("@codigoForn", mov.codigoForn);
                    cmd.Parameters.AddWithValue("@dataMov", mov.dataMov);
                    cmd.Parameters.AddWithValue("@historico", mov.historico);
                    cmd.Parameters.AddWithValue("@valorDebito", mov.debito);
                    cmd.Parameters.AddWithValue("@valorCredito", mov.credito);
                    cmd.Parameters.AddWithValue("@numNota", mov.notaRef);
                    cmd.Parameters.AddWithValue("@dataEncerramento", mov.dataEncerramento);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void AddConta(CodigoContas conta)
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "INSERT OR IGNORE INTO CadastroContas(codigo, contaAnalitica, nomeFornecedor) values (@codigo, @contaAnalitica, @nomeFornecedor)";
                    cmd.Parameters.AddWithValue("@codigo", conta.codigoForn);
                    cmd.Parameters.AddWithValue("@contaAnalitica", conta.contaAnalitica);
                    cmd.Parameters.AddWithValue("@nomeFornecedor", conta.nomeForn);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void RemoveConta(string codigoConta)
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM CadastroContas WHERE codigo=@Codigo";
                    cmd.Parameters.AddWithValue("@Codigo", codigoConta);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void EncerrarMovimento(string codigo, string historico, string data)
        {
            try
            {
                using (var cmd = new SQLiteCommand(DbConnection()))
                {
                    cmd.CommandText = "UPDATE Movimento SET dataEncerramento=@DataEncerramento WHERE codigoForn=@Codigo AND historico=@Historico";
                    cmd.Parameters.AddWithValue("@DataEncerramento", data);
                    cmd.Parameters.AddWithValue("@Historico", historico);
                    cmd.Parameters.AddWithValue("@Codigo", codigo);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        public static List<Movimento> GetMovimentos()
        {
            List<Movimento> lista = new();
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Movimento";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Movimento
                            {
                                idx = (long)reader["idx"],
                                codigoForn = reader["codigoForn"].ToString(),
                                dataMov = reader["dataMov"].ToString(),
                                historico = reader["historico"].ToString(),
                                debito = Convert.ToDouble(reader["valorDebito"]),
                                credito = Convert.ToDouble(reader["valorCredito"]),
                                notaRef = reader["numNota"].ToString(),
                                dataEncerramento = reader["dataEncerramento"].ToString()
                            });

                        }
                        return lista;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new Exception(ex.Message);
            }
        }
        public static List<CodigoContas> GetContas()
        {
            List<CodigoContas> lista = new();
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM CadastroContas";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new CodigoContas
                            {
                                codigoForn = reader["codigo"].ToString(),
                                contaAnalitica = reader["contaAnalitica"].ToString(),
                                nomeForn = reader["nomeFornecedor"].ToString()
                            });

                        }
                        return lista;
                    }
                }
                ;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static void ExcluirMovimento(long index)
        {
            try
            {
                using (var cmd = new SQLiteCommand(DbConnection()))
                {
                    cmd.CommandText = "DELETE FROM Movimento Where idx=@Index";
                    cmd.Parameters.AddWithValue("@Index", index);
                    cmd.ExecuteNonQuery();
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void UpdateMovimento(Movimento mov, long index)
        {
            try
            {
                using (var cmd = new SQLiteCommand(DbConnection()))
                {
                    cmd.CommandText = "UPDATE Movimento SET dataMov = @dataMov, historico = @historico, valorDebito = @valorDebito, valorCredito = @valorCredito, numNota = @notaRef, dataEncerramento = @dataEncerramento WHERE idx=@Index";
                    cmd.Parameters.AddWithValue("@dataMov", mov.dataMov);
                    cmd.Parameters.AddWithValue("@historico", mov.historico);
                    cmd.Parameters.AddWithValue("@valorDebito", mov.debito);
                    cmd.Parameters.AddWithValue("@valorCredito", mov.credito);
                    cmd.Parameters.AddWithValue("@notaRef", mov.notaRef);
                    cmd.Parameters.AddWithValue("@dataEncerramento", mov.dataEncerramento);
                    cmd.Parameters.AddWithValue("@Index", index);
                    cmd.ExecuteNonQuery();
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void ValidaçãoDB()
        {
            using (var cmd = new SQLiteCommand(DbConnection()))
            {
                if (Program.ClienteFornecedor() == "Fornecedor")
                {
                    cmd.CommandText = "UPDATE Movimento SET valorDebito = -ABS(valorDebito);";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "UPDATE Movimento SET valorCredito = ABS(valorCredito)";
                    cmd.ExecuteNonQuery();
                }
                else if(Program.ClienteFornecedor() == "Cliente")
                {
                    cmd.CommandText = "UPDATE Movimento SET valorDebito = ABS(valorDebito);";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "UPDATE Movimento SET valorCredito = -ABS(valorCredito)";
                    cmd.ExecuteNonQuery();
                }
                cmd.CommandText = "UPDATE Movimento SET idx = rowid";
                cmd.ExecuteNonQuery();
            }
        }
    }
}
