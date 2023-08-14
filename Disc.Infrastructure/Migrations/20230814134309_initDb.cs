using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Disc.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Condition",
                columns: table => new
                {
                    ConditionId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConditionName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Condition", x => x.ConditionId);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    CountryId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    GenreId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenreName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.GenreId);
                });

            migrationBuilder.CreateTable(
                name: "Style",
                columns: table => new
                {
                    StyleId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StyleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Style", x => x.StyleId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Artist",
                columns: table => new
                {
                    ArtistId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArtistName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RealName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artist", x => x.ArtistId);
                    table.ForeignKey(
                        name: "FK_Artist_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Label",
                columns: table => new
                {
                    LabelId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LabelName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Label", x => x.LabelId);
                    table.ForeignKey(
                        name: "FK_Label_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Release",
                columns: table => new
                {
                    DiscogsId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArtistId = table.Column<long>(type: "bigint", nullable: false),
                    CountryId = table.Column<long>(type: "bigint", nullable: false),
                    ReleaseYear = table.Column<int>(type: "int", nullable: false),
                    ConditionId = table.Column<long>(type: "bigint", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Release", x => x.DiscogsId);
                    table.ForeignKey(
                        name: "FK_Release_Artist_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artist",
                        principalColumn: "ArtistId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Release_Condition_ConditionId",
                        column: x => x.ConditionId,
                        principalTable: "Condition",
                        principalColumn: "ConditionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Release_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Release_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ArtistMusicLabel",
                columns: table => new
                {
                    ArtistId = table.Column<long>(type: "bigint", nullable: false),
                    MusicLabelId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistMusicLabel", x => new { x.ArtistId, x.MusicLabelId });
                    table.ForeignKey(
                        name: "FK_ArtistMusicLabel_Artist_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artist",
                        principalColumn: "ArtistId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ArtistMusicLabel_Label_MusicLabelId",
                        column: x => x.MusicLabelId,
                        principalTable: "Label",
                        principalColumn: "LabelId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Link",
                columns: table => new
                {
                    LinkId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiteUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MusicLabelLabelId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Link", x => x.LinkId);
                    table.ForeignKey(
                        name: "FK_Link_Label_MusicLabelLabelId",
                        column: x => x.MusicLabelLabelId,
                        principalTable: "Label",
                        principalColumn: "LabelId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReleaseGenre",
                columns: table => new
                {
                    ReleaseId = table.Column<long>(type: "bigint", nullable: false),
                    GenreId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReleaseGenre", x => new { x.ReleaseId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_ReleaseGenre_Genre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genre",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReleaseGenre_Release_ReleaseId",
                        column: x => x.ReleaseId,
                        principalTable: "Release",
                        principalColumn: "DiscogsId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReleaseStyle",
                columns: table => new
                {
                    ReleaseId = table.Column<long>(type: "bigint", nullable: false),
                    StyleId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReleaseStyle", x => new { x.ReleaseId, x.StyleId });
                    table.ForeignKey(
                        name: "FK_ReleaseStyle_Release_ReleaseId",
                        column: x => x.ReleaseId,
                        principalTable: "Release",
                        principalColumn: "DiscogsId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReleaseStyle_Style_StyleId",
                        column: x => x.StyleId,
                        principalTable: "Style",
                        principalColumn: "StyleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ArtistLink",
                columns: table => new
                {
                    ArtistId = table.Column<long>(type: "bigint", nullable: false),
                    LinkId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistLink", x => new { x.ArtistId, x.LinkId });
                    table.ForeignKey(
                        name: "FK_ArtistLink_Artist_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artist",
                        principalColumn: "ArtistId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ArtistLink_Link_LinkId",
                        column: x => x.LinkId,
                        principalTable: "Link",
                        principalColumn: "LinkId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Artist_CountryId",
                table: "Artist",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtistLink_LinkId",
                table: "ArtistLink",
                column: "LinkId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtistMusicLabel_MusicLabelId",
                table: "ArtistMusicLabel",
                column: "MusicLabelId");

            migrationBuilder.CreateIndex(
                name: "IX_Label_CountryId",
                table: "Label",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Link_MusicLabelLabelId",
                table: "Link",
                column: "MusicLabelLabelId");

            migrationBuilder.CreateIndex(
                name: "IX_Release_ArtistId",
                table: "Release",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Release_ConditionId",
                table: "Release",
                column: "ConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_Release_CountryId",
                table: "Release",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Release_UserId",
                table: "Release",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ReleaseGenre_GenreId",
                table: "ReleaseGenre",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_ReleaseStyle_StyleId",
                table: "ReleaseStyle",
                column: "StyleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtistLink");

            migrationBuilder.DropTable(
                name: "ArtistMusicLabel");

            migrationBuilder.DropTable(
                name: "ReleaseGenre");

            migrationBuilder.DropTable(
                name: "ReleaseStyle");

            migrationBuilder.DropTable(
                name: "Link");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "Release");

            migrationBuilder.DropTable(
                name: "Style");

            migrationBuilder.DropTable(
                name: "Label");

            migrationBuilder.DropTable(
                name: "Artist");

            migrationBuilder.DropTable(
                name: "Condition");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
