using System.Collections.Generic;

namespace ListManager
{
    public class ListManager
    {
        public void AddElement(List<int> list, int element)
        {
            if (list == null)
                return;

            list.Add(element);
        }

        public void RemoveElement(List<int> list, int element)
        {
            if (list == null)
                return;

            list.Remove(element);
        }

        public int GetSize(List<int> list)
        {
            if (list == null)
                return 0;

            return list.Count;
        }
    }
}
