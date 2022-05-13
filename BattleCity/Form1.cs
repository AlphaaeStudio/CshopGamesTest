using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleCity {
    public partial class Form1 : Form {
        private Thread gameMainThread;
        private static Graphics g;
        private static Bitmap tempBmp;
        private static Graphics tmpG;

        public Form1() {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            g = CreateGraphics();
            tempBmp = new Bitmap(390, 390);
            tmpG = Graphics.FromImage(tempBmp);
            GameFramework.G = tmpG;

            gameMainThread = new Thread(new ThreadStart(GameMainMethod));
            gameMainThread.Start();
        }

        private void Form1_Paint(object sender, PaintEventArgs e) {
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
            gameMainThread.Abort();
        }

        private static void GameMainMethod() {

            GameFramework.Start();

            // 60 tick
            int sleepTime = 1000 / 60;

            while (true) {
                GameFramework.Update();
                g.DrawImage(tempBmp, 0, 0);
                Thread.Sleep(sleepTime);
            }
        }
    }
}
