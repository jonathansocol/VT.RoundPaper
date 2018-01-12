using Microsoft.VisualStudio.TestTools.UnitTesting;
using VT.RoundPaper.CustomExceptions;
using VT.RoundPaper.Domain;

namespace VT.RoundPaper.Test.Domain
{
    [TestClass]
    [TestCategory("Delivery Methods")]
    public class AscendingDeliveryMethodTest
    {
        int[] numbers = new int[] { 1, 2, 3, 4 };
        AscendingDeliveryMethod deliveryMethod;

        [TestInitialize]
        public void Initialize()
        {
            var specificationFile = new StreetSpecificationFile(numbers);
            deliveryMethod = new AscendingDeliveryMethod(specificationFile);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidSpecificationFileException))]
        public void AscendingDeliveryMethod_IsSpecificationFileInvalid_ReturnsException()
        {
            var specificationFile = new StreetSpecificationFile(new int[] { 2, 3, 4 });
            var deliveryMethod = new AscendingDeliveryMethod(specificationFile);
        }

        [TestMethod]
        public void AscendingDeliveryMethod_CrossingsAreCorrect()
        {
            Assert.IsTrue(deliveryMethod.NumberOfCrossings == numbers.Length - 1);
        }

        [TestMethod]
        public void AscendingDeliveryMethod_IsOrderCorrect()
        {
            var expectedOrder = new int[] { 1, 2, 3, 4 };

            CollectionAssert.AreEqual(deliveryMethod.HouseNumbers, expectedOrder);
        }
    }
}
