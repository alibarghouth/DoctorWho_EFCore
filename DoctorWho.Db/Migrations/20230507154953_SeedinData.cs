using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable


namespace DoctorWho.Db.Migrations
{
    /// <inheritdoc />
    public partial class SeedinData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Auther1" },
                    { 2, "Auther2" },
                    { 3, "Auther3" },
                    { 4, "Auther4" },
                    { 5, "Auther5" }
                });

            migrationBuilder.InsertData(
                table: "Companions",
                columns: new[] { "Id", "Name", "WhoPlayed" },
                values: new object[,]
                {
                    { 1, "Companion1", "WhoPlayed1" },
                    { 2, "Companion2", "WhoPlayed2" },
                    { 3, "Companion3", "WhoPlayed3" },
                    { 4, "Companion4", "WhoPlayed4" },
                    { 5, "Companion5", "WhoPlayed5" }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "BirthDate", "FirstEpisodeDate", "LastEpisodeDate", "Name", "Number" },
                values: new object[,]
                {
                    { 1, new DateTime(1999, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doctor", "0599728416" },
                    { 2, new DateTime(1999, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doctor2", "0599728416" },
                    { 3, new DateTime(1999, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doctor3", "0599728416" },
                    { 4, new DateTime(1999, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doctor4", "0599728416" },
                    { 5, new DateTime(1999, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doctor5", "0599728416" }
                });

            migrationBuilder.InsertData(
                table: "Enemies",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Description1", "Name1" },
                    { 2, "Description2", "Name2" },
                    { 3, "Description3", "Name3" },
                    { 4, "Description4", "Name4" },
                    { 5, "Description5", "Name5" }
                });

            migrationBuilder.InsertData(
                table: "Episodes",
                columns: new[] { "Id", "AuthorId", "DoctorId", "EpisodeNumber", "Episodetype", "EpsodeDate", "Notes", "SeriesNumber", "Title" },
                values: new object[,]
                {
                    { 1, 2, 2, 234, "type1", new DateTime(2000, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "notes1", 123, "title1" },
                    { 2, 1, 3, 234, "type1", new DateTime(2000, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "notes1", 123, "title1" },
                    { 3, 4, 4, 234, "type1", new DateTime(2000, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "notes1", 123, "title1" },
                    { 4, 3, 5, 234, "type1", new DateTime(2000, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "notes1", 123, "title1" },
                    { 5, 5, 2, 234, "type1", new DateTime(2000, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "notes1", 123, "title1" }
                });

            migrationBuilder.InsertData(
                table: "EpisodeCompanions",
                columns: new[] { "Id", "CompanionId", "EpisodeId" },
                values: new object[,]
                {
                    { 1, 5, 1 },
                    { 2, 2, 4 },
                    { 3, 4, 5 },
                    { 4, 2, 2 },
                    { 5, 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "EpisodeEnemies",
                columns: new[] { "Id", "EnemyId", "EpisodeId" },
                values: new object[,]
                {
                    { 1, 2, 3 },
                    { 2, 1, 4 },
                    { 3, 4, 3 },
                    { 4, 5, 2 },
                    { 5, 5, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Companions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "EpisodeCompanions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EpisodeCompanions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EpisodeCompanions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "EpisodeCompanions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "EpisodeCompanions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "EpisodeEnemies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EpisodeEnemies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EpisodeEnemies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "EpisodeEnemies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "EpisodeEnemies",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Companions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Companions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Companions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Companions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
