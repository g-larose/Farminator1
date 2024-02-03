using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Farminator1.Interfaces;
using Farminator1.Models;
using Guilded.Base;
using Guilded.Content;

namespace Farminator1.Services
{
    public class ProfileProviderService : IProfileProvider
    {
        public string Create(Farmer farmer)
        {
            var title = $"**{farmer!.Member!.Name}'s Profile";
            var content = new StringBuilder();
            content.Append($"Username: {farmer!.Member!.Name}");
            content.Append($"Lifetime Corn Grown: {farmer!.LifetimeCornGrown}");
            content.Append($"Current Corn: {farmer!.CurrentCorn}");
            content.Append($"Farm Coin: {farmer!.Coin}");

            return content.ToString();
        }
    }
}
