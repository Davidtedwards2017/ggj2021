using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spooky.Effects
{
    public class FlickerEffect : MonoBehaviour
    {
        SpriteRenderer spriteRenderer;
        Color baseColor;
        Color FlickerColor = new Color(1,1,1,0);
        public float Duration = 1.0f;
        public int NumberOfBlinks = 5;

        // Start is called before the first frame update
        void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            baseColor = spriteRenderer.color;
            StartCoroutine(EffectSequence());
        }

        IEnumerator EffectSequence()
        {
            var timeBetweenBlinks = Duration / (NumberOfBlinks * 2);
            while (NumberOfBlinks-- > 0)
            {
                spriteRenderer.color = FlickerColor;
                yield return new WaitForSeconds(timeBetweenBlinks);
                spriteRenderer.color = baseColor;
            }

            Destroy(this);
        }
    }
}