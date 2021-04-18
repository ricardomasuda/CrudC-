using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Macorati.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public string TipoUsurio { get; set; }
        public User Login(string email, string senha)
        {
            DataAccess DataAcess = new DataAccess();

            var sql = "select u.Id , u.Email , u.Nome , u.Tipo from user as u  where email = '" + email + "' and senha = '" + senha + "'";
            User user = new User();

            MySqlDataReader myReader = DataAcess.select(sql);

            if (myReader.Read())
            {

                user.Id = Convert.ToInt32(myReader.GetValue(0));
                user.Email = myReader.GetString(1);
                user.Nome = myReader.GetString(2);
                user.TipoUsurio = myReader.GetString(3);
                //user.IdAtletica = Convert.ToInt32(myReader.GetValue(5));
                //user.Foto_Perfil = myReader.GetString(6);


                myReader.Close();
                DataAcess.connection.Close();

                //user.Atletica = GetAtletica(user.IdAtletica);
                //user.privilegios = getPrivilegiosFormUser(user.Id);
                return user;

            }
            myReader.Close();
            DataAcess.connection.Close();
            return null;

        }
    }
}
