// ---- C# I (Dor Ben Dor) ----
// Ori Shacham-Barr
// ----------------------------

class Program
{
    static void Main(string[] args)
    {
        StringList list = new StringList();
        
        list.Add("1");
        list.Add("2");
        list.Add("3");
        list.Add("4");
        list.Add("5");
        list.Add("6");

        list.Remove("5");
        list.RemoveAt(3);

        list.Print();
        list.Clear();
        list.Print();
    }
}