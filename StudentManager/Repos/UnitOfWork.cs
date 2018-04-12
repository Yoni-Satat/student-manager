using System;
using StudentManager.Models;
using StudentManager.DAL;

namespace StudentManager.Repos
{
    public class UnitOfWork : IDisposable
    {
        private SMContext context = new SMContext();
        private GenericRepository<Student> studentRepository;
        private GenericRepository<Course> courseRepository;
        private GenericRepository<Group> groupRepository;
        private GenericRepository<Lesson> lessonRepository;

        public GenericRepository<Student> StudentRepository
        {
            get
            {

                if (this.studentRepository == null)
                {
                    this.studentRepository = new GenericRepository<Student>(context);
                }
                return studentRepository;
            }
        }

        public GenericRepository<Course> CourseRepository
        {
            get
            {

                if (this.courseRepository == null)
                {
                    this.courseRepository = new GenericRepository<Course>(context);
                }
                return courseRepository;
            }
        }

        public GenericRepository<Group> GroupRepository 
        {
            get
            {

                if (this.groupRepository == null)
                {
                    this.groupRepository = new GenericRepository<Group>(context);
                }
                return groupRepository;
            }
        }

        public GenericRepository<Lesson> LessonRepository
        {
            get
            {

                if (this.lessonRepository == null)
                {
                    this.lessonRepository = new GenericRepository<Lesson>(context);
                }
                return lessonRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}