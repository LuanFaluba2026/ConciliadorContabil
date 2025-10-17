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
            sqliteConnection = new SQLiteConnection("Data Source=c:\\Data\\SaldosEmAberto.sqlite; Version=3");
            sqliteConnection.Open();
            return sqliteConnection;
        }
        public static void CriarBancoSQlite()
        {
            try
            {
                SQLiteConnection.CreateFile(@"c:\Data\SaldosEmAberto.sqlite");
            }catch
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
                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS SaldosEmAberto (codigoForn TEXT NOT NULL, dataMov TEXT NOT NULL, notaRef TEXT, historico TEXT, credito REAL, dataEncerramento TEXT, PRIMARY KEY (codigoForn, historico));";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS CadastroContas (codigo TEXT NOT NULL, contaAnalitica TEXT NOT NULL, nomeFornecedor TEXT NOT NULL, saldo REAL, PRIMARY KEY(codigo));";
                    cmd.ExecuteNonQuery();
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void AddSaldo(MovimentosAbertos mov)
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "INSERT OR IGNORE INTO SaldosEmAberto(codigoForn, dataMov, notaRef, historico, credito) values (@codigoForn, @dataMov, @notaRef, @historico, @credito)";
                    cmd.Parameters.AddWithValue("@codigoForn", mov.codigoForn);
                    cmd.Parameters.AddWithValue("@dataMov", mov.dataMov);
                    cmd.Parameters.AddWithValue("@notaRef", mov.notaRef);
                    cmd.Parameters.AddWithValue("@historico", mov.historico);
                    cmd.Parameters.AddWithValue("@credito", mov.credito);
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "DELETE FROM SaldosEmAberto WHERE credito = 0;";
                    cmd.ExecuteNonQuery();
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void EncerrarSaldo(string codigo, string historico, string data)
        {
            try
            {
                using (var cmd = new SQLiteCommand(DbConnection()))
                {
                    cmd.CommandText = "UPDATE SaldosEmAberto SET dataEncerramento=@DataEncerramento WHERE codigoForn=@Codigo AND historico=@Historico";
                    cmd.Parameters.AddWithValue("@DataEncerramento", data);
                    cmd.Parameters.AddWithValue("@Historico", historico);
                    cmd.Parameters.AddWithValue("@Codigo", codigo);
                    cmd.ExecuteNonQuery();
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void AddConta(CodigoContas contas)
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "INSERT OR IGNORE INTO CadastroContas(codigo, contaAnalitica, nomeFornecedor, saldo) values (@codigo, @contaAnalitica, @nomeFornecedor, @saldo)";
                    cmd.Parameters.AddWithValue("@codigo", contas.codigo);
                    cmd.Parameters.AddWithValue("@contaAnalitica", contas.contaAnalitica);
                    cmd.Parameters.AddWithValue("@nomeFornecedor", contas.nomeFornecedor);
                    cmd.Parameters.AddWithValue("@saldo", contas.saldo);
                    cmd.ExecuteNonQuery();
                }

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static List<MovimentosAbertos> GetSaldos()
        {
            List<MovimentosAbertos> lista = new();
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM SaldosEmAberto";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            lista.Add(new MovimentosAbertos
                            {
                                codigoForn = reader["codigoForn"].ToString(),
                                dataMov = reader["dataMov"].ToString(),
                                notaRef = reader["notaRef"].ToString(),
                                historico = reader["historico"].ToString(),
                                credito = Convert.ToDouble(reader["credito"]),
                                dataEncerramento = reader["dataEncerramento"].ToString()
                            });

                        }
                        return lista;
                    }
                };
            }catch(Exception ex)
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
                                codigo = reader["codigo"].ToString(),
                                contaAnalitica = reader["contaAnalitica"].ToString(),
                                nomeFornecedor = reader["nomeFornecedor"].ToString(),
                                saldo = Convert.ToDouble(reader["saldo"])
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
        public static void UpdateSaldo(string conta, double saldo)
        {
            try
            {
                using (var cmd = new SQLiteCommand(DbConnection()))
                {
                    cmd.CommandText = "UPDATE CadastroContas SET saldo=@Saldo WHERE codigo=@Codigo";
                    cmd.Parameters.AddWithValue("@Codigo", conta);
                    cmd.Parameters.AddWithValue("@Saldo", saldo);
                    cmd.ExecuteNonQuery();
                }
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void SomaSaldo(string conta, double saldo)
        {
            try
            {
                using (var cmd = new SQLiteCommand(DbConnection()))
                {
                    cmd.CommandText = "UPDATE CadastroContas SET saldo = saldo + @Saldo WHERE codigo=@Codigo";
                    cmd.Parameters.AddWithValue("@Codigo", conta);
                    cmd.Parameters.AddWithValue("@Saldo", saldo);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void DeleteSaldo(MovimentosAbertos saldo)
        {
            try
            {
                using (var cmd = new SQLiteCommand(DbConnection()))
                {
                    cmd.CommandText = "DELETE FROM SaldosEmAberto WHERE historico=@Historico AND notaRef=@NotaRef AND credito=@Credito";
                    cmd.Parameters.AddWithValue("@Historico", saldo.historico);
                    cmd.Parameters.AddWithValue("@NotaRef", saldo.notaRef);
                    cmd.Parameters.AddWithValue("@Credito", saldo.credito);
                    cmd.ExecuteNonQuery();
                }
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
