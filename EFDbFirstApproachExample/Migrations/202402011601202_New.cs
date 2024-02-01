namespace EFDbFirstApproachExample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class New : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "BrandID", "dbo.Brands");
            DropForeignKey("dbo.Products", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "CategoryID" });
            DropIndex("dbo.Products", new[] { "BrandID" });
            AlterColumn("dbo.Products", "CategoryID", c => c.Long());
            AlterColumn("dbo.Products", "BrandID", c => c.Long());
            CreateIndex("dbo.Products", "CategoryID");
            CreateIndex("dbo.Products", "BrandID");
            AddForeignKey("dbo.Products", "BrandID", "dbo.Brands", "BrandID");
            AddForeignKey("dbo.Products", "CategoryID", "dbo.Categories", "CategoryID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Products", "BrandID", "dbo.Brands");
            DropIndex("dbo.Products", new[] { "BrandID" });
            DropIndex("dbo.Products", new[] { "CategoryID" });
            AlterColumn("dbo.Products", "BrandID", c => c.Long(nullable: false));
            AlterColumn("dbo.Products", "CategoryID", c => c.Long(nullable: false));
            CreateIndex("dbo.Products", "BrandID");
            CreateIndex("dbo.Products", "CategoryID");
            AddForeignKey("dbo.Products", "CategoryID", "dbo.Categories", "CategoryID", cascadeDelete: true);
            AddForeignKey("dbo.Products", "BrandID", "dbo.Brands", "BrandID", cascadeDelete: true);
        }
    }
}
