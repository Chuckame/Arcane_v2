using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dofus.IO
{
    public class FinalInt64
    {
        private static readonly double POW_2_OF_32 = Math.Pow(2, 32);

        #region Variables

        public uint Low;
        public uint High;

        #endregion

        #region Builder

        public FinalInt64(uint param1 = 0, int param2 = 0)
        {
            Low = param1;
            High = (uint)param2;
        }

        #endregion

        #region Methods

        public static FinalInt64 FromNumber(Double param1)
        {
            return new FinalInt64((uint)param1, (int)Math.Floor((double)(param1 / POW_2_OF_32)));
        }

        public Double ToNumber()
        {
            return High * POW_2_OF_32 + Low;
        }

        #endregion

    }

}