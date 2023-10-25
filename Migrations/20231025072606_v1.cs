using System;
using Bogus;
using Bogus.DataSets;
using Microsoft.EntityFrameworkCore.Migrations;
using withEF.Models;

#nullable disable

namespace withEF.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Article",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Article", x => x.ID);
                });
                var fakerArticle = new Faker<Article>();
                fakerArticle.RuleFor(a => a.Title, fakerArticle => fakerArticle.Lorem.Sentence(5, 5));
                fakerArticle.RuleFor(a => a.PublishDate, fakerArticle => fakerArticle.Date.Between(new DateTime(2023,1, 1), new DateTime(2024,1,1)));
                fakerArticle.RuleFor(a => a.Content, fakerArticle => fakerArticle.Lorem.Paragraphs(1, 4));
                for (int i = 0; i < 100; i++)
                {
                    var article = fakerArticle.Generate();
                    migrationBuilder.InsertData(
                        table: "Article",
                        columns: new string[] {"Title", "PublishDate", "Content"},
                        values: new object[] {article.Title, article.PublishDate, article.Content}
                    );
                }
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Article");
        }
    }
}
