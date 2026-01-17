// Node.cs
public class Node
{
    public string Data { get; set; }
    public Node Prev { get; set; }
    public Node Next { get; set; }

    public Node(string data)
    {
        Data = data;
        Prev = null;
        Next = null;
    }
}
