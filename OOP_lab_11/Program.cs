using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOP_lab_11
{
    class Program
    {
        static void Main(string[] args)
        {


            string[] month = { "January",
                "Februaby",
                "March",
                "April",
                "May", "June",
                "July",
                "August",
                "Septemer",
                "October",
                "November",
                "December"};


            Console.WriteLine("Введите кол-во букв в названии месяца");

            int с = Convert.ToInt32(Console.ReadLine());

            var query1 = from m in month
                where m.Length == с
                select m;

            Console.WriteLine("месяц c введенной длиной");

            foreach (var item in query1)
            {
                Console.WriteLine(" {0} ", item);
            }

            IEnumerable<string> month1 = month.Skip(5);
            IEnumerable<string> month2 = month1.Take(3);
            Console.WriteLine("Летние месяцы:");
            foreach (string s in month2)
            {
                Console.WriteLine(s);
            }
            IEnumerable<string> month3 = month.Take(2).Concat(month.Skip(11));
            Console.WriteLine("Зимние месяцы:");
            foreach (string s in month3)
            {
                Console.WriteLine(s);
            }

            var query3 = from m in month
                         orderby m
                         select m;

            Console.WriteLine("Month sort");
            foreach (var item in query3)
            {
                Console.Write("-{0}-", item);
            }

            Console.WriteLine(  );

            var query4 = from m in month
                         where m.Contains("u") == true
                         where m.Length > 4
                         select m;

            Console.WriteLine("Month with U and have more then 4 litter");
            foreach (var item in query4)
            {
                Console.Write(" {0} ", item);
            }

            Console.WriteLine(  );

            List<Date> list = new List<Date>();

            list.Add(new Date(12, 4));
            list.Add(new Date(20, 4));
            list.Add(new Date(13, 9));
            list.Add(new Date(1, 1));
            list.Add(new Date(13, 9));
            list.Add(new Date(9, 2));

            var listQuery1 = from m in list
                             where m.hour == 12
                             select m;
            foreach (var item in listQuery1)
            {
                Console.WriteLine("Время с заданным числом часов: ");
                item.InfoOfDate();
            }

            var listQuery2 = from m in list
                             where m.hour >= 0 && m.hour <= 6
                             select m;
            foreach (var item in listQuery2)
            {
                Console.WriteLine("Night:");
                item.InfoOfDate();
            }
            listQuery2 = from m in list
                where m.hour >= 7 && m.hour <= 12
                select m;
            foreach (var item in listQuery2)
            {
                Console.WriteLine("Morning:");
                item.InfoOfDate();
            }
            listQuery2 = from m in list
                where m.hour >= 13 && m.hour <= 18
                select m;
            foreach (var item in listQuery2)
            {
                Console.WriteLine("Middle:");
                item.InfoOfDate();
            }
            listQuery2 = from m in list
                where m.hour >= 19 && m.hour <= 24
                select m;
            foreach (var item in listQuery2)
            {
                Console.WriteLine("evening:");
                item.InfoOfDate();
            }



            var listQuery4 = from m in list
                             orderby m.hour descending, m.minut
                             select m;

            var buf = listQuery4.Last();
            Console.WriteLine("Минимальное время -");
            buf.InfoOfDate();

            var listQuery3 = from m in list
                             where m.hour == m.minut
                             select m;
            foreach (var item in listQuery3)
            {
                Console.WriteLine("Первое совпадающее время:");
                item.InfoOfDate();
            }

            Console.WriteLine("Cортировка по времени: ");
            var listQuery6 = from m in list
                             orderby m.hour, m.minut
                             select m;
            foreach (var item in listQuery6)
            {
                item.InfoOfDate();
            }

           //task 4-5

                List<int> list1 = new List<int>();
                list1.AddRange(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });

                List<int> list2 = new List<int>();
                list2.AddRange(new int[] { 2, 4, 6, 8, 10 });

                var selectedList = from t1 in list1
                    join t2 in list2 on t1 equals t2
                    orderby t1
                    select t1;

                Console.Write("Task 4: ");
                foreach (var s in selectedList)
                {
                    Console.Write(s + " ");
                }
                Console.WriteLine();
            

        }

        class Date
        {


            static int CountOfObjects = 0;
            private int HourValue;
            private int MinValue;

            public void InfoOfDate()
            {

                Console.WriteLine("--- {0}:{1}", this.hour, this.minut);
            }
            //
            public int hour
            {
                get
                {
                    return HourValue;
                }
                set
                {
                    HourValue = value;
                }
            }

            public int minut
            {
                get
                {
                    return MinValue;
                }
                set
                {
                    MinValue = value;
                }
            }


            public Date(int h, int m)
            {
                hour = h;
                minut = m;
                
                if (h < 0 || h > 24 || m < 0 || m > 60)
                {
                    Console.WriteLine("Некорректно введены данные");
                }
            }

            public override bool Equals(object obj)
            {
                if (obj == null) return false;
                if (obj.GetType() != this.GetType()) return false;
                Date stud = (Date)obj;
                return (this.hour == stud.hour && this.minut == stud.minut);
            }

            public override int GetHashCode()
            {
                int hash = 269;
                hash = (hour < 0) ? 0 : hour.GetHashCode();
                return hash;
            }
        }


    }
    
}
