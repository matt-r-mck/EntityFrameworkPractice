using System;
using System.Linq;
using System.Threading.Tasks;
using EdDbEFLib.Controllers;
using EdDbEFLib.models;

namespace EntityFrameworkPractice {
    class Program {


        public static async Task Main(string[] args) {

            var stuCtrl = new StudentsController();

            var student = new Student(64);
            //{
            //    Id = 0, Firstname = "James", Lastname = "Joyce", StateCode = "CA", Sat = 1100, Gpa = 3, MajorId = null
            //};
            student.StateCode = "OH";
            await stuCtrl.Update(student.Id, student);

            //var student = new Student() {
            //     
            //};

            //await stuCtrl.InsertAsync(student);

            //var student = await stuCtrl.GetByPKAsync(8);

            //var students = await stuCtrl.GetAllAsync();

        }


        //var majCtrl = new MajorsController();

        //var majors = await majCtrl.GetAllAsync();

        //var mathMajor = await majCtrl.GetByPKAsync(4);

        //var major = new Major() {
        //    Id = 11, Code = "MEDS", Description = "Medical", MinSat = 1200
        //};

        //var result = await majCtrl.InsertAsync(major);
        //major.Id = 11;
        //    major.Description = "Medicine";
        //    var result = await majCtrl.Update(major.Id, major);

        //var result = await majCtrl.Delete(11);

    }
}
