using Disc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disc.Application.Releases
{
    public class ReleasDto
    {
        public uint DiscogsId { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
    }
}
