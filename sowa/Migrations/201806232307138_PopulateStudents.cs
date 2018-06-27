namespace sowa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateStudents : DbMigration
    {
        public override void Up()
        {
            Sql(
            "INSERT INTO Students (Name, MembershipTypeId, IsSubscribedToNewsLetter, Birthday) " + 
            "VALUES ('John Johnson', 1, 0, '1977-12-12')"
                );
        }
        
        public override void Down()
        {
        }
    }
}
