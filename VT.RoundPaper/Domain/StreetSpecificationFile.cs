using System;
using System.Linq;

namespace VT.RoundPaper.Domain
{
    public class StreetSpecificationFile
    {
        private readonly int[] _streetNumbers;

        public StreetSpecificationFile(int[] streetNumbers)
        {
            if (streetNumbers.Length < 1)
            {
                throw new ArgumentException("Street Specification Files must contain at least one number.");
            }

            _streetNumbers = streetNumbers.OrderBy(x => x).ToArray();
        }

        public int[] StreetNumbers
        {
            get { return _streetNumbers; }
        }

        public int[] LeftStreetNumbers
        {
            get
            {
                return _streetNumbers
                    .Where(x => x % 2 > 0)
                    .ToArray();
            }
        }

        public int[] RightStreetNumbers
        {
            get
            {
                return _streetNumbers
                    .Where(x => x % 2 == 0)
                    .ToArray(); }
        }

        public virtual bool IsValid
        {
            get
            {
                if (_streetNumbers[0] != 1)
                {
                    return false;
                }

                for (int i = 0; i < _streetNumbers.Length - 1; i++)
                {
                    if (_streetNumbers[i + 1] - _streetNumbers[i] != 1)
                    {
                        return false;
                    }
                }

                return true;
            }
        }        
    }
}
