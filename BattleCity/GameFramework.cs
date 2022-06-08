using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BattleCity.Properties;

namespace BattleCity {

    enum GameState {
        Running,
        GameOver,
    }
    class GameFramework {
        private static GameState state;
        public static Graphics G { get; set; }
        public static void Start() {
            state = GameState.Running;
            GameObjectManager.Start();
        }
        public static void Update() {
            G.Clear(Color.Black);
            if (state == GameState.Running) GameObjectManager.Update();
            else if (state == GameState.GameOver) GameOverUpdate();
        }

        private static void GameOverUpdate() {
            int x = 390 / 2 - Resources.GameOver.Width / 2;
            int y = 390 / 2 - Resources.GameOver.Height / 2;
            G.DrawImage(Resources.GameOver, x, y);
        }

        public static void ChangeToGameOver() {
            state = GameState.GameOver;
        }

        internal static void KeyDown(KeyEventArgs e) {
            GameObjectManager.KeyDown(e);
        }

        internal static void KeyUp(KeyEventArgs e) {
            GameObjectManager.KeyUp(e);
        }
    }
}
