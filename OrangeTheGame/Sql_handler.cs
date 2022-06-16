using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace OrangeTheGame
{
    public class Sql_handler
    {
        #region Variables
        private  SqlConnection con = new SqlConnection("server=(localdb)\\MSSQLLocalDB; Integrated Security = true;");
        private string username;
        private string password;
        private SqlCommand cmd;
        private int progress = 1;
        private int size_width = 800;
        private int size_height = 450;
        private bool music;
        private bool fullscreen;
        #endregion

        #region Constructor
        public Sql_handler()
        {

        }
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

        public int Progress
        {
            get { return progress; }
            set { progress = value; }
        }

        public int Size_Width
        {
            get { return size_width; }
            set { size_width = value; }
        }

        public int Size_Height
        {
            get { return size_height; }
            set { size_height = value; }
        }

        public bool Music
        {
            get { return music; }
            set { music = value; }
        }

        public bool Fullscreen
        {
            get { return fullscreen; }
            set { fullscreen = value; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// creating the database and table to save the users preferences and progress
        /// </summary>
        /// <param name="connection"></param>
        public void create_db(SqlConnection connection)
        {
            Cmd = new SqlCommand();
            Cmd.Connection = connection;
            try
            {
                Cmd.CommandText = "create database orange;";
                Cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                //Database already exists
            }

            Cmd.CommandText = "use orange;";
            Cmd.ExecuteNonQuery();

            try
            {
                Cmd.CommandText = "create table login(UID int primary key identity(1,1), username varchar(30), password varchar(100), progress int, width int, height int, fullscreen varchar(10), music varchar(10));";
                Cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                // table already exists
            }
        }

        /// <summary>
        /// saving a new users data
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="progress"></param>
        /// <param name="size_width"></param>
        /// <param name="size_height"></param>
        /// <param name="fullscreen"></param>
        /// <param name="music"></param>
        /// <returns></returns>
        public string signup(string username, string password, int progress, int size_width, int size_height, bool fullscreen, bool music)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            Cmd = new SqlCommand();
            Cmd.Connection = con;
            Cmd.CommandText = "select username from login;";
            SqlDataReader reader = Cmd.ExecuteReader();
            while (reader.Read())
            {
                if (username.Equals(reader.GetString(0)))
                {
                    reader.Close();
                    return "Username already exists";
                }
            }
            reader.Close();

            if(username.Length > 30)
            {
                return "Username is too long";
            }

            try
            {
                string pasword_hashed = BCrypt.HashPassword(password, BCrypt.GenerateSalt());
                Cmd.CommandText = "insert into login (username, password, progress, width, height, fullscreen, music) " +
                    "values('" + username + "', '" + pasword_hashed + "', " + progress + ", " + size_width + ", " + size_height + ", '" + fullscreen.ToString() + "', '" + music.ToString() + "');";
                Cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

            return "success";
        }

        /// <summary>
        /// reading the users data to load his progress and preferences
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="con"></param>
        /// <returns></returns>
        public bool signin(string username, string password, SqlConnection con)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            Cmd = new SqlCommand();
            Cmd.Connection = con;
            create_db(con);
            Cmd.CommandText = "use orange;";
            Cmd.ExecuteNonQuery();
            Cmd.CommandText = "select username from login;";
            SqlDataReader reader = Cmd.ExecuteReader();
            while (reader.Read())
            {
                if (username.Equals(reader.GetString(0)))
                {
                    reader.Close();
                    Cmd.CommandText = "select password from login where username = '" + username + "';";
                    reader = Cmd.ExecuteReader();
                    reader.Read();
                    if (BCrypt.CheckPassword(password, reader.GetString(0)))
                    {
                        reader.Close();
                        return true;
                    }
                }
            }
            return false;
        }
        #endregion

    }
}
