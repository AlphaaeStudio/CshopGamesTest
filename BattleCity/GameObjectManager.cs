using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BattleCity.Properties;

namespace BattleCity {
    class GameObjectManager {

        private static Random rd = new Random();

        private static List<NotMovething> mapObjects = new List<NotMovething>();
        private static List<EnemyTank> enemyTanks = new List<EnemyTank>();
        private static MyTank myTank;

        private static List<Bullet> readyBullets = new List<Bullet>();
        private static List<Bullet> destroyBullets = new List<Bullet>();
        private static List<Bullet> bullets = new List<Bullet>();

        private static List<Explosion> destroyExplosion = new List<Explosion>();
        private static List<Explosion> explosions = new List<Explosion>();

        private static int enemyBornSpeed = 90;
        private static int enemyBornCount = -80;
        private static Point[] enemyBornPoints = {
            new Point(0, 0),
            new Point(12 * 15, 0),
            new Point(24 * 15, 0)
        };

        internal static void KeyDown(KeyEventArgs e) {
            myTank.KeyDown(e);
        }
        internal static void KeyUp(KeyEventArgs e) {
            myTank.KeyUp(e);
        }
        internal static void Start() {
            CreateMap();
            CreateMyTank();
            SoundManenger.Init();
            SoundManenger.PlayStart();
        }

        internal static void Update() {
            // Draw
            foreach (NotMovething mapObj in mapObjects) mapObj.Update();
            foreach (EnemyTank eTank in enemyTanks) eTank.Update();
            foreach (Bullet bullet in bullets) bullet.Update();
            foreach (Explosion exp in explosions) exp.Update();
            myTank.Update();
            // Born
            EnemyBorn();
            foreach (Bullet bullet in readyBullets) bullets.Add(bullet);
            readyBullets.Clear();
            foreach (Bullet bullet in destroyBullets) bullets.Remove(bullet);
            destroyBullets.Clear();
            foreach (Explosion exp in destroyExplosion) explosions.Remove(exp);
            destroyExplosion.Clear();
        }

        private static void EnemyBorn() {
            enemyBornCount++;
            if (enemyBornCount < enemyBornSpeed) return;
            enemyBornCount = 0;

            SoundManenger.PlayAdd();
            Point p = enemyBornPoints[rd.Next(0, enemyBornPoints.Length)];
            Bitmap[] eTankTexture = Tank.EnemyTanksTexture[rd.Next(0, Tank.EnemyTanksTexture.Length)];
            EnemyTank eTank = new EnemyTank(p.X, p.Y, 2, eTankTexture);
            enemyTanks.Add(eTank);
        }

        public static NotMovething IsCollidedMapObj(Rectangle r) {
            foreach (NotMovething obj in mapObjects) {
                if (obj.GetRectangle().IntersectsWith(r)) return obj;
            }
            return null;
        }
        public static EnemyTank IsCollidedTanks(Rectangle r) {
            foreach (EnemyTank obj in enemyTanks) {
                if (obj.GetRectangle().IntersectsWith(r)) return obj;
            }
            return null;
        }
        public static MyTank IsCollidedMyTank(Rectangle r) {
            if (myTank.GetRectangle().IntersectsWith(r)) return myTank;
            return null;
        }

        public static void CreateBullet(int x, int y, int speed, Direction dir, BulletTag tag) {
            Bullet bullet = new Bullet(x, y, speed, dir, tag);
            readyBullets.Add(bullet);
        }

        public static void DestroyBullet(Bullet bullet) {
            destroyBullets.Add(bullet);
        }

        public static void CreateExplosion(int x, int y) {
            Explosion exp = new Explosion(x, y);
            explosions.Add(exp);
        }

        public static void DestroyExplosion(Explosion exp) {
            destroyExplosion.Add(exp);
        }

        public static void DestroyMapObj(NotMovething obj) {
            if (obj.Tag == NotMovethingTag.Wall) mapObjects.Remove(obj);
            else if (obj.Tag == NotMovethingTag.Steel) return;
            else if (obj.Tag == NotMovethingTag.Boss) GameFramework.ChangeToGameOver();
        }
        public static void DestroyTank(EnemyTank tank) {
            enemyTanks.Remove(tank);
        }

        public static void CreateMap() {
            CreateWall(2, 2, 2, 8);
            CreateWall(6, 2, 2, 8);
            CreateWall(10, 2, 2, 6);
            CreateWall(14, 2, 2, 6);
            CreateWall(18, 2, 2, 8);
            CreateWall(22, 2, 2, 8);

            CreateWall(10, 10, 2, 2);
            CreateWall(14, 10, 2, 2);

            CreateWall(4, 12, 4, 2);
            CreateWall(18, 12, 4, 2);

            CreateWall(2, 16, 2, 8);
            CreateWall(6, 16, 2, 8);
            CreateWall(10, 14, 2, 7);
            CreateWall(12, 15, 2, 2);
            CreateWall(14, 14, 2, 7);
            CreateWall(18, 16, 2, 8);
            CreateWall(22, 16, 2, 8);

            CreateWall(11, 23, 1, 3);
            CreateWall(12, 23, 2, 1);
            CreateWall(14, 23, 1, 3);

            CreateSteel(0, 13, 2, 1);
            CreateSteel(12, 5, 2, 2);
            CreateSteel(24, 13, 2, 1);

            CreateBoss(12, 24);
        }

        private static void CreateWall(int x, int y, int xCount, int yCount) {
            CreateWalls(x, y, xCount, yCount, Resources.wall, NotMovethingTag.Wall);
        }
        private static void CreateSteel(int x, int y, int xCount, int yCount) {
            CreateWalls(x, y, xCount, yCount, Resources.steel, NotMovethingTag.Steel);
        }
        private static void CreateBoss(int x, int y) {
            mapObjects.Add(new NotMovething(Resources.Boss, x * 15, y * 15, NotMovethingTag.Boss));
        }
        private static void CreateWalls(int x, int y, int xCount, int yCount, Bitmap bmp, NotMovethingTag tag) {
            int xPos = x * 15;
            int yPos = y * 15;
            for (int nowX = xPos; nowX < xPos + 15 * xCount; nowX += 15) {
                for (int nowY = yPos; nowY < yPos + 15 * yCount; nowY += 15) {
                    mapObjects.Add(new NotMovething(bmp, nowX, nowY, tag));
                }
            }
        }

        public static void CreateMyTank() {
            myTank = new MyTank(9 * 15, 24 * 15, 2);
        }

    }
}
