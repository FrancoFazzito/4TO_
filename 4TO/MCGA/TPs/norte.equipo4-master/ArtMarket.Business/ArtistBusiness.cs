using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtMarket.Data;
using ArtMarket.Entities.Model;

namespace ArtMarket.Business
{
    public class ArtistBusiness
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="artist"></param>
        /// <returns></returns>
        public Artist Add(Artist artist)
        {
            Artist result = default(Artist);
            var artistDAC = new ArtistDAC();

            result = artistDAC.Create(artist);
            return result;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void Remove(int id)
        {
            var artistDAC = new ArtistDAC();
            artistDAC.DeleteById(id);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Artist> List()
        {
            List<Artist> result = default(List<Artist>);
            var artistDAC = new ArtistDAC();
            result = artistDAC.Select();
            return result;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Artist Find(int id)
        {
            Artist result = default(Artist);
            var artistDAC = new ArtistDAC();
            result = artistDAC.SelectById(id);
            return result;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="artist"></param>
        public void Edit(Artist artist)
        {
            var artistDAC = new ArtistDAC();
            artistDAC.UpdateById(artist);
        }
    }
}
