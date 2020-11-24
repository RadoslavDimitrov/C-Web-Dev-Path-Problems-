using ProductCatalog.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductCatalog.Pages
{
    public class ProductPage
    {
        public void Show(Menu menu)
        {
            bool running = true;

            while (running)
            {
                running = menu.ProductMenu();
            }
        }
    }
}
