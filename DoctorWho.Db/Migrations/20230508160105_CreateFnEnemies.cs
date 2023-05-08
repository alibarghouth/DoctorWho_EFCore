using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorWho.Db.Migrations
{
    /// <inheritdoc />
    public partial class CreateFnEnemies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var fnEnemies = @"CREATE FUNCTION fnEnemies (
                                	@id INT
                                )
                                RETURNS VARCHAR(MAX)
                                BEGIN
                                DECLARE @return_value VARCHAR(MAX)
                                	SELECT
                                		@return_value =  COALESCE(@return_value + ', ','') + EnemyName 
                                	FROM
                                		Enemy C
                                	JOIN EpisodeEnemy E 
                                		ON C.Id = E.EnemyId
                                	WHERE
                                		E.EpisodeId = @id;
                                return @return_value
                                END;";

            migrationBuilder.Sql(fnEnemies);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP FUNCTION IF EXISTS fnEnemies;");
        }
    }
}
