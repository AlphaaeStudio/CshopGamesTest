using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleCity {
    enum Direction {
        Up, Right, Down, Left
    }
    class Movething : GameObject {
        public Bitmap[] bitmap { get; set; }

        public Direction Dir { get; set; }

        protected override Image GetDrawImage() {
            Bitmap tmpBitmap = bitmap[(int)Dir];
            tmpBitmap.MakeTransparent(Color.Black);
            return tmpBitmap;
        }
    }
}
