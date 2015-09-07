﻿namespace Santase.Logic.Tests.Extensions
{
    using NUnit.Framework;

    using Santase.Logic.Extensions;

    // TODO: Improve tests (e.g. test for randomness)
    [TestFixture]
    public class RandomProviderTests
    {
        [Test]
        public void NextWithParametersShouldReturnValue()
        {
            var value = RandomProvider.Next(1, 2);
            Assert.AreEqual(1, value);
        }
    }
}
