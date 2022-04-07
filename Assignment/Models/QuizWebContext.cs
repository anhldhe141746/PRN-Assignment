using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
#nullable disable

namespace Assignment.Models
{
    public partial class QuizWebContext : DbContext
    {
        public QuizWebContext()
        {
        }

        public QuizWebContext(DbContextOptions<QuizWebContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblAdmin> TblAdmins { get; set; }
        public virtual DbSet<TblCategroy> TblCategroys { get; set; }
        public virtual DbSet<TblQuestion> TblQuestions { get; set; }
        public virtual DbSet<TblSetexam> TblSetexams { get; set; }
        public virtual DbSet<TblStudent> TblStudents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
                optionsBuilder.UseSqlServer(config.GetConnectionString("AppConStr"));
                string s = config.GetConnectionString("AppConStr");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<TblAdmin>(entity =>
            {
                entity.HasKey(e => e.AdId)
                    .HasName("PK__TBL_ADMI__B5B611FBF4D43771");

                entity.ToTable("TBL_ADMIN");

                entity.HasIndex(e => e.AdName, "UQ__TBL_ADMI__C07C26437C031869")
                    .IsUnique();

                entity.Property(e => e.AdId).HasColumnName("AD_ID");

                entity.Property(e => e.AdName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("AD_NAME");

                entity.Property(e => e.AdPassword)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("AD_PASSWORD");
            });

            modelBuilder.Entity<TblCategroy>(entity =>
            {
                entity.HasKey(e => e.CatId)
                    .HasName("PK__tbl_cate__DD5DDDBDA86E5966");

                entity.ToTable("tbl_categroy");

                entity.Property(e => e.CatId).HasColumnName("cat_id");

                entity.Property(e => e.CatEncyptedstring)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cat_encyptedstring");

                entity.Property(e => e.CatFkAdid).HasColumnName("cat_fk_adid");

                entity.Property(e => e.CatName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("cat_name");

                entity.HasOne(d => d.CatFkAd)
                    .WithMany(p => p.TblCategroys)
                    .HasForeignKey(d => d.CatFkAdid)
                    .HasConstraintName("FK__tbl_categ__cat_f__49C3F6B7");
            });

            modelBuilder.Entity<TblQuestion>(entity =>
            {
                entity.HasKey(e => e.QuestionId)
                    .HasName("PK__TBL_QUES__30BE07AD475D1466");

                entity.ToTable("TBL_QUESTIONS");

                entity.HasIndex(e => e.Opb, "UQ__TBL_QUES__CB3963988BC6194D")
                    .IsUnique();

                entity.HasIndex(e => e.Opc, "UQ__TBL_QUES__CB396399F0BD6C13")
                    .IsUnique();

                entity.HasIndex(e => e.Opa, "UQ__TBL_QUES__CB39639B05C65D88")
                    .IsUnique();

                entity.HasIndex(e => e.Opd, "UQ__TBL_QUES__CB39639EB3E759C4")
                    .IsUnique();

                entity.Property(e => e.QuestionId).HasColumnName("QUESTION_ID");

                entity.Property(e => e.Cop)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("COP");

                entity.Property(e => e.Opa)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("OPA");

                entity.Property(e => e.Opb)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("OPB");

                entity.Property(e => e.Opc)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("OPC");

                entity.Property(e => e.Opd)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("OPD");

                entity.Property(e => e.QFkCatid).HasColumnName("q_fk_catid");

                entity.Property(e => e.QText)
                    .IsRequired()
                    .HasColumnName("Q_TEXT");

                entity.HasOne(d => d.QFkCat)
                    .WithMany(p => p.TblQuestions)
                    .HasForeignKey(d => d.QFkCatid)
                    .HasConstraintName("FK__TBL_QUEST__q_fk___4AB81AF0");
            });

            modelBuilder.Entity<TblSetexam>(entity =>
            {
                entity.HasKey(e => e.ExamId)
                    .HasName("PK__TBL_SETE__2A3D8F88DB5E3654");

                entity.ToTable("TBL_SETEXAM");

                entity.Property(e => e.ExamId).HasColumnName("EXAM_ID");

                entity.Property(e => e.ExamDate)
                    .HasColumnType("datetime")
                    .HasColumnName("EXAM_DATE");

                entity.Property(e => e.ExamFkStu).HasColumnName("EXAM_FK_STU");

                entity.Property(e => e.ExamName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("EXAM_NAME");

                entity.Property(e => e.ExamStdScore).HasColumnName("EXAM_STD_SCORE");

                entity.HasOne(d => d.ExamFkStuNavigation)
                    .WithMany(p => p.TblSetexams)
                    .HasForeignKey(d => d.ExamFkStu)
                    .HasConstraintName("FK__TBL_SETEX__EXAM___300424B4");
            });

            modelBuilder.Entity<TblStudent>(entity =>
            {
                entity.HasKey(e => e.SId)
                    .HasName("PK__TBL_STUD__A3DFF16D9CC99F47");

                entity.ToTable("TBL_STUDENT");

                entity.HasIndex(e => e.SName, "UQ__TBL_STUD__8ADDC207656E71FC")
                    .IsUnique();

                entity.Property(e => e.SId).HasColumnName("S_ID");

                entity.Property(e => e.SName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("S_NAME");

                entity.Property(e => e.SPassword)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("S_PASSWORD");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
