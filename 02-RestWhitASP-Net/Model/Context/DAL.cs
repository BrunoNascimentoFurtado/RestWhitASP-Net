using MySqlConnector;
using System.Data;

namespace RestWhitASP_Net.Model.Context
{
    public class DAL
    {
        private static string Server = "localhost";
        private static string Database = "dbcliente";
        private static string User = "root";
        private static string Password = "123456";
        private MySqlConnection Connection;

        private string ConnectionString = $"Server={Server};Database={Database};Uid={User};pwd={Password};Sslmode = none;";

        public DAL()
        {
            Connection = new MySqlConnection(ConnectionString);
            Connection.Open();
        }

        // executa comandos : insert, update, delete
        public void ExecutarComendoSQl(string sql)
        {
            MySqlCommand Command = new MySqlCommand(sql, Connection);
            Command.ExecuteNonQuery();
        }

        //Retorna dados do banco 
        public DataTable RetornarDataTable(string sql)
        {
            MySqlCommand Command = new MySqlCommand(sql, Connection);
            MySqlDataAdapter DataAdapter = new MySqlDataAdapter(Command);

            DataTable dados = new DataTable();

            DataAdapter.Fill(dados);
            return dados;

        }
    }
}
