using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilites;

namespace Spooky.Utilities.Effects
{
    public class ParticleSystemTriggerRandomSoundEffect : ParticleSystemTriggerSoundEffect
    {
        public List<SoundEffectData> Sounds;

        private FilteredRandom<SoundEffectData> _RandSfx;

        protected override void Awake()
        {
            base.Awake();
            _RandSfx = new FilteredRandom<SoundEffectData>(Sounds, 3);
        }

        public override SoundEffectData GetSoundEffectData
        {
            get
            {
                return _RandSfx.GetNextRandom();
            }
        }
    }
}