using MySql.Data.MySqlClient;

public class MySqlExec
{
    private static MySqlConnection Connection()
    {
        string strConnection = "server=127.0.0.1;uid=root;pwd=12345;database=test";
        MySqlConnection cnn = new MySqlConnection(strConnection);
        return cnn;
    }

    public class MySqlParams
    {
        private string Param { get; set; }
        private string Value { get; set; }
        public MySqlParams(string param, string value)
        {
            Param = param;
            Value = value;
        }
    }

    public static void ExecQuery(string query)
    {
        Connection().Open();
        MySqlCommand command = new MySqlCommand
        {
            Connection = Connection(),
            CommandText = query
        };
        command.ExecuteNonQuery();
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
        }
        Connection().Close();
    }
}
