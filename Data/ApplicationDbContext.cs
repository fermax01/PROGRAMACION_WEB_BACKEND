using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProgramacionWeb_Backend.Models;

namespace ProgramacionWeb_Backend.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public virtual DbSet<Persona> Personas { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
    }
}