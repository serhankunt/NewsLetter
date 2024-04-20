using Microsoft.EntityFrameworkCore;
using NewsLetter.Consumer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsLetter.Consumer.Context;
internal sealed class ApplicationDbContext :DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=DESKTOP-L1BOF4K\\SQLEXPRESS;Initial Catalog=NewsletterDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
    }
    public DbSet<Blog> Blogs { get; set; }
}
