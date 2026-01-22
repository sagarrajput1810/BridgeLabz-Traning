using System;

class RemoveDuplicate
{
    static void Main()
    {
        List<int> list = new List<int>{1,2,2,3,4,5,6,6,7,2,3};
        list.Sort();
        for(int i = 1; i< list.Count(); i++)
        {
            if(list[i-1] == list[i])
            {
                list.RemoveAt(i);
                i--;
            }
        }
        Console.WriteLine(string.Join(", ",list));
    }
}