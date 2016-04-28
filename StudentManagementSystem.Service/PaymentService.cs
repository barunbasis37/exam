﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagementSystem.Model;
using StudentManagementSystem.Request;
using StudentManagementSystem.ViewMod;
using StudentManagementSystem.Repo;
using Vm = StudentManagementSystem.ViewMod.PaymentViewModel;
using Rm = StudentManagementSystem.Request.PaymentRequestModel;
using Repository = StudentManagementSystem.Repo.PaymentRepository;
using M = StudentManagementSystem.Model.Payment;

namespace StudentManagementSystem.Service
{
    public class PaymentService : BaseService<M>
    {
        private readonly Repository repository;

        public PaymentService(Repository repository) : base(repository)
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
            IQueryable<Payment> queryable = request.GetOrderedData(Repository.Get()).Include(y => y.Student);
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
            bool add = base.Add(m);
            var studentRepository = new StudentRepository(Repository.Db);
            StudentService studentService = new StudentService(studentRepository);
            studentService.UpdateDue(m.StudentId);
            return true;
        }
    }
}
