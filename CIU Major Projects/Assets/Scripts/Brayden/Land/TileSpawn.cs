using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class TileSpawn : MonoBehaviour
{
    public GameObject myTilePiece, myParentObject;
    SpriteRenderer myRenderer;
    public Sprite[] mySprites;
    public Color[] myColors;
    public float xPos, yPos;
    public int maxHeight, maxLength;

    private void Start()
    {
        SpawnTiles();
    }

    //Handles how the tiles are spawned, how many etc.
    void SpawnTiles()
    {
        for (int j = 0; j < maxHeight; j++)
        {
            for (int i = 0; i < maxLength; i++)
            {
                Instantiate(myTilePiece, myParentObject.transform.position + new Vector3(i * xPos, j * yPos, 0), Quaternion.identity);
                UpdateTiles();
            }
        }
    }

    void UpdateTiles()
    {
        //Get all the sprite renderers.
        for (int j = 0; j < 10; j++)
        {
            myRenderer = myTilePiece.GetComponent<SpriteRenderer>();
            
            int a = Random.Range(0, 6);
            if (a == 6)
            {
                myRenderer.color = myColors[6];
                myRenderer.sprite = mySprites[6];
            }
            if (a == 5)
            {
                myRenderer.color = myColors[5];
                myRenderer.sprite = mySprites[5];
            }
            if (a == 4)
            {
                myRenderer.color = myColors[4];
                myRenderer.sprite = mySprites[4];
            }
            if (a == 3)
            {
                myRenderer.color = myColors[3];
                myRenderer.sprite = mySprites[3];
            }
            if (a == 2)
            {
                myRenderer.color = myColors[2];
                myRenderer.sprite = mySprites[2];
            }
            if (a == 1)
            {
                myRenderer.color = myColors[1];
                myRenderer.sprite = mySprites[1];
            }
            if (a == 0)
            {
                myRenderer.color = myColors[0];
                myRenderer.sprite = mySprites[0];
            }
        }
    }
}
