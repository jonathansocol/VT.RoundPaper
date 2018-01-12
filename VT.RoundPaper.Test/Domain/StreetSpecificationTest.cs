using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VT.RoundPaper.Domain;

namespace VT.RoundPaper.Domain.Test
{
    [TestClass]
    [TestCategory("Street Specification File")]
    public class StreetSpecificationTest
    {
        [TestMethod]
        public void StreetSpecificationFile_LeftStreetNumbers_AreOdd()
        {
            int[] streetNumbers = new int[] { 1, 2, 3, 4 };
            int[] leftNumbers;

            StreetSpecificationFile streetSpecification = new StreetSpecificationFile(streetNumbers);
            leftNumbers = streetSpecification.LeftStreetNumbers;

            for (int i = 0; i < leftNumbers.Length; i++)
            {
                if (leftNumbers[i] % 2 == 0)
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod]
        public void StreetSpecificationFile_RightStreetNumbers_AreEven()
        {
            int[] streetNumbers = new int[] { 1, 2, 3, 4 };
            int[] rightNumbers;

            StreetSpecificationFile streetSpecification = new StreetSpecificationFile(streetNumbers);
            rightNumbers = streetSpecification.RightStreetNumbers;

            for (int i = 0; i < rightNumbers.Length; i++)
            {
                if (rightNumbers[i] % 2 > 0)
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod]
        public void StreetNumbers_HaveCorrectFormat_IsValid()
        {
            int[] streetNumbers = new int[] { 1, 2, 3, 4 };

            StreetSpecificationFile streetSpecification = new StreetSpecificationFile(streetNumbers);

            Assert.IsTrue(streetSpecification.IsValid);
        }

        [TestMethod]
        public void StreetNumbers_SkipNumbers_IsNotValid()
        {
            int[] streetNumbers = new int[] { 1, 2, 4, 5 };

            StreetSpecificationFile streetSpecification = new StreetSpecificationFile(streetNumbers);

            Assert.IsFalse(streetSpecification.IsValid);
        }

        [TestMethod]
        public void StreetNumbers_NotStartingAtOne_IsNotValid()
        {
            int[] streetNumbers = new int[] { 2, 3, 4, 5 };

            StreetSpecificationFile streetSpecification = new StreetSpecificationFile(streetNumbers);

            Assert.IsFalse(streetSpecification.IsValid);
        }

        [TestMethod]
        public void StreetNumbers_HaveDuplicates_IsNotValid()
        {
            int[] streetNumbers = new int[] { 1, 2, 3, 3 };

            StreetSpecificationFile streetSpecification = new StreetSpecificationFile(streetNumbers);

            Assert.IsFalse(streetSpecification.IsValid);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void StreetNumbers_HaveNoNumbers_ReturnsArgumentException()
        {
            int[] streetNumbers = new int[] {};

            StreetSpecificationFile streetSpecification = new StreetSpecificationFile(streetNumbers);
        }
    }
}
