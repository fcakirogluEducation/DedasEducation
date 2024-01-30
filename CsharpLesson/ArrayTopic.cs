using System.Collections;

namespace CsharpLesson;

internal class ArrayTopic
{
    // bet practice yöntem değil
    //private static ArrayList numArrayList = new(); // instance variable
    public static readonly List<int> Numbers = new();
    public static Dictionary<string, string> MyDictionary = new();
    public static readonly HashSet<int> NumbersAsHashSet = new();
    public static readonly Hashtable DictionaryAsHashTable = new();
    private static int[] _numberAsArray = new int[2] { 1, 2 };

    static ArrayTopic()
    {
        //Hash
        // Kaydedildiği sıralama korunmaz
        // unique olmalı


        DictionaryAsHashTable.Add("ahmet", 23);
        DictionaryAsHashTable.Add("ahmet", 40);
        DictionaryAsHashTable.Add("mehmet", 40);


        Numbers = [1, 1, 2, 3];
        NumbersAsHashSet.Add(1);
        NumbersAsHashSet.Add(10);
        MyDictionary.Add("pen", "kalem");
        MyDictionary.Add("pen", "kalem");
        MyDictionary.Add("pen", "kalem");
        // 32 23 64 65 128
        //1. kere çalışır
    }

    private static void Method2()
    {
    }

    internal void Method1()
    {
    }


    //internal ArrayTopic(int a, int b)
    //{
    //}
}