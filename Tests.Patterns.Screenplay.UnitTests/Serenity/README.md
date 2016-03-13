# Serenity BDD

## Things I do not like

* "Dirty" fluent API - Actor has Name property witch is shown in intelisense. It is used only for loging purposes so it could should be ditributed. In C# it coudl be done through implicit interfacce implemntation witch is used only by loging mechanism. (SRP, ISP)
* Not clear what is the asActor method in Ability class. This provide such strange code like as method in BrowseTheWeb class (`return actor.abilityTo(BrowseTheWeb.class).asActor(actor);`) why not just return actor.abilityTo(BrowseTheWeb.class). Again some placeholder for feature reusability (YAGNI). 
* Page object aloow to pass IWebDriver through constructor as well as property seter. As the result the Open action get the web drier from browseTheWeb ability and set it on the target PageObject before call open method. THs add aditional complexity when we want to find out what the webdriver i came from. Why not use some Di contaner?
* usage of 'instrumented' method it is DI and loging binder in one.
* As such Serenity screenplay as the implemnatation pretend to have solid design backgrand conform to the most poular pricipies. Unfortunetly it valiotates lots of them.