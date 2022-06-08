﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using BattleCity.Properties;

namespace BattleCity {

    class SoundManenger {

        private static SoundPlayer startPlayer = new SoundPlayer();
        private static SoundPlayer addPlayer = new SoundPlayer();
        private static SoundPlayer blastPlayer = new SoundPlayer();
        private static SoundPlayer firePlayer = new SoundPlayer();
        private static SoundPlayer hitPlayer = new SoundPlayer();

        public static void Init() {
            startPlayer.Stream = Resources.start;
            addPlayer.Stream = Resources.add;
            blastPlayer.Stream = Resources.blast;
            firePlayer.Stream = Resources.fire;
            hitPlayer.Stream = Resources.hit;
        }

        public static void PlayStart() {
            startPlayer.Play();
        }
        public static void PlayAdd() {
            addPlayer.Play();
        }
        public static void PlayBlast() {
            blastPlayer.Play();
        }
        public static void PlayFire() {
            firePlayer.Play();
        }
        public static void PlayHit() {
            hitPlayer.Play();
        }
    }
}
