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

        public int Width { get; set; }
        public int Height { get; set; }

        protected abstract Image GetDrawImage();

        private void DrawSelf() {
            GameFramework.G.DrawImage(GetDrawImage(), X, Y);
        }

        public virtual void Update() {
            DrawSelf();
        }

        public Rectangle GetRectangle() {
            return new Rectangle(X, Y, Width, Height);
        }

    }
}
