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
    class PageData
    {
        private static int _pageSize = 17; // количество объектов на страницу

        public static int PageSize { get { return _pageSize; } set { _pageSize = value; } }

        public static PageViewModel GetPageData(int sectionAndSubsectionId, int page)
        {
            var context = new Context();
            List<Part> phonesPerPages = context.Parts.ToList().Where(p=>p.SectionAndSubsectionId == sectionAndSubsectionId).Skip((page - 1) * _pageSize).Take(_pageSize).ToList();
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = _pageSize, TotalItems = context.Parts.ToList().Where(p => p.SectionAndSubsectionId == sectionAndSubsectionId).Count() };
            PageViewModel ivm = new PageViewModel { PageInfo = pageInfo, Parts = phonesPerPages };
            ivm.SectionOrSubsectionId = sectionAndSubsectionId;
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
        public List<Part> Parts { get; set; }
        public int SectionOrSubsectionId { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}
