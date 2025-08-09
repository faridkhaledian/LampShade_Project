using _0_Framework.Application;
using _0_Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contracts.Comment;
using ShopManagement.Domain.CommentAgg;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class CommentRepository : RepositoryBase<long, Comment>, ICommentRepository
    {

        private readonly ShopContext _Context;

        public CommentRepository(ShopContext context) : base(context)
        {
            _Context = context;
        }
        public List<CommentViewModel> Search(CommentSearchModel searchModel)
        {
            var query = _Context.Comments.Include(x=> x.Product).Select(x => new CommentViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email,
                Message = x.Message,
                IsConfirmed = x.IsConfirmed,
                IsCanceled = x.IsCanceled,
               CommentDate = x.CreationDate.ToFarsi(),
                ProductId = x.ProductId,
                ProductName=x.Product.Name
            });
            if(!string.IsNullOrWhiteSpace(searchModel.Name) )
                query=query.Where(x=> x.Name.Contains(searchModel.Name));

            if(!string.IsNullOrWhiteSpace(searchModel.Email) )
                query=query.Where(x=> x.Email.Contains(searchModel.Email));

            return query.OrderByDescending(x => x.Id).ToList();

        }
    }
}
