using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mastonet.Tests
{
    [TestClass]
    public class StatusTests : MastodonClientTests
    {
        [TestMethod]
        public async Task GetAccountStatuses()
        {
            var client = GetReadClient();

            var status = await client.GetAccountStatuses(1);
            Assert.IsNotNull(status);
            Assert.IsTrue(status.Any());
            status = await client.GetAccountStatuses(1, onlyMedia: true);
            Assert.IsNotNull(status);
            Assert.IsTrue(status.Any());
            status = await client.GetAccountStatuses(1, excludeReplies: true);
            Assert.IsNotNull(status);
            Assert.IsTrue(status.Any());
        }

        [TestMethod]
        public async Task GetStatus()
        {
            var client = GetReadClient();
            throw new NotImplementedException();
        }

        [TestMethod]
        public async Task GetStatusContext()
        {
            var client = GetReadClient();
            throw new NotImplementedException();
        }

        [TestMethod]
        public async Task GetStatusCard()
        {
            var client = GetReadClient();
            throw new NotImplementedException();
        }

        [TestMethod]
        public async Task GetRebloggedBy()
        {
            var client = GetReadClient();
            throw new NotImplementedException();
        }

        [TestMethod]
        public async Task GetFavouritedBy()
        {
            var client = GetReadClient();
            throw new NotImplementedException();
        }
    }
}
