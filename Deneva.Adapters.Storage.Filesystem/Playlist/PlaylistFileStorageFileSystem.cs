using Deneva.Core.Domain.Models.Playlist;
using Deneva.Core.Domain.SecondaryPorts.Storage;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Deneva.Adapters.Storage.Filesystem.Playlist
{
    public class PlaylistFileStorageFileSystem : IPlaylistFileStorage
    {
        private readonly IConfiguration config;
        private readonly String pathPlaylist;
        private readonly String playlistFileExtension;
        private readonly String playlistFilePrefix;

        public PlaylistFileStorageFileSystem(IConfiguration configuration)
        {
            config = configuration;
            pathPlaylist = config.GetValue<String>("PlaylistBasePath");
            playlistFilePrefix = config.GetValue<String>("PlaylistFilePrefix");
            playlistFileExtension = config.GetValue<String>("PlaylistFileExtension");
        }

        public void Delete(int objID)
        {
            string tmpFullFileName = Path.Combine(pathPlaylist, playlistFilePrefix + objID.ToString() + playlistFileExtension);
            if (File.Exists(tmpFullFileName))
            {
                File.Delete(tmpFullFileName);
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public PlaylistFile Get(int objID)
        {
            PlaylistFile tmpPL;
            try
            {
                string tmpFullFileName = Path.Combine(pathPlaylist, playlistFilePrefix + objID.ToString() + playlistFileExtension);
                if (!File.Exists(tmpFullFileName))
                    tmpPL = null;
                else
                {
                    tmpPL = new PlaylistFile() {ObjID=objID, Content= XElement.Load(tmpFullFileName), LastModified=File.GetLastWriteTimeUtc(tmpFullFileName)};
                }
            }
            catch
            {
                tmpPL = null;
            }
            return tmpPL;
        }

        public void Replace(int objID, PlaylistFile playlist)
        {
            throw new NotImplementedException();
        }

        public int Save(PlaylistFile playlist)
        {
            int tmpReturn = 0;
            try
            {
                string tmpFullFileName = Path.Combine(pathPlaylist, playlistFilePrefix + playlist.ObjID.ToString() + playlistFileExtension);
                File.WriteAllText(tmpFullFileName, playlist.Content.ToString(), System.Text.Encoding.UTF8);
            }
            catch
            {
                tmpReturn = -1;
            }
            return tmpReturn;
        }
    }
}
