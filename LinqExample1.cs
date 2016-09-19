
namespace AdvancedCsharp.Linq
{
    using Domain;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using static Helper;

    public class LinqExample1
    {

        public void Run()
        {
            ExampleOrderBy();
            ExampleDistinct();
            ExampleSelect();
            ExampleSelect2();
            ExampleSelectMany();
            ExampleOfType();
            ExampleSingleWithException();
            ExampleSingleOrDefault();
            ExampleGroupBy();
            ExampleGroupBy2();
            ExampleToDictionary();
            ExampleZip();
            ExampleSkipTake();
            ExampleConcat();
            ExampleJoin();
            ExampleLookUp();
        }

        private void ExampleOrderBy()
        {
            Header("OrderBy");
            DisplayList(TestData.AllStudents.OrderBy(x => x.Id));

        }

        private void ExampleDistinct()
        {
            Header("Distinct");

            var uniqueIds = TestData.AllStudentsWithDuplicate.GroupBy(x => x.Id).Select(x => x.First());

            DisplayList(uniqueIds);

        }

        private void ExampleSelect()
        {
            Header("Select");

            DisplayList(TestData.AllStudents.Select(x => x.FirstName.ToUpper()));
        }

        private void ExampleSelect2()
        {
            Header("Select2");

            DisplayList(TestData.CommaList.Select(x => x.Split(',')));
        }

        private void ExampleSelectMany()
        {
            Header("Select Many");

            DisplayList(TestData.CommaList.SelectMany(x => x.Split(',')));
        }

        private void ExampleOfType()
        {
            Header("OfType Student");
            DisplayList(TestData.AllPeople.OfType<Student>());

            Header("OfType Person");
            DisplayList(TestData.AllPeople.OfType<Person>()); // Alla Student'er räknas också som Person's
        }

        private void ExampleSingleWithException()
        {
            Header("Single with exception");

            var testFirstName = "Liiisa";
            Person person;

            try
            {
                person = TestData.AllPeople.Single(x => x.FirstName == testFirstName);
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine($"{testFirstName} finns inte");
                return;
            }

            Console.WriteLine($"{testFirstName} är född {person.Birthday.ToShortDateString()}");
        }

        private void ExampleSingleOrDefault()
        {
            Header("Single or default");

            var testFirstName = "Liiisa";

            var person = TestData.AllPeople.SingleOrDefault(x => x.FirstName == testFirstName);

            if (person==null)
            {
                Console.WriteLine($"{testFirstName} finns inte");
            }
            else
            {
                Console.WriteLine($"{testFirstName} är född {person.Birthday.ToShortDateString()}");
            }

        }

        private void ExampleGroupBy()
        {
            Header("Group by");

            var result = TestData.SomeNumbers.GroupBy(a => IsEven(a));

            // Grupperna är de (unika) resultatet av grupperingsfunktionen (IsEven)
            foreach (var group in result)
            {
                // Key är gruppens nyckel, i detta fall "true" eller "false"
                Console.WriteLine("IsEven = {0}:", group.Key);

                // group innehåller värdena för den nuvarane gruppen
                foreach (var value in group)
                {
                    Console.Write("{0} ", value);
                }
                Console.WriteLine();
                Console.WriteLine();
            }
        }

        private void ExampleGroupBy2()
        {
            Header("Group by - yngst utifrån favoritämne");

            foreach (var subjectGrouping in TestData.AllStudents.GroupBy(x=>x.FavoriteSubject))
            {
                var subject = subjectGrouping.Key;

                var youngestDate = subjectGrouping.Max(x => x.Birthday);

                var youngestInSubject = subjectGrouping.Where(x => x.Birthday == youngestDate).First();

                Console.WriteLine($"{youngestInSubject.FirstName} är yngst utifrån ämnet {subject}");
            }

        }

        private void ExampleToDictionary()
        {
            Header("To dictionary");
            
            // Skapar en Dictionary utifrån en lista
            // En lista består av enskilda element. En Dictionary har en "key" och en "value"
            // I detta fall så bygger vi upp en multiplikationstabell
            // Ger exception om det finns flera likadana värden är med i listan

            Dictionary<string, int> multiplicationTable = TestData.SomeNumbers.ToDictionary(v => "Number " + v, v => v * v);

            var valueOfKeyThree = multiplicationTable["Number 3"];

            Console.WriteLine($"Värdet av 'Number 3' är: {valueOfKeyThree}");

            // Det går att göra foreach över en dictionary

            foreach (KeyValuePair<string, int> pair in multiplicationTable)
            {
                Console.WriteLine(pair);
            }

        }

        private void ExampleZip()
        {
            Header("Zip");

            // Tar två listor och fogar ihop dem som ett blixtlås
            // De extra elementen får inte vara med

            var zip = TestData.SomeNumbers.Zip(TestData.SomeHighNumbersWithExtra, (a, b) => (a + " <===> " + b));

            foreach (var value in zip)
            {
                Console.WriteLine(value);
            }
        }

        private void ExampleSkipTake()
        {
            Header("SkipTake");

            // Hoppar över de första två elementen i listan och plockar ut de tre efterföljande elementen

            var skiptake = TestData.AllStudents.Skip(2).Take(3);
            DisplayList(skiptake);
        }

        private void ExampleConcat()
        {
            Header("Concat");

            // Lägger listorna efter varandra (bryr sig inte duplicerade värden)

            var concat = TestData.AllStudents.Concat(TestData.AllPeople);
            DisplayList(concat);
        }

        private void ExampleJoin()
        {
            Header("Join");

            // Inte så vanlig

            var query = from student in TestData.AllStudents
                        join order in TestData.AllOrders on student.Id equals order.PersonId
                        select new { student.FirstName, order.Product };

            foreach (var group in query)
            {
                Console.WriteLine($"{group.FirstName} bought {group.Product}");
            }
        }

        private void ExampleLookUp()
        {
            Header("Lookup");

            // Skapar en Lookup-tabell utifrån studenterna 

            var myLookup = TestData.AllStudents.ToLookup(
                                    (item) => item.Birthday,
                                    (item) => item
                                    );

            // Lookuptabellen skapar ett "fack" per födelsedag
            // Studenterna fyller år vid tre (unika) tillfällen, så det skapas tre "fack". De kan användas vid uppslag.
            // Här slår vi upp de studenter som fyller år 1980-01-01

            var entry = myLookup[new DateTime(1980, 1, 1)];

            Console.WriteLine("De som fyller år 1980-01-01:");
            DisplayList(entry);

            // I en lookuptable så kan man försöka hämta ett värde som inte finns (till skillnad från Dictionary)
            // En lookuptable kan man inte lägga till värden efter att den är skapad

            var mayNotExist = myLookup[new DateTime(1700, 1, 1)].Count(); 

            Console.WriteLine($"Antal som har födelsedag år 1700-01-01: {mayNotExist}");
        }


    }
}
