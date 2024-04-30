namespace Module3HW4;

public class Task2
{
   private List<Contact> _list;

   public Task2()
   {
      _list = new List<Contact>()
      {
         new Contact() { Id = 1, FirstName = "John", LastName = "Johnson", Email = "John32@gmail.com" },
         new Contact() { Id = 1, FirstName = "John", LastName = "Johnson", Email = "John32@gmail.com" },
         new Contact() { Id = 1, FirstName = "John", LastName = "Johnson", Email = "John32@gmail.com" },
         new Contact() { Id = 2, FirstName = "Julia", LastName = "Johnson", Email = "Julia333@gmail.com" },
         new Contact() { Id = 3, FirstName = "Sonya", LastName = "Johnson", Email = "Sonya32@gmail.com" },
         new Contact() { Id = 4, FirstName = "Valentin", LastName = "Johnson", Email = "Valentin12@gmail.com" },
         new Contact() { Id = 5, FirstName = "Sasha", LastName = "Johnson", Email = "Sasha2@gmail.com" },
         new Contact() { Id = 6, FirstName = "Katya", LastName = "Johnson", Email = "Katya432@gmail.com" },
         new Contact() { Id = 7, FirstName = "John", LastName = "Johnson", Email = "John3342@gmail.com" },
      };
   }

   public Contact CheckFirstOrDefault(string name)
   {
      return _list.FirstOrDefault(contact => contact.FirstName == name);
   }

   public IEnumerable<Contact> CheckWhere(string query)
   {
      return _list.Where(contact => contact.Email.Contains(query));
   }

   public IEnumerable<object> CheckSelect()
   {
      return _list.Select(contact => new
      {
         Name = contact.FirstName + " " + contact.LastName,
         Email = contact.Email
      });
   }

   public IEnumerable<Contact> OrderByNameDescending()
   {
      return _list.OrderByDescending(contact => contact.FirstName);
   }

   public IEnumerable<Contact> DistinctContacts()
   {
      return _list.DistinctBy(contact => contact.FirstName);
   }

   public bool CheckAny(string name)
   {
      return _list.Any(contact => contact.FirstName == name);
   }
}