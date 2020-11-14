using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes.Attributes
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        private int minValue;
        private int maxValue;
        public MyRangeAttribute(int min, int max)
        {
            this.minValue = min;
            this.maxValue = max;
        }
        public override bool IsValid(object objProperty)
        {
            int intObj = Convert.ToInt32(objProperty);

            return intObj >= this.minValue && intObj <= this.maxValue;
        }
    }
}
