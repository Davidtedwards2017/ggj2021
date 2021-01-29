using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//[RequireComponent(typeof(tk2dBaseSprite))]
public class RandomSpriteFlip : MonoBehaviour {

    public bool CanHorizontalFlip;
    //private tk2dBaseSprite _Sprite;

	void Start ()
    {
        throw new NotImplementedException();
        //_Sprite = GetComponent<tk2dBaseSprite>();

        if (CanHorizontalFlip)
        {
            //_Sprite.FlipX = Random.Range(0, 2) == 0 ? true : false;
        }
	}
	
}
