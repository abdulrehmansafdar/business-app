using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeShop.UI;

namespace CoffeeShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string ItemsPath = "Item.txt";
            string CoffeeShopsPath = "Shops.txt";

            MenuItemDL.ReadItems(ItemsPath);
           CoffeShopDL.ReadCoffeShops(CoffeeShopsPath);

            while (true)
            {
                ConsoleUtility.ClearScreen();
                string Choice = MainUI.MainMenu();
                if (Choice == "1")
                {
                    ConsoleUtility.ClearScreen();
                    MenuItemBL m = MenuItemUI.TakeInputForItem();
                    MenuItemDL.AddItemsInMenu(m);
                    MenuItemDL.StoreItem(ItemsPath, m);
                    ConsoleUtility.ReturnForAll();
                }
                else if (Choice == "2")
                {
                    ConsoleUtility.ClearScreen();
                    MenuItemUI.DisplayAllItems();
                    CoffeeShopBL c = CoffeeShopUI.TakeDetails();
                    CoffeShopDL.AddCoffeeShop(c);
                    CoffeShopDL.StoreShops(CoffeeShopsPath, c);
                    ConsoleUtility.ReturnForAll();

                }
                else if (Choice == "3")
                {
                    ConsoleUtility.ClearScreen();
                    string Name =  CoffeeShopUI.TakeNameOfShop();
                    CoffeeShopBL c = CoffeShopDL.FindShop(Name);
                    if(CoffeeShopBL.IsShop(c))
                    {
                        CoffeeShopUI.PrintCheapest(c);
                    }
                    else
                    {
                        CoffeeShopUI.PrintShopNotFound();

                    }

                    ConsoleUtility.ReturnForAll();
                }
                else if (Choice == "4")
                {
                    ConsoleUtility.ClearScreen();
                    string Name = CoffeeShopUI.TakeNameOfShop();
                    CoffeeShopBL c = CoffeShopDL.FindShop(Name);
                    if (CoffeeShopBL.IsShop(c))
                    {
                        CoffeeShopUI.DisplayDrinks(c.GetDrinks());
                    }
                    else
                    {
                        CoffeeShopUI.PrintShopNotFound();

                    }
                    ConsoleUtility.ReturnForAll();

                }
                else if (Choice == "5")
                {
                    ConsoleUtility.ClearScreen();
                    string Name = CoffeeShopUI.TakeNameOfShop();
                    CoffeeShopBL c = CoffeShopDL.FindShop(Name);
                    if (CoffeeShopBL.IsShop(c))
                    {
                        CoffeeShopUI.DisplayFoods(c.GetFoods());
                    }
                    else
                    {
                        CoffeeShopUI.PrintShopNotFound();

                    }
                    ConsoleUtility.ReturnForAll();

                }
                else if (Choice == "6")
                {
                    ConsoleUtility.ClearScreen();
                    string Name = CoffeeShopUI.TakeNameOfShop();
                    CoffeeShopBL c = CoffeShopDL.FindShop(Name);
                    if (CoffeeShopBL.IsShop(c))
                    {
                        CoffeeShopUI.DisplayMenu(c);
                        string Item = CoffeeShopUI.TakeNameOfItem();
                        if(c.AddOrder(Item))
                        {
                            CoffeeShopUI.ItemAdded();
                        }
                        else
                        {
                            CoffeeShopUI.ItemUnavailable();
                        }

                    }
                    else
                    {
                        CoffeeShopUI.PrintShopNotFound();

                    }
                    ConsoleUtility.ReturnForAll();

                }
                else if(Choice == "7")
                {
                    ConsoleUtility.ClearScreen();
                    string Name = CoffeeShopUI.TakeNameOfShop();
                    CoffeeShopBL c = CoffeShopDL.FindShop(Name);
                    if (CoffeeShopBL.IsShop(c))
                    {
                        CoffeeShopUI.ClearOrders(c);
                    }
                    else
                    {
                        CoffeeShopUI.PrintShopNotFound();

                    }
                    ConsoleUtility.ReturnForAll();

                }
                else if (Choice == "8")
                {
                    ConsoleUtility.ClearScreen();
                    string Name = CoffeeShopUI.TakeNameOfShop();
                    CoffeeShopBL c = CoffeShopDL.FindShop(Name);
                    if (CoffeeShopBL.IsShop(c))
                    {
                        CoffeeShopUI.DisplayOrders(c.Orders);
                    }
                    else
                    {
                        CoffeeShopUI.PrintShopNotFound();

                    }
                    ConsoleUtility.ReturnForAll();
                }
                else if (Choice == "9")
                {
                    ConsoleUtility.ClearScreen();
                    string Name = CoffeeShopUI.TakeNameOfShop();
                    CoffeeShopBL c = CoffeShopDL.FindShop(Name);
                    if (CoffeeShopBL.IsShop(c))
                    {
                        CoffeeShopUI.PrintTotal(c);
                    }
                    else
                    {
                        CoffeeShopUI.PrintShopNotFound();

                    }
                    ConsoleUtility.ReturnForAll();

                }
                else if(Choice == "10")
                {
                    break;
                }

            }
        }
    }
}
