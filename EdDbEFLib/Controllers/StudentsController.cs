using Castle.Core.Logging;
using EdDbEFLib.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EdDbEFLib.Controllers {
    public class StudentsController {

        private readonly EdDbContext _context = null;

        public async Task<IEnumerable<Student>> GetAllAsync() {
            return await _context.Student.ToListAsync();
        }

        public async Task<Student> GetByPKAsync(int id) {
            return await _context.Student.FindAsync(id);
        }

        public async Task<IEnumerable<Student>> GetByMajor(string description) {
            var students = await _context.Student.Where(s => s.Major.Description.StartsWith(description)).ToListAsync();
            return students;
        }

        //public async Task<Student> GetByLastname(string Lastname) {
        //    var student = await _context.Student.Where(s => s.Lastname.StartsWith(Lastname));
        //    return student;

        //}

        public async Task<bool> InsertAsync(Student student) {
            CheckStudentNull(student);
            await _context.Student.AddAsync(student);
            await _context.SaveChangesAsync();
            return true;
        }

        private static void CheckStudentNull(Student student) {
            if (student == null) {
                throw new Exception("Student input cannot be null");
            }
        }

        public async Task<bool> Update (int id, Student student) {
            CheckStudentNull(student);
            if (id != student.Id) {
                throw new Exception("is does not match Student.Id");
            }
            _context.Update(student);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Student student) {
            if (student == null) {
                throw new Exception("Student input canno be null");
            }
            _context.Remove(student);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id) {
            var student = GetByPKAsync(id);
            if (student == null) {
                throw new Exception("Student id not found");
            }
            await Delete(student.Result);
            return true;
        }

        public StudentsController() {
            _context = new EdDbContext();
        }

    }
}
