using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagementSystem.Model;
using StudentManagementSystem.ViewMod;

namespace StudentManagementSystem.Service
{
    public class DropdownDataService
    {
        private BusinessDbContext db;
        public DropdownDataService(BusinessDbContext db)
        {
            this.db = db;
        }

        public async Task<List<DropdownViewModel>> GetList(string name)
        {

            switch (name)
            {
                case "fee":
                    return await db.Fees.Select(x => new DropdownViewModel() { Id = x.Id, Name = x.Name }).ToListAsync();
                case "student":
                    return await db.Students.Select(x => new DropdownViewModel() { Id = x.Id, Name = x.Name }).ToListAsync();
                default:
                    return null;
            }
        }
    }
}
