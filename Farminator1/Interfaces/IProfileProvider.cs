using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Farminator1.Models;
using Guilded.Content;
using Guilded.Servers;

namespace Farminator1.Interfaces
{
    public interface IProfileProvider
    {
        string Create(Farmer farmer);
    }
}
