namespace Eron.core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class confsliderCategoryinit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SliderCategories",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SliderSliderCategories",
                c => new
                    {
                        Slider_Id = c.Long(nullable: false),
                        SliderCategory_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.Slider_Id, t.SliderCategory_Id })
                .ForeignKey("dbo.Sliders", t => t.Slider_Id, cascadeDelete: true)
                .ForeignKey("dbo.SliderCategories", t => t.SliderCategory_Id, cascadeDelete: true)
                .Index(t => t.Slider_Id)
                .Index(t => t.SliderCategory_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SliderSliderCategories", "SliderCategory_Id", "dbo.SliderCategories");
            DropForeignKey("dbo.SliderSliderCategories", "Slider_Id", "dbo.Sliders");
            DropIndex("dbo.SliderSliderCategories", new[] { "SliderCategory_Id" });
            DropIndex("dbo.SliderSliderCategories", new[] { "Slider_Id" });
            DropTable("dbo.SliderSliderCategories");
            DropTable("dbo.SliderCategories");
        }
    }
}
