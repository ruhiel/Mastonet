using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace Mastonet.Tests
{
    [TestClass]
    public class TimelineTests : MastodonClientTests
    {
        [TestMethod]
        public async Task GetHomeTimeline()
        {
            var client = GetReadClient();
            var timeline = await client.GetHomeTimeline();
            Assert.IsNotNull(timeline);
        }

        [TestMethod]
        public async Task GetPublicTimeline()
        {
            var client = GetReadClient();
            var timeline = await client.GetPublicTimeline();
            Assert.IsNotNull(timeline);
        }

        [TestMethod]
        public async Task GetTagTimeline()
        {
            var client = GetReadClient();
            var timeline = await client.GetTagTimeline("mastodon");
            Assert.IsNotNull(timeline);
        }
    }
}
