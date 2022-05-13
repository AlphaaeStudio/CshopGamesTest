using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleCity.Properties;

namespace BattleCity {
    class GameObjectManager {

        private static List<NotMovething> mapObjects = new List<NotMovething>();

        public static void DrawMap() {
            foreach (NotMovething mapObj in mapObjects) {
                mapObj.DrawSelf();
            }
        }

        public static void CreateMap() {
            DrawWall(2, 2, 2, 8);
            DrawWall(6, 2, 2, 8);
            DrawWall(10, 2, 2, 6);
            DrawWall(14, 2, 2, 6);
            DrawWall(18, 2, 2, 8);
            DrawWall(22, 2, 2, 8);

            DrawWall(10, 10, 2, 2);
            DrawWall(14, 10, 2, 2);

            DrawWall(4, 12, 4, 2);
            DrawWall(18, 12, 4, 2);

            DrawWall(2, 16, 2, 8);
            DrawWall(6, 16, 2, 8);
            DrawWall(10, 14, 2, 7);
            DrawWall(12, 15, 2, 2);
            DrawWall(14, 14, 2, 7);
            DrawWall(18, 16, 2, 8);
            DrawWall(22, 16, 2, 8);

            DrawWall(11, 23, 1, 3);
            DrawWall(12, 23, 2, 1);
            DrawWall(14, 23, 1, 3);

            DrawSteel(0, 13, 2, 1);
            DrawSteel(12, 5, 2, 2);
            DrawSteel(24, 13, 2, 1);

            Drawboss(12, 24);
        }
        public static void DrawWall(int x, int y, int xCount, int yCount) {
            DrawWalls(x, y, xCount, yCount, Resources.wall);
        }
        public static void DrawSteel(int x, int y, int xCount, int yCount) {
            DrawWalls(x, y, xCount, yCount, Resources.steel);
        }
        public static void Drawboss(int x, int y) {
            mapObjects.Add(new NotMovething(Resources.Boss, x * 15, y * 15));
        }
        public static void DrawWalls(int x, int y, int xCount, int yCount, Bitmap bmp) {
            int xPos = x * 15;
            int yPos = y * 15;
            for (int nowX = xPos; nowX < xPos + 15 * xCount; nowX += 15) {
                for (int nowY = yPos; nowY < yPos + 15 * yCount; nowY += 15) {
                    mapObjects.Add(new NotMovething(bmp, nowX, nowY));
                }
            }
        }
    }
}
