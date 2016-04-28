using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagementSystem.Model;

namespace StudentManagementSystem.Repo
{
    public class FeeRepository : BaseRepository<Fee>
    {
        public FeeRepository(BusinessDbContext db) : base(db)
        {
        }
    }

    public class PaymentRepository : BaseRepository<Payment>
    {
        public PaymentRepository(BusinessDbContext db) : base(db)
        {
        }
    }

    public class CollectionRepository : BaseRepository<Collection>
    {
        public CollectionRepository(BusinessDbContext db) : base(db)
        {
        }
    }

    public class CollectionDetailRepository : BaseRepository<CollectionDetail>
    {
        public CollectionDetailRepository(BusinessDbContext db) : base(db)
        {
        }
    }

    public class StudentRepository : BaseRepository<Student>
    {
        public StudentRepository(BusinessDbContext db) : base(db)
        {
        }
    }
}

