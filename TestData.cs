
namespace AdvancedCsharp.Linq
{
    using Domain;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class TestData
    {
        public static int[] SomeNumbers
        {
            get
            {
                return new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            }
        }

        public static int[] SomeHighNumbers
        {
            get
            {
                return new[] { 201, 202, 203, 204, 205, 206, 207, 208, 209 };
            }
        }


        public static int[] SomeHighNumbersWithExtra
        {
            get
            {
                return new[] { 201, 202, 203, 204, 205, 206, 207, 208, 209, 3000, 4000, 5000, 6000 };
            }
        }

        public static string[] CommaList
        {
            get
            {
                return new[]{
                    "what,did",
                    "the",
                    "fox,say"
                };
            }
        }



       

        public static List<string> HakParantes
        {
            get
            {

                return new List<string> {"[", "]" };
            }
        }

        public static List<Order> AllOrders
        {
            get
            {
                return new List<Order>
                {
                    new Order{Id=100, PersonId = 2, Product = "Book"},
                    new Order{Id=101, PersonId = 2, Product = "Game"},
                    new Order{Id=102, PersonId = 3, Product = "Game"},
                    new Order{Id=103, PersonId = 4, Product = "Computer"},
                };
            }
        }


        public static List<Student> Dikt
        {
            get
            {
                List<Student> stuList = new List<Student>();
               Dictionary<int, string> result =  stuList.ToDictionary(x => x.Id, x => x.FirstName);

                return stuList;
            }
        }
        public static List<Student> AllStudents
        {
            get
            {
                List<Student> li = new List<Student>();
                li.Add(new Student { Id = 1, FirstName = "Lisa", Birthday = new DateTime(1980, 1, 1), FavoriteSubject = "Geography", NumberOfOwnedBooks = 10 });
                li.Add(new Student { Id = 2, FirstName = "Ali", Birthday = new DateTime(1985, 2, 2), FavoriteSubject = "Geography", NumberOfOwnedBooks = 10 });
                li.Add(new Student { Id = 4, FirstName = "George", Birthday = new DateTime(1960, 3, 3), FavoriteSubject = "Mathematics", NumberOfOwnedBooks = 20 });
                li.Add(new Student { Id = 5, FirstName = "Susan", Birthday = new DateTime(1960, 3, 3), FavoriteSubject = "Mathematics", NumberOfOwnedBooks = 30 });
                li.Add(new Student { Id = 3, FirstName = "Britney", Birthday = new DateTime(1980, 1, 1), FavoriteSubject = "Mathematics", NumberOfOwnedBooks = 40 });

                return li;
                //return  new List<Student>
                //{
                //    new Student {Id=1, FirstName="Lisa", Birthday=new DateTime(1980, 1, 1), FavoriteSubject="Geography", NumberOfOwnedBooks=10},
                //    new Student {Id=2, FirstName="Ali", Birthday=new DateTime(1985, 2, 2), FavoriteSubject="Geography", NumberOfOwnedBooks=10},
                //    new Student {Id=4, FirstName="George", Birthday=new DateTime(1960, 3, 3), FavoriteSubject="Mathematics", NumberOfOwnedBooks=20},
                //    new Student {Id=5, FirstName="Susan", Birthday = new DateTime(1960, 3, 3), FavoriteSubject = "Mathematics", NumberOfOwnedBooks = 30 },
                //    new Student {Id=3, FirstName="Britney", Birthday=new DateTime(1980, 1, 1), FavoriteSubject="Mathematics", NumberOfOwnedBooks=40},
                //};
            }
        }


        //public static List<Student> Linq3
        //{
        //    get
        //    {
        //        List<Student> lista = new List<Student>();
        //        //  li.Sort((x, y) => int.Compare(x.Id, y.Id));
        //        lista.Sort((x, y) => int.TryParse(Comparer(x.Id, y.Id)));
                
        //        lista.Sort((a, b) => a.CompareTo(b));

        //        var sort = 
        //        return true;


        //    }
        //}

        public static List<Student> AllStudentsWithDuplicate
        {
            get
            {
                return AllStudents.Concat(
                    new List<Student> {
                        new Student { Id = 5, FirstName = "Susan", Birthday = new DateTime(1960, 3, 3), FavoriteSubject = "Mathematics", NumberOfOwnedBooks = 30 }
                }).ToList();
            }
        }

        public static List<Person> AllPeople
        {
            get
            {
                return SomePeople.Concat(AllStudents).ToList();
            }
        }

        static List<Person> SomePeople
        {
            get
            {
                return new List<Person>
                {
                    new Person {Id=100, FirstName="Mikael", Birthday=new DateTime(1985, 1, 1) },
                    new Person {Id=101, FirstName="Julia", Birthday=new DateTime(1985, 1, 1) }
                };
            }
        }
    }
}
