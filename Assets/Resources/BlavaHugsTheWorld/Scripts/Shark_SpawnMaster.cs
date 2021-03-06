﻿using UnityEngine;
using System.Collections;

public class Shark_SpawnMaster : MonoBehaviour
{
    public GameObject theRock;   //Can you smell what the Rock is cooking?!
    public GameObject theVillage;   // Burn it all down!
    public int numRocks;
    int currLayer;

    GameObject[] theNodes;

    public Vector2 theCenter;

    public float upBound, downBound, leftBound, rightBound;

    // Use this for initialization
    public void Initialize()
    {
        theNodes = GameObject.FindGameObjectsWithTag("Node");

        theCenter = new Vector2(transform.position.x, transform.position.y);

        RaycastHit2D hitUp = Physics2D.Raycast(theCenter, new Vector2(0, 1));
        RaycastHit2D hitDown = Physics2D.Raycast(theCenter, new Vector2(0, -1));

        upBound = hitUp.point.y;
        downBound = hitDown.point.y;

        for (int i = 0; i < numRocks; i++)
        {
            SpawnRock();
        }

        SpawnVillage();
    }


    // Spawns random rock obstacles
    public void SpawnRock()
    {
        //float offsetX, offsetY;

        //offsetX = theRock.GetComponent<CircleCollider2D>().radius;
        //offsetY = theRock.GetComponent<CircleCollider2D>().radius;

        //float spawnY, spawnX;       // place to spawn

        //spawnY = Random.Range(downBound + offsetY, upBound - offsetY);  // randomly decide vertical spawn point

        //Vector2 start = new Vector2(theCenter.x, spawnY);  // place to start raycasting in order to get left and right bounds

        //RaycastHit2D hitLeft = Physics2D.Raycast(start, new Vector2(-1, 0));   // determines left bound
        //RaycastHit2D hitRight = Physics2D.Raycast(start, new Vector2(1, 0));   // determines right bound

        //leftBound = hitLeft.point.x;
        //rightBound = hitRight.point.x;

        //spawnX = Random.Range(leftBound + offsetX, rightBound - offsetX);   // randomly decide horizontal spawn point

        bool done = false;

        while (!done)
        {
            int index = Random.Range(0, theNodes.Length);

            if (!theNodes[index].GetComponent<Shark_Node>().occupied)
            {
                theNodes[index].GetComponent<Shark_Node>().occupied = true;
                Instantiate(theRock, theNodes[index].transform.position, Quaternion.identity);   // spawn rock
                done = true;
            }
        }
    }

    public void SpawnVillage()
    {
        float offsetY, offsetX, spawnY, spawnX;

        offsetY = theVillage.GetComponent<BoxCollider2D>().size.y;
        offsetX = theVillage.GetComponent<BoxCollider2D>().size.x;

        spawnY = downBound + offsetY;

        Vector2 start = new Vector2(theCenter.x, spawnY);  // place to start raycasting in order to get left and right bounds

        RaycastHit2D hitLeft = Physics2D.Raycast(start, new Vector2(-1, 0));   // determines left bound
        RaycastHit2D hitRight = Physics2D.Raycast(start, new Vector2(1, 0));   // determines right bound

        leftBound = hitLeft.point.x;
        rightBound = hitRight.point.x;

        spawnX = Random.Range(leftBound + offsetX, rightBound - offsetX);

        Instantiate(theVillage, new Vector3(spawnX, spawnY, 0), Quaternion.identity);
    }
}
