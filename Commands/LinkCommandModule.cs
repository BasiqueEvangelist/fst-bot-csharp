using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;

namespace FabricServerToolsBot.Commands
{
    public class LinkCommandModule : BaseCommandModule
    {
        [Command("github")]
        public async Task Github(CommandContext ctx, string user, string repo)
        {
            await ctx.RespondAsync($"https://github.com/{user}/{repo}");
        }

        [Command("cf")]
        public async Task Curseforge(CommandContext ctx, string slug)
        {
            await ctx.RespondAsync($"https://curseforge.com/minecraft/mc-mods/{slug}");
        }
    }
}