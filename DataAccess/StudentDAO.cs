using BusinessObject.Object;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess
{
    public class StudentDAO
    {
        private static StudentDAO instance = null;
        private static readonly object instanceLock = new object();
        public static StudentDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new StudentDAO();
                    }
                }
                return instance;
            }
        }

        public IEnumerable<Student> GetStudentList()
        {
            var students = new List<Student>();
            try
            {
                using var context = new studentmanagementContext();
                students = context.Students.ToList();
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return students;
        }
    
        public Student GetStudentByID(string id)
        {
            Student student = null;
            try
            {
                using var context = new studentmanagementContext();
                student = context.Students.SingleOrDefault(s => s.StudentId.Equals(id));
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return student;
        }

        public void Add(Student student)
        {
            try
            {
                Student _student = GetStudentByID(student.StudentId);
                if (_student == null)
                {
                    using var context = new studentmanagementContext();
                    context.Students.Add(student);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Student is already exist!");
                }
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Student student)
        {
            try
            {
                Student _student = GetStudentByID(student.StudentId);
                if (_student != null)
                {
                    using var context = new studentmanagementContext();
                    context.Students.Update(student);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Student does not already exist!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Remove(string id)
        {
            try
            {
                Student student = GetStudentByID(id);
                if (student != null)
                {
                    using var context = new studentmanagementContext();
                    context.Students.Remove(student);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Student does not already exist!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
