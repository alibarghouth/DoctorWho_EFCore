using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorWho.Db.Migrations
{
    /// <inheritdoc />
    public partial class CreateView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var view = @"CREATE VIEW viewEpisodes AS
                          SELECT 
                             E.Id, E.Title, A.Name, D.Name,
                             dbo.fnCompanions(E.Id) AS Companions, dbo.fnEnemies(E.Id) AS Enemies
                          FROM 
                             Episode E
                          JOIN 
                             Doctor D ON E.DoctorId = D.Id
                          JOIN 
                             Author A ON E.AuthorId = A.Id;";

            migrationBuilder.Sql(view);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW IF EXISTS viewEpisodes;");
        }
    }
}
