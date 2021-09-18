using Microsoft.EntityFrameworkCore;
using Symphony_V2.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symphony_V2.Infrastructure
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> contextOptions) : base(contextOptions)
    {
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<QuestionAnswer> QuestionAnswers { get; set; }
    public DbSet<Questionnaire> Questionnaires { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<User>(_ => {
            _.HasKey(x => x.Guid);
            _.HasIndex(x => x.Guid).IsUnique();
            _.HasOne(x => x.Questionnaire);
        });

        AddQuestions(modelBuilder);
    }

    private static void AddQuestions(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Question>().HasData(
       new Question { Id = 1, QuestionValue = "I feel that I am a person of worth, at least on an equal plane with others." },
       new Question { Id = 2, QuestionValue = "I feel that I have a number of good qualities." },
       new Question { Id = 3, QuestionValue = "All in all, I am inclined to feel that I am a failure." },
       new Question { Id = 4, QuestionValue = "I am able to do things as well as most other people." },
       new Question { Id = 5, QuestionValue = "I feel I do not have much to be proud of." },
       new Question { Id = 6, QuestionValue = "I take a positive attitude toward myself." },
       new Question { Id = 7, QuestionValue = "On the whole, I am satisfied with myself." },
       new Question { Id = 8, QuestionValue = "I wish I could have more respect for myself." },
       new Question { Id = 9, QuestionValue = "I certainly feel useless at times." },
       new Question { Id = 10, QuestionValue = "At times I think I am no good at all." }
       );
    }
}
}

