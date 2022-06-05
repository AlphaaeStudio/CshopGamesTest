using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleCity {
    class GameFramework {
        public static Graphics G { get; set; }
        public static void Start() {
            GameObjectManager.Start();
        }
        public static void Update() {
            G.Clear(Color.Black);
            GameObjectManager.Update();
        }

        internal static void KeyDown(KeyEventArgs e) {
            GameObjectManager.KeyDown(e);
        }

        internal static void KeyUp(KeyEventArgs e) {
            GameObjectManager.KeyUp(e);
        }
    }
}
