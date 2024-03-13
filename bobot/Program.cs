using DSharpPlus;
using DSharpPlus.CommandsNext;
using bobot.config;
using bobot.config.DiscordBotTutorialExampleProject.Config;
using DSharpPlus.Interactivity;
using DSharpPlus.Interactivity.Extensions;
using DSharpPlus.EventArgs;
using bobot.commands;
using bobot.embed;
using static System.Runtime.InteropServices.JavaScript.JSType;
using DSharpPlus.Entities;
using DSharpPlus.AsyncEvents;
using System.Threading.Tasks;
using System.Data;
using System.Linq;

namespace bobot;

class Program
{
    public static object Client { get; internal set; }

    public sealed class Programe
    {
        static DiscordClient Client { get; set; }
        static CommandsNextExtension Commands { get; set; }
        static InteractivityExtension Interactivity { get; set; }

        static async Task Main(string[] args)
        {

            var configProperties = new ConfigJsonReader();
            await configProperties.ReadJSON();


            var discordConfig = new DiscordConfiguration
            {
                Intents = DiscordIntents.All,
                Token = configProperties.discordToken,
                TokenType = TokenType.Bot,
                AutoReconnect = true,
            };


            Client = new DiscordClient(discordConfig);
            Client.Ready += Client_Ready;
            Client.GuildMemberAdded += UserJoinHandler;
           Client.MessageReactionAdded += MessageReactionAdded;
            Client.MessageReactionRemoved += MessageReactionRemoved;

            Client.UseInteractivity(new InteractivityConfiguration());


            var commandsConfig = new CommandsNextConfiguration
            {
                StringPrefixes = new string[] { configProperties.discordPrefix },
                EnableMentionPrefix = true,
                EnableDms = true,
                EnableDefaultHelp = false
            };
            Commands = Client.UseCommandsNext(commandsConfig);
            Commands.RegisterCommands<basic>(); //to prvni je jmeno te tridy kde je command
            Commands.RegisterCommands<embedcommands>();


            await Client.ConnectAsync();
            await Task.Delay(-1);

        }
        private static Task Client_Ready(DiscordClient sender, ReadyEventArgs args)
        {
            return Task.CompletedTask;
        }
        private static async Task UserJoinHandler(DiscordClient sender, GuildMemberAddEventArgs e)
        {
            var defaultChannel = e.Guild.GetChannel(1216774628756946955);
            string[] zpravy = { "Ahoj","Zdravím","Čau",};
            Random rnd = new Random();
            int y = rnd.Next(0, 3);
            var welcomeEmbed = new DiscordEmbedBuilder()
            {
                Color = DiscordColor.MidnightBlue,
                Title = zpravy[y],
                Description = $"**Vítám tě na serveru {e.Member.Username} !**\nProsím **přečti si pravidla** a **ověř se** :yellow_heart:"

                
            };
            var guild = e.Guild;
            var role = guild.GetRole(1216424541249863830);
            await e.Member.GrantRoleAsync(role);

            await defaultChannel.SendMessageAsync(embed: welcomeEmbed);
        }
        private static async Task MessageReactionAdded(DiscordClient sender, DSharpPlus.EventArgs.MessageReactionAddEventArgs e)
        {
           var embed = e.Message.Embeds.First(); // gets the embed
            if (embed.Title == "role") // Check if Title is "role"
            {
                DiscordMember member = (DiscordMember)e.User;

                DiscordEmoji one = DiscordEmoji.FromName(Client, ":one:");
                DiscordEmoji two = DiscordEmoji.FromName(Client, ":two:");

                DiscordRole role1 = e.Guild.GetRole(1217111664936091798);
                DiscordRole role2 = e.Guild.GetRole(1217111713753858158);

                if (e.Emoji == one && !member.Roles.Contains(role2))
                {
                    await member.GrantRoleAsync(role1);
                }
                else if (e.Emoji == two && !member.Roles.Contains(role1))
                {
                    await member.GrantRoleAsync(role2);
                }
            }
            
        }

        private static async Task MessageReactionRemoved(DiscordClient sender, DSharpPlus.EventArgs.MessageReactionRemoveEventArgs e)
        {
            var embed = e.Message.Embeds.First(); // gets the embed
            if (embed.Title == "role") // Check if Title is "role"
            {
                DiscordMember member = (DiscordMember)e.User;

                DiscordEmoji one = DiscordEmoji.FromName(Client, ":one:");
                DiscordEmoji two = DiscordEmoji.FromName(Client, ":two:");

                DiscordRole role1 = e.Guild.GetRole(1217111664936091798);
                DiscordRole role2 = e.Guild.GetRole(1217111713753858158);

                if (e.Emoji == one && member.Roles.Contains(role1))
                {
                    await member.RevokeRoleAsync(role1);
                }
                else if (e.Emoji == two && member.Roles.Contains(role2))
                {
                    await member.RevokeRoleAsync(role2);
                }
            }
        }

    }

}
