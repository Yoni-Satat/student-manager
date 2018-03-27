using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using StudentManager.Models;

namespace StudentManager.DAL
{
    public class SMInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<SMContext>
    {
        protected override void Seed(SMContext context)
        {
            var students = new List<Student>
            {
            new Student{FirstName="Carson",LastName="Alexander",DateOfBirth=DateTime.Parse("2005-09-01"),
                        MatricNumber ="SN0001", Gender="Male",
                        Adjustments=true, Origin="UK", YearOfStudy=2018, ImageURL=""},
            new Student{FirstName="Meredith",LastName="Alonso",DateOfBirth=DateTime.Parse("2002-04-11"),
                        MatricNumber ="SN0002", Gender="Female",
                        Adjustments=true, Origin="UK", YearOfStudy=2018, ImageURL=""},
            new Student{FirstName="Arturo",LastName="Anand",DateOfBirth=DateTime.Parse("2003-09-01"),
                        MatricNumber ="SN0003", Gender="Male",
                        Adjustments=true, Origin="EU", YearOfStudy=2018, ImageURL=""},
            new Student{FirstName="Gytis",LastName="Barzdukas",DateOfBirth=DateTime.Parse("2002-09-01"),
                        MatricNumber ="SN0004", Gender="Male",
                        Adjustments=false, Origin="USA", YearOfStudy=2018, ImageURL=""},
            new Student{FirstName="Yan",LastName="Li",DateOfBirth=DateTime.Parse("2002-09-01"),
                        MatricNumber ="SN0005", Gender="Male",
                        Adjustments=true, Origin="UK", YearOfStudy=2018, ImageURL=""},
            new Student{FirstName="Peggy",LastName="Justice",DateOfBirth=DateTime.Parse("2001-09-01"),
                        MatricNumber ="SN0006", Gender="Female",
                        Adjustments=false, Origin="UK", YearOfStudy=2018, ImageURL=""},
            new Student{FirstName="Laura",LastName="Norman",DateOfBirth=DateTime.Parse("2003-09-01"),
                        MatricNumber ="SN0007", Gender="Female",
                        Adjustments=false, Origin="UK", YearOfStudy=2018, ImageURL=""},
            new Student{FirstName="Nino",LastName="Olivetto",DateOfBirth=DateTime.Parse("2005-09-01"),
                        MatricNumber ="SN0008", Gender="Male",
                        Adjustments=false, Origin="UK", YearOfStudy=2018, ImageURL=""}
            };

            students.ForEach(s => context.Students.Add(s));
            context.SaveChanges();


            var Lessons = new List<Lesson>
            {
            new Lesson{Topic="Introduction",StartTime=DateTime.Parse("2002-04-11"),
                       EndTime =DateTime.Parse("2002-04-11"),IsMandatory=false,Location="CMB 1.12"},
            new Lesson{Topic="Loops",StartTime=DateTime.Parse("2002-04-11"),
                       EndTime =DateTime.Parse("2002-04-11"),IsMandatory=false,Location="CMB 1.12"},
            new Lesson{Topic="Arrays",StartTime=DateTime.Parse("2002-04-11"),
                       EndTime=DateTime.Parse("2002-04-11"),IsMandatory=false,Location="CMB 1.12"},
            new Lesson{Topic="Functions",StartTime=DateTime.Parse("2002-04-11"),
                       EndTime=DateTime.Parse("2002-04-11"),IsMandatory=false,Location="CMB 1.12"},
            new Lesson{Topic="OOP",StartTime=DateTime.Parse("2002-04-11"),
                       EndTime=DateTime.Parse("2002-04-11"),IsMandatory=false,Location="CMB 1.12"},
            new Lesson{Topic="TDD",StartTime=DateTime.Parse("2002-04-11"),
                       EndTime=DateTime.Parse("2002-04-11"),IsMandatory=false,Location="CMB 1.12"},
            new Lesson{Topic="Conditionals",StartTime=DateTime.Parse("2002-04-11"),
                       EndTime=DateTime.Parse("2002-04-11"),IsMandatory=false,Location="CMB 1.12"},
            new Lesson{Topic="Classes",StartTime=DateTime.Parse("2002-04-11"),
                       EndTime=DateTime.Parse("2002-04-11"),IsMandatory=false,Location="CMB 1.12"},
            new Lesson{Topic="Objects",StartTime=DateTime.Parse("2002-04-11"),
                       EndTime=DateTime.Parse("2002-04-11"),IsMandatory=false,Location="CMB 1.12"},
            new Lesson{Topic="Quiz",StartTime=DateTime.Parse("2002-04-11"),
                       EndTime=DateTime.Parse("2002-04-11"),IsMandatory=false, Location="CMB 1.12"}
            };
            Lessons.ForEach(s => context.Lessons.Add(s));
            context.SaveChanges();

            var courses = new List<Course>
            {
            new Course{CourseID=1050,Title="Chemistry",Level="A",},
            new Course{CourseID=2050,Title="Physico Meditation",Level="A",}
            };
            courses.ForEach(s => context.Courses.Add(s));
            context.SaveChanges();

            var groups = new List<Group>
            {
                new Group{GroupName="C Sharp"},
                new Group{GroupName="Javascript"}
            };
            groups.ForEach(g => context.Groups.Add(g));
            context.SaveChanges();

            var enrollments = new List<Enrollment>
            {
                new Enrollment{GroupID=1, StudentID=1, LessonID=1, CourseID=1050},
                new Enrollment{GroupID=1, StudentID=2, LessonID=1, CourseID=1050},
                new Enrollment{GroupID=1, StudentID=3, LessonID=1, CourseID=1050},
                new Enrollment{GroupID=1, StudentID=4, LessonID=1, CourseID=1050},

                new Enrollment{GroupID=2, StudentID=1, LessonID=1, CourseID=2050},
                new Enrollment{GroupID=2, StudentID=2, LessonID=1, CourseID=2050},
                new Enrollment{GroupID=2, StudentID=3, LessonID=1, CourseID=2050},
                new Enrollment{GroupID=2, StudentID=4, LessonID=1, CourseID=2050}
            };
        }
    }
}