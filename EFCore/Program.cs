using EFCoreModel;
using System.Reflection;

namespace EFCore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var db = new Context())
            {
                foreach (var item in db.EventInfos.ToList())
                {
                    Console.WriteLine(item.id+"----"+item.name);
                } 

            }
        }
    }
}