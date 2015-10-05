using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using UnityEngine;


namespace UnityTest
{
    [TestFixture]
    [RequireComponent(typeof(LevelManager))]
    [Category("Player Tests")]
    internal class PlayerTest
        {
        [Test]
        public void CreatePlayerTest()
        {
            LevelManager lm = new LevelManager();
            lm.start();
            Assert.AreNotEqual(lm.flubba, null);
        }

    }
}
