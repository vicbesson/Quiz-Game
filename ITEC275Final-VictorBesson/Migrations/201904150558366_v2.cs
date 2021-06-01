namespace ITEC275Final_VictorBesson.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LiveGames", "RandomCode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.LiveGames", "RandomCode");
        }
    }
}
