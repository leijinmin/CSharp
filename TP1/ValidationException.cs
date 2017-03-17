using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    public class DateOutOfRangeExceiption : ArgumentOutOfRangeException
    {
        public DateOutOfRangeExceiption()
        {}

        public DateOutOfRangeExceiption(string message)
            : base(message)
        {}

        public DateOutOfRangeExceiption(string message, Exception inner)
            : base(message, inner)
        {}
    }

    public class HeureOutOfRangeExceiption : ArgumentOutOfRangeException
    {
        public HeureOutOfRangeExceiption()
        {}

        public HeureOutOfRangeExceiption(string message)
            : base(message)
        {}

        public HeureOutOfRangeExceiption(string message, Exception inner)
            : base(message, inner)
        {}
    }

    public class VilleInattandueExceiption : NotSupportedException
    {
        public VilleInattandueExceiption()
        {}

        public VilleInattandueExceiption(string message)
            : base(message)
        {}

        public VilleInattandueExceiption(string message, Exception inner)
            : base(message, inner)
        {}
    }

    public class TempsDifferenceExceiption : ArgumentException
    {
        public TempsDifferenceExceiption()
        {}

        public TempsDifferenceExceiption(string message)
            : base(message)
        {}

        public TempsDifferenceExceiption(string message, Exception inner)
            : base(message, inner)
        {}
    }
}
