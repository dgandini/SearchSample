using LinqKit;
using SearchSampleApp.Data;
using SearchSampleApp.Domain;
using SearchSampleApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

using PagedList;

namespace SearchSampleApp.Controllers
{
    public class SearchController : Controller
    {
        private readonly GenericRepository<Order> _orderRepository;

        public SearchController()
        {
            _orderRepository = new GenericRepository<Order>(new AppDbContext());
        }



        // GET: Search
        [HttpPost]
        public PartialViewResult Execute(SearchExecuteViewModel filters)
        {
            var query = PredicateBuilder.True<Order>();

            if (filters.Total != null)
            {
                query = query.And(x => x.Total == filters.Total);
            }

            if (filters.Date != null)
            {
                query = query.And(x => x.Date == filters.Date);
            }

            if (filters.Status != null)
            {
                query = query.And(x => x.Status == filters.Status);
            }

            if (!string.IsNullOrEmpty(filters.Name))
            {
                var nameQuery = PredicateBuilder.False<Order>();
                foreach (var n in filters.Name.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    nameQuery = nameQuery.Or(p => p.Customer.Name.Contains(n));
                }

                query = query.And(nameQuery);
            }

            var orders = _orderRepository.Get(filter: query, orderBy: sort => sort.OrderBy(o => o.Date));

            return PartialView(orders.ToPagedList(filters.PageNumber ?? 1, filters.PageSize ?? 4));
        }
    }
}