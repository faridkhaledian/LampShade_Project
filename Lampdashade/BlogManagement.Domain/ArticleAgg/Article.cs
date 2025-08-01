using _0_Framework.Domain;
using BlogManagement.Domain.ArticleCategoryAgg;

namespace BlogManagement.Domain.ArticleAgg
{
    public class Article:EntityBase
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string ShortDescription { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public DateTime PublishDate { get; private set; }
        public string Slug { get; private set; }
        public string KeyWords { get; private set; }
        public string MetaDescription { get; private set; }
        public string CanonicalAddress { get; private set; }
        public long CategoryId { get;private set; }
        public ArticleCategory  Category { get;private set; }

        public Article(string title, string description, string shortDescription,
            string picture, string pictureAlt, string pictureTitle, DateTime publishDate,
            string slug, string keyWords, string metaDescription, string canonicalAddress, long categoryId)
        {
            Title = title;
            Description = description;
            ShortDescription = shortDescription;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            PublishDate = publishDate;
            Slug = slug;
            KeyWords = keyWords;
            MetaDescription = metaDescription;
            CanonicalAddress = canonicalAddress;
            CategoryId = categoryId;
        }
        public void Edit(string title, string description, string shortDescription,
            string picture, string pictureAlt, string pictureTitle, DateTime publishDate,
            string slug, string keyWords, string metaDescription, string canonicalAddress, long categoryId)
        {
            Title = title;
            Description = description;
            ShortDescription = shortDescription;
            if(!string.IsNullOrWhiteSpace(picture)  )
                Picture = picture;
       
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            PublishDate = publishDate;
            Slug = slug;
            KeyWords = keyWords;
            MetaDescription = metaDescription;
            CanonicalAddress = canonicalAddress;
            CategoryId = categoryId;
        }
    }
}
