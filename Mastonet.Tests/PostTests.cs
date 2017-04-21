using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace Mastonet.Tests
{
    [TestClass]
    public class PostTests : MastodonClientTests
    {
        [TestMethod]
        public async Task UploadMedia()
        {
            var client = GetWriteClient();
            throw new NotImplementedException();
        }

        [TestMethod]
        public async Task PostStatus()
        {
            var client = GetWriteClient();
            throw new NotImplementedException();
        }

        [TestMethod]
        public async Task DeleteStatus()
        {
            var client = GetWriteClient();
            throw new NotImplementedException();
        }

        [TestMethod]
        public async Task Reblog()
        {
            var client = GetWriteClient();
            throw new NotImplementedException();
        }

        [TestMethod]
        public async Task Unreblog()
        {
            var client = GetWriteClient();
            throw new NotImplementedException();
        }
    }
}
