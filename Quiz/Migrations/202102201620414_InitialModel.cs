namespace Quiz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.QuizQuestions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QstText = c.String(),
                        IsMultiple = c.Boolean(nullable: false),
                        NumOrdrer = c.Int(nullable: false),
                        QuizId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Quizs", t => t.QuizId, cascadeDelete: true)
                .Index(t => t.QuizId);
            
            CreateTable(
                "dbo.Quizs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Subject = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.QuizReponses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RespText = c.String(),
                        IsCorrect = c.Boolean(nullable: false),
                        QuizQuestionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.QuizQuestions", t => t.QuizQuestionId, cascadeDelete: true)
                .Index(t => t.QuizQuestionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QuizReponses", "QuizQuestionId", "dbo.QuizQuestions");
            DropForeignKey("dbo.QuizQuestions", "QuizId", "dbo.Quizs");
            DropIndex("dbo.QuizReponses", new[] { "QuizQuestionId" });
            DropIndex("dbo.QuizQuestions", new[] { "QuizId" });
            DropTable("dbo.QuizReponses");
            DropTable("dbo.Quizs");
            DropTable("dbo.QuizQuestions");
        }
    }
}
