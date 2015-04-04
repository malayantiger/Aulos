using Aulos.Core.Infrastructure.Data;
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
        private ITrackFileFactory _trackFileDtoFactory;

        public TagLibFileProvider(ITrackFileFactory trackFileDtoFactory)
        {
            _trackFileDtoFactory = trackFileDtoFactory;
        }

        public IEnumerable<ITrackFile> GetAlbum(string albumPath)
        {
            var tracklistFileNames = GetAlbumTracklistFileNames(albumPath);
            var tracklistFileDto = new List<ITrackFile>();

            foreach (var fileName in tracklistFileNames)
            {
                var filePath = GetFilePath(albumPath, fileName);
                tracklistFileDto.Add(GetTrack(filePath));
            }

            return tracklistFileDto;
        }

        public ITrackFile GetTrack(string filePath)
        {
            using (var file = TagLib.File.Create(filePath))
            {
                return _trackFileDtoFactory.Create(file.Tag, file.Properties, filePath);
            }
        }

        public void SaveAlbum(IEnumerable<ITrackFile> tracks)
        {
            foreach (var track in tracks)
            {
                using (var file = TagLib.File.Create(track.SourcePath))
                {
                    var tag = file.Tag.Edit(track);
                    tag.CopyTo(file.Tag, true);
                    file.Save();
                }
            }
        }

        private IList<string> GetAlbumTracklistFileNames(string sourcePath)
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
