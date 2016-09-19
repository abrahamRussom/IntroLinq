
namespace AdvancedCsharp.Linq.Domain
{
    using System;

    public class Person 
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public DateTime Birthday { get; set; }

        public override string ToString()
        {
            return $"Person\t{Id}\t{FirstName}\t{Birthday.ToShortDateString()}";
        }
    }
}
