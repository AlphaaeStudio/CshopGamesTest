using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleCity {
    class GameFramework {
        public static Graphics G { get; set; }
        public static void Start() {
            GameObjectManager.CreateMap();
        }
        public static void Update() {
            G.Clear(Color.Black);
            GameObjectManager.DrawMap();
        }
    }
}
