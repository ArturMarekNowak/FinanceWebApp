using System.Net.Http;
using NUnit.Framework;
using TestProject1;
using WebApp;

namespace BaseTests
{
    public class BaseTests
    {
        protected HttpClient _client;
        protected CustomWebApplicationFactory<Startup> _customWebApplicationFactory;
        
        [OneTimeSetUp]
        public void Setup()
        {
            _customWebApplicationFactory = new CustomWebApplicationFactory<Startup>();
            _client = _customWebApplicationFactory.CreateClient();
        }
    }
}