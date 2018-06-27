namespace sowa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMemberShipType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MembershipTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DurationInMonths = c.Byte(nullable: false),
                        SignUpFee = c.Short(nullable: false),
                        DiscountRate = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Students", "MembershipTypeId", c => c.Int(nullable: false));
            AddColumn("dbo.Students", "IsSubscribedToNewsletter", c => c.Boolean(nullable: false));
            CreateIndex("dbo.Students", "MembershipTypeId");
            AddForeignKey("dbo.Students", "MembershipTypeId", "dbo.MembershipTypes", "Id", cascadeDelete: true);
            DropColumn("dbo.Students", "MembershipType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "MembershipType", c => c.String());
            DropForeignKey("dbo.Students", "MembershipTypeId", "dbo.MembershipTypes");
            DropIndex("dbo.Students", new[] { "MembershipTypeId" });
            DropColumn("dbo.Students", "IsSubscribedToNewsletter");
            DropColumn("dbo.Students", "MembershipTypeId");
            DropTable("dbo.MembershipTypes");
        }
    }
}
