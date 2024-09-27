using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic27._09._2024.Part3
{
    public delegate void ExamDelegate(string text);
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public override string ToString()
        {
            return $"{FirstName} {LastName}: {BirthDate.ToLongDateString()}";
        }
        public void Exam(string task)
        {
            Console.WriteLine($"Студент {FirstName} начал сдавать {task}");
        }
    }

    class Teacher
    {
        // [модификатор_доступа] event Имя_Делегата Имя_События;
        public event ExamDelegate examEvent;

        public void ExamInit(string task)
        {
            if (examEvent != null) 
                examEvent(task);
        }

        /*[модификатор_доступа] event Имя_Делегата Имя_События {
            add {}
            remove {}
         }
         */
        SortedList<int, ExamDelegate> _sortedList = 
            new SortedList<int, ExamDelegate>();
        Random _rand = new Random();

        public event ExamDelegate examRandomEvent
        {
            add
            {
                for (int i; ;)
                {
                    i = _rand.Next();
                    if (!_sortedList.ContainsKey(i))
                    {
                        _sortedList.Add(i, value);
                        break;
                    }
                }
            }
            remove
            {
                _sortedList.RemoveAt(_sortedList.IndexOfValue(value));
            }
        }
        public void ExamInitRandom(string task)
        {
            foreach (int i in _sortedList.Keys)
            {
                if (_sortedList[i] != null)
                {
                    _sortedList[i](task);
                }
            }
        }
    }
    internal class Program
    {
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

            Teacher teacher = new Teacher();

            foreach (Student student in students)
            {              
                 //teacher.examEvent += student.Exam;
                 teacher.examRandomEvent += student.Exam;
            }

            //teacher.ExamInit("математика");
            teacher.ExamInitRandom("математика");
        }
    }
}
