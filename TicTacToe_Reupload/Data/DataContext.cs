using Microsoft.EntityFrameworkCore;

namespace TicTacToe_Reupload.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<TicTacToeMove>? TicTacToeMoves { get; set; }

    }
}
