using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AidaCarParts.Models
{
    public class PageData
    {
        public PageViewModel GetPageData(int sectionAndSubsectionId, int page)
        {
            var context = new Context();
            int pageSize = 17; // количество объектов на страницу
            IEnumerable<Part> phonesPerPages = context.Parts.ToList().Where(p=>p.SectionAndSubsectionId == sectionAndSubsectionId).Skip((page - 1) * pageSize).Take(pageSize);
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = context.Parts.ToList().Where(p => p.SectionAndSubsectionId == sectionAndSubsectionId).Count() };
            PageViewModel ivm = new PageViewModel { PageInfo = pageInfo, Parts = phonesPerPages };
            return ivm;
        }

    }
    public class PageInfo
    {
        public int PageNumber { get; set; } // номер текущей страницы
        public int PageSize { get; set; } // кол-во объектов на странице
        public int TotalItems { get; set; } // всего объектов
        public int TotalPages  // всего страниц
        {
            get { return (int)Math.Ceiling((decimal)TotalItems / PageSize); }
        }
    }
    public class PageViewModel
    {
        public IEnumerable<Part> Parts { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}
