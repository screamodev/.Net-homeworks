namespace Homeworks.Module2HW1;

internal class Node
{
     public Node(string data)
     {
          Data = data;
     }

     public string Data { get; }
     public Node Next { get; set; }
}