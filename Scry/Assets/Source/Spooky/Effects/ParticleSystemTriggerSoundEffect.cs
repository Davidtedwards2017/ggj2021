using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilites;

namespace Spooky.Utilities.Effects
{
    [RequireComponent(typeof(ParticleSystem))]
    public abstract class ParticleSystemTriggerSoundEffect : MonoBehaviour
    {
        protected ParticleSystem _ParticleSystem;
        public bool TriggerOnBirth = true;

        protected int _ParticleCount = 0;

        public abstract SoundEffectData GetSoundEffectData { get; }

        protected virtual void Awake()
        {
            _ParticleSystem = GetComponent<ParticleSystem>();
        }

        void Update()
        {
            var count = _ParticleSystem.particleCount;
            if (TriggerOnBirth && count > _ParticleCount)
            {
                PlaySound();
            }

            _ParticleCount = count;
        }

        protected void PlaySound()
        {
            GetSoundEffectData.PlaySfx();
        }

    }
}
