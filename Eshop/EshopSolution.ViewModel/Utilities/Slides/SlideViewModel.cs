﻿using EshopSolution.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using EshopSolution.Data.Enums;

namespace EshopSolution.ViewModels.Utilities.Slides
{
    public class SlideViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desciption { get; set; }
        public string Url { get; set; }
        public string Image { get; set; }
        public int SortOrder { get; set; }
        public Status status { get; set; }
    }
}
