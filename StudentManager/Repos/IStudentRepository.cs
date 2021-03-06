﻿using System;
using System.Collections.Generic;
using StudentManager.Models;
using StudentManager.DAL;

namespace StudentManager.Repos
{
    public interface IStudentRepository : IDisposable
    {
        IEnumerable<Student> GetStudents();
        Student GetStudentByID(int studentId);
        void InsertStudent(Student student);
        void DeleteStudent(int studentID);
        void UpdateStudent(Student student);
        void Save();
        Student GetStudentByID(int? id);
    }
}
