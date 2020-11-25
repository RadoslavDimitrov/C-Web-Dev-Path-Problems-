using ProductCatalog.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductCatalog.Utils
{
    public class Menu
    {
        private readonly ProductPage productPage;

        public Menu(ProductPage _productPage)
        {
            productPage = _productPage;
        }
        public bool MainMenu()
        {
            bool running = true;
            int option = 0;

            do
            {
                Console.Clear();
                Console.WriteLine("1. Products");
                Console.WriteLine("2. Sales");
                Console.WriteLine("3. Exit");
                Console.Write("Choose an option....");

                string opt = Console.ReadLine();

                int.TryParse(opt, out option);

            } while (option < 1 || option > 3);

            switch (option)
            {
                case 1:
                    productPage.Show(this);
                    break;
                case 2:
                    break;
                case 3:
                    running = false;
                    break;
            }

            return running;
        }

        public bool ProductMenu()
        {
            bool running = true;
            int option = 0;

            do
            {
                Console.WriteLine("1. List products");
                Console.WriteLine("2. Add product");
                Console.WriteLine("3. return to Main menun");
                Console.Write("Choose an option....");

                string opt = Console.ReadLine();

                int.TryParse(opt, out option);

            } while (option < 1 || option > 3);

            switch (option)
            {
                case 1:
                    productPage.List();
                    break;
                case 2:
                    productPage.Add();
                    break;
                case 3:
                    running = false;
                    break;
            }

            return running;
        }
    }
}
