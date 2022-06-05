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
        public Bitmap[] BitmapTexture { get; set; }

        public int Speed { get; set; }

        public bool isMoving = false;

        private Direction dir;
        public Direction Dir { get { return dir; } 
            set {
                dir = value;
                Width = BitmapTexture[(int)Dir].Width;
                Height = BitmapTexture[(int)Dir].Height;
            }
        }

        protected override Image GetDrawImage() {
            Bitmap tmpBitmap = BitmapTexture[(int)Dir];
            tmpBitmap.MakeTransparent(Color.Black);
            return tmpBitmap;
        }
    }
}
