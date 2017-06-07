namespace CurrencyRateAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        CountryId = c.Int(nullable: false, identity: true),
                        CurrencyId = c.Int(nullable: false),
                        CountryName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CountryId)
                .ForeignKey("dbo.Currencies", t => t.CurrencyId, cascadeDelete: true)
                .Index(t => t.CurrencyId);
            
            CreateTable(
                "dbo.Currencies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Category = c.String(),
                        Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Countries", "CurrencyId", "dbo.Currencies");
            DropIndex("dbo.Countries", new[] { "CurrencyId" });
            DropTable("dbo.Currencies");
            DropTable("dbo.Countries");
        }
    }
}
