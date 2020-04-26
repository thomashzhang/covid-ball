using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockBreakEffect;
    [SerializeField] public Sprite[] hitSprites;
    [SerializeField] int pointsWhenDestroyed = 3;
    public int timesHit = 0;
    Level level;
    GameStatus status;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.tag == "Breakable")
        {
            timesHit += 1;
            var maxHits = hitSprites.Length + 1;
            if (timesHit >= maxHits)
            {
                Destroy(gameObject);
                TriggerBreakEffect();
                level.BlockDestroyed();
                status.AddStatsWhenBlockDestoryed(pointsWhenDestroyed);
                AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
            }
            else
            {
                ShowNextHitSprite();
            }
        }
    }

    protected virtual void AddPoints()
    {
        status.AddStatsWhenBlockDestoryed(pointsWhenDestroyed);
    }

    public virtual void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
    }

    private void Start()
    {
        level = FindObjectOfType<Level>();
        if (gameObject.tag == "Breakable")
        {
            level.CountBreakableBlocks();
        }
        status = FindObjectOfType<GameStatus>();
    }

    private void TriggerBreakEffect()
    {
        var sparkles = Instantiate(blockBreakEffect, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
}
