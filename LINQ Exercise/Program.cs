
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            var courses = new List<Course>
            {
                new Course {Id = 1, Name = "Calculus", Credits = 3 },
                new Course {Id = 2, Name = "Physics", Credits = 4 },
                new Course {Id = 3, Name = "Psychology", Credits = 1 },
                new Course {Id = 4, Name = "Underwater Basketweaving", Credits = 0 },
            };

            var students = new List<Student>
            {
                new Student
                {
                    Id = 1,
                    Name = "Alice",
                    Age = 20,
                    EnrolledCourseId = 3
                },
                new Student
                {
                    Id = 2,
                    Name = "Bob",
                    Age = 23,
                    EnrolledCourseId = 1
                },
                new Student
                {
                    Id = 3,
                    Name = "Charlie",
                    Age = 19,
                    EnrolledCourseId = 2
                },
                new Student
                {
                    Id = 4,
                    Name = "Diane",
                    Age = 20,
                    EnrolledCourseId = 4
                },
                new Student
                {
                    Id = 5,
                    Name = "Elliot",
                    Age = 21,
                    EnrolledCourseId = 1
                },
                new Student
                {
                    Id = 6,
                    Name = "Frank",
                    Age = 18,
                    EnrolledCourseId = 3
                },
            };


            var names = students.Select(s => s.Name);
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();
            

            students.Add(new Student
            {
                Id = 8,
                Name = "Johnnie",
                Age = 28,
                EnrolledCourseId = 3
            });

            names = students.Select(s => s.Name);
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();


            names = students.Select(s => s.Name).ToList();
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();


            int a = students.Where(s=> s.EnrolledCourseId==3).Count();
            Console.WriteLine("Number od students enrolled in Course ID 3 is: " + a);

           
            names = students.Where(s => s.Age >= 21).Select(s => s.Name);
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();


            var courseName = courses.Where(c => c.Credits >= 2).Select(c => c.Name);
            foreach (var name in courseName)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine();


            var averageAge = students.Select(s => s.Age).Average();
            Console.WriteLine(averageAge);
            
            Console.WriteLine();


            averageAge = students.Where(c => c.EnrolledCourseId == 1).Select(s => s.Age).Average();
            Console.WriteLine(averageAge);

            Console.WriteLine();


            Console.WriteLine(students.OrderByDescending(x => x.Age).First().Name);
            Console.WriteLine();


            foreach (var name in students.OrderByDescending(x => x.Age).Take(3).Select(x => x.Name))
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();

                        
            var query =
               students.Join(courses,
                (s => s.EnrolledCourseId),
                (c=> c.Id),
                (s, c) => new EnrolledStudent(s, c));

            foreach (var obj in query)
            {
                Console.WriteLine(
                    "{0} - {1}",
                    obj.StudentName,
                    obj.CourseName);
            }


            Console.ReadKey(true);
        }
    }

    class Student
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
        public int EnrolledCourseId { get; set; }
    }

    class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Credits { get; set; }
    }

    class EnrolledStudent
    {
        public EnrolledStudent(Student s, Course c)
        {
            StudentId = s.Id;
            StudentAge = s.Age;
            StudentName = s.Name;
            CourseName = c.Name;
            Credits = c.Credits;
        }

        public int StudentId { get; set; }
        public int StudentAge { get; set; }
        public string StudentName { get; set; }
        public string CourseName { get; set; }
        public int Credits { get; set; }
    }
}
