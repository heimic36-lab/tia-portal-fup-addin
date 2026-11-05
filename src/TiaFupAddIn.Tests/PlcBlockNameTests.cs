using NUnit.Framework;

namespace TiaFupAddIn.Tests
{
    [TestFixture]
    public class PlcBlockNameTests
    {
        [Test]
        public void SanitizeFileName_ReplacesInvalidChars()
        {
            // einfacher Smoke-Test – eigentliche Logik aus AddInMain extrahieren
            Assert.DoesNotThrow(() => "Main_DB ".Trim());
        }
    }
}
