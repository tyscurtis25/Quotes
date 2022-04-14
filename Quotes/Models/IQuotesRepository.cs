using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quotes.Models
{
    public interface IQuotesRepository
    {
        IQueryable<Quote> Quotes { get; }
        public void Save(Quote q);
        public void AddQuote(Quote q);
        public void Edit(Quote q);
        public void Delete(Quote q);
    }
}
