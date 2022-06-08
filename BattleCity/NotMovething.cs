using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleCity {

    enum NotMovethingTag {
        Boss,
        Wall,
        Steel
    }
    class NotMovething : GameObject {

        public NotMovethingTag Tag { get; set; }
        public NotMovething(Image img, int x, int y, NotMovethingTag tag) {
            Img = img;
            X = x;
            Y = y;
            Tag = tag;
        }
        private Image img;
        public Image Img { get { return img; } 
            set { 
                img = value;
                Width = img.Width;
                Height = img.Height;
            } 
        }
        protected override Image GetDrawImage() {
            return Img;
        }
    }
}
