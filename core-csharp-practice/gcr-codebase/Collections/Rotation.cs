using System;

class Rotation
{
    static void Main()
    {
        List<int> list = new List<int>{1,2,3,4,5,6,7,8};
        int k = 2;
        list.Reverse(0,k);
        list.Reverse(k,list.Count()-k);
        list.Reverse();
        Console.WriteLine(string.Join(", ",list));
    }

}