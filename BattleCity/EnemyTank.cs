using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleCity {
    class EnemyTank : Tank {
        private Random rd = new Random();

        private int AutoMoveCheckSpeed;
        private int AutoMoveCheckCount = 0;
        private int AutoAttackSpeed;
        private int AutoAttackCount = 0;

        public EnemyTank(int x, int y, int speed, Bitmap[] bitmapTexture) : base(x, y, speed, bitmapTexture) {
            isMoving = true;
            Dir = Direction.Down;

            AutoMoveCheckSpeed = rd.Next(40, 70);
            AutoAttackSpeed = rd.Next(60, 100);
        }

        public override void Update() {
            base.Update();
            AutoAttack();
            AutoMoveCheck();
        }
        private void AutoAttack() {
            AutoAttackCount++;
            if (AutoAttackCount < AutoAttackSpeed) return;
            AutoAttackCount = 0;
            Attack(BulletTag.EnemyTank);
        }

        private void AutoMoveCheck() {
            AutoMoveCheckCount++;
            if (AutoMoveCheckCount < AutoMoveCheckSpeed) return;
            AutoMoveCheckCount = 0;
            HandleMoveCheck();
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
