﻿using System.ComponentModel.DataAnnotations;
using _0_Framework.Application;
using Microsoft.AspNetCore.Http;

namespace ShopManagement.Application.Contracts.Slide
{
   public  class CreateSlide
    {
        [MaxFileSize(3*1024*1024 , ErrorMessage =ValidationMessages.MaxFileSize)]
        [FileExtentionLimitation(new string[] {"","",""}, ErrorMessage =ValidationMessages.InvalidFileFormat)]
        public IFormFile Picture { get;  set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string PictureAlt { get;  set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string PictureTitle { get;  set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Heading { get;  set; }

        public string Title { get;  set; }
        public string Text { get;  set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string BtnText { get;  set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Link { get; set; }

    }
}
