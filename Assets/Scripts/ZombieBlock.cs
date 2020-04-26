using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBlock : Block
{
    public override void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
            GetComponent<SpriteRenderer>().color = new Color(151/255f, 241/255f, 146/255f);
        }
    }
}
