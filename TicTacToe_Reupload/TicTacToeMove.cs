using Microsoft.EntityFrameworkCore;

namespace TicTacToe_Reupload
{
    [Keyless]
    public class TicTacToeMove
    {
        public int? Game_id { get; set; }
        public int? Box1 { get; set; }
        public int? Box2 { get; set; }
        public int? Box3 { get; set; }
        public int? Box4 { get; set; }
        public int? Box5 { get; set; }
        public int? Box6 { get; set; }
        public int? Box7 { get; set; }
        public int? Box8 { get; set; }
        public int? Box9 { get; set; }
        public int? win { get; set; }

    }
}
