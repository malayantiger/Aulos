using Aulos.Core.Data;
using Aulos.Core.Infrastructure.Services;
using Aulos.Infrastructure.Factories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aulos.Infrastructure.Services
{
    public class TagLibFileProvider : IFileProvider
    {
        private IAlbumFileDtoFactory _albumFileDtoFactory;
        private ITrackDtoFactory _trackFileDtoFactory;

        public TagLibFileProvider(IAlbumFileDtoFactory albumFileDtoFactory, ITrackDtoFactory trackFileDtoFactory)
        {
            _albumFileDtoFactory = albumFileDtoFactory;
            _trackFileDtoFactory = trackFileDtoFactory;
        }

        public IAlbumDto GetAlbum(string albumPath)
        {
            var tracklistFileNames = GetAlbumTracklistFileNames(albumPath);
            var tracklistFileDto = new List<ITrackDto>();
            var filePath = GetFilePath(albumPath, tracklistFileNames.FirstOrDefault());

            foreach (var fileName in tracklistFileNames)
            {
                filePath = GetFilePath(albumPath, fileName);
                tracklistFileDto.Add(GetTrack(filePath));
            }

            using (var file = TagLib.File.Create(filePath))
            {
                return _albumFileDtoFactory.Create(file.Tag, tracklistFileDto, albumPath);
            }
        }

        public ITrackDto GetTrack(string filePath)
        {
            using (var file = TagLib.File.Create(filePath))
            {
                return _trackFileDtoFactory.Create(file.Tag, file.Properties);
            }
        }

        private string[] GetAlbumTracklistFileNames(string sourcePath)
        {
            string[] tracksFileNames = Directory.EnumerateFiles(sourcePath, "*", SearchOption.AllDirectories)
                .Where(s => s.EndsWith(".mp3", StringComparison.OrdinalIgnoreCase) || s.EndsWith(".flac", StringComparison.OrdinalIgnoreCase))
                .Select(p => Path.GetFileName(p))
                .ToArray();

            return tracksFileNames;
        }

        private string GetFilePath(string fileDirectory, string fileName)
        {
            return fileDirectory + "\\" + fileName;
        }
    }
}
