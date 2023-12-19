using Core.DataAccess.EntityFramework;
using Core.Entities.Concretes;
using DataAccess.Abstracts;
using DataAccess.Concrete.Entityframework.Context;


namespace DataAccess.Concrete.Entityframework
{
    public class EfUserDal : EfEntityRepositoryBase<User, QuizContext>, IUserDal
    {
        //Kullanıcıya ait rolleri ayrı tablolardan çekmek için join işlemi
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new QuizContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.OperationClaimID equals userOperationClaim.OperationClaimID
                             where userOperationClaim.UserID == user.UserID
                             select new OperationClaim { OperationClaimID = operationClaim.OperationClaimID, OperationClaimName = operationClaim.OperationClaimName };
                return result.ToList();
            }
        }
    }
}