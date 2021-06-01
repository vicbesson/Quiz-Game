namespace ITEC275Final_VictorBesson.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AnonUsers",
                c => new
                    {
                        AnonUserID = c.Int(nullable: false, identity: true),
                        LiveGameID = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 15),
                    })
                .PrimaryKey(t => t.AnonUserID)
                .ForeignKey("dbo.LiveGames", t => t.LiveGameID)
                .Index(t => t.LiveGameID)
                .Index(t => t.UserName, unique: true);
            
            CreateTable(
                "dbo.LiveAnswers",
                c => new
                    {
                        LiveAnswerID = c.Int(nullable: false, identity: true),
                        AnonUserID = c.Int(nullable: false),
                        LiveQuestionID = c.Int(nullable: false),
                        QuestionAnswerID = c.Int(nullable: false),
                        AnswerDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.LiveAnswerID)
                .ForeignKey("dbo.AnonUsers", t => t.AnonUserID)
                .ForeignKey("dbo.LiveQuestions", t => t.LiveQuestionID)
                .ForeignKey("dbo.QuestionAnswers", t => t.QuestionAnswerID)
                .Index(t => t.AnonUserID)
                .Index(t => t.LiveQuestionID)
                .Index(t => t.QuestionAnswerID);
            
            CreateTable(
                "dbo.LiveQuestions",
                c => new
                    {
                        LiveQuestionID = c.Int(nullable: false, identity: true),
                        LiveGameID = c.Int(nullable: false),
                        QuestionID = c.Int(nullable: false),
                        EndDateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.LiveQuestionID)
                .ForeignKey("dbo.LiveGames", t => t.LiveGameID)
                .ForeignKey("dbo.Questions", t => t.QuestionID)
                .Index(t => t.LiveGameID)
                .Index(t => t.QuestionID);
            
            CreateTable(
                "dbo.LiveGames",
                c => new
                    {
                        LiveGameID = c.Int(nullable: false, identity: true),
                        QuizID = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        StartedDate = c.DateTime(),
                        EndedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.LiveGameID)
                .ForeignKey("dbo.Quizs", t => t.QuizID)
                .Index(t => t.QuizID);
            
            CreateTable(
                "dbo.Quizs",
                c => new
                    {
                        QuizID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 60),
                        UserID = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        IsPrivate = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.QuizID)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        QuestionID = c.Int(nullable: false, identity: true),
                        QuizID = c.Int(),
                        CreateDate = c.DateTime(nullable: false),
                        QuestionText = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.QuestionID)
                .ForeignKey("dbo.Quizs", t => t.QuizID)
                .Index(t => t.QuizID);
            
            CreateTable(
                "dbo.QuestionAnswers",
                c => new
                    {
                        QuestionAnswerID = c.Int(nullable: false, identity: true),
                        QuestionID = c.Int(),
                        CreateDate = c.DateTime(nullable: false),
                        AnswerText = c.String(nullable: false, maxLength: 255),
                        Answer = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.QuestionAnswerID)
                .ForeignKey("dbo.Questions", t => t.QuestionID)
                .Index(t => t.QuestionID);
            
            CreateTable(
                "dbo.SharedQuizs",
                c => new
                    {
                        SharedQuizID = c.Int(nullable: false, identity: true),
                        QuizID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SharedQuizID)
                .ForeignKey("dbo.Quizs", t => t.QuizID)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.QuizID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 15),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserID)
                .Index(t => t.UserName, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AnonUsers", "LiveGameID", "dbo.LiveGames");
            DropForeignKey("dbo.SharedQuizs", "UserID", "dbo.Users");
            DropForeignKey("dbo.Quizs", "UserID", "dbo.Users");
            DropForeignKey("dbo.SharedQuizs", "QuizID", "dbo.Quizs");
            DropForeignKey("dbo.Questions", "QuizID", "dbo.Quizs");
            DropForeignKey("dbo.QuestionAnswers", "QuestionID", "dbo.Questions");
            DropForeignKey("dbo.LiveAnswers", "QuestionAnswerID", "dbo.QuestionAnswers");
            DropForeignKey("dbo.LiveQuestions", "QuestionID", "dbo.Questions");
            DropForeignKey("dbo.LiveGames", "QuizID", "dbo.Quizs");
            DropForeignKey("dbo.LiveQuestions", "LiveGameID", "dbo.LiveGames");
            DropForeignKey("dbo.LiveAnswers", "LiveQuestionID", "dbo.LiveQuestions");
            DropForeignKey("dbo.LiveAnswers", "AnonUserID", "dbo.AnonUsers");
            DropIndex("dbo.Users", new[] { "UserName" });
            DropIndex("dbo.SharedQuizs", new[] { "UserID" });
            DropIndex("dbo.SharedQuizs", new[] { "QuizID" });
            DropIndex("dbo.QuestionAnswers", new[] { "QuestionID" });
            DropIndex("dbo.Questions", new[] { "QuizID" });
            DropIndex("dbo.Quizs", new[] { "UserID" });
            DropIndex("dbo.LiveGames", new[] { "QuizID" });
            DropIndex("dbo.LiveQuestions", new[] { "QuestionID" });
            DropIndex("dbo.LiveQuestions", new[] { "LiveGameID" });
            DropIndex("dbo.LiveAnswers", new[] { "QuestionAnswerID" });
            DropIndex("dbo.LiveAnswers", new[] { "LiveQuestionID" });
            DropIndex("dbo.LiveAnswers", new[] { "AnonUserID" });
            DropIndex("dbo.AnonUsers", new[] { "UserName" });
            DropIndex("dbo.AnonUsers", new[] { "LiveGameID" });
            DropTable("dbo.Users");
            DropTable("dbo.SharedQuizs");
            DropTable("dbo.QuestionAnswers");
            DropTable("dbo.Questions");
            DropTable("dbo.Quizs");
            DropTable("dbo.LiveGames");
            DropTable("dbo.LiveQuestions");
            DropTable("dbo.LiveAnswers");
            DropTable("dbo.AnonUsers");
        }
    }
}
