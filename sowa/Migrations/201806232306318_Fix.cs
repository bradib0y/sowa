namespace sowa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "MembershipTypeId", "dbo.MembershipTypes");
            DropIndex("dbo.Students", new[] { "MembershipTypeId" });
            DropPrimaryKey("dbo.MembershipTypes");
            AddColumn("dbo.Students", "Birthday", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Students", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Students", "MembershipTypeId", c => c.Byte(nullable: false));
            AlterColumn("dbo.MembershipTypes", "Id", c => c.Byte(nullable: false));
            AlterColumn("dbo.MembershipTypes", "Name", c => c.String(maxLength: 100));
            AddPrimaryKey("dbo.MembershipTypes", "Id");
            CreateIndex("dbo.Students", "MembershipTypeId");
            AddForeignKey("dbo.Students", "MembershipTypeId", "dbo.MembershipTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "MembershipTypeId", "dbo.MembershipTypes");
            DropIndex("dbo.Students", new[] { "MembershipTypeId" });
            DropPrimaryKey("dbo.MembershipTypes");
            AlterColumn("dbo.MembershipTypes", "Name", c => c.String());
            AlterColumn("dbo.MembershipTypes", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Students", "MembershipTypeId", c => c.Int(nullable: false));
            AlterColumn("dbo.Students", "Name", c => c.String());
            DropColumn("dbo.Students", "Birthday");
            AddPrimaryKey("dbo.MembershipTypes", "Id");
            CreateIndex("dbo.Students", "MembershipTypeId");
            AddForeignKey("dbo.Students", "MembershipTypeId", "dbo.MembershipTypes", "Id", cascadeDelete: true);
        }
    }
}
