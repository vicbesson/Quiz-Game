namespace ITEC275Final_VictorBesson.DAL
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using ITEC275Final_VictorBesson.Models;
    using System.Data.Entity.ModelConfiguration.Conventions;
    public class SuperModel : DbContext
    {
       
        public SuperModel()
            : base("name=SuperModel")
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<AnonUser> AnonUsers { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionAnswer> QuestionAnswers { get; set; }
        public DbSet<LiveGame> LiveGames { get; set; }
        public DbSet<LiveQuestion> LiveQuestions { get; set; }
        public DbSet<LiveAnswer> LiveAnswers { get; set; }
        public DbSet<SharedQuiz> SharedQuizzes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}