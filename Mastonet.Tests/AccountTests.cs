using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mastonet.Tests
{
    [TestClass]
    public class AccountTests : MastodonClientTests
    {
        [TestMethod]
        public async Task GetAccount()
        {
            var client = GetReadClient();

            var account = await client.GetAccount(1);

            Assert.IsNotNull(account.ProfileUrl);
            Assert.IsNotNull(account.UserName);
        }

        [TestMethod]
        public async Task GetCurrentUser()
        {
            var client = GetReadClient();

            var account = await client.GetCurrentUser();

            Assert.IsNotNull(account.ProfileUrl);
            Assert.IsNotNull(account.UserName);
        }

        [TestMethod]
        public async Task GetAccountRelationships()
        {
            var client = GetReadClient();

            var relationships = await client.GetAccountRelationships(1);

            Assert.IsNotNull(relationships);
            Assert.AreNotEqual(0, relationships.Count());
        }
    }
}
