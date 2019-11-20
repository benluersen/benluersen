using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;
using Capstone;
using CapstoneCLI;

namespace VendingMachineTests
{
    [TestClass]
    public class VendingMachineTests
    {
        [TestMethod]
        public void FeedMoneyTest()
        {
            VendingMachine vendingMachineTest = new VendingMachine();
            vendingMachineTest.FeedMoney(10M);
            Assert.AreEqual(10M, vendingMachineTest._balance);
        }
        [TestMethod]
        public void PurchaseTest()
        {
            VendingMachine vendingMachineTest = new VendingMachine();
            vendingMachineTest.CreateItemDictionary(Program.FILE_PATH);
            vendingMachineTest.FeedMoney(10M);
            vendingMachineTest.Purchase("a1");
            Assert.AreEqual(6.95M, vendingMachineTest._balance);
        }
        [TestMethod]
        public void PurchaseUpdatesTotalMoneyTest()
        {
            VendingMachine vendingMachineTest = new VendingMachine();
            vendingMachineTest.CreateItemDictionary(Program.FILE_PATH);
            vendingMachineTest.FeedMoney(20M);
            vendingMachineTest.Purchase("a1");
            vendingMachineTest.Purchase("b2");
            vendingMachineTest.Purchase("a3");
            vendingMachineTest.Purchase("b4");
            vendingMachineTest.Purchase("d1");
            Assert.AreEqual(9.90M, vendingMachineTest._totalMoney);
        }
        [TestMethod]
        public void PurchaseUpdatesQuantityTest()
        {
            VendingMachine vendingMachineTest = new VendingMachine();
            vendingMachineTest.CreateItemDictionary(Program.FILE_PATH);
            vendingMachineTest.FeedMoney(20M);
            vendingMachineTest.Purchase("A1");
            Assert.AreEqual(4, vendingMachineTest._itemDictionary["A1"].ItemQuantity);
        }
        [TestMethod]
        public void MakeChangeReturnsQuartersTest()
        {
            VendingMachine vendingMachineTest = new VendingMachine();
            vendingMachineTest.FeedMoney(10M);
            Assert.IsTrue(vendingMachineTest.MakeChange().Contains("40"));

        }
        [TestMethod]
        public void MakeChangeReturnsDimesTest()
        {
            VendingMachine vendingMachineTest = new VendingMachine();
            vendingMachineTest.FeedMoney(.1M);
            Assert.IsTrue(vendingMachineTest.MakeChange().Contains("1"));

        }
        [TestMethod]
        public void MakeChangeReturnsNickelsTest()
        {
            VendingMachine vendingMachineTest = new VendingMachine();
            vendingMachineTest.FeedMoney(.05M);
            Assert.IsTrue(vendingMachineTest.MakeChange().Contains("1"));

        }
    }
}
