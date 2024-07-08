using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;
using Discord.WebSocket;
using Tweetinvi;
using Tweetinvi.Client;
using CommunityThoughts;
using Discord;
using Tweetinvi.Parameters;
using System.Linq;

namespace CommunityThoughts.Modules
{
    public class InfoModule : ModuleBase<SocketCommandContext>
    {
        [Command("tweet")]
        [Summary("I sing your muse to Twitter.")]
        public async Task TweetAsync([Remainder] [Summary("I sing your muse to Twitter")] string echo)
        {
            var userInfo = Context.User;
            string letterCheck = $"\"{echo}\" -{userInfo.Username}";
            if (letterCheck.Length <= 280)
            {
                
                var userClient = new TwitterClient(botToken.consumerKey, botToken.consumerSecret, botToken.accessToken, botToken.accessTokenSecret);
                var tweet = await userClient.Tweets.PublishTweetAsync($"\"{echo}\" -{userInfo.Username}");
                await ReplyAsync($"Tweet sent. :slight_smile:");
            }
            else
            {
                await ReplyAsync("Tweet has not been sent because it's too long. Please shorten your message or name. :slight_frown:");
            }

        }

        /*
        [Command("ptweet")]
        [Summary("Sends a tweet with a picture attached.")]
        public async Task PictureTweetAsync([Summary("Sends a tweet with a picture attached.")] string echo)
        {
            var userInfo = Context.User;
            var picture = Context.Message.Attachments;
            string letterCheck = $"\"{echo}\" -{userInfo.Username}#{userInfo.Discriminator}";
            if (letterCheck.Length <= 280)
            {
                var userClient = new TwitterClient(botToken.consumerKey, botToken.consumerSecret, botToken.accessToken, botToken.accessTokenSecret);
                
                //$"\"{echo}\" -{userInfo.Username}#{userInfo.Discriminator}"
                var tweetWithImage = await userClient.Tweets.PublishTweetAsync(new PublishTweetParameters($"\"{echo}\" -{userInfo.Username}#{userInfo.Discriminator}")
                {
                    Medias = { picture }
                });
                await ReplyAsync($"Tweet sent. :slight_smile:");
            }
            else
            {
                await ReplyAsync("Tweet has not been sent because it's too long. Please shorten your message or name. :slight_frown:");
            }
        }  */

        [Command("check")]
        [Summary("Echoes a message.")]
        public async Task CheckAsync([Summary("The text to echo")] int num = 0) // the fact you HAVE to use a variable for this to work is tacky
        {
            //var userInfo
            var userInfo = Context.User;

            //IReadOnlyCollection<SocketMessage> GetCachedMessages(IMessage message, Direction Before, int limit = 1);
            await ReplyAsync($"I am online! 🙂");

        }

    /*

    I NEED THIS
    await ReplyAsync($"{echo} by {userInfo.Username}#{userInfo.Discriminator}");
    */

        [Command("echo")]
        [Summary("Echoes a message.")]
        public Task EchoAsync([Remainder][Summary("I sing your muse to Twitter")] string echo) 
            => ReplyAsync(echo);

    }


    /*
    [Group("sample")]
    public class SampleModule : ModuleBase<SocketCommandContext>
    {
        // ~sample square 20 -> 400
        [Command("square")]
        [Summary("Squares a number.")]
        public async Task SquareAsync(
            [Summary("The number to square.")]
        int num)
        {
            // We can also access the channel from the Command Context.
            await Context.Channel.SendMessageAsync($"{num}^2 = {Math.Pow(num, 2)}");
        }

        // ~sample userinfo --> foxbot#0282
        // ~sample userinfo @Khionu --> Khionu#8708
        // ~sample userinfo Khionu#8708 --> Khionu#8708
        // ~sample userinfo Khionu --> Khionu#8708
        // ~sample userinfo 96642168176807936 --> Khionu#8708
        // ~sample whois 96642168176807936 --> Khionu#8708
        [Command("userinfo")]
        [Summary
        ("Returns info about the current user, or the user parameter, if one passed.")]
        [Alias("user", "whois")]
        public async Task UserInfoAsync(
            [Summary("The (optional) user to get info from")]
        SocketUser user = null)
        {
            var userInfo = user ?? Context.Client.CurrentUser;
            await ReplyAsync($"{userInfo.Username}#{userInfo.Discriminator}");
        }
    } */
}
