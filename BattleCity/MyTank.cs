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


        public MyTank(int x, int y, int speed) : base(x, y, speed, MyTankTexture) { }

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
    }
}
