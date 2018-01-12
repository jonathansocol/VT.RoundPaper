using Microsoft.VisualStudio.TestTools.UnitTesting;
using VT.RoundPaper.CustomExceptions;
using VT.RoundPaper.Domain;

namespace VT.RoundPaper.Test.Domain
{
    [TestClass]
    [TestCategory("Delivery Methods")]
    public class RoundDeliveryMethodTest
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidSpecificationFileException))]
        public void RoundDeliveryMethod_IsSpecificationFileInvalid_ReturnsException()
        {
            var specificationFile = new StreetSpecificationFile(new int[] { 2, 3, 4 });
            var deliveryMethod = new RoundDeliveryMethod(specificationFile);
        }

        [TestMethod]
        public void RoundDeliveryMethod_HousesOnBothSides_CrossOnce()
        {
            int[] numbers = new int[] { 1, 2, 3, 4 };
            StreetSpecificationFile specificationFile;
            RoundDeliveryMethod deliveryMethod;

            specificationFile = new StreetSpecificationFile(numbers);
            deliveryMethod = new RoundDeliveryMethod(specificationFile);

            Assert.IsTrue(deliveryMethod.NumberOfCrossings == 1);
        }

        [TestMethod]
        public void RoundDeliveryMethod_OneOnlyHouse_NotCrossing()
        {
            int[] numbers = new int[] { 1 };
            StreetSpecificationFile specificationFile;
            RoundDeliveryMethod deliveryMethod;

            specificationFile = new StreetSpecificationFile(numbers);
            deliveryMethod = new RoundDeliveryMethod(specificationFile);

            Assert.IsTrue(deliveryMethod.NumberOfCrossings == 0);
        }

        [TestMethod]
        public void RoundDeliveryMethod_IsOrderCorrect()
        {
            var specificationFile = new StreetSpecificationFile(new int[] { 1, 2, 3, 4 });
            var deliveryMethod = new RoundDeliveryMethod(specificationFile);
            var expectedOrder = new int[] { 1, 3, 4, 2 };

            CollectionAssert.AreEqual(deliveryMethod.HouseNumbers, expectedOrder);
        }
    }
}
