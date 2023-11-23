using Deneva.Core.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Deneva.Core.Domain.Models.Playlist
{
    public class PlaylistFile : IAggregateRoot
    {
        public DateTime LastModified { get; set; }
        public int ObjID { get; set; }
        public XElement Content { get; set; }
    }
}
