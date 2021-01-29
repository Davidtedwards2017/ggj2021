using UnityEngine;
using System.Collections;
using System.Linq;
using Utilites;

namespace Spooky.Utilities.Effects
{

    public static class EffectExtensions
    {
        public static void Play(this SlowDownEffectData data)
        {
            if (data == null) return;
            EffectsController.Instance.PlaySlowDownEffect(data);
        }

        public static GameObject Spawn(this EffectData effect, Vector3 position, Transform parent = null)
        {
            if (effect == null) return null;

            return effect.SpawnEffect(position, parent);
        }


        public static GameObject SpawnEffect(this EffectData effect, Vector3 position, Transform parent = null)
        {
            return SpawnEffectInstance(effect, position, parent);
        }

        private static GameObject SpawnEffectInstance(this EffectData effect, Vector3 position, Transform parent = null)
        {
            if (effect == null || effect.Prefab == null) return null;

            var instance = GameObject.Instantiate<GameObject>(effect.Prefab, position + effect.Offset, Quaternion.identity);
            if (parent != null)
            {
                instance.AttachTo(parent.gameObject);
            }

            if (effect.OverrideColor)
            {
                instance.SetColor(effect.Color);
            }

            if (effect.Duration > 0)
            {
                instance.Fizzle(effect.Duration, effect.FizzleDuration);
            }

            return instance;
        }

        //public static void SpawnDelayedEffect(this  EffectData effect, Vector3 position, float delay)
        //{
        //    StartCoroutine(SpawnDelayedEffectAsync(effect, position, delay));
        //}

        public static IEnumerator SpawnDelayedEffectAsync(this EffectData effect, Vector3 position, float delay)
        {
            yield return new WaitForSeconds(delay);
            SpawnEffectInstance(effect, position);
        }
    }
}