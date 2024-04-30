using Module3HW4;

public class Program
{
    public static void Main()
    {
        var task1 = new Task1();

        task1.OnCalculate += task1.Print;
        task1.OnCalculate += task1.AnotherPrint;

        task1.Run(task1.Calculate, 5, 10);

        var task2 = new Task2();

        Contact person1 = task2.CheckFirstOrDefault("Sasha");
        Console.WriteLine($"Check first or default: {person1.FirstName} {person1.LastName} {person1.Email}");

        IEnumerable<Contact> persons1 = task2.CheckWhere("John");
        Console.WriteLine($"Check where email contains John: ");

        foreach (var person in persons1)
        {
            Console.WriteLine($"{person.FirstName} {person.LastName} {person.Email}");
        }

        IEnumerable<object> persons2 = task2.CheckSelect();
        Console.WriteLine($"Select result: ");

        foreach (var person in persons2)
        {
            Console.WriteLine(person);
        }

        IEnumerable<Contact> persons3 = task2.OrderByNameDescending();
        Console.WriteLine($"Select by name result: ");

        foreach (var person in persons3)
        {
            Console.WriteLine($"{person.FirstName} {person.LastName} {person.Email}");
        }

        IEnumerable<Contact> persons4 = task2.DistinctContacts();
        Console.WriteLine($"Destinct contacts result: ");

        foreach (var person in persons4)
        {
            Console.WriteLine($"{person.FirstName} {person.LastName} {person.Email}");
        }

        bool isExist = task2.CheckAny("John");
        Console.WriteLine($"Is person exist?: {isExist}");
    }
}