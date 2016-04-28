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
using Repository = StudentManagementSystem.Repo.FeeRepository;
using Vm = StudentManagementSystem.ViewMod.FeeViewModel;
using Rm = StudentManagementSystem.Request.FeeRequestModel;
using M = StudentManagementSystem.Model.Fee;

namespace StudentManagementSystem.Service
{
    public class FeeService : BaseService<M>
    {
        private readonly Repository repository;

        public FeeService(Repository repository) : base(repository)
        {
            this.repository = repository;
        }

        public async Task<List<Vm>> GetAllAsync()
        {
            return await repository.Get().Select(x => new Vm(x)).ToListAsync();
        }

        public List<Vm> GetAll()
        {
            return repository.Get().ToList().ConvertAll(x => new Vm(x)).ToList();
        }

        public async Task<List<Vm>> SearchAsync(Rm request)
        {
            var queryable = request.GetOrderedData(Repository.Get());
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

        public bool Collection(CollectionDetail detail)
        {
            var p = GetById(detail.FeeId);
            p.Amount = p.Amount;
            return base.Edit(p);
        }

       
    }
}
