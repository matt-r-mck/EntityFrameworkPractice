using Castle.Core.Logging;
using EdDbEFLib.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdDbEFLib.Controllers {
    public class MajorsController {

        //read only = allowed to set value in constructor only.
        private readonly EdDbContext _context = null;

        public async Task<IEnumerable<Major>> GetAllAsync() {
            return await _context.Major.ToListAsync();
        }

        public async Task<Major> GetByPKAsync(int id) {
            return await _context.Major.FindAsync(id);
        }

        public async Task<bool> InsertAsync (Major major) {
            NewMethod(major);
            await _context.Major.AddAsync(major);
            await _context.SaveChangesAsync();
            return true;
        }

        private static void NewMethod(Major major) {
            if (major == null) {
                throw new Exception("Major input cannot be null.");
            }
        }

        public async Task<bool> Update(int id, Major major) {
            if (major == null) {
                throw new Exception("Major input cannot be null");
            }
            if(id != major.Id) {
                throw new Exception("id does not match major.Id");
            }
            //_context.Entry(major).State = EntityState.Modified;
            _context.Update(major);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Major major) {
            if (major == null) {
                throw new Exception("Major input cannot be null");
            }
            _context.Remove(major);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id) {
            var major = GetByPKAsync(id);
            if (major == null) {
                throw new Exception("Major Id not found");
            }
            await Delete(major.Result);
            //_context.Remove(major.Result);
            //await _context.SaveChangesAsync();
            return true;
        }

        public MajorsController() {
            _context = new EdDbContext();
        }

        

    }
}
