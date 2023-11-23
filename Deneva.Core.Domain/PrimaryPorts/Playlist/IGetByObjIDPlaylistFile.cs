using Deneva.Core.Domain.Models.Playlist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deneva.Core.Domain.PrimaryPorts.Playlist
{
    public interface IGetByObjIDPlaylistFile
    {
        Task<PlaylistFile> ExecuteAsync(int objID);
    }
}
