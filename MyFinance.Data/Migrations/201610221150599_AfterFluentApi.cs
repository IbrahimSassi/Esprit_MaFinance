namespace MyFinance.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AfterFluentApi : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Categories", newName: "MyCategories");
            RenameTable(name: "dbo.ProviderProducts", newName: "MyProductsProviders");
            RenameColumn(table: "dbo.MyProductsProviders", name: "Provider_Id", newName: "CleProv");
            RenameColumn(table: "dbo.MyProductsProviders", name: "Product_Id", newName: "CleProd");
            RenameIndex(table: "dbo.MyProductsProviders", name: "IX_Product_Id", newName: "IX_CleProd");
            RenameIndex(table: "dbo.MyProductsProviders", name: "IX_Provider_Id", newName: "IX_CleProv");
            DropPrimaryKey("dbo.MyProductsProviders");
            AddColumn("dbo.Products", "IsBiological", c => c.Int());
            AlterColumn("dbo.MyCategories", "name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Products", "Adresse_StreetAdress", c => c.String(maxLength: 50));
            AddPrimaryKey("dbo.MyProductsProviders", new[] { "CleProd", "CleProv" });
            DropColumn("dbo.Products", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            DropPrimaryKey("dbo.MyProductsProviders");
            AlterColumn("dbo.Products", "Adresse_StreetAdress", c => c.String());
            AlterColumn("dbo.MyCategories", "name", c => c.String());
            DropColumn("dbo.Products", "IsBiological");
            AddPrimaryKey("dbo.MyProductsProviders", new[] { "Provider_Id", "Product_Id" });
            RenameIndex(table: "dbo.MyProductsProviders", name: "IX_CleProv", newName: "IX_Provider_Id");
            RenameIndex(table: "dbo.MyProductsProviders", name: "IX_CleProd", newName: "IX_Product_Id");
            RenameColumn(table: "dbo.MyProductsProviders", name: "CleProd", newName: "Product_Id");
            RenameColumn(table: "dbo.MyProductsProviders", name: "CleProv", newName: "Provider_Id");
            RenameTable(name: "dbo.MyProductsProviders", newName: "ProviderProducts");
            RenameTable(name: "dbo.MyCategories", newName: "Categories");
        }
    }
}
