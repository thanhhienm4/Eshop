﻿using EshopSolution.Data.EF;
using EshopSolution.ViewModel.Utilities.Slides;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using EshopSolution.ViewModel.Common;

namespace EshopSolution.Application.Unilities.Slides
{
    public class SlideService : ISlideService
    {
        private readonly EshopDbContext _context;
        public SlideService(EshopDbContext context)
        {
            this._context = context;
        }
        public async Task<ApiResult<List<SlideViewModel>>>GetAll()
        {
            var slides = await _context.Slides.OrderBy(x=>x.SortOrder).Select(x => new  SlideViewModel()
            {
                Id = x.Id,
                Desciption = x.Desciption,
                Name = x.Name,
                Url = x.Url,
                Image = x.Image
            }).ToListAsync();

            return new ApiSuccessResult<List<SlideViewModel>>(slides);
        }
    }
}