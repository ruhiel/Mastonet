using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mastonet.Tests
{
    [TestClass]
    public class FollowTests : MastodonClientTests
    {
        [TestMethod]
        public async Task GetAccountFollowers()
        {
            var client = GetReadClient();
            var accounts = await client.GetAccountFollowers(1);

            Assert.IsNotNull(accounts);
            Assert.IsTrue(accounts.Any());
        }

        [TestMethod]
        public async Task GetAccountFollowing()
        {
            var client = GetReadClient();
            var accounts = await client.GetAccountFollowing(1);

            Assert.IsNotNull(accounts);
            Assert.IsTrue(accounts.Any());
        }

        [TestMethod]
        public async Task Follow()
        {
            // Follow local
            var client = GetFollowClient();
            var followedAccount = await client.Follow(1);
            Assert.IsNotNull(followedAccount);

            //follow remote
            followedAccount = await client.Follow("");
            Assert.IsNotNull(followedAccount);
        }

        [TestMethod]
        public async Task Unfollow()
        {
            var client = GetFollowClient();
            var unfollowedAccount = await client.Unfollow(1);
            Assert.IsNotNull(unfollowedAccount);
        }


        [TestMethod]
        public async Task GetFollowRequests()
        {
            var client = GetFollowClient();
            var requests = await client.GetFollowRequests();
            Assert.IsNotNull(requests);
        }

        [TestMethod]
        public async Task AuthorizeRequest()
        {
            var client = GetFollowClient();
            throw new NotImplementedException();
        }

        [TestMethod]
        public async Task RejectRequest()
        {
            var client = GetFollowClient();
            throw new NotImplementedException();
        }
    }
}
