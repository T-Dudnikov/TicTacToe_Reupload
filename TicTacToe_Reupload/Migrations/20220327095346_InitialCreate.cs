using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicTacToe_Reupload.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TicTacToeMoves",
                columns: table => new
                {
                    Game_id = table.Column<int>(type: "bigint", nullable: true),
                    Box1 = table.Column<int>(type: "int", nullable: true),
                    Box2 = table.Column<int>(type: "int", nullable: true),
                    Box3 = table.Column<int>(type: "int", nullable: true),
                    Box4 = table.Column<int>(type: "int", nullable: true),
                    Box5 = table.Column<int>(type: "int", nullable: true),
                    Box6 = table.Column<int>(type: "int", nullable: true),
                    Box7 = table.Column<int>(type: "int", nullable: true),
                    Box8 = table.Column<int>(type: "int", nullable: true),
                    Box9 = table.Column<int>(type: "int", nullable: true),
                    win = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                });
            var createProcSql = @"
CREATE OR ALTER PROC addMove(@Game_id bigint, @box1 int, @box2 int, @box3 int, @box4 int, @box5 int, @box6 int, @box7 int, @box8 int, @box9 int, @resultData NVARCHAR(30) OUT) as
    Declare @win int;
    Set @win = -1;
    if ((@win = -1) and ((@box1 * @box4 * @box7 = 1) or (@box2 * @box5 * @box8 = 1) or (@box3 * @box6 * @box9 = 1)
        or (@box1 * @box2 * @box3 = 1) or (@box4 * @box5 * @box6 = 1) or (@box7 * @box8 * @box9 = 1)
        or (@box1 * @box5 * @box9 = 1) or (@box3 * @box5 * @box7 = 1)))
            set @win = 1
    if ((@win = -1) and ((@box1 * @box4 * @box7 = 8) or (@box2 * @box5 * @box8 = 8) or (@box3 * @box6 * @box9 = 8)
        or (@box1 * @box2 * @box3 = 8) or (@box4 * @box5 * @box6 = 8) or (@box7 * @box8 * @box9 = 8)
        or (@box1 * @box5 * @box9 = 8) or (@box3 * @box5 * @box7 = 8)))
            set @win = 2
    if ((@win = -1) and (@box1 * @box2 * @box3 * @box4 * @box5 * @box6 * @box7 * @box8 * @box9 <> 0))
            set @win = 0
    if (@win = 1)
	begin
        set @resultData = 'X won'
		insert into dbo.TicTacToeMoves values(@Game_id, @box1, @box2, @box3, @box4, @box5, @box6, @box7, @box8, @box9, @win)
	end
    if (@win = 2)
	begin
        set @resultData = '0 won'
		insert into dbo.TicTacToeMoves values(@Game_id, @box1, @box2, @box3, @box4, @box5, @box6, @box7, @box8, @box9, @win)
	end
    if (@win = 0)
	begin
        set @resultData = 'Match Tie'
		insert into dbo.TicTacToeMoves values(@Game_id, @box1, @box2, @box3, @box4, @box5, @box6, @box7, @box8, @box9, @win)
	end
    if (@win = -1)
	begin
        set @resultData = 'Continue'
		insert into dbo.TicTacToeMoves values(@Game_id, @box1, @box2, @box3, @box4, @box5, @box6, @box7, @box8, @box9, NULL)
	end
    ";
            migrationBuilder.Sql(createProcSql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TicTacToeMoves");
        }
    }
}
