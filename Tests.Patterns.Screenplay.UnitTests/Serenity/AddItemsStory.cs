using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Patterns.Screenplay.UnitTests.Serenity
{
    // http://thucydides.info/docs/articles/screenplay-tutorial.html
    [TestFixture]
    public class AddItemsStory
    {
        [SetUp]
        public void SetUp()
        {
            _justin = Actor.Named("Justin");
            _hisBrowser = new ChromeDriver();

            _justin.Can(BrowseTheWeb.With(_hisBrowser));
        }
        private Actor _justin;
        private IWebDriver _hisBrowser;

        [TearDown]
        public void TearDown()
        {
            if (_hisBrowser != null) _hisBrowser.Dispose();
        }

        [Test]
        // Actor named Ana can browse The Web with new Browser
        public void ShouldBeAbleToAddAnItemToTheTodoList()
        {
            _justin.WasAbleTo(StartWith.AnEmptyTodoList());
        }

        class BrowseTheWeb : Perform
        {
            protected BrowseTheWeb(IWebDriver browser)
            {
                _browser = browser;
            }
            public IWebDriver Browser
            {
                get { return _browser; }
            }
            private readonly IWebDriver _browser;


            public static BrowseTheWeb With(IWebDriver browser)
            {
                return new BrowseTheWeb(browser);
            }

            // TBD: Is there any scenario where this will be relay used as the only methdo of the Ability in Serenity?
            public override void As(Actor actor)
            {

            }

            public static BrowseTheWeb By(Actor actor)
            {
                return actor.AbilityTo<BrowseTheWeb>();
            }
        }

        class StartWith : Perform
        {
            public static StartWith AnEmptyTodoList()
            {
                return new StartWith();
            }

            public override void As(Actor actor)
            {
                actor.AttemptsTo(Open.BrowserOn(new TodoMvcApplicationHomePage()));
            }
        }
        class Open : Perform
        {
            public Open(Page page)
            {
                _page = page;
            }
            private readonly Page _page;

            public override void As(Actor actor)
            {
                // TBD: Mayby pass the Browser only by constructor? Is the reason resuability in singleton pattern style?
                _page.Browser = BrowseTheWeb.By(actor).Browser;
                _page.Open();
            }

            public static Perform BrowserOn(Page page)
            {
                return new Open(page);
            }
        }

        class TodoMvcApplicationHomePage : Page
        {
            public TodoMvcApplicationHomePage()
                : base("http://todomvc.com/examples/dojo/")
            {
            }
        }
    }
}
