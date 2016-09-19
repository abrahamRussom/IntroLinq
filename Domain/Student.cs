
namespace AdvancedCsharp.Linq.Domain
{
    public class Student: Person
    {
        public string FavoriteSubject { get; set; }
        public int NumberOfOwnedBooks { get; set; }

        public override string ToString()
        {
            return $"Student\t{Id}\t{FirstName}\t{Birthday.ToShortDateString()}\t{FavoriteSubject}\t{NumberOfOwnedBooks}";
        }
    }
}

