using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorWho.Db.Migrations
{
    /// <inheritdoc />
    public partial class CreateSP : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
               var sp = @"CREATE PROCEDURE spSummariseEpisodes
                            AS
                            BEGIN	
                            	SELECT 
                            	   TOP 3 c.Name, COUNT(*) AS CompanionCount
                            	FROM 
                            	   EpisodeCompanions EC  JOIN Companions C
                            	ON 
                            	   C.Id = EC.CompanionId 
                            	GROUP BY Name
                            	ORDER BY COUNT(*) DESC;
                            
                            	SELECT  
                            	   TOP 3 Name, COUNT(*) AS EnemyCount
                            	FROM 
                            	   EpisodeEnemy EE  JOIN Enemy E  ON E.Id = EE.EnemyId 
                            	GROUP BY EnemyName
                            	ORDER BY COUNT(*) DESC;
                            END;";

            migrationBuilder.Sql(sp);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROCEDURE IF EXISTS spSummariseEpisodes;");
        }
    }
}
