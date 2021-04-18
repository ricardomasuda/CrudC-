using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Macorati.Models
{
    public class Lanches
    {
        public int LancheId { get; set; }
        public int CategoriaId {get ;set ;}
        public string DescricaoCurta { get; set; }
        public string DescricaoDetalhada { get; set; }
        public string EmEstoque { get; set; }
        public string ImagemThumbnailUrl { get; set; }
        public string Imagemurl { get; set; }
        public string IsLanchePreferico { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public List<Lanches> LanchesList { get; set; }

        public List<Lanches> GetLanches()
        {
            DataAccess data = new DataAccess();
            var sql = "SELECT `LancheId`,`CategoriaId`,`DescricaoCurta`,`DescricaoDetalhada`,`EmEstoque`,`ImagemThumbnailUrl`,`ImagemUrl`,`IsLanchePreferido`,`Nome`,`Preco` FROM `lanches` WHERE 1";
             LanchesList = new List<Lanches>();
            MySqlDataReader myReader = data.select(sql);
            while (myReader.Read())
            {
                Lanches lanches = new Lanches();
                lanches.LancheId = Convert.ToInt32(myReader.GetValue(0));
                lanches.CategoriaId = Convert.ToInt32(myReader.GetValue(1));
                lanches.DescricaoCurta = myReader.GetString(2);
                lanches.DescricaoDetalhada = myReader.GetString(3);
                lanches.EmEstoque = myReader.GetString(4);
                lanches.ImagemThumbnailUrl = myReader.GetString(5);
                lanches.Imagemurl = myReader.GetString(6);
                lanches.IsLanchePreferico = myReader.GetString(7);
                lanches.Nome = myReader.GetString(8);
                lanches.Preco = Convert.ToDecimal(myReader.GetValue(9));

                LanchesList.Add(lanches);


            }

            myReader.Close();
            data.connection.Close();


            return LanchesList;
        }

    }
}
