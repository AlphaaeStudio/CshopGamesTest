using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BattleCity.Properties;

namespace BattleCity {
    class MyTank : Tank {

        private int HP;
        private int originX;
        private int originY;

        public MyTank(int x, int y, int speed) : base(x, y, speed, MyTankTexture) {
            this.HP = 3;
            originX = x;
            originY = y;
        }

        public override void HandleMoveCheck() {
            isMoving = false;
        }

        internal void KeyDown(KeyEventArgs e) {
            switch (e.KeyCode) {
                case Keys.W:
                    if (Dir != Direction.Up) Dir = Direction.Up;
                    isMoving = true;
                    break;
                case Keys.S:
                    if (Dir != Direction.Down) Dir = Direction.Down;
                    isMoving = true;
                    break;
                case Keys.A:
                    if (Dir != Direction.Left) Dir = Direction.Left;
                    isMoving = true;
                    break;
                case Keys.D:
                    if (Dir != Direction.Right) Dir = Direction.Right;
                    isMoving = true;
                    break;
                case Keys.Space:
                    Attack(BulletTag.MyTank);
                    break;
            }
        }

        internal void KeyUp(KeyEventArgs e) {
            switch (e.KeyCode) {
                case Keys.W:
                    isMoving = false;
                    break;
                case Keys.S:
                    isMoving = false;
                    break;
                case Keys.A:
                    isMoving = false;
                    break;
                case Keys.D:
                    isMoving = false;
                    break;
            }
        }

        public void TakeDamage() {
            if (HP <= 0) {
                //gameover
                GameFramework.ChangeToGameOver();
            }
            X = originX;
            Y = originY;
            Dir = Direction.Up;
            SoundManenger.PlayHit();
        }

        protected override void Attack(BulletTag tag) {
            base.Attack(tag);
            SoundManenger.PlayFire();
        }
    }
}
