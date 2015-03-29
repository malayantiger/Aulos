using Aulos.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aulos.Infrastructure.Data
{
    public class TagLibTrackFileDtoAdapter : ITrackDto
    {
        private TagLib.Tag _trackMetadata;

        private string _title;
        public string Title 
        {
            get { return _title ?? (_title = _trackMetadata.Title); }
            set { _title = value; }
        }

        public TagLibTrackFileDtoAdapter(TagLib.Tag trackMetadata)
        {
            if (trackMetadata == null)
            {
                throw new ArgumentNullException("Track metadata cannot be null.");
            }

            _trackMetadata = trackMetadata;
        }
    }
}
