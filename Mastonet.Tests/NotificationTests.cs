using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mastonet.Tests
{
    [TestClass]
    public class NotificationTests : MastodonClientTests
    {
        [TestMethod]
        public async Task GetNotifications()
        {
            var client = GetReadClient();
            throw new NotImplementedException();
        }

        [TestMethod]
        public async Task GetNotification()
        {
            var client = GetReadClient();
            throw new NotImplementedException();
        }

        [TestMethod]
        public async Task ClearNotifications()
        {
            var client = GetReadClient();
            throw new NotImplementedException();
        }
    }
}
