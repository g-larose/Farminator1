using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Guilded.Servers;
using Guilded.Users;

namespace Farminator1.Models
{
    public class Farmer
    {
        public Guid Id { get; set; }
        public Member? Member { get; set; }
        public uint Coin { get; set; }
        public uint LifetimeCornGrown { get; set; }
        public uint CurrentCorn { get; set; }

    }
}
