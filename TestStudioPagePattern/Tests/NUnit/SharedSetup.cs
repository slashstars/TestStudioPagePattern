using NUnit.Framework;
using System;
using TestStudioPagePattern.Context;

namespace TestStudioPagePattern.Tests.NUnit
{
    [SetUpFixture]
    public class SharedSetup
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            AutomationContext.Initialize();       
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            AutomationContext.CleanUp();
        }
    }
}