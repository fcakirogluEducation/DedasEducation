namespace CsharpLesson;

internal class Product
{
    //anti-pattern
    internal static int Tax = 20; //Field
    internal int Count = 100;

    internal int GetPrice()
    {
        return Count * Tax;
    }


    internal static int GetQuantity()
    {
        return 100;
    }
}