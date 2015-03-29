using Aulos.Core.Domain.Entities;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aulos.UI.ViewModels
{
    public class AlbumViewModel : Screen, IShell
    {
        private string _artist;
        public string Artist
        {
            get { return _artist; }
            set
            {
                _artist = value;
                NotifyOfPropertyChange(() => Artist);
            }
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                NotifyOfPropertyChange(() => Title);
            }
        }

        private string _path;
        public string Path
        {
            get { return _path; }
            set
            {
                _path = value;
                NotifyOfPropertyChange(() => Path);
            }
        }
    }
}
