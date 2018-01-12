using VT.RoundPaper.CustomExceptions;
using VT.RoundPaper.Interfaces;

namespace VT.RoundPaper.Domain
{
    public class AscendingDeliveryMethod : IDeliveryMethod
    {
        private readonly StreetSpecificationFile _streetSpecification;

        public AscendingDeliveryMethod(StreetSpecificationFile streetSpecification)
        {
            if (!streetSpecification.IsValid)
            {
                throw new InvalidSpecificationFileException("Please, use a valid Street Specification File.");
            }

            _streetSpecification = streetSpecification;
        }

        public int[] HouseNumbers
        {
            get { return _streetSpecification.StreetNumbers; }            
        }

        public int NumberOfCrossings
        {
            get { return _streetSpecification.StreetNumbers.Length - 1; }            
        }
    }
}
