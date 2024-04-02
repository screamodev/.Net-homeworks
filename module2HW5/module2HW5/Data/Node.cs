using Module2HW5.Entities;

namespace Module2HW5.Data;

internal class Node
{
    public Node(Result data)
    {
        Data = data;
    }

    public Result Data { get; }
    public Node Next { get; set; }
}