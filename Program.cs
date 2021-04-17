using System;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using FabricServerToolsBot.Commands;
using FabricServerToolsBot.Listeners;

namespace FabricServerToolsBot
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var discord = new DiscordClient(new DiscordConfiguration()
            {
                Token = Environment.GetEnvironmentVariable("FST_DISCORD_TOKEN"),
                Intents = DiscordIntents.AllUnprivileged
            });

            var commands = discord.UseCommandsNext(new CommandsNextConfiguration()
            {
                StringPrefixes = new[] { "!" },
                EnableDefaultHelp = false
            });

            commands.RegisterCommands<LinkCommandModule>();
            commands.RegisterCommands<HelpCommandModule>();

            PronounsListener.Register(discord);

            await discord.ConnectAsync();
            await Task.Delay(-1);
        }
    }
}
