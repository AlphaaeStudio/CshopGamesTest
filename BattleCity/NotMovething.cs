using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleCity {
    class NotMovething : GameObject {
        public NotMovething(Image img, int x, int y) {
            Img = img;
            X = x;
            Y = y;
        }

        public Image Img { get; set; }
        protected override Image GetDrawImage() {
            return Img;
        }
    }
}
