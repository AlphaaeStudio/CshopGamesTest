using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleCity {
    class EnemyTank : Tank {

        private Random rd = new Random();
        public EnemyTank(int x, int y, int speed, Bitmap[] bitmapTexture) : base(x, y, speed, bitmapTexture) {
            isMoving = true;
            Dir = Direction.Down;
        }

        public override void HandleMoveCheck() {
            while (true) {
                var tmpDir = (Direction)rd.Next(0, 4);
                if (Dir != tmpDir) {
                    Dir = tmpDir;
                    MoveCheck();
                    return;
                }
            }
        }
    }
}
