namespace BookLibrary
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<Book> books = new List<Book>()
                                               {
                      new Book("1","C#", new string[]{"Ali"}, DateTime.Now, 100),
                      new Book("2","Java", new string[]{"Sara"}, DateTime.Now, 200)
                           };

            Console.WriteLine("--------------------------------------userdefine------------------------------");
           
            LibraryEngine.ProcessBooks(books, BookFunctions.GetTitle);
            Console.WriteLine("--------------------------------------BCL Delegate (Func)------------------------------");

             
            Func<Book, string> ptr = BookFunctions.GetAuthors;

            foreach (var b in books)
            {
                Console.WriteLine(ptr(b));
            }
            Console.WriteLine("--------------------------------------Anonymous Method------------------------------");

            
            LibraryEngine.ProcessBooks(books, delegate (Book B)
            {
                return B.ISBN;
            });
            Console.WriteLine("--------------------------------------Lambda Expression------------------------------");

           
            LibraryEngine.ProcessBooks(books, B => B.PublicationDate.ToShortDateString());
        }
    }
}
