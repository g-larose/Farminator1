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
            var content = new StringBuilder();
            content.Append($"Username: {farmer!.Member!.Name}\r\n");
            content.Append($"Lifetime Corn Grown: {farmer!.LifetimeCornGrown}\r\n");
            content.Append($"Current Corn: {farmer!.CurrentCorn}\r\n");
            content.Append($"Farm Coin: {farmer!.Coin}\r\n");

            return content.ToString();
        }
    }
}
