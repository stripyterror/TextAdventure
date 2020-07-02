using System;

public class Hammer : Item
{
    // Constructor of base class Item is called with arguments
    public Hammer(string d, int w, bool s) : base(d, w, s) {
        Console.WriteLine("Hammer ctor");
    }

    // this method 'overrides' the 'virtual' method in base class Item.
    public override void Use() {
        Console.WriteLine("Hitting the nail on the head!");
    }
}
