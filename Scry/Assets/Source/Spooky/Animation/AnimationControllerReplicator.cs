using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spooky.Utilities.Animation
{
    public class AnimationControllerReplicator : MonoBehaviour
    {
        public Animator[] animators;

        public void SetTrigger(string name)
        {
            foreach(var animator in animators)
            {
                animator.SetTrigger(name);
            }
        }

        public void SetBool(string name, bool value)
        {
            foreach (var animator in animators)
            {
                animator.SetBool(name, value);
            }
        }

        public void SetFloat(string name, float value)
        {
            foreach (var animator in animators)
            {
                animator.SetFloat(name, value);
            }
        }
    }
}