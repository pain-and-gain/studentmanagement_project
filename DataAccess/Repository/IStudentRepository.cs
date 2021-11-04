using BusinessObject.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetStudentList();
        Student GetStudentByID(string id);
        void Add(Student student);
        void Update(Student student);
        void Remove(string id);
    }
}
