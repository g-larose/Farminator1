using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Farminator1.Commands;
using Farminator1.Models;
using Guilded;
using Guilded.Commands;

namespace Farminator1
{
    public class Bot
    {
        private static string? json = File.ReadAllText("config.json");
        private static string? token = JsonSerializer.Deserialize<ConfigJson>(json!)!.Token!;
        private static string? prefix = JsonSerializer.Deserialize<ConfigJson>(json!).Prefix!;
        private static string? timePattern = "hh:mm:ss tt";
        public async Task RunAsync()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            await using var client = new GuildedBotClient(token!)
                .AddCommands(new ModCommands(), prefix!)
                .AddCommands(new MemberCommands(), prefix!);

            client.Prepared
                .Subscribe(async me =>
                {
                    var channelID = new Guid("ac89c524-722d-4fde-a84f-80b5f09166a7");
                    var time = DateTime.Now.ToString(timePattern);
                    var date = DateTime.Now.ToShortDateString();
                    Console.WriteLine($"[{date}][{time}][INFO]  [{me.ParentClient.Name}] talking to gateway...");
                    await me.ParentClient.CreateMessageAsync(channelID, $"{me.ParentClient.Name} is now connected!");
                });

            client.MemberJoined
                .Subscribe(async memJoined =>
                {
                    var memId = memJoined.Id;
                    var serverId = memJoined.ServerId;
                    var profileChannelId = new Guid("99837597-ed2b-4f5c-9a05-d3615dca62e7");
                    await memJoined.ParentClient.CreateDocAsync(profileChannelId, "test", "this is a test profile"); //here we need a StringBuilder() to build the profile content.
                });


            await client.ConnectAsync();
            await client.SetStatusAsync("farming...", 90002924);
            var time = DateTime.Now.ToString(timePattern);
            var date = DateTime.Now.ToShortDateString();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"[{date}][{time}][INFO]  [{client.Name}] connected...");
            Console.WriteLine($"[{date}][{time}][INFO]  [{client.Name}] registering command modules...");
            await Task.Delay(200);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"[{date}][{time}][INFO]  [{client.Name}] listening for events...");
            await Task.Delay(-1);
        }
    }
}
