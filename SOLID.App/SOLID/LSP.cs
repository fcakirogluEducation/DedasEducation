namespace SOLID.App.SOLID.LSP;

public interface ITakePhoto
{
    void TakePhoto();
}

public abstract class Phone
{
    public void Call()
    {
        Console.WriteLine("Phone is calling");
    }
}

public class SmartPhone : Phone, ITakePhoto
{
    public void TakePhoto()
    {
        Console.WriteLine("Take Photo");
    }
}

public class OldPhone : Phone
{
}