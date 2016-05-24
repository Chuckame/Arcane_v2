using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dofus.Files.Dofus.Files.Maps.Types
{
    public class ColorMultiplicator
    {
        public double Red { get; private set; }
        public double Green { get; private set; }
        public double Blue { get; private set; }
        public bool IsOne { get; private set; }

        public ColorMultiplicator(double redMultiplicator, double greenMultiplicator, double blueMultiplicator, bool param4 = false)
        {
            this.Red = redMultiplicator;
            this.Green = greenMultiplicator;
            this.Blue = blueMultiplicator;
            if (!param4 && redMultiplicator + greenMultiplicator + blueMultiplicator == 0)
            {
                this.IsOne = true;
            }
        }

        public ColorMultiplicator Multiply(ColorMultiplicator param1)
        {
            if (this.IsOne)
            {
                return param1;
            }
            if (param1.IsOne)
            {
                return this;
            }
            var _loc_2 = new ColorMultiplicator(0, 0, 0);
            _loc_2.Red = this.Red + param1.Red;
            _loc_2.Green = this.Green + param1.Green;
            _loc_2.Blue = this.Blue + param1.Blue;
            _loc_2.Red = Clamp(_loc_2.Red, -128, 127);
            _loc_2.Green = Clamp(_loc_2.Green, -128, 127);
            _loc_2.Blue = Clamp(_loc_2.Blue, -128, 127);
            _loc_2.IsOne = false;
            return _loc_2;
        }

        public override string ToString()
        {
            return "[r: " + this.Red + ", g: " + this.Green + ", b: " + this.Blue + "]";
        }

        public static double Clamp(double r, double g, double b)
        {
            if (r > b)
            {
                return b;
            }
            if (r < g)
            {
                return g;
            }
            return r;
        }
    }
}
