namespace JQxGrid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class qwerty : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("jq.Customers", "Product_ProductId", "jq.Products");
            DropForeignKey("jq.Orders", "Customer_Id", "jq.Customers");
            DropIndex("jq.Customers", new[] { "Product_ProductId" });
            DropIndex("jq.Orders", new[] { "Customer_Id" });
            AddColumn("jq.Customers", "Product_ProductId1", c => c.Int());
            AddColumn("jq.Orders", "Customer_Id1", c => c.Int());
            CreateIndex("jq.Customers", "Product_ProductId1");
            CreateIndex("jq.Orders", "Customer_Id1");
            AddForeignKey("jq.Customers", "Product_ProductId1", "jq.Products", "ProductId");
            AddForeignKey("jq.Orders", "Customer_Id1", "jq.Customers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("jq.Orders", "Customer_Id1", "jq.Customers");
            DropForeignKey("jq.Customers", "Product_ProductId1", "jq.Products");
            DropIndex("jq.Orders", new[] { "Customer_Id1" });
            DropIndex("jq.Customers", new[] { "Product_ProductId1" });
            DropColumn("jq.Orders", "Customer_Id1");
            DropColumn("jq.Customers", "Product_ProductId1");
            CreateIndex("jq.Orders", "Customer_Id");
            CreateIndex("jq.Customers", "Product_ProductId");
            AddForeignKey("jq.Orders", "Customer_Id", "jq.Customers", "Id");
            AddForeignKey("jq.Customers", "Product_ProductId", "jq.Products", "ProductId");
        }
    }
}
