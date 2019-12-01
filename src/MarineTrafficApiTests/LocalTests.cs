
namespace MarineTrafficApiTests
{
    using MarineTrafficApi;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public static class LocalTests
    {
        private static bool hasLocalApiKey;
        private static string localApiKey = null;

        /// <summary>
        /// Allows the use of an API key for unit tests. WARNING: This will consume credit!
        /// </summary>
        public static bool AllowLocalApiKey { get; set; } = false;

        public static string LocalApiKey
        {
            get
            {
                if (!AllowLocalApiKey)
                {
                    return null;
                }

                if (hasLocalApiKey)
                {
                    return localApiKey;
                }

                hasLocalApiKey = true;
                var folderInfo = new DirectoryInfo(Environment.CurrentDirectory);
                while (folderInfo.Exists && folderInfo != folderInfo.Root)
                {
                    var filePath = Path.Combine(folderInfo.FullName, "MarineTrafficApiTests.ApiKey.txt");
                    if (File.Exists(filePath))
                    {
                        localApiKey = File.ReadAllText(filePath, Encoding.UTF8).Trim();
                        return localApiKey;
                    }

                    folderInfo = folderInfo.Parent;
                }

                return localApiKey;
            }
        }

        internal static void VerifySucceed(IMarineTrafficResult target)
        {
            Assert.IsTrue(target.Succeed, "Expected Succeed to be true in result, got " + target.Succeed + ". Error codes: " + string.Join(", ", target.Errors.Select(x => x.Code + " (" + x.Detail + ") " + x.Message)) + ".");

            if (target.Errors != null && target.Errors.Count > 0)
            {
                Assert.Fail("Result Succeed but errors are present! Error codes: " + string.Join(", ", target.Errors.Select(x => x.Code + " (" + x.Detail + ")")) + ".");
            }
        }

        internal static void VerifyFailed(IMarineTrafficResult target)
        {
            Assert.IsFalse(target.Succeed, "Expected Succeed to be false in result, got " + target.Succeed + ".");
            Assert.IsNotNull(target.Errors);
            Assert.IsTrue(target.Errors.Count > 0, "Expected error codes in result, got none.");
        }

        ////internal static void HasError(IMarineTrafficResult target, string code = null)
        ////{
        ////    Assert.IsFalse(target.Succeed, "Expected Succeed to be false in result, got " + target.Succeed + ".");
        ////    Assert.IsNotNull(target.Errors);
        ////    Assert.IsTrue(target.Errors.Any(x => x.Code.Equals(code.ToString())), "Expected error code " + code + " in result, got " + string.Join("+", target.Errors.Select(x => x.Code + " (" + x.Detail + ")")) + ".");
        ////}
    }
}
