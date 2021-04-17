using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;

namespace FabricServerToolsBot.Commands
{
    public class HelpCommandModule : BaseCommandModule
    {
        [Command("help")]
        public async Task Help(CommandContext context)
        {
            await context.RespondAsync(string.Join("\n",
                "List of bot commands:", "React :red_circle: to a message in #welcome to get he/him role",
                "React :yellow_circle: in #welcome to get they/them role",
                "React :green_circle: in #welcome to get she/her role",
                "!help: lists commands",
                "!cf <mod>: links to the Curseforge page of <mod>",
                "!github <user> repo>: links to the GitHub page of the repo specified",
                "!stop: makes bot :crab:"));
        }
    }
}