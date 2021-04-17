using System;
using System.Linq;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;

namespace FabricServerToolsBot.Listeners
{
    public static class PronounsListener
    {
        public static void Register(DiscordClient client)
        {
            client.MessageReactionAdded += ReactionAdded;
            client.MessageReactionRemoved += ReactionRemoved;
        }

        private static async Task ReactionRemoved(DiscordClient sender, MessageReactionRemoveEventArgs e)
        {
            if (e.Channel.Name != "welcome") return;

            String roleName = e.Emoji.GetDiscordName() switch
            {
                ":red_circle:" => "he/him",
                ":yellow_circle:" => "they/them",
                ":green_circle:" => "she/her",
                _ => null
            };

            if (roleName == null)
                return;

            DiscordRole role = e.Guild.Roles.Values.FirstOrDefault(x => x.Name == roleName);
            if (role == null)
                return;

            if (e.User is not DiscordMember member)
                return;

            await member.RevokeRoleAsync(role);
        }

        private static async Task ReactionAdded(DiscordClient sender, MessageReactionAddEventArgs e)
        {
            if (e.Channel.Name != "welcome") return;

            String roleName = e.Emoji.GetDiscordName() switch
            {
                ":red_circle:" => "he/him",
                ":yellow_circle:" => "they/them",
                ":green_circle:" => "she/her",
                _ => null
            };

            if (roleName == null)
                return;

            DiscordRole role = e.Guild.Roles.Values.FirstOrDefault(x => x.Name == roleName);
            if (role == null)
                return;

            if (e.User is not DiscordMember member)
                return;

            await member.GrantRoleAsync(role);
        }
    }
}