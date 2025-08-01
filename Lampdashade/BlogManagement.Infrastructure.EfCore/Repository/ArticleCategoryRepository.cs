using _0_Framework.Application;
using _0_Framework.Infrastructure;
using BlogManagement.Application.Contracts.ArticleCategory;
using BlogManagement.Domain.ArticleCategoryAgg;

namespace BlogManagement.Infrastructure.EfCore.Repository
{
    public class ArticleCategoryRepository : RepositoryBase<long, ArticleCategory>, IArticleCategoryRepository
    {
        private readonly BlogContext _context;
        public ArticleCategoryRepository(BlogContext contex) : base(contex) 
        {
            _context = contex;
        }

        public EditArticleCategory GetDetails(long id)
        {
            return _context.ArticleCategories.Select(x => new EditArticleCategory {
            Id=x.Id,
            Name=x.Name,
            PictureAlt=x.PictureAlt,
            PictureTitle=x.PictureTitle,
            CanonicalAddress=x.CanonicalAddress,
            Description=x.Description,
            KeyWords=x.KeyWords,
            MetaDescription=x.MetaDescription,
            ShowOrder=x.ShowOrder,
            Slug=x.Slug
            
            }).SingleOrDefault(x => x.Id == id);
        }

        public string GetSlugBy(long id)
        {
            return _context.ArticleCategories.Select(x => new { x.Id, x.Slug })
                .SingleOrDefault(x => x.Id == id).Slug;
        }

        public List<ArticleCategoryViewModel> Search(ArticleCategorySearchModel searchModel)
        {
            var query = _context.ArticleCategories.Select(x=> new ArticleCategoryViewModel
            {
                Id=x.Id,
                Description=x.Description,
                Name=x.Name,
                Picture=x.Picture,
                ShowOrder = x.ShowOrder,
                CreationDate = x.CreationDate.ToFarsi()
            });

            if(!string.IsNullOrWhiteSpace(searchModel.Name) )
                query=query.Where(x=> x.Name.Contains(searchModel.Name));

            return query.OrderByDescending(x=> x.ShowOrder).ToList();
        }
    }
}
