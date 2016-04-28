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
using Repository = StudentManagementSystem.Repo.CollectionDetailRepository;
using Vm = StudentManagementSystem.ViewMod.CollectionDetailViewModel;
using Rm = StudentManagementSystem.Request.CollectionDetailRequestModel;
using M = StudentManagementSystem.Model.CollectionDetail;

namespace StudentManagementSystem.Service
{
    public class CollectionDetailService : BaseService<M>
    {
        private readonly Repository repository;

        public CollectionDetailService(Repository repository) : base(repository)
        {
            this.repository = repository;
        }

        public async Task<List<Vm>> GetAllAsync()
        {
            return await repository.Get().Select(x => new Vm(x)).ToListAsync();
        }

        public async Task<List<Vm>> SearchAsync(Rm request)
        {
            var list = await request.GetOrderedData(Repository.Get()).Include("Fee").ToListAsync();
            return list.ConvertAll(x => new Vm(x));
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

        //public override bool Add(M m)
        //{
        //    bool added = base.Add(m);
        //    if (added)
        //    {
        //        FeeService feeService = new FeeService(new FeeRepository(Repository.Db));
        //        feeService.Collection(m);
        //        // CollectionService purchaseService=new CollectionService(new CollectionRepository(Repository.Db));
        //        //  purchaseService.UpdateTotal(m.CollectionId);                
        //    }
        //    return added;
        //}
    }
}
