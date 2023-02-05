using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            University university = new University();
            Course course1 = new Course("CS", "Computer Science");
            course1.AddStudent(new Student(1, "Mai", 20, 3.5f));
            course1.AddStudent(new Student(2, "Beo", 16, 3.8f));
            course1.AddStudent(new Student(3, "Bo", 15, 3.6f));
            university.AddCourse(course1);

            Course course2 = new Course("DS", "Data Science");
            course2.AddStudent(new Student(4, "Cam", 18, 3.7f));
            course2.AddStudent(new Student(5, "Du", 19, 3.75f));
            course2.AddStudent(new Student(6, "Bi", 16, 3.9f));
            university.AddCourse(course2);

            Course course3 = new Course("OOP", "Object Oriented Programming");
            course3.AddStudent(new Student(7, "Teo", 18, 3.8f));
            course3.AddStudent(new Student(8, "Tu", 16, 3.4f));
            course3.AddStudent(new Student(9, "Chao", 16, 3.55f));
            university.AddCourse(course3);


            Console.WriteLine("Học sinh có điềm cao nhất: "+university.GetTopStudent().Name);
            Console.WriteLine("Khóa học có điểm trung bình cao nhất: " + university.GetTopCourse().Name);
        }
        class Student
        {
            private int id;
            private string name;
            private int age;
            private float score;

           
            public int Id { get => id; set => id = value; }
            public string Name { get => name; set => name = value; }
            public int Age { get => age; set => age = value; }
            public float Score { get => score; set => score = value; }

            public Student(int id, string name, int age, float score)
            {
                Id = id;
                Name = name;
                Age = age;              
                Score = score;
            }
        }

        class Course
        {
            private string name;
            private string code;
            private List<Student> students;
           
            public string Name { get => name; set => name = value; }
            public string Code { get => code; set => code = value; }
            public List<Student> Students { get => students; set => students = value; }

            public Course(string code, string name)
            {
                Code = code;
                Name = name;
                Students = new List<Student>();
            }
            public void AddStudent(Student student)
            {
                Students.Add(student);
            }

            public float GetAverageScore()
            {
                if (Students.Count == 0)
                {
                    return 0;
                }
                float total = 0;
                foreach (var student in Students)
                {
                    total += student.Score;
                }
                return total / Students.Count;
            }
        }

        class University
        {
            private List<Course> courses;
            public List<Course> Courses { get => courses; set => courses = value; }

            public University()
            {
                Courses = new List<Course>();
            }
            public void AddCourse(Course course)
            {
                Courses.Add(course);
            }
            public Student GetTopStudent()
            {
                if (Courses.Count == 0)
                {
                    return null;
                }
                Student topStudent = null;
                float topScore = float.MinValue;
                foreach (Course course in Courses)
                {
                    foreach (Student student in course.Students)
                    {
                        if (student.Score > topScore)
                        {
                            topScore = student.Score;
                            topStudent = student;
                        }
                    }
                }
                return topStudent;
            }

            public Course GetTopCourse()
            {
                if (Courses.Count == 0)
                {
                    return null;
                }
                Course topCourse = null;
                float topAverage = float.MinValue;
                foreach (var course in Courses)
                {
                    float average = course.GetAverageScore();
                    if (average > topAverage)
                    {
                        topAverage = average;
                        topCourse = course;
                    }
                }
                return topCourse;
            }
        }

    }
}
