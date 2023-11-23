using Deneva.Core.Domain.Models.Playlist;
using Deneva.Core.Domain.PrimaryPorts.Playlist;
using Deneva.Core.Domain.SecondaryPorts.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deneva.Core.Application.PrimaryPorts.Playlist
{
    public class GetByObjIDPlaylistFile :IGetByObjIDPlaylistFile
    {
        private readonly IPlaylistFileStorage _playlistFileStorage;

        public GetByObjIDPlaylistFile(IPlaylistFileStorage playlistFileStorage)
        {
            _playlistFileStorage = playlistFileStorage;
        }

        public async Task<PlaylistFile> ExecuteAsync(int objID)
        {
            return await Task.FromResult(_playlistFileStorage.Get(objID));
        }
    }
}
