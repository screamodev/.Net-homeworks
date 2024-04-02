using Module2HW5.Entities;

namespace Module2HW5.Data;

internal class LinkedList
{
    private Node Head { get; set; }
    private int Length { get; set; }

    internal void InsertLast(LinkedList singlyList, Result newData)
    {
        Node newNode = new Node(newData);
        Length++;
        
        if (singlyList.Head == null)
        {
            singlyList.Head = newNode;
            return;
        }

        Node lastNode = GetLastNode(singlyList);
        lastNode.Next = newNode;
    }

    internal Result[] GetAllNodes(LinkedList singlyList)
    {
        Result[] result = new Result[Length];

        Node temp = singlyList.Head;

        for (int i = 0; i < Length; i++)
        {
            result[i] = temp.Data;
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