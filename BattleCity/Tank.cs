using BattleCity.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleCity {
    abstract class Tank : Movething {
        public static Bitmap[] MyTankTexture = new Bitmap[] {
                Resources.MyTankUp,
                Resources.MyTankRight,
                Resources.MyTankDown,
                Resources.MyTankLeft
        };

        public static Bitmap[] EnemyTankGrayTexture = new Bitmap[] {
                Resources.GrayUp,
                Resources.GrayRight,
                Resources.GrayDown,
                Resources.GrayLeft
        };

        public static Bitmap[] EnemyTankGreenTexture = new Bitmap[] {
                Resources.GreenUp,
                Resources.GreenRight,
                Resources.GreenDown,
                Resources.GreenLeft
        };

        public static Bitmap[] EnemyTankQuickTexture = new Bitmap[] {
                Resources.QuickUp,
                Resources.QuickRight,
                Resources.QuickDown,
                Resources.QuickLeft
        };

        public static Bitmap[] EnemyTankSlowTexture = new Bitmap[] {
                Resources.SlowUp,
                Resources.SlowRight,
                Resources.SlowDown,
                Resources.SlowLeft
        };

        public static Bitmap[][] EnemyTanksTexture = {
            EnemyTankGrayTexture,
            EnemyTankGreenTexture,
            EnemyTankQuickTexture,
            EnemyTankSlowTexture
        };

        public Tank(int x, int y, int speed, Bitmap[] bitmapTexture) {
            this.X = x;
            this.Y = y;
            this.Speed = speed;
            this.BitmapTexture = bitmapTexture;
            this.Dir = Direction.Up;
        }

        public override void Update() {
            base.Update();
            MoveCheck();
            Move();
        }

        public abstract void HandleMoveCheck();

        public void Move() {
            if (!isMoving) return;
            switch (Dir) {
                case Direction.Up:
                    Y -= Speed;
                    break;
                case Direction.Down:
                    Y += Speed;
                    break;
                case Direction.Left:
                    X -= Speed;
                    break;
                case Direction.Right:
                    X += Speed;
                    break;
            }
        }
        public void MoveCheck() {
            if (!isMoving) return;
            #region 边界检测
            if (Dir == Direction.Up) {
                if (Y - Speed < 0) {
                    HandleMoveCheck();
                    return;
                }
            } else if (Dir == Direction.Down) {
                if (Y + Speed + Height > 390) {
                    HandleMoveCheck();
                    return;
                }
            } else if (Dir == Direction.Left) {
                if (X - Speed < 0) {
                    HandleMoveCheck();
                    return;
                }
            } else if (Dir == Direction.Right) {
                if (X + Speed + Width > 390) {
                    HandleMoveCheck();
                    return;
                }
            }
            #endregion

            #region 地图对象碰撞检测
            var r = GetRectangle();
            if (Dir == Direction.Up) {
                r.Y -= Speed;
            } else if (Dir == Direction.Down) {
                r.Y += Speed;
            } else if (Dir == Direction.Left) {
                r.X -= Speed;
            } else if (Dir == Direction.Right) {
                r.X += Speed;
            }
            if (GameObjectManager.IsCollidedMapObj(r) != null) {
                HandleMoveCheck();
                return;
            }
            #endregion
        }

    }
}
