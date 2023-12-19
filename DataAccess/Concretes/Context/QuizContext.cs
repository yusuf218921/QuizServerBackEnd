using Core.Entities.Concretes;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Entityframework.Context
{
    // Quiz DB'ye bağlantı kurmak için EntityFramework Kullanılarak yazılmış sınıf
    public class QuizContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Bu kısım Bilgisayardan Bilgisayara değişiyor, kendi PC'nizdeki VeriTabanına bağlantı kurmak için 
            // duruma göre configüre edin

            //ssl hatası almamak için "Trusted_Connection=true;TrustServerCertificate=true" kısmı bu şekil kalmalı
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-DB85IPR;Database=Quiz;User Id=SA;Password=218921aa;Trusted_Connection=true;TrustServerCertificate=true");
        }

        // VeriTabanındaki tüm tabloları Entitylerle eşlemek için 
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<RecomendedQuiz> RecomendedQuizzes { get; set; }
        public DbSet<TotalScore> TotalScores { get; set; }
        public DbSet<QuizScore> QuizScores { get; set; }

    }
}
