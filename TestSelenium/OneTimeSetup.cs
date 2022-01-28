using System;
using System.IO;
using NUnit.Framework;

namespace TestSelenium
{
    public class OneTimeSetup
    {
        [OneTimeSetUp]
        public void Init()
        {
            Environment.CurrentDirectory = Path.GetDirectoryName(GetType().Assembly.Location);
        }
    }
}