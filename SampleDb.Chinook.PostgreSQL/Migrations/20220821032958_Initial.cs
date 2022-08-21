using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SampleDb.Chinook.PostgreSQL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "artists",
                columns: table => new
                {
                    artist_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_artists", x => x.artist_id);
                });

            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    employee_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    last_name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    first_name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    title = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    reports_to = table.Column<int>(type: "integer", nullable: true),
                    birth_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    hire_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    address = table.Column<string>(type: "character varying(70)", maxLength: 70, nullable: true),
                    city = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    state = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    country = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    postal_code = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    phone = table.Column<string>(type: "character varying(24)", maxLength: 24, nullable: true),
                    fax = table.Column<string>(type: "character varying(24)", maxLength: 24, nullable: true),
                    email = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_employees", x => x.employee_id);
                    table.ForeignKey(
                        name: "fk_employees_employees_employee_to_be_reported_employee_id",
                        column: x => x.reports_to,
                        principalTable: "employees",
                        principalColumn: "employee_id");
                });

            migrationBuilder.CreateTable(
                name: "genres",
                columns: table => new
                {
                    genre_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_genres", x => x.genre_id);
                });

            migrationBuilder.CreateTable(
                name: "media_types",
                columns: table => new
                {
                    media_type_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_media_types", x => x.media_type_id);
                });

            migrationBuilder.CreateTable(
                name: "playlists",
                columns: table => new
                {
                    playlist_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_playlists", x => x.playlist_id);
                });

            migrationBuilder.CreateTable(
                name: "albums",
                columns: table => new
                {
                    album_id = table.Column<int>(type: "integer", nullable: false),
                    title = table.Column<string>(type: "character varying(160)", maxLength: 160, nullable: false),
                    artist_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_albums", x => x.album_id);
                    table.ForeignKey(
                        name: "fk_albums_artists_artist_id",
                        column: x => x.artist_id,
                        principalTable: "artists",
                        principalColumn: "artist_id");
                });

            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    customer_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    first_name = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    last_name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    company = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: true),
                    address = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    city = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    state = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    country = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    postal_code = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    phone = table.Column<string>(type: "character varying(24)", maxLength: 24, nullable: true),
                    fax = table.Column<string>(type: "character varying(24)", maxLength: 24, nullable: true),
                    email = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    support_rep_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_customers", x => x.customer_id);
                    table.ForeignKey(
                        name: "fk_customers_employees_support_rep_id",
                        column: x => x.support_rep_id,
                        principalTable: "employees",
                        principalColumn: "employee_id");
                });

            migrationBuilder.CreateTable(
                name: "tracks",
                columns: table => new
                {
                    track_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    album_id = table.Column<int>(type: "integer", nullable: true),
                    media_type_id = table.Column<int>(type: "integer", nullable: false),
                    genre_id = table.Column<int>(type: "integer", nullable: true),
                    composer = table.Column<string>(type: "character varying(220)", maxLength: 220, nullable: true),
                    milliseconds = table.Column<int>(type: "integer", nullable: false),
                    bytes = table.Column<int>(type: "integer", nullable: true),
                    unit_price = table.Column<decimal>(type: "numeric(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tracks", x => x.track_id);
                    table.ForeignKey(
                        name: "fk_tracks_albums_album_id",
                        column: x => x.album_id,
                        principalTable: "albums",
                        principalColumn: "album_id");
                    table.ForeignKey(
                        name: "fk_tracks_genres_genre_id",
                        column: x => x.genre_id,
                        principalTable: "genres",
                        principalColumn: "genre_id");
                    table.ForeignKey(
                        name: "fk_tracks_media_types_media_type_id",
                        column: x => x.media_type_id,
                        principalTable: "media_types",
                        principalColumn: "media_type_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "invoices",
                columns: table => new
                {
                    invoice_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    customer_id = table.Column<int>(type: "integer", nullable: false),
                    invoice_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    billing_address = table.Column<string>(type: "character varying(70)", maxLength: 70, nullable: true),
                    billing_city = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    billing_state = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    billing_country = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    billing_postal_code = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    total = table.Column<decimal>(type: "numeric(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_invoices", x => x.invoice_id);
                    table.ForeignKey(
                        name: "fk_invoices_customers_customer_id",
                        column: x => x.customer_id,
                        principalTable: "customers",
                        principalColumn: "customer_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "playlist_track",
                columns: table => new
                {
                    playlist_id = table.Column<int>(type: "integer", nullable: false),
                    track_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_playlist_track", x => new { x.playlist_id, x.track_id });
                    table.ForeignKey(
                        name: "fk_playlist_track_playlists_playlist_id",
                        column: x => x.playlist_id,
                        principalTable: "playlists",
                        principalColumn: "playlist_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_playlist_track_tracks_track_id",
                        column: x => x.track_id,
                        principalTable: "tracks",
                        principalColumn: "track_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "invoice_lines",
                columns: table => new
                {
                    invoice_line_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    invoice_id = table.Column<int>(type: "integer", nullable: false),
                    track_id = table.Column<int>(type: "integer", nullable: false),
                    unit_price = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_invoice_lines", x => x.invoice_line_id);
                    table.ForeignKey(
                        name: "fk_invoice_lines_invoices_invoice_id",
                        column: x => x.invoice_id,
                        principalTable: "invoices",
                        principalColumn: "invoice_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_invoice_lines_tracks_track_id",
                        column: x => x.track_id,
                        principalTable: "tracks",
                        principalColumn: "track_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_albums_artist_id",
                table: "albums",
                column: "artist_id");

            migrationBuilder.CreateIndex(
                name: "ix_customers_support_rep_id",
                table: "customers",
                column: "support_rep_id");

            migrationBuilder.CreateIndex(
                name: "ix_employees_reports_to",
                table: "employees",
                column: "reports_to");

            migrationBuilder.CreateIndex(
                name: "ix_invoice_lines_invoice_id",
                table: "invoice_lines",
                column: "invoice_id");

            migrationBuilder.CreateIndex(
                name: "ix_invoice_lines_track_id",
                table: "invoice_lines",
                column: "track_id");

            migrationBuilder.CreateIndex(
                name: "ix_invoices_customer_id",
                table: "invoices",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "ix_playlist_track_track_id",
                table: "playlist_track",
                column: "track_id");

            migrationBuilder.CreateIndex(
                name: "ix_tracks_album_id",
                table: "tracks",
                column: "album_id");

            migrationBuilder.CreateIndex(
                name: "ix_tracks_genre_id",
                table: "tracks",
                column: "genre_id");

            migrationBuilder.CreateIndex(
                name: "ix_tracks_media_type_id",
                table: "tracks",
                column: "media_type_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "invoice_lines");

            migrationBuilder.DropTable(
                name: "playlist_track");

            migrationBuilder.DropTable(
                name: "invoices");

            migrationBuilder.DropTable(
                name: "playlists");

            migrationBuilder.DropTable(
                name: "tracks");

            migrationBuilder.DropTable(
                name: "customers");

            migrationBuilder.DropTable(
                name: "albums");

            migrationBuilder.DropTable(
                name: "genres");

            migrationBuilder.DropTable(
                name: "media_types");

            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropTable(
                name: "artists");
        }
    }
}
