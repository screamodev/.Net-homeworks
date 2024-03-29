namespace Homeworks.Module2HW1;

internal class Node
{
    public Node(Result data)
    {
        Data = data;
    }

    public Result Data { get; }
    public Node Next { get; set; }
}