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
        private static int _sectionAndSubsectionId;
        private static int _currentPage;

        public static int PageSize { get { return _pageSize; } set { _pageSize = value; } }

        public static PageViewModel GetPageData(int sectionAndSubsectionId, int page)
        {
            _sectionAndSubsectionId = sectionAndSubsectionId;
            _currentPage = page;
            var context = new Context();
            IEnumerable<Part> phonesPerPages = context.Parts.ToList().Where(p=>p.SectionAndSubsectionId == sectionAndSubsectionId).Skip((page - 1) * _pageSize).Take(_pageSize);
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = _pageSize, TotalItems = context.Parts.ToList().Where(p => p.SectionAndSubsectionId == sectionAndSubsectionId).Count() };
            PageViewModel ivm = new PageViewModel { PageInfo = pageInfo, Parts = phonesPerPages };
            return ivm;
        }

        public static PageViewModel NextPage()
        {
            ++_currentPage;
            var context = new Context();
            IEnumerable<Part> phonesPerPages = context.Parts.ToList().Where(p => p.SectionAndSubsectionId == _sectionAndSubsectionId).Skip((_currentPage - 1) * _pageSize).Take(_pageSize);
            PageInfo pageInfo = new PageInfo { PageNumber = _currentPage, PageSize = _pageSize, TotalItems = context.Parts.ToList().Where(p => p.SectionAndSubsectionId == _sectionAndSubsectionId).Count() };
            PageViewModel ivm = new PageViewModel { PageInfo = pageInfo, Parts = phonesPerPages };
            return ivm;
        }

        public static PageViewModel PreviousPage()
        {
            --_currentPage;
            var context = new Context();
            IEnumerable<Part> phonesPerPages = context.Parts.ToList().Where(p => p.SectionAndSubsectionId == _sectionAndSubsectionId).Skip((_currentPage - 1) * _pageSize).Take(_pageSize);
            PageInfo pageInfo = new PageInfo { PageNumber = _currentPage, PageSize = _pageSize, TotalItems = context.Parts.ToList().Where(p => p.SectionAndSubsectionId == _sectionAndSubsectionId).Count() };
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
