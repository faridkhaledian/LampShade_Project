﻿using _0_Framework.Application;
using _0_Framework.Infrastructure;
using ShopManagement.Application.Contracts.Slide;
using ShopManagement.Domain.SlideAgg;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class SlideRepository : RepositoryBase<long, Slide>, ISlideRepository
    {
        private readonly ShopContext _context;

        public SlideRepository(ShopContext context) : base(context)
        {
            _context = context;
        }

        public EditSlide GetDetails(long id)
        {
            return _context.Slides.Select(x => new EditSlide
            {
                Id = x.Id,
                BtnText = x.BtnText,
                Heading = x.Heading,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Text=x.Text,
                Link=x.Link,
                Title = x.Title
            }).FirstOrDefault(x => x.Id == id);
        }
        public List<SlideViewModel> GetList()
        {
        return _context.Slides.Select(x=> new SlideViewModel { 
        Id=x.Id,
        Picture=x.Picture,
        Heading=x.Heading,
        Title=x.Title,
        IsRemoved=x.IsRemoved,
        CreationDate=x.CreationDate.ToFarsi()
        }).OrderByDescending(x=> x.Id).ToList();
        }
    }
}
