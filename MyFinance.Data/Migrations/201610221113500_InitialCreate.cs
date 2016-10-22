namespace MyFinance.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateProd = c.DateTime(nullable: false),
                        Description = c.String(),
                        Name = c.String(nullable: false, maxLength: 50),
                        Price = c.Double(nullable: false),
                        Quantity = c.Int(nullable: false),
                        CategoryId = c.Int(),
                        Herbs = c.String(),
                        LabName = c.String(),
                        Adresse_City = c.String(),
                        Adresse_StreetAdress = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Providers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateCreated = c.DateTime(nullable: false),
                        IsApproved = c.Boolean(nullable: false),
                        Password = c.String(nullable: false),
                        UserName = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProviderProducts",
                c => new
                    {
                        Provider_Id = c.Int(nullable: false),
                        Product_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Provider_Id, t.Product_Id })
                .ForeignKey("dbo.Providers", t => t.Provider_Id, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Product_Id, cascadeDelete: true)
                .Index(t => t.Provider_Id)
                .Index(t => t.Product_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProviderProducts", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.ProviderProducts", "Provider_Id", "dbo.Providers");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropIndex("dbo.ProviderProducts", new[] { "Product_Id" });
            DropIndex("dbo.ProviderProducts", new[] { "Provider_Id" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropTable("dbo.ProviderProducts");
            DropTable("dbo.Providers");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
