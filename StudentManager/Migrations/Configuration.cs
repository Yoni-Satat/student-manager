namespace StudentManager.Migrations
{
    using StudentManager.DAL;
    using StudentManager.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SMContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SMContext context)
        {
            var students = new List<Student>
            {
            new Student{FirstName="Carson",LastName="Alexander",DateOfBirth=DateTime.Parse("2005-09-01"),
                        MatricNumber ="SN0001", Gender="Male",
                        Adjustments=true, Origin="UK", YearOfStudy=2018, ImageURL="",
                        Groups=new List<Group>()},
            new Student{FirstName="Meredith",LastName="Alonso",DateOfBirth=DateTime.Parse("2002-04-11"),
                        MatricNumber ="SN0002", Gender="Female",
                        Adjustments=true, Origin="UK", YearOfStudy=2018, ImageURL="",
                        Groups=new List<Group>()},
            new Student{FirstName="Arturo",LastName="Anand",DateOfBirth=DateTime.Parse("2003-09-01"),
                        MatricNumber ="SN0003", Gender="Male",
                        Adjustments=true, Origin="EU", YearOfStudy=2018, ImageURL="",
                        Groups=new List<Group>()},
            new Student{FirstName="Gytis",LastName="Barzdukas",DateOfBirth=DateTime.Parse("2002-09-01"),
                        MatricNumber ="SN0004", Gender="Male",
                        Adjustments=false, Origin="USA", YearOfStudy=2018, ImageURL="",
                        Groups=new List<Group>()},
            new Student{FirstName="Yan",LastName="Li",DateOfBirth=DateTime.Parse("2002-09-01"),
                        MatricNumber ="SN0005", Gender="Male",
                        Adjustments=true, Origin="UK", YearOfStudy=2018, ImageURL="",
                        Groups=new List<Group>()},
            new Student{FirstName="Peggy",LastName="Justice",DateOfBirth=DateTime.Parse("2001-09-01"),
                        MatricNumber ="SN0006", Gender="Female",
                        Adjustments=false, Origin="UK", YearOfStudy=2018, ImageURL="",
                        Groups=new List<Group>()},
            new Student{FirstName="Laura",LastName="Norman",DateOfBirth=DateTime.Parse("2003-09-01"),
                        MatricNumber ="SN0007", Gender="Female",
                        Adjustments=false, Origin="UK", YearOfStudy=2018, ImageURL="",
                        Groups=new List<Group>()},
            new Student{FirstName="Nino",LastName="Olivetto",DateOfBirth=DateTime.Parse("2005-09-01"),
                        MatricNumber ="SN0008", Gender="Male",
                        Adjustments=false, Origin="UK", YearOfStudy=2018, ImageURL="",
                        Groups=new List<Group>()}
            };

            students.ForEach(s => context.Students.AddOrUpdate(p => p.StudentID, s));
            context.SaveChanges();

            var courses = new List<Course>
            {
            new Course{CourseID=1000,Title="Statistic 101",Level="A", Groups=new List<Group>()},
            new Course{CourseID=1001,Title="Advanced Statistic",Level="A", Groups=new List<Group>()},
            new Course{CourseID=1002,Title="Statistic in Education",Level="A", Groups=new List<Group>()},
            };
            courses.ForEach(s => context.Courses.AddOrUpdate(p => p.CourseID, s));
            context.SaveChanges();

            var groups = new List<Group>
            {
                new Group{CourseID=1000, GroupTitle="Q-Step - 101", Students = new List<Student>()},
                new Group{CourseID=1001, GroupTitle="Q-Step - Advanced", Students = new List<Student>()},
                new Group{CourseID=1002, GroupTitle="Q-Step - Education", Students = new List<Student>()}
            };
            groups.ForEach(s => context.Groups.AddOrUpdate(p => p.GroupID ,s));
            context.SaveChanges();

            AddOrUpdateStudent(context, 1, 1);
            AddOrUpdateStudent(context, 1, 2);
            AddOrUpdateStudent(context, 1, 3);
            AddOrUpdateStudent(context, 1, 4);
            AddOrUpdateStudent(context, 1, 5);

            context.SaveChanges();

        } //END OF Seed();
        
        void AddOrUpdateStudent(SMContext context, int groupID, int studentID)
        {
            var grp = context.Groups.SingleOrDefault(g => g.GroupID == groupID);
            var stu = grp.Students.SingleOrDefault(s => s.StudentID == studentID);
            if (stu == null)
                grp.Students.Add(context.Students.Single(s => s.StudentID == studentID));
        }

        
    }
}
