using OnlineShop.Common.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Models.Products.Components
{
    public class CentralProcessingUnit : Component
    {
        private const double Modifier = ComponentMultiplyers.CentralProcessingUnit;  
        public CentralProcessingUnit(int id, string manufacturer, string model, decimal price, double overallPerformance, int generation) 
            : base(id, manufacturer, model, price, overallPerformance * Modifier, generation)
        {
        }
    }
}
