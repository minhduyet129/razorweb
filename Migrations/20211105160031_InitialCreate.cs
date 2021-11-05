using System;
using Bogus;
using entityframework.Models;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _09EntityFramework.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Content = table.Column<string>(type: "ntext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_articles", x => x.Id);
                });


            // Insert Data
            //Fake Data: Bogus
            Randomizer.Seed = new Random(8675309);
            var fakeArticle=new Faker<Article>();
            fakeArticle.RuleFor(x=>x.Title,y=>y.Lorem.Sentence(5,5));
            fakeArticle.RuleFor(x=>x.Created,y=>y.Date.Between(new DateTime(2021,1,1),new DateTime(2021,11,05)));
            fakeArticle.RuleFor(x=>x.Content,y=>y.Lorem.Paragraphs(1,4));
            
           
            for(int i=0;i<150;i++){
                Article article=fakeArticle.Generate();
                migrationBuilder.InsertData(
                table:"articles",
                columns:new[] {"Title","Created","Content"},
                values :new object[]{
                    article.Title,
                    article.Created,
                    article.Content
                }
                );
            }
                
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "articles");
        }
    }
}
