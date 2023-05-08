using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorWho.Db.Migrations
{
    /// <inheritdoc />
    public partial class CreateFnCompanions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE FUNCTION fnCompanions (
                                        	@id INT
                                        )
                                        RETURNS VARCHAR(MAX)
                                        BEGIN
                                        	DECLARE @return_value VARCHAR(MAX)
                                        	SELECT
                                        		@return_value = COALESCE(@return_value + ', ','') + C.Name 
                                        	FROM
                                        		Companions C
                                        	JOIN EpisodeCompanions E 
                                        		ON C.Id = E.CompanionId
                                        	WHERE
                                        		E.EpisodeId = @id;
                                        return @return_value;
                                        END;");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP FUNCTION IF EXISTS fnCompanions;");
        }
    }
}
