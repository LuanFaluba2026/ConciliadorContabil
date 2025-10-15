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
        private static SQLiteConnection sqliteConnection;

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
                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS SaldosEmAberto( codigoForn TEXT NOT NULL, dataMov TEXT NOT NULL, notaRef TEXT, historico TEXT, credito REAL, PRIMARY KEY(codigoForn);";
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
                                credito = Convert.ToDouble(reader["credito"])
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

    }
}
