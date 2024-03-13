using System;
using System.Threading.Channels;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity.Extensions;
using static System.Net.WebRequestMethods;
using DSharpPlus.Interactivity;
using System;
using System.Threading.Tasks;




namespace bobot.embed
{


    public class embedcommands : BaseCommandModule
    {
        public string ImageUrl { get; set; }
        public static object Client { get; internal set; }
        [Command("prikazy")]
        public async Task nevim(CommandContext ctx)
        {
            var embed1 = new DiscordMessageBuilder()
                .AddEmbed(new DiscordEmbedBuilder()
                    .WithColor(DiscordColor.Gold)
                    .WithTitle("Příkazy Truneckbota")
                    .WithDescription("\nprefix **!T**\n" +
                    "\n ➢ **prikazy** zobrazím všechny příkazy" +
                    "\n ➢ **info** představím se" +
                    "\n ➢ **eurovolby** zobrazím informace k nadcházejícím volbám do Europarlamentu" +
                    "\n ➢ **aktuality** zobrazím nejbližší akci s Adamem" +
                    "\n ➢ **kontakty** poskytnu kontatky na Adama" +
                    "\n ➢ **stan** pošlu odkaz na oficiální stránky Starostů a nezávislých" +
                    "\n ➢ **dobrovolnici** poskytnu informace k dobrovolnictví pro STAN"));


            await ctx.Channel.SendMessageAsync(embed1);
        }
        [Command("aktuality")]
        public async Task a(CommandContext ctx)
        {
            var embed2 = new DiscordEmbedBuilder()
            {
                Color = DiscordColor.MidnightBlue,
                Title = "Aktuality",
                Description = "**Ve čtvrtek 14.3. bude mít CzechCloud rozhovor s Adamem na streamu**" +
                "\n Od 19:00 na https://www.twitch.tv/czechcloud :yellow_heart:",
              
            };
            await ctx.Channel.SendMessageAsync(embed: embed2);
            embed2 = new DiscordEmbedBuilder()
            {
                Color = DiscordColor.Goldenrod,
                Description = "**V neděli 17.3. se s Adamem můžete vidět naživo a sdělit mu \"Co chcete po EU?\" **" +
                "\n Od 19:00 v Kolkovně Olympia na smíchově ⇒ https://olympia.kolkovna.cz/ 🇪🇺"
            };
            await ctx.Channel.SendMessageAsync(embed: embed2);
            embed2 = new DiscordEmbedBuilder()
            {
                Color = DiscordColor.MidnightBlue,
                Description = "**V pondělí 18.3.bude Adam přednášet na debatním klubu Tima Kožuchova na téma \"Jak vyhrát jakoukoliv debatu o EU?\" **" +
                "\n Od 18:00, pro více informací sledujte Adamův <:adam_vysvetluje_veci:1216431941176397998> a Timův <:RakusanLove:1216968640805601402> instagram *@debatnidenik @adam.the.trunecka* " +
                "\n" +
                "\n*To je vše, nezapomeňte se zase v neděli podívat, co nového se bude dít <:EUwU:1216431034619662346>* ",

            };
            await ctx.Channel.SendMessageAsync(embed: embed2);
        }
        [Command("kontakty")]
        public async Task kontakty(CommandContext ctx)
        {


            var embed3 = new DiscordMessageBuilder()
                 .AddEmbed(new DiscordEmbedBuilder()
                     .WithColor(DiscordColor.Gold)
                     .WithTitle("Kontakty na Adama")
                     .WithDescription("**:blue_heart: Kliknutím na tlačítko budete přesměrováni :yellow_heart:**"))
                 .AddComponents(new DiscordComponent[]
                  {
        new DiscordLinkButtonComponent("https://www.instagram.com/adam.the.trunecka","Instagram"),
        new DiscordLinkButtonComponent("https://x.com/adam_trun?s=21&t=ZKtrlX4fFM6MWGh7oVsj6Q", "X"),
        new DiscordLinkButtonComponent("https://facebook.com/trunecka","Facebook"),
        new DiscordLinkButtonComponent("https://cz.linkedin.com/in/adam-trune%C4%8Dka-46b359225", "LinkedIn"),
        new DiscordLinkButtonComponent("https://linktr.ee/trunecka", "Linktree")
                });
            await ctx.Channel.SendMessageAsync(embed3);
        }
        [Command("role1")]
        [RequireRoles(RoleCheckMode.Any, "The Senate", "Komisař", "Director-General")]
        public async Task r1(CommandContext ctx)
        {
            var o = new DiscordEmbedBuilder
            {
                Title = "role",
                Color = DiscordColor.MidnightBlue
            };
            var joinm = await ctx.Channel.SendMessageAsync(embed: o);
            var one = DiscordEmoji.FromName(ctx.Client, ":one:");
            var two = DiscordEmoji.FromName(ctx.Client, ":two:");
            await joinm.CreateReactionAsync(one);
            await joinm.CreateReactionAsync(two);

            
        }
        [Command("dobrovolnici")]
        public async Task d(CommandContext ctx)
        {
            var dd = new DiscordMessageBuilder()
                .AddEmbed(new DiscordEmbedBuilder()
                    .WithColor(DiscordColor.Rose)
                    .WithTitle("**STAŇ se dobrovolníkem**")
                    .WithDescription("Podporuješ STAN a chceš mu více pomoci?* <:STAN:1216431396093034576>\n **Přidej se k dobrovolníkům !**" +
                    "\n *Pokud se připojíš, napiš našim adminům ;)*")).AddComponents(new DiscordComponent[]
                  {
        new DiscordLinkButtonComponent("https://www.starameseocesko.eu/stante-se-nasim-dobrovolnikem","Klikni sem!") });



            await ctx.Channel.SendMessageAsync(dd);
        }
        // await joinm.DeleteAsync()
        // [RequireRoles(RoleCheckMode.Any, "Mod", "Owner")]
    }
}

