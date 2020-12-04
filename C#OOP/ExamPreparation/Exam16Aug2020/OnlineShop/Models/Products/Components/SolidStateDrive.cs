using OnlineShop.Common.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Models.Products.Components
{
   public  class SolidStateDrive : Component
    {
        private const double Modifier = ComponentMultiplyers.SolidStateDrive;
        public SolidStateDrive(int id, string manufacturer, string model, decimal price, double overallPerformance, int generation)
            : base(id, manufacturer, model, price, overallPerformance * Modifier, generation)
        {
        }
    }
}
