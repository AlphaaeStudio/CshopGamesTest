using System;
using System.Collections.Generic;

namespace _2DMapBuilder {
    class Program {

        const int x = 35;
        const int y = 20;

        private MapType[,] gameMap = new MapType[y, x];
        private enum MapType {
            WALL, FLOOR
        }

        private Dictionary<MapType, String> mapShowDict = new Dictionary<MapType, String>() {
            {MapType.WALL, "■"}, {MapType.FLOOR, "□"}
        };

        public Program() {
            InitMap();
            ShowMap(this.gameMap);

            for (int c = 0; c < 4; c++) {
                MapType[,] tempMap = Rule45();
                this.gameMap = tempMap;
                ShowMap(this.gameMap);
            }

        }
        private void InitMap() {
            Random rd = new Random();
            for (int i = 0; i < gameMap.GetLength(0); i++) {
                for (int j = 0; j < gameMap.GetLength(1); j++) {
                    if (i == 0 || j == 0 || i == gameMap.GetLength(0) - 1 || j == gameMap.GetLength(1) - 1) continue;
                    gameMap[i, j] = rd.NextDouble() <= 0.45 ? MapType.WALL : MapType.FLOOR;
                }
            }
        }

        private MapType[,] Rule45() {
            MapType[,] tempMap = new MapType[y, x];
            for (int i = 0; i < gameMap.GetLength(0); i++) {
                for (int j = 0; j < gameMap.GetLength(1); j++) {
                    if (i == 0 || j == 0 || i == gameMap.GetLength(0) - 1 || j == gameMap.GetLength(1) - 1) continue;
                    int count = CheckNeighborWalls(i, j);
                    if (gameMap[i, j] == MapType.WALL) {
                        tempMap[i, j] = (count >= 4) ? MapType.WALL : MapType.FLOOR;
                    } else {
                        tempMap[i, j] = (count >= 5) ? MapType.WALL : MapType.FLOOR;
                    }
                }
            }
            return tempMap;
        }

        private int CheckNeighborWalls(int x, int y) {
            int count = 0;
            int[,] neighborPos = { { -1, -1 }, { -1, 0 }, { -1, 1 }, { 0, -1 }, { 0, 1 }, { 1, 1 }, { 1, 0 }, { 1, -1 } };
            for (int i = 0; i < neighborPos.GetLength(0); i++) {
                try {
                    if (gameMap[x + neighborPos[i, 0], y + neighborPos[i, 1]] == MapType.WALL) count++;
                } catch {
                }
            }
            return count;
        }

        private void ShowMap(MapType[,] gameMap) {
            for (int i = 0; i < gameMap.GetLength(0); i++) {
                for (int j = 0; j < gameMap.GetLength(1); j++) {
                    Console.Write(mapShowDict[gameMap[i, j]]);
                }
                Console.WriteLine("");
            }
            Console.WriteLine("-----------------------------------");
        }

        static void Main(string[] args) {
            var mapBuilder = new Program();
        }
    }
}
