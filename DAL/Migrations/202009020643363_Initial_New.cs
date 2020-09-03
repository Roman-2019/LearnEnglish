namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial_New : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Audios", "AudioPath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Audios", "AudioPath");
        }
    }
}
