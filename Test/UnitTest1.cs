using HashingAlgorithm.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        [DataRow("", "D41D8CD98F00B204E9800998ECF8427E")]
        [DataRow("a", "0CC175B9C0F1B6A831C399E269772661")]
        [DataRow("abc", "900150983CD24FB0D6963F7D28E17F72")]
        [DataRow("message digest", "F96B697D7CB7938D525A2F31AAF161D0")]
        [DataRow("abcdefghijklmnopqrstuvwxyz", "C3FCD3D76192E4007DFB496CCA67E13B")]
        [DataRow("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789", "D174AB98D277D9F5A5611C2C9F419D9F")]
        [DataRow("12345678901234567890123456789012345678901234567890123456789012345678901234567890", "57EDF4A22BE3C955AC49DA2E2107B67A")]
        [DataTestMethod]
        public void HashesString(string input, string expectedHash)
        {
            var hasher = new MD5();
            hasher.ComputeHash(input);

            Assert.AreEqual(hasher.HashAsString.ToUpper(), expectedHash);

        }
    }
}
