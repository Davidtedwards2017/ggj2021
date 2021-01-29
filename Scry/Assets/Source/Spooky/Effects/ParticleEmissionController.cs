using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spooky.Utilities.Effects
{

    public class ParticleEmissionController : MonoBehaviour
    {
        public float TargetEmission;
        private ParticleSystem m_ParticleSystemEffect;

        public float Emission
        {
            get
            {
                return m_ParticleSystemEffect.GetEmissionRate();
            }
            set
            {
                TargetEmission = value;
                //SetEmission(value);
            }
        }

        void Update()
        {
            if(Emission != TargetEmission)
            {
                SetToTargetEmission();
            }
        }

        void Awake()
        {
            m_ParticleSystemEffect = GetComponent<ParticleSystem>();
        }

        public void StopEmission()
        {
            SetEmission(0);
        }

        public void StopEmission(float duration)
        {
            DOTween.To(() => Emission, x => Emission = x, 0, duration);
        }

        public void SetToTargetEmission()
        {
            SetEmission(TargetEmission);
        }

        private void SetEmission(float value)
        {
            m_ParticleSystemEffect.SetEmissionRate(value);
        }
    }

    public static class ParticleEmissionControllerExtensions
    {
        public static void SetToTargetEmission(this GameObject go)
        {
            var emissionCtrls = go.GetComponentsInChildren<ParticleEmissionController>();
            foreach (var entry in emissionCtrls)
            {
                entry.SetToTargetEmission();
            }
        }

        public static void StopEmission(this GameObject go)
        {
            var emissionCtrls = go.GetComponentsInChildren<ParticleEmissionController>();
            foreach (var entry in emissionCtrls)
            {
                entry.StopEmission();
            }
        }


        public static void StopEmission(this GameObject go, float duration)
        {
            var emissionCtrls = go.GetComponentsInChildren<ParticleEmissionController>();
            foreach (var entry in emissionCtrls)
            {
                entry.StopEmission(duration);
            }
        }
    }
}