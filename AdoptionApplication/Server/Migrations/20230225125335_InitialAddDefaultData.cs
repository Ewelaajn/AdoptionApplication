using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AdoptionApplication.Server.Migrations
{
    public partial class InitialAddDefaultData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Species",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Url = table.Column<string>(type: "text", nullable: false),
                    Icon = table.Column<string>(type: "text", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "CURRENT_DATE"),
                    Deleted = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Species", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Animal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    IsAdopted = table.Column<bool>(type: "boolean", nullable: true),
                    Gender = table.Column<string>(type: "text", nullable: true),
                    ShortDescription = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    HealthStatus = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "text", nullable: true),
                    Province = table.Column<string>(type: "text", nullable: true),
                    Image = table.Column<string>(type: "text", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "CURRENT_DATE"),
                    AdoptionDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Deleted = table.Column<bool>(type: "boolean", nullable: true),
                    SpeciesId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animal", x => x.Id);
                    table.ForeignKey(
                        name: "Animal_SpeciesId_fkey",
                        column: x => x.SpeciesId,
                        principalTable: "Species",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Species",
                columns: new[] { "Id", "Deleted", "Icon", "Name", "Url" },
                values: new object[,]
                {
                    { 1, false, "fa-solid fa-carrot", "Króliki", "rabbits" },
                    { 2, false, "fas fa-dog", "Psy", "dogs" },
                    { 3, false, "fas fa-cat", "Koty", "cats" }
                });

            migrationBuilder.InsertData(
                table: "Animal",
                columns: new[] { "Id", "AdoptionDate", "City", "DateOfBirth", "Deleted", "Description", "Gender", "HealthStatus", "Image", "IsAdopted", "Name", "Province", "ShortDescription", "SpeciesId" },
                values: new object[,]
                {
                    { 1, null, "Kraków", new DateTime(2018, 12, 31, 23, 0, 0, 0, DateTimeKind.Utc), false, "Bazylka to urocza króliczka o pięknej, jasnorudej sierści. Ma duże, brązowe oczy i długie, puszyste uszy, które ciągle kręcą się na boki,słysząc każdy dźwięk w otoczeniu.Charakter Bazylki jest bardzo energiczny i zwinny. Lubi skakać, biegać i bawić się na świeżym powietrzu. Jest bardzoruchliwa i szybka, dzięki czemu unika niebezpieczeństw i łatwo przemieszcza się po swoim terenie.Bazylka jest także bardzo ciekawska i lubi odkrywać nowe rzeczy. Często chodzi po nowych miejscach,grzebie w ziemi i przekopywa nowe tunele. Lubi też poznawać nowych ludzi i zwierzęta, zachęcającdo zabawy swoim wesołym podejściem i chęcią do zabawy.Króliczka ta jest także bardzo uparta iczasem trudno zmusić ją do zrobienia czegoś, czego nie chce.Jednakże jest też bardzo kochana iprzyjacielska, zwłaszcza wobec swoich opiekunów. Lubi pieszczoty i przytulanie, a czasem sama uciekado ciepłego kąta, aby odpocząć i zrelaksować się.Ogólnie rzecz biorąc, Bazylka to urocza, pełna energiii wesoła króliczka o pięknej, jasnorudej sierści. Jej ruchliwość i zwinność sprawiają, że jest doskonałymtowarzyszem zabaw, a jej przyjacielskie nastawienie przyciąga do niej wiele nowych znajomości.", "Samica", "Chory", "https://iili.io/HGRJuG1.jpg", false, "Bazylka", "Małopolskie", "Śmieszna wiewiórka, lubi jeść", 1 },
                    { 2, null, "Kraków", new DateTime(2019, 3, 4, 23, 0, 0, 0, DateTimeKind.Utc), false, "Chlebusz to uroczy królik o miękkim i puszystym, szarym futrze. Ma duże, czarne oczy i długie, uszate uszy, które ciągle kręcą się na boki, słysząc każdy dźwięk w otoczeniu.Charakter Chlebusza jest bardzo przyjacielski i łagodny. Lubi spędzać czas na wypoczynku, leżąc wygodnie na miękkiej poduszce lub grzebiąc w swojej ulubionej zielonej trawie. Jest bardzo łagodny i nieśmiały, ale też ciekawy świata i lubi poznawać nowych ludzi i zwierzęta.Chlebusz jest bardzo aktywny w ciągu dnia, lubi biegać po łące i skakać z jednego miejsca na drugie. Czasami jest też nieco roztrzepany i zapomina o swoich zadaniach, ale zawsze stara się naprawić swoje błędy.Królik ten lubi też dobrą, soczystą marchewkę oraz inne smaczne warzywa, które lubi zjadać podczas swoich przekąsek. Jest bardzo przywiązany do swojej rodziny i lubi spędzać czas z nimi, a także lubi przesypiać większą część dnia.Ogólnie rzecz biorąc, Chlebusz to uroczy, przyjacielski i aktywny królik, który kocha spędzać czas na wypoczynku, ale też chętnie poznaje nowych przyjaciół.", "Samiec", "Zdrowy", "https://iili.io/HGRJA6F.jpg", false, "Chlebusz", "Małopolskie", "Królik nie z tego świata", 1 },
                    { 3, null, "Wrocław", new DateTime(2020, 2, 9, 23, 0, 0, 0, DateTimeKind.Utc), false, "Bamboszek to biały shih tzu o przyjaznym charakterze. Ma krótkie futerko, które jest miękkie w dotyku i wymaga regularnej pielęgnacji. Jego małe, czarne oczy emanują ciepłem i życzliwością, co sprawia, że trudno mu się oprzeć.Bamboszek jest bardzo energiczny i uwielbia bawić się ze swoim właścicielem. Jest to piesek inteligentny, który szybko się uczy i z łatwością zapamiętuje komendy. Lubi też biegać, skakać i bawić się zabawkami, a jego radosny temperament sprawia, że potrafi rozśmieszać każdego.Jest też bardzo przyjacielski i lojalny. Lubi być w bliskim kontakcie ze swoim właścicielem i często chętnie siada na kolanach lub przytula się do niego. Jest też bardzo czuły i wrażliwy, co sprawia, że łatwo go rozpieszczać i dawać mu wiele radości.Podsumowując, Bamboszek to uroczy shih tzu, który jest idealnym towarzyszem dla osób, które cenią sobie energię, inteligencję i lojalność w swoim psie. Jego radosny temperament i przyjacielski charakter sprawiają, że zawsze jest on gotowy do zabawy i pełen życzliwości w stosunku do swojego właściciela.", "Samiec", "Zdrowy", "https://iili.io/HGAVrG4.jpg", false, "Bamboszek", "Dolnośląskie", "Mięciutki Bamboszek szuka domu", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animal_SpeciesId",
                table: "Animal",
                column: "SpeciesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animal");

            migrationBuilder.DropTable(
                name: "Species");
        }
    }
}
