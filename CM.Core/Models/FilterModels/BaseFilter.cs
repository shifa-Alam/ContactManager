﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.Core.Models.FilterModels
{
    public class BaseFilter
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public BaseFilter()
        {
            PageNumber = 1;
            PageSize = 10;
        }
        public BaseFilter(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber < 1 ? 1 : pageNumber;
            PageSize = pageSize < 10 ? 10 : pageSize;
        }
    }
}
