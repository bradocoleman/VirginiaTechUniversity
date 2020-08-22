using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VirginiaTechUniversity.Models;

namespace VirginiaTechUniversity.DAL
{
    interface IStudentRepository : IDisposable
    {
        IEnumerable<Student> GetStudents();
        Student GetStudentById(int Id);
        void InsertStudent(Student student);
        void UpdateStudent(Student student);
        void DeleteStudent(int Id);
        void Save();

    }
}
