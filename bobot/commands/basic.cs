using System;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus;
using bobot.config;
using bobot.config.DiscordBotTutorialExampleProject.Config;
using DSharpPlus.Interactivity;
using DSharpPlus.Interactivity.Extensions;
using DSharpPlus.EventArgs;
using bobot.commands;
using System.Threading.Tasks;
using System.Threading.Channels;
using DSharpPlus.Entities;
using static System.Net.WebRequestMethods;




namespace bobot.commands
{
    public class basic : BaseCommandModule
    {
       
        [Command("info")]
        public async Task Info(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync("Ahoj! Jsem osobní bot Adama Trunečky! :blue_heart:\nNapiš ***!T prikazy*** pro seznam mých příkazů");
        }
        [Command("help")]
        public async Task help(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync("Ahoj! Jsem osobní bot Adama Trunečky! :blue_heart:\nNapiš ***!T prikazy*** pro seznam mých příkazů");
        }
        [Command("eurovolby")]
        public async Task eurovolby(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync("Příší volby do Evropského parlamentu se uskuteční 7.6. a 8.6. 2024 :flag_eu:\n**Adam je 7. na kandidátce STANu tak nezapomeň kroužkovat! :blue_heart: **\nPro více informací se podívejte na stránku :point_right: https://elections.europa.eu/cs/");
        }

        [Command("stan")]
        public async Task stan(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync("<:STAN:1216431396093034576> https://www.starostove-nezavisli.cz <:STAN:1216431396093034576>");
        }

        [Command("pravidla")]
        public async Task pr(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync(":flag_eu: **Zde jsou pravidla, ke kterým se zavazují všichni vstupující na tento server:**" +
                "\n" +     
                "\n►**Dodržujte Discord TOS.**" +
                "\n►Chovejte se slušně, respektujte ostatní, nevyvolávejte drama ani zbytečné hádky." +
                "\n►Nesdílejte reklamu na cokoliv. (pokud vám to moderátor nepovolí)" +
                "\n►Neposílejte NSFW obsah ani odkazy. (porno apod.)" +
                "\n►Nespamujte, pokud vám někdo neodpovídá." +
                "\n►Nepingujte zbytečně majitele - Adama Trunečku." +
                "\n►Nezesměšňujte ostatní kandidáty STANu" +
                "\n►Edgy humor do zdravé míry. (Jestli si nejste jistí jestli nějaký edgy meme není už moc tak se můžete zeptat moderátora v soukromých zprávách)" +
                "\n►Dodržujte roomky na to, k čemu jsou určené." +
                "\n");

        }
        [Command("tim")]
        public async Task tim(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync("<:RakusanLove:1216968640805601402>");
        }


    }

}

