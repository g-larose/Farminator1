using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Farminator1.Models;
using Farminator1.Services;
using Guilded.Base;
using Guilded.Commands;
using Guilded.Content;
using Guilded.Servers;

namespace Farminator1.Commands
{
    public class ModCommands : CommandModule
    {
        [Command(Aliases = new string[] { "profile" })]
        [Description("create, update, delete or view member profile")]
        public async Task Profile(CommandEvent invokator, string args, string username)
        {
            try
            {
                var profileService = new ProfileProviderService();
                var channelId = new Guid("99837597-ed2b-4f5c-9a05-d3615dca62e7");
                var serverId = invokator.ServerId;
                var memberId = invokator!.Mentions!.Users!.First().Id;
                var farmer = new Farmer();
                farmer.Id = Guid.NewGuid();
                farmer.Member = await invokator.ParentClient.GetMemberAsync((HashId)serverId!, memberId);
                farmer.LifetimeCornGrown = 0;
                farmer.CurrentCorn = 0;
                farmer.Coin = 0;

                switch (args)
                {
                    case "create":
                        var profile = profileService.Create(farmer);

                        await invokator.ParentClient.CreateDocAsync(channelId, title: $"{farmer.Member.Name}'s Profile", content: profile);
                        break;
                    default:

                        break;
                }
                
            }
            catch (Exception e)
            {
                await invokator.ReplyAsync(
                    $"something went wrong with the command, please try again. example command [!fprofile view @username]");
            }
        }
    }
}
