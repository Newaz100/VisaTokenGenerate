using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TokenGenerate.EF.Tables;

namespace TokenGenerate.EF
{
    public class TokenContext : DbContext
    {
       // public TokenContext() : base("DefaultConnection") { }

        public DbSet<Token> Tokens { get; set; }
    }
}