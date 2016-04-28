using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagementSystem.Model;
using StudentManagementSystem.Repo;
using StudentManagementSystem.ViewMod;
using StudentManagementSystem.Request;
using Repository = StudentManagementSystem.Repo.CollectionRepository;
using Vm = StudentManagementSystem.ViewMod.CollectionViewModel;
using Rm = StudentManagementSystem.Request.CollectionRequestModel;
using M = StudentManagementSystem.Model.Collection;

namespace StudentManagementSystem.Service
{
    public class CollectionService : BaseService<M>
    {
        private readonly Repository repository;

        public CollectionService(Repository repository) : base(repository)
        {
            this.repository = repository;
        }

        public async Task<List<Vm>> GetAllAsync()
        {
            return await repository.Get().Select(x => new Vm(x)).ToListAsync();
        }
        public List<Vm> GetAll()
        {
            return repository.Get().Include(y => y.Student).ToList().ConvertAll(x => new Vm(x)).ToList();
        }

        public async Task<List<Vm>> SearchAsync(Rm request)
        {
            IQueryable<Collection> queryable = request.GetOrderedData(Repository.Get()).Include(y => y.Student);
            queryable = request.SkipAndTake(queryable);
            var list = await queryable.ToListAsync();
            return list.ConvertAll(x => new Vm(x));
        }
        public async Task<int> CountAsync(Rm request)
        {
            var queryable = request.GetOrderedData(Repository.Get());
            var count = await queryable.CountAsync();
            return count;
        }

        public Vm GetDetail(string id)
        {
            var model = Repository.GetById(id);
            if (model == null)
            {
                return null;
            }
            return new Vm(model);
        }

        public override bool Add(M m)
        {
            bool added = base.Add(m);
            if (added)
            {
                UpdateTotal(m.Id);
            }
            return added;
        }

        public override bool Edit(M m)
        {
            bool added = base.Edit(m);
            if (added)
            {
                UpdateTotal(m.Id);
            }
            return added;
        }


        public bool UpdateTotal(string purchaseId)
        {
            var purchase = GetById(purchaseId);
            //  purchase.Total = purchase.CollectionDetails.Sum(x => x.Total);
            //   bool updateTotal = Edit(purchase);
            StudentService supplierService = new StudentService(new StudentRepository(Repository.Db));
            bool updated = supplierService.UpdateDue(purchase.StudentId);
            return updated;
        }
    }
}
