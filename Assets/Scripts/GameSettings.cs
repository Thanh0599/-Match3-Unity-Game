using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : ScriptableObject
{
    public int BoardSizeX = 5;

    public int BoardSizeY = 5;

    public int MatchesMin = 3;

    public int LevelMoves = 16;

    public float LevelTime = 30f;

    public float TimeForHint = 5f;

    public List<GameObject> ListPrefab;
    public bool UseNormalSprite;
    public List<Sprite> NormalSprite;
    public List<Sprite> FishSprite;

    private void OnValidate()
    {
        if (UseNormalSprite)
        {
            if (ListPrefab.Count != NormalSprite.Count)
            {
                Debug.LogError("Missing prefab or normal sprite");
            }
            else
            {
                SetSprite(ListPrefab, NormalSprite);
            }
        }    
        else
        {
            if (ListPrefab.Count != FishSprite.Count)
            {
                Debug.LogError("Missing prefab or fish sprite");
            }
            else
            {
                SetSprite(ListPrefab, FishSprite);
            }
        }
    }

    void SetSprite(List<GameObject> listPrefab, List<Sprite> listSprite)
    {
        for(int i = 0; i < listPrefab.Count; i++)
        {
            SpriteRenderer spriteRenderer = listPrefab[i].transform.GetComponent<SpriteRenderer>();
            if(spriteRenderer != null)
            {
                spriteRenderer.sprite = listSprite[i];
            }
        }
    }
}
