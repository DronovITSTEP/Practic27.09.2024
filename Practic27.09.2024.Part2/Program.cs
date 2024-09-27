using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Practic27._09._2024.Part2
{
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public override string ToString()
        {
            return $"{FirstName} {LastName}: {BirthDate.ToLongDateString()}";
        }
    }
    internal class Program
    {
        static void FullName(Student student)
        {
            Console.WriteLine($"{student.FirstName} {student.LastName}");
        }
        static string FullName2(Student student)
        {
            return $"{student.FirstName} {student.LastName}";
        }
        static bool DecemberOnly(Student student)
        {
            return student.BirthDate.Month == 12;
        }
        static int SortedStudent(Student student1, Student student2)
        {
            return student1.BirthDate.CompareTo(student2.BirthDate);
        }
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>
            {
                new Student
                {
                    FirstName = "Ivan",
                    LastName = "Ivanov",
                    BirthDate = DateTime.Parse("1992-12-5")
                },
                new Student
                {
                    FirstName = "Petr",
                    LastName = "Petrov",
                    BirthDate = DateTime.Parse("1990-5-16")
                },
                new Student
                {
                    FirstName = "Sergey",
                    LastName = "Sergeev",
                    BirthDate = DateTime.Parse("1992-12-15")
                },
                new Student
                {
                    FirstName = "Elena",
                    LastName = "Elenova",
                    BirthDate = DateTime.Now
                }
            };

            // void Action<T> (T t1, ..., T t16); 
            students.ForEach(FullName);

            Console.WriteLine();

            // T Func<TResult, T> (TResult res1, ... , TResult t16);
            IEnumerable<string> studs = students.Select(FullName2);
            foreach (string stud in studs)
            {
                Console.WriteLine(stud);
            }

            // bool Predicate<T>(T t)
            List<Student> decemberStudents = students.FindAll(DecemberOnly);
            foreach (Student student in decemberStudents)
            {
                Console.WriteLine(student);
            }

            Console.WriteLine();
            // int Comparison<T> (T t1, T t2)
            students.Sort(SortedStudent);
            foreach (Student student in students)
            {
                Console.WriteLine(student);
            }
        }
    }
}
