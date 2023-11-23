using Deneva.Core.Domain.Models.Playlist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deneva.Core.Domain.SecondaryPorts.Storage
{
    public interface IPlaylistFileStorage
    {
        int Save(PlaylistFile playlist);
        void Replace(int objID, PlaylistFile playlist);
        void Delete(int objID);
        PlaylistFile Get(int objID);
    }
}
