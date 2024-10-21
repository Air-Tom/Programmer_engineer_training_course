using Microsoft.AspNetCore.Components.Forms;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using WebAppExamJobMVC.Models;

namespace WebAppExamJobMVC.Models
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options)
       : base(options)
        { }
        public DbSet<Student> Students { get; set; }
        public DbSet<Discipline> Disciplines { get; set; }
    }
}