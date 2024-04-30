using System.Globalization;
using Module3HW2;

public class Program
{
    public static void Main(string[] args)
    {
        var contacts = new Contacts();

        var en = new CultureInfo(Contacts.EnglishCultureName);
        var uk = new CultureInfo(Contacts.UkrainianCultureName);

        contacts.Add(new Contact() { FirstName = "Boris", LastName = "Johnsonyk", Number = "4324235321" }, en);
        contacts.Add(new Contact() { FirstName = "Дмитро", LastName = "Гордон", Number = "64356235321" }, uk);
        contacts.Add(new Contact() { FirstName = "Barak", LastName = "Obama", Number = "2423235321" }, en);
        contacts.Add(new Contact() { FirstName = "Ну", LastName = "типа", Number = "734321" }, uk);
        contacts.Add(new Contact() { FirstName = "$#@", LastName = "$#@", Number = "23435321" }, null);
        contacts.Add(new Contact() { FirstName = "john", LastName = "john", Number = "23435321" }, uk);

        foreach (var item in contacts)
        {
            var chapter = (KeyValuePair<string, List<IContact>>)item;

            foreach (var contact in chapter.Value)
            {
                Console.WriteLine(contact.FirstName + " " + contact.LastName);
            }
        }
    }
}