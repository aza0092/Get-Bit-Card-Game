using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using GetBit_Project;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GetBitTest
{
    [TestClass]
    public class CardTest
    {
        [TestMethod]
        public void TestTwoEqualCards()
        {
            /// it is assumed two cards with the same value will be equal.
            /// A card that is null cannot be equal to another card
            /// a null cannot be equal to a card
            Player p = new Player(new Graphics(), "red");
            // create several cards to compare
            Card a = new Card(7, "red");
            Card b = new Card(7, "red");
            Assert.IsTrue(a == b);
        }
    }
}
