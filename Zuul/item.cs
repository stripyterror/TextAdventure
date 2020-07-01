using System;

public abstract class Item
{
    public string description { get; set; }
    public int weight { get; set; }

    public Item(string d, int w) {
        Console.WriteLine("Item ctor");
        this.description = d;
        this.weight = w;
    }

    // this method is executed when called on a subclass.
    public void Show() {
        Console.WriteLine(" - Item '" + this.description + "' weighs " + this.weight);
    }

    // this method is 'virtual', and should be 'override' in subclasses.
    public virtual void Use() {
        Console.WriteLine("Generic 'Use' method called");
    }
}
