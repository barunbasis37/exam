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
using Repository=StudentManagementSystem.Repo.StudentRepository;
using Vm = StudentManagementSystem.ViewMod.StudentViewModel;
using Rm = StudentManagementSystem.Request.StudentRequestModel;
using M = StudentManagementSystem.Model.Student;

namespace StudentManagementSystem.Service
{
    public class StudentService : BaseService<M>
    {
        private readonly Repository repository;

        public StudentService(Repository repository) : base(repository)
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
            IQueryable<Student> queryable = request.GetOrderedData(Repository.Get());
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

        public async Task<StudentHistoryViewModel> GetHistoryAsync(string studentId)
        {
            var collectionRequest = new CollectionRequestModel("", "Modified", "True") { ParentId = studentId };
            var collectionService = new CollectionService(new CollectionRepository(repository.Db));
            var paymentRequest = new PaymentRequestModel("", "Modified", "True") { ParentId = studentId };
            var paymentService = new PaymentService(new PaymentRepository(repository.Db));
            List<CollectionViewModel> collections = await collectionService.SearchAsync(collectionRequest);
            List<PaymentViewModel> payments = await paymentService.SearchAsync(paymentRequest);
            List<StudentHistoryDetailViewModel> histories = new List<StudentHistoryDetailViewModel>();
            histories.AddRange(collections.ConvertAll(x => new StudentHistoryDetailViewModel(x)));
            histories.AddRange(payments.ConvertAll(x => new StudentHistoryDetailViewModel(x)));

            StudentHistoryViewModel history = new StudentHistoryViewModel
            {
                Payments = payments,
                Collections = collections,
                CollectionTotal = collections.Sum(x => x.Total),
                PaymentTotal = payments.Sum(x => x.Amount),
                Histories = histories.OrderBy(x => x.Created).ToList()
            };
            return history;
        }



        public bool UpdateDue(string studentId)
        {
            IQueryable<Collection> studentCollections = repository.Db.Collections.Where(x => x.StudentId == studentId);
            double collectionTotal = 0;
            if (studentCollections.Any())
            {
                collectionTotal = studentCollections
                    .Select(x => x.Total)
                    .Sum(x => x != null ? x : 0);
            }


            IQueryable<Payment> studentPayments = repository.Db.Payments.Where(x => x.StudentId == studentId);
            double paymentTotal = 0;
            if (studentPayments.Any())
            {
                paymentTotal = studentPayments
                    .Select(x => x.Amount)
                    .Sum(x => x != null ? x : 0);
            }

            var entity = repository.Db.Students.Find(studentId);
            entity.Due = collectionTotal - paymentTotal;
            repository.Db.Entry(entity).State = EntityState.Modified;
            repository.Db.SaveChanges();
            return true;
        }
    }
}
