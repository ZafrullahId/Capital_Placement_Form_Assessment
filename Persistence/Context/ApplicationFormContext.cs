using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Context
{
    public class ApplicationFormContext(DbContextOptions<ApplicationFormContext> options) : DbContext(options)
    {
        public DbSet<Choice> Choices { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<FormWindow> FormWindows { get; set; }
        public DbSet<QuestionType> QuestionTypes { get; set; }
        public DbSet<ApplicationProgram> ApplicationPrograms { get; set; }
        public DbSet<Submission> Submissions { get; set; }
    }
}
