using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleCity {
    abstract class GameObject {
        public int X { get; set; }
        public int Y { get; set; }

        protected abstract Image GetDrawImage();

        public void DrawSelf() {
            GameFramework.G.DrawImage(GetDrawImage(), X, Y);
        }

    }
}
