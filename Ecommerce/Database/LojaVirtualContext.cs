using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Database
{
    public class LojaVirtualContext : DbContext
    {
        public LojaVirtualContext(DbContextOptions options) : base(options)
        {

        }

        DbSet<Client> Client { get; set; }
        DbSet<NewsletterEmail> NewsletterEmails { get; set; }
    } 
}
