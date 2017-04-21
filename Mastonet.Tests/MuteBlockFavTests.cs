using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mastonet.Tests
{
    [TestClass]
    public class MuteBlockFavTests : MastodonClientTests
    {
        [TestMethod]
        public async Task Block()
        {
            var client = GetFollowClient();
            var blocked = await client.Block(10);
            Assert.IsNotNull(blocked);
        }

        [TestMethod]
        public async Task Unblock()
        {
            var client = GetFollowClient();
            var unblocked = await client.Unblock(10);
            Assert.IsNotNull(unblocked);
        }

        [TestMethod]
        public async Task GetBlocks()
        {
            var client = GetReadClient();
            var blocked = await client.GetBlocks();
            Assert.IsNotNull(blocked);
        }

        [TestMethod]
        public async Task Mute()
        {
            var client = GetFollowClient();
            var muted = await client.Mute(10);
            Assert.IsNotNull(muted);
        }

        [TestMethod]
        public async Task Unmute()
        {
            var client = GetFollowClient();
            var unmuted = await client.Unmute(10);
            Assert.IsNotNull(unmuted);
        }

        [TestMethod]
        public async Task GetMutes()
        {
            var client = GetReadClient();
            var muted = await client.GetMutes();
            Assert.IsNotNull(muted);
        }

        [TestMethod]
        public async Task Favourite()
        {
            var client = GetFollowClient();
            throw new NotImplementedException();
        }

        [TestMethod]
        public async Task Unfavourite()
        {
            var client = GetFollowClient();
            throw new NotImplementedException();
        }

        [TestMethod]
        public async Task GetFavourites()
        {
            var client = GetReadClient();
            var favs = await client.GetFavourites();
            Assert.IsNotNull(favs);
        }
    }
}
