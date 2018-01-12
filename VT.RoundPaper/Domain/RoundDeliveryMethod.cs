using System.Linq;
using VT.RoundPaper.CustomExceptions;
using VT.RoundPaper.Interfaces;

namespace VT.RoundPaper.Domain
{
    public class RoundDeliveryMethod : IDeliveryMethod
    {
        private readonly StreetSpecificationFile _streetSpecification;

        public RoundDeliveryMethod(StreetSpecificationFile streetSpecification)
        {
            if (!streetSpecification.IsValid)
            {
                throw new InvalidSpecificationFileException("Please, use a valid Street Specification File.");
            }

            _streetSpecification = streetSpecification;
        }

        public int[] HouseNumbers
        {
            get
            {
                var leftNumbers = _streetSpecification.LeftStreetNumbers;
                var rightNumbers = _streetSpecification.RightStreetNumbers;

                var plan = leftNumbers.Union(rightNumbers.Reverse()).ToArray();

                return plan;
            }            
        }

        public int NumberOfCrossings
        {
            get
            {
                if (_streetSpecification.RightStreetNumbers.Length > 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
