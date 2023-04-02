# Sample selenium 4 project in C#

This kind of a template on how to structure tests in selenium 4.

What have i done?:

1. Setting up webdrivers and tear down in `SetupTest.cs` 
2. Tests and pages (POM) inherits `TestSetup class` so that the driver can be initialised once.
3. Have class that can hande response stubbing.

I got one example using Page-Object model (POM) and on that does not use it, you decide what fits you best.

Iam using a global Setup and a global teardown. The setup method initialises the webdriver, js webdriver and my custom waits method. Teardown method is closing the webdriver.

In the actual test files i also got a setup method, which is run between every test. See code.
