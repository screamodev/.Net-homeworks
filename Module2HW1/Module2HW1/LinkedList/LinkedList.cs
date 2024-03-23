namespace Homeworks.Module2HW1;

internal class LinkedList
{
    private Node Head { get; set; }

    internal void InsertLast(LinkedList singlyList, string newData)
    {
        Node newNode = new Node(newData);
        if (singlyList.Head == null)
        {
            singlyList.Head = newNode;
            return;
        }

        Node lastNode = GetLastNode(singlyList);
        lastNode.Next = newNode;
    }

    internal string GetAllNodes(LinkedList singlyList)
    {
        string result = string.Empty;

        Node temp = singlyList.Head;
        while (temp.Next != null)
        {
            result += temp.Data;
            temp = temp.Next;
        }

        return result;
    }

    private Node GetLastNode(LinkedList singlyList)
    {
        Node temp = singlyList.Head;
        while (temp.Next != null)
        {
            temp = temp.Next;
        }

        return temp;
    }
}