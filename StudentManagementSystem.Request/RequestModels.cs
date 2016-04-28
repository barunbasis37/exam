using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using StudentManagementSystem.Model;

namespace StudentManagementSystem.Request
{
   
    public class FeeRequestModel : RequestModel<Fee>
    {
        public int MaxQuantity { get; set; }

        public FeeRequestModel(string keyword, string orderBy, string isAscending) : base(keyword, orderBy, isAscending)
        {
        }



        protected override Expression<Func<Fee, bool>> GetExpression()
        {
            if (!string.IsNullOrWhiteSpace(Keyword))
            {
                ExpressionObj = x => x.Name.ToLower().Contains(Keyword);
            }
            return ExpressionObj;
        }
    }

    public class PaymentRequestModel : RequestModel<Payment>
    {
        public PaymentRequestModel(string keyword, string orderBy, string isAscending) : base(keyword, orderBy, isAscending)
        {
        }


        protected override Expression<Func<Payment, bool>> GetExpression()
        {
            if (!string.IsNullOrWhiteSpace(Keyword))
            {
                ExpressionObj = x => x.Student.Name.ToLower().Contains(Keyword) || x.Student.DepartmentId.ToLower().Contains(Keyword) || x.Memo.ToLower().Contains(Keyword);
            }
            if (!string.IsNullOrWhiteSpace(ParentId))
            {
                ExpressionObj = ExpressionObj.And(x => x.StudentId == ParentId);
            }
            if (StartDate != new DateTime() && EndDate != new DateTime())
            {
                StartDate = StartDate.Date;
                EndDate = EndDate.Date.AddDays(1).AddMinutes(-1);
                ExpressionObj = ExpressionObj.And(x => x.Created >= StartDate && x.Created <= EndDate);
            }
            return ExpressionObj;
        }
    }

    public class CollectionRequestModel : RequestModel<Collection>
    {
        public CollectionRequestModel(string keyword, string orderBy, string isAscending) : base(keyword, orderBy, isAscending)
        {
        }


        protected override Expression<Func<Collection, bool>> GetExpression()
        {
            if (!string.IsNullOrWhiteSpace(Keyword))
            {
                ExpressionObj = x => x.Student.Name.ToLower().Contains(Keyword) || x.Student.DepartmentId.ToLower().Contains(Keyword) || x.Memo.ToLower().Contains(Keyword);
            }
            if (!string.IsNullOrWhiteSpace(ParentId))
            {
                  ExpressionObj =  ExpressionObj.And(x => x.StudentId == ParentId);
            }
            if (StartDate != new DateTime() && EndDate != new DateTime())
            {
                StartDate = StartDate.Date;
                EndDate = EndDate.Date.AddDays(1).AddMinutes(-1);
                ExpressionObj = ExpressionObj.And(x => x.Created >= StartDate && x.Created <= EndDate);
            }
            return ExpressionObj;
        }
    }

    public class CollectionDetailRequestModel : RequestModel<CollectionDetail>
    {
        public CollectionDetailRequestModel(string keyword, string orderBy, string isAscending) : base(keyword, orderBy, isAscending)
        {
        }


        protected override Expression<Func<CollectionDetail, bool>> GetExpression()
        {
            if (!string.IsNullOrWhiteSpace(Keyword))
            {
                ExpressionObj = x => x.Fee.Name.ToLower().Contains(Keyword);
            }
            if (!string.IsNullOrWhiteSpace(ParentId))
            {
                ExpressionObj = ExpressionObj.And(x => x.CollectionId == ParentId);
            }
            return ExpressionObj;
        }
    }
  
    public class StudentRequestModel : RequestModel<Student>
    {
        public StudentRequestModel(string keyword, string orderBy, string isAscending) : base(keyword, orderBy, isAscending)
        {
        }


        protected override Expression<Func<Student, bool>> GetExpression()
        {
            if (!string.IsNullOrWhiteSpace(Keyword))
            {
                ExpressionObj = x => x.Name.ToLower().Contains(Keyword) || x.Department.Name.ToLower().Contains(Keyword) || x.Phone.ToLower().Contains(Keyword) || x.Address.ToLower().Contains(Keyword);
            }
            if (!string.IsNullOrWhiteSpace(Id))
            {
                ExpressionObj.And(x => x.Id == Id);
            }
            return ExpressionObj;
        }
    }
    
}
