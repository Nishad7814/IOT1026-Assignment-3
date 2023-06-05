﻿using System;

namespace Assignment
{
    static class Program
    {
        static void Main()
        {
            // You could try creating a class that takes user input to produce packs
            // if you want more practice (PackMerchant or something)
            // You can comment out this code until you are ready to use it if you 
            // want to use the Main method for something else.
            const int PackMaxItems = 10;
            const float PackMaxVolume = 20;
            const float PackMaxWeight = 30;
            Pack pack = new(PackMaxItems, PackMaxVolume, PackMaxWeight);
            PackTester.AddEquipment(pack);

            /*
            List<InventoryItem> items = new List<InventoryItem>();

            items.Add(new Sword());
            items.Add(new Rope());
            items.Add(new Water());
            items.Add(new Food());
            items.Add(new Bow());
            items.Add(new Arrow());

            foreach (var item in items)
            {
                // Massive switch statement if we don't use inheritance/polymorphism
                System.Console.WriteLine(item.Display());
            }
            */
        }
    }
}