using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using VirginiaTechUniversity.Models;

namespace VirginiaTechUniversity.DAL
{
    public class StudentRepository : IStudentRepository
    {

        private SchoolContext context;

        public StudentRepository(SchoolContext context)
        {
            this.context = context;
        }

        //CREATE
        public void InsertStudent(Student student)
        {
            context.Students.Add(student);
        }

        //READ
        public Student GetStudentById(int Id)
        { 
            //return context.Students.Find(Id);
            //why cant we use the following? WE CAN!
            return context.Students.SingleOrDefault(x => x.StudentId == Id);
        }

        //READ
        public IEnumerable<Student> GetStudents()
        {
            return context.Students.ToList();
        }

        //UPDATE
        public void UpdateStudent(Student student)
        {
            context.Entry(student).State = EntityState.Modified;
        }

        //DELETE
        public void DeleteStudent(int Id)
        {
            Student student = context.Students.Find(Id);
            context.Students.Remove(student);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    context.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                this.disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~StudentRepository()
        // {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion


    }
}
