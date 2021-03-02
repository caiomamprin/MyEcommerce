using Ecommerce.Database;
using Ecommerce.Models;
using Ecommerce.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Repositories
{
    public class NewsletterRepository : INewsletterRepository
    {
        private LojaVirtualContext _database;

        public NewsletterRepository(LojaVirtualContext database)
        {
            _database = database;
        }
        public IEnumerable<NewsletterEmail> GetAllNewsletter()
        {
            return _database.NewsletterEmails.ToList();
        }

        public void RegisterNewsletter(NewsletterEmail newsletter)
        {
            _database.Add(newsletter);
            _database.SaveChanges();
        }
    }
}
