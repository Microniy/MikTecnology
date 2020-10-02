using System;
using System.Linq;

namespace InitializationDB
{
    class Program
    {
        static void Main(string[] args)
        {
            using(RepositoryDB.ApplicationContext db=new RepositoryDB.ApplicationContext())
            {
                var links = db.Links.ToList();
                Console.WriteLine("Count - "+ links.Count());
            }
            Console.WriteLine("Exit..");
        }
    }
}
