using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quotes.Models
{
    public class EFQuotesRepository : IQuotesRepository
    {
        private QuotesDBContext _context { get; set; }
        public EFQuotesRepository(QuotesDBContext temp)
        {
            _context = temp;
        }

        public IQueryable<Quote> Quotes => _context.Quotes;

        public void Save(Quote q)
        {
            _context.SaveChanges();
        }

        public void AddQuote(Quote q)
        {
            _context.Add(q);
            _context.SaveChanges();
        }

        public void Edit(Quote q)
        {
            _context.Update(q);
            _context.SaveChanges();
        }

        public void Delete(Quote q)
        {
            _context.Remove(q);
            _context.SaveChanges();
        }
    }
}
