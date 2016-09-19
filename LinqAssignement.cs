
namespace AdvancedCsharp.Linq
{
    using Domain;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using static Helper;

    class LinqAssignement
    {
        // Ändra inget i denna metoden "Run()"

        public void Run()
        {
            Linq1();
            Linq2();
            Linq3();
            Linq4();
            Linq5();
            Linq6();
            Linq7(3);
            Linq7(1234);
            Linq8(3);
            Linq8(1234);
        }

        private void Linq1()
        {
            Header("Linq1");

            // Använd LINQ för att lösa uppgiften
            // Utgå ifrån "AllStudents"
            // Sortera studenterna utifrån födelsedag 
            DisplayList(TestData.AllStudents.OrderBy(x => x.Birthday));

        }


        private void Linq2()
        {
            Header("Linq2");

            // Använd LINQ för att lösa uppgiften
            // Utgå ifrån "AllStudents"
            // Ta fram de studenter som är födda 1984 eller är tidigare (alltså de som är gamla) och där favoritämnet är matematik
            // Sortera utefter Id
            DateTime Older = new DateTime(1984, 01, 01);
            DisplayList(TestData.AllStudents.OrderBy(x => x.Id).Where(b => b.Birthday < Older)

                                            .Where(b => b.FavoriteSubject == "Mathematics")
                                           
                                              );
             

        }


        private void Linq3()
        {
            Header("Linq3");


            // Lös förra uppgiften *utan* att använda Linq
            DateTime Older = new DateTime(1984, 01, 01);

            var result = TestData.AllStudents;
         

        }


        private void Linq4()
        {
            Header("Linq4");

            // Använd LINQ för att lösa uppgiften
            // Utgå ifrån "AllStudents"
            // Ta fram de studenter som har matematik som favoritämne och räkna ihop hur många böcker de har tillsammans

       

              var result = TestData.AllStudents.Where(b => b.FavoriteSubject == "Mathematics").Sum(s => s.NumberOfOwnedBooks).ToString();

            Console.Write("Antal böcker : ");
            foreach (var item in result)
            {
                Console.Write(item);
            }
 

        }

        private void Linq5()
        {
            Header("Linq5");

            // Använd LINQ för att lösa uppgiften
            // Utgå ifrån "SomeHighNumbersWithExtra"
            // Använd "Select"
            // Ta fram de nummer som är lägre än 300 och samtidigt är ett jämnt tal
            // Skapa en lista av strängar där du placerar en hakparantes runt varje heltal, t.ex [202]
            // Skriv sedan ut denna lista av strängar


           var result = TestData.HakParantes;

          

            var Extra = TestData.SomeHighNumbersWithExtra.Where(x => x < 300).Where(x => x % 2 == 0);


            foreach (var item in Extra)
            {
                Console.WriteLine(result[0] + item+ result[1]);
            }

 

        }

        private void Linq6()
        {
            Header("Linq6");

            // Använd LINQ för att lösa uppgiften
            // Utgå ifrån "AllStudents"
            // Använd "GroupBy" 

            // Gruppera studenterna utifrån vilket år de är födda
            // För varje grupp: Skriv ut en rubrik "Födelseår: XXXX" och under detta förnamnen på studenterna som fyller år detta år
            // I varje grupp ska studenterna vara sorterade på förnamn


           
            var result = from st in TestData.AllStudents
                         orderby st.Birthday
                         group st by st.Birthday;


            foreach (var grupp in result)
            {

                Console.WriteLine("Födelseår : {0}", grupp.Key.Year);


                foreach (var st in grupp)
                {
                    Console.WriteLine("* " + st.FirstName);
                }


            }

        }

        
   


        private void Linq7(int id)
        {
            Header("Linq7");

            // Använd LINQ för att lösa uppgiften
            // Utgå ifrån "AllStudents"
            // Leta upp namnet på studenten med id't som skickas in som parameter
            // Om studenten inte finns så skriv ut detta
           

          var result = TestData.AllStudents.Where(x => x.Id == id);
            

            if (result.Count() > 0)
            {
                foreach (var n in result)
                {
                     

                    Console.WriteLine("Student med id = {0} heter {1}", n.Id, n.FirstName);


                    
                }

            }
            else
            {
                 
                    Console.WriteLine("Student med id = {0} finns inte ", id);
               
            }


        }

    


        private void Linq8(int id)
        {
            Header("Linq8");

            // Använd LINQ för att lösa uppgiften
            // Utgå ifrån "AllStudents"
            // Använd "ToDictionary"
            // Bygg upp en dictionary utifrån alla studenter. Dictionary't ska bestå av Id och FirstName
            // Skriv ut dictionary't
            // Hämta sedan upp förnamnet på den student med det id som skickas in i metoden
            // Om id't inte finns i dictionary't så meddela användaren detta 

            

           Dictionary<int, string> antal = TestData.AllStudents.Where(x => x.Id == id).ToDictionary(x => x.Id, x => x.FirstName);//.Where(x => x.Key == id);
            Dictionary<int, string> result = TestData.AllStudents.ToDictionary(x => x.Id, x => x.FirstName);
            foreach (KeyValuePair<int, string> kvp in result)
            {
                Console.WriteLine("[ {0}, {1}]", kvp.Key , kvp.Value );
            }
            if(antal.Count > 0)
            {
                foreach (KeyValuePair<int, string> kvp in antal)
                {
                    Console.WriteLine("Förnamn på student med id  {0}: {1}", kvp.Key, kvp.Value);
                }

            }
            else
            {

                Console.WriteLine("Student med id = {0} finns inte ", id);

            }


        }
    }
}
