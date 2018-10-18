using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Web;
using System.Web.Script.Serialization;

namespace ConsoleApplication4
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    int i = 10;
        //    Foo(i);
        //    Console.WriteLine(i);
        //}

        public static void Foo(int i)
        {
            i = 20;
        }
    }

    public class Persons
    {
        public int PersonId { get; set; }
        public string PersonName { get; set; }
        public double Earning { get; set; }
    }

    class Wrapper
    {
        [JsonProperty("JsonValues")]
        public ValueSet ValueSet { get; set; }
    }

    class ValueSet
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("values")]
        public Dictionary<string, Value> Values { get; set; }
    }

    class Value
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("diaplayName")]
        public string DisplayName { get; set; }
    }
    public class App
    {


        static string s;
        static DateTime d;

        public static void Main()
        {
            //Persons me = new Persons() { PersonId = 3, Earning = 10000, PersonName = "Abc" };
            //string meJson= JsonConvert.SerializeObject(me);
            //Persons ji= JsonConvert.DeserializeObject<Persons>(meJson);
            //List<Persons> personList = new List<Persons>() {
            //        new Persons() {PersonId=1,Earning=20000,PersonName="Davig" },
            //        new Persons() {PersonId=21,Earning=30000,PersonName="Davig" },
            //        new Persons() {PersonId=13,Earning=40000,PersonName="Davig" },
            //        new Persons() {PersonId=221,Earning=50000,PersonName="Davig" },
            //        new Persons() {PersonId=11,Earning=60000,PersonName="Davig" },
            //        new Persons() {PersonId=331,Earning=20000,PersonName="Davig" },
            //        new Persons() {PersonId=2221,Earning=20000,PersonName="Davig" },
            //        new Persons() {PersonId=14,Earning=20000,PersonName="Davig" },
            //        new Persons() {PersonId=16,Earning=20000,PersonName="Davig" }

            //};

            //var query = personList.GroupBy(x => x.Earning);

            //foreach (var  group in query)
            //{
            //    Console.WriteLine("Starting Group\n");
            //    Console.WriteLine("Salary Group: {0}", group.Key);
            //    Console.WriteLine("Order count: {0}", group.Count());

            //    if(group.Count()>0)
            //    {
            //        foreach (var subItem in group)
            //        {
            //            Console.WriteLine("-------------");
            //            Console.WriteLine("PersonId = " + subItem.PersonId);
            //            Console.WriteLine("Earning = " + subItem.Earning);        
            //            Console.WriteLine("Earning = " + subItem.PersonName);
            //        }
            //    }


            //    Console.WriteLine("Ending Group\n");
            //}
            //string sJSONResponse = JsonConvert.SerializeObject(personList);


            //JavaScriptSerializer ser = new JavaScriptSerializer();

            //List<Persons> myNewList = ser.Deserialize<List<Persons>>(sJSONResponse);



            //    //todayannabuygrapes 4
            //    //321wesawracecarontheradar! 7
            string str = "todayannabuygrapes";
         //   GetAllIndexes('e', "esawracecaronthe");
            int maxLength=longestPalSubstr(str);

        }

        static int longestPalSubstr(String str)
        {
            int i = 0;
            List<string> palindomes = new List<string>();
            string originalString = str;
            while (str.Length > 1)
            {
                char first = str[0];
                List<int> myList = GetAllIndexes(first, str);
                str = str.Remove(0, 1);
                int lastIndex = str.LastIndexOf(first);

                if (lastIndex > -1)
                {
                    
                    if (str[lastIndex] != str[str.Length - 1])
                        str = str.Remove(lastIndex + 1);
                    str = first + str;

                    string reversed = new string(str.Reverse().ToArray());

                    if (str == reversed)
                    {
                        palindomes.Add(str);
                        str = originalString.Remove(0, i + 1);

                    }
                    else if(myList.Count>2)
                    {
                        str = str.Remove(str.Length - 1, 1);
                        continue;
                    }

                    else
                    {
                        str = str.Remove(0, 1);
                        str = originalString.Remove(0, i + 1);
                        myList = null;
                    }
                }

                i++;
            }

            return palindomes.OrderByDescending(s => s.Length).First().Length;

        }

        private static List<int> GetAllIndexes(char ch, string str)
        {
            List<int> indexes = new List<int>();
            int ind;
            ind = str.IndexOf(ch);
            int i = 0;

            do
            {

                ind = str.LastIndexOf(ch);
                if (ind == -1)
                {
                    break;
                }
                indexes.Add(ind);
                str = str.Remove(ind);



            } while (ind != -1);

            return indexes;


        }

        private static string GetLongestPalindrome(string input)
        {
            int rightIndex = 0, leftIndex = 0;
            var x = "";
            string currentPalindrome = string.Empty;
            string longestPalindrome = string.Empty;
            for (int currentIndex = 1; currentIndex < input.Length - 1; currentIndex++)
            {
                leftIndex = currentIndex - 1;
                rightIndex = currentIndex + 1;
                while (leftIndex >= 0 && rightIndex < input.Length)
                {
                    if (input[leftIndex] != input[rightIndex])
                    {
                        break;
                    }
                    currentPalindrome = input.Substring(leftIndex, rightIndex - leftIndex + 1);
                    if (currentPalindrome.Length > x.Length)
                        x = currentPalindrome;
                    leftIndex--;
                    rightIndex++;
                }
            }
            return x;
        }

        static bool CheckPalidrome(string str)
        {

            IEnumerable<char> ch = str.Reverse();
            var reversedString = String.Concat(
             ch.Where(c => str.Contains(c))
            );

            if (str == reversedString)
            {
                return true;
            }

            return false;
        }

        public int OldWaySum(int a, int b)
        {
            return a + b;
        }

        public int NewWaySum(int a, int b) => a + b;
    }

    class Employee
    {
        static int nextEmpId;
        int empId;

        public Employee()
        {
            empId = nextEmpId++;

        }

        public int GetEmpId()
        {
            return empId;
        }

        public static int GetNextEmpId()
        {
            return nextEmpId;
        }

        public static void SetNextEmpId(int value)
        {
            nextEmpId = value;

        }
    }

    struct WeatherForecast
    {
        public float MedianTemperature { get; set; }
        public float MinTemperature { get; set; }
        public float MaxTemperature { get; set; }
        public string City { get; set; }
        public DateTime Date { get; set; }
    }




}