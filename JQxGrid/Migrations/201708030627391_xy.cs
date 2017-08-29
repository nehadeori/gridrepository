namespace JQxGrid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class xy : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "jq.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 15),
                        Address = c.String(maxLength: 50),
                        Email = c.String(),
                        Phone = c.Long(nullable: false),
                        Product_ProductId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("jq.Products", t => t.Product_ProductId)
                .Index(t => t.Product_ProductId);
            
            CreateTable(
                "jq.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        OrderDate = c.String(),
                        Quantity = c.Int(nullable: false),
                        Customer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("jq.Customers", t => t.Customer_Id)
                .Index(t => t.Customer_Id);
            
            CreateTable(
                "jq.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        OrderId = c.Int(nullable: false),
                        Cost = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("jq.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("jq.Orders", "Customer_Id", "jq.Customers");
            DropForeignKey("jq.Products", "OrderId", "jq.Orders");
            DropForeignKey("jq.Customers", "Product_ProductId", "jq.Products");
            DropIndex("jq.Products", new[] { "OrderId" });
            DropIndex("jq.Orders", new[] { "Customer_Id" });
            DropIndex("jq.Customers", new[] { "Product_ProductId" });
            DropTable("jq.Products");
            DropTable("jq.Orders");
            DropTable("jq.Customers");
        }
    }
}
