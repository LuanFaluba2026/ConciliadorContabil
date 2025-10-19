using DocumentFormat.OpenXml.Office.Word;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conciliacao_Plamev
{
    public class BancoDeDados
    {
        private static SQLiteConnection? sqliteConnection;

        private static SQLiteConnection DbConnection()
        {
            sqliteConnection = new SQLiteConnection("Data Source=c:\\Data\\BancoDeDados_Movimentação.sqlite; Version=3");
            sqliteConnection.Open();
            return sqliteConnection;
        }
        public static void CriarBancoSQlite()
        {
            try
            {
                SQLiteConnection.CreateFile(@"c:\Data\BancoDeDados_Movimentação.sqlite");
            }
            catch
            {
                throw;
            }
        }
        public static void CriarTabelaSQLite()
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS Movimento (codigoForn TEXT NOT NULL, dataMov TEXT NOT NULL, historico TEXT, valorDebito REAL, valorCredito REAL, numNota TEXT, dataEncerramento TEXT, PRIMARY KEY (codigoForn, historico));";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS CadastroContas (codigo TEXT NOT NULL, contaAnalitica TEXT NOT NULL, nomeFornecedor TEXT NOT NULL, PRIMARY KEY(codigo));";
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void AddMovimento(Movimento mov)
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "INSERT OR IGNORE INTO Movimento(codigoForn, dataMov, historico, valorDebito, valorCredito, numNota, dataEncerramento) values (@codigoForn, @dataMov, @historico, @valorDebito, @valorCredito, @numNota, @dataEncerramento)";
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
                throw new Exception(ex.Message);
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
                throw new Exception(ex.Message);
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
                throw new Exception(ex.Message);
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
                ;
            }
            catch (Exception ex)
            {
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
                throw new Exception(ex.Message);
            }
        }
    }
}
