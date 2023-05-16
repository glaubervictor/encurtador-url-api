using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EncurtadorUrl.Api.Data.Migrations
{
    public partial class SeedAdresses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("adresses",
                columns: new[] { "hits", "url", "short_url" },
                values: new object[,] {
                    {5, "http://globo.com", "http://chr.dc/9dtr4"},
                    {4, "http://google.com", "http://chr.dc/aUx71"},
                    {7, "http://terra.com.br", "http://chr.dc/u9jh3"},
                    {1, "http://facebook.com", "http://chr.dc/qy61p"},
                    {2, "http://diariocatarinense.com.br", "http://chr.dc/87itr"},
                    {0, "http://uol.com.br", "http://chr.dc/y81xc"},
                    {2, "http://chaordic.com.br", "http://chr.dc/qy5k9"},
                    {4, "http://youtube.com", "http://chr.dc/1w5tg"},
                    {5, "http://twitter.com", "http://chr.dc/7tmv1"},
                    {2, "http://bing.com", "http://chr.dc/9opw2"}
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM adresses");
        }
    }
}
