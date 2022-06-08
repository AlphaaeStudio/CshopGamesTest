using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleCity.Properties;

namespace BattleCity {
    class Explosion : GameObject {

        public Bitmap[] BitmapTexture { get; set; }

        private int playSpeed = 1;
        private int playCount = 0;
        private int index = 0;

        public Explosion(int x, int y) {
            this.X = x;
            this.Y = y;
            BitmapTexture = new Bitmap[] {
                Resources.EXP1,
                Resources.EXP2,
                Resources.EXP3,
                Resources.EXP4,
                Resources.EXP5,
            };
            Width = BitmapTexture[0].Width;
            Height = BitmapTexture[0].Height;
            foreach (Bitmap bitmap in BitmapTexture) {
                bitmap.MakeTransparent(Color.Black);
            }
            X -= Width / 2;
            Y -= Height / 2;
        }
        protected override Image GetDrawImage() {
            return BitmapTexture[index];
        }

        public override void Update() {
            base.Update();
            playCount++;
            index = playCount / playSpeed;
            if (index > 4) {
                index = 4;
                GameObjectManager.DestroyExplosion(this);
            }
        }
    }
}
