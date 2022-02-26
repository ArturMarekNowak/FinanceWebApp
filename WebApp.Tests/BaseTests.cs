using System.Net.Http;
using NUnit.Framework;
using TestProject1;
using WebApp;

namespace BaseTests
{
    public class BaseTests
    {
        protected HttpClient Client;
        private CustomWebApplicationFactory<Startup> _customWebApplicationFactory;
        
        [OneTimeSetUp]
        public void Setup()
        {
            _customWebApplicationFactory = new CustomWebApplicationFactory<Startup>();
            Client = _customWebApplicationFactory.CreateClient();
        }
    }
}