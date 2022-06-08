using BattleCity.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleCity {
    enum BulletTag {
        MyTank,
        EnemyTank
    }
    class Bullet : Movething {
        public BulletTag Tag { get; set; }
        public Bullet(int x, int y, int speed, Direction dir, BulletTag tag) {
            this.isMoving = true;
            this.X = x;
            this.Y = y;
            this.Speed = speed;
            this.BitmapTexture = new Bitmap[] {
                Resources.BulletUp,
                Resources.BulletRight,
                Resources.BulletDown,
                Resources.BulletLeft
            };
            this.Dir = dir;
            this.Tag = tag;

            this.X = this.X - Width / 2;
            this.Y = this.Y - Height / 2;
        }

        public override void MoveCheck() {
            if (!isMoving) return;
            #region 边界检测
            if (Dir == Direction.Up) {
                if (Y + Height < 0) {
                    HandleMoveCheck();
                    return;
                }
            } else if (Dir == Direction.Down) {
                if (Y > 390) {
                    HandleMoveCheck();
                    return;
                }
            } else if (Dir == Direction.Left) {
                if (X + Width < 0) {
                    HandleMoveCheck();
                    return;
                }
            } else if (Dir == Direction.Right) {
                if (X > 390) {
                    HandleMoveCheck();
                    return;
                }
            }
            #endregion

            var r = GetRectangle();
            r.X = r.X + Width / 2 - 3;
            r.Y = r.Y + Height / 2 - 3;
            r.Width = 3;
            r.Height = 3;

            var expX = X + Width / 2;
            var expY = Y + Height / 2;
            #region 地图对象碰撞检测
            var wall = GameObjectManager.IsCollidedMapObj(r);
            if (wall != null) {
                HandleMoveCheck();
                GameObjectManager.DestroyMapObj(wall);
                GameObjectManager.CreateExplosion(expX, expY);
                SoundManenger.PlayBlast();
                return;
            }
            #endregion

            #region 坦克对象碰撞检测
            if (Tag == BulletTag.MyTank) {
                var tank = GameObjectManager.IsCollidedTanks(r);
                if (tank != null) {
                    HandleMoveCheck();
                    GameObjectManager.DestroyTank(tank);
                    GameObjectManager.CreateExplosion(expX, expY);
                    SoundManenger.PlayBlast();
                    return;
                }
            }else if(Tag == BulletTag.EnemyTank) {
                var tank = GameObjectManager.IsCollidedMyTank(r);
                if (tank != null) {
                    HandleMoveCheck();
                    GameObjectManager.CreateExplosion(expX, expY);
                    tank.TakeDamage();
                    SoundManenger.PlayBlast();
                    return;
                }
            }
            
            #endregion
        }

        private void HandleMoveCheck() {
            GameObjectManager.DestroyBullet(this);
        }

    }
}
