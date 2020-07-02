using System;

public class Potion : Item
{
    // Constructor of base class Item is called with arguments
    public Potion(string d, int w, bool s) : base(d, w, s) {
        Console.WriteLine("Potion ctor");
    }

    // this method 'overrides' the 'virtual' method in base class Item.
    public override void Use() {
        Console.WriteLine("Gluck, gluck, gluck. Health restored!");
    }
}
