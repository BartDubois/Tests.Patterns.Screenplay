using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Patterns.Screenplay
{
    public abstract class Page
    {
        protected Page(string url)
        {
            _url = url;
        }
        private readonly string _url;

        public IWebDriver Browser { get; set; }

        public void Open()
        {
            Browser.Navigate().GoToUrl(_url);
        }
    }
}
