using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace OrangeTheGame
{
    class Sql_handler
    {
        static SqlConnection conn = new SqlConnection("localdb\\MSSQLLocalDB");
        #region Variables
        private SqlConnection con;
        private string username;
        private string password;
        private SqlCommand cmd;
        #endregion

        #region Constructor
        #endregion

        #region Properties
        public SqlConnection Con
        {
            get { return con; }
            set { con = value; }
        }

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public SqlCommand Cmd
        {
            get { return cmd; }
            set { cmd = value; }
        }
        #endregion

        #region Methods
        public void create_db()
        {
            Cmd.Connection = conn;
            Cmd.CommandText = "create database orange;";
            Cmd.ExecuteNonQuery();

            Cmd.CommandText = "use orange;";
            Cmd.ExecuteNonQuery();

            Cmd.CommandText = "create table login(int UID primary key identity(1,1), varchar(30) username, varchar(100) password, int progress, int width, int height, bool music);";
            Cmd.ExecuteNonQuery();
        }

        public string signup()
        {
            Cmd.CommandText = "select username from login;";
            Cmd.ExecuteNonQuery();
            SqlDataReader reader = Cmd.ExecuteReader();
            while (reader.Read())
            {
                if (username.Equals(reader.GetString(0)))
                {
                    return "Username already exists";
                }
            }

            if(username.Length > 30)
            {
                return "Username is too long";
            }

            try
            {
                string pasword_hashed = BCrypt.HashPassword(password, BCrypt.GenerateSalt());
                Cmd.CommandText = "insert into table login (username, password) values('" + username + "', '" + pasword_hashed + "');";
            }
        }
        #endregion

    }
}
