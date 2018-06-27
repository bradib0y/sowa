namespace sowa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypes (Name, DurationInMonths, SignUpFee, DiscountRate) VALUES ('Free', 0, 0, 0);");
            Sql("INSERT INTO MembershipTypes (Name, DurationInMonths, SignUpFee, DiscountRate) VALUES ('Monthly', 1, 4, 10);");
            Sql("INSERT INTO MembershipTypes (Name, DurationInMonths, SignUpFee, DiscountRate) VALUES ('Quarterly', 3, 10, 15);");
            Sql("INSERT INTO MembershipTypes (Name, DurationInMonths, SignUpFee, DiscountRate) VALUES ('Biannual', 6, 18, 20);");
            Sql("INSERT INTO MembershipTypes (Name, DurationInMonths, SignUpFee, DiscountRate) VALUES ('Annual', 12, 34, 25);");
            
        }
        
        public override void Down()
        {
        }
    }
}
