using Aulos.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aulos.Core.Domain.Factories
{
    public class AlbumFactory : IAlbumFactory
    {
        protected IArtistFactory _artistFactory;

        public AlbumFactory(IArtistFactory artistFactory)
        {
            _artistFactory = artistFactory;
        }

        public Album Create()
        {
            var album = new Album();
            album.Artist = _artistFactory.Create();

            return album;
        }
    }
}
