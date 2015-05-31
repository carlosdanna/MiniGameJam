using UnityEngine;
using System.Collections;

public class CANYOUSMELL : MonoBehaviour
{
    float timeLimit, heightLimit, currHeight, waitTime;
    bool ascending;

    // Use this for initialization
    void Start()
    {
        ascending = true;
        timeLimit = 10.0f;
        heightLimit = 100.0f;
        currHeight = 0;
        waitTime = 3.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timeLimit -= Time.deltaTime;

        if (timeLimit <= 0 && ascending)
        {
            transform.position += new Vector3(0, 10 * Time.deltaTime, 0);
            currHeight += (10 * Time.deltaTime);
            if (currHeight >= heightLimit)
                ascending = false;
        }
        else if (!ascending)
        {
            waitTime -= Time.deltaTime;

            if (waitTime <= 0)
            {
                transform.position -= new Vector3(0, 10 * Time.deltaTime, 0);
                currHeight -= (10 * Time.deltaTime);
                if (currHeight <= 0)
                {
                    timeLimit = 10.0f;
                    ascending = true;
                    waitTime = 3.0f;
                }
            }
        }
    }
}
