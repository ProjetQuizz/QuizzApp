namespace Quiz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddClassQuizCategory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.QuizCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Category = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Quizs", "Category", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Quizs", "Category");
            DropTable("dbo.QuizCategories");
        }
    }
}
