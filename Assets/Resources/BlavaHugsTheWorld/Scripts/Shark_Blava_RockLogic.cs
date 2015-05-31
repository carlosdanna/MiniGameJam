using UnityEngine;
using System.Collections;

public class Shark_Blava_RockLogic : MonoBehaviour {

    int state = 0;
    // states
    // 0 - Wander
    // 1 - Panic, jump in place!
    // 2 - Panic, run back and forth!
    // 3 - Panic, scatter!
    public VillageScript village;
    public float wanderSpeed = 33;
    public float panicSpeed = 100;
    public float jumpSpeed = 80;
    public Vector2 direction;
    float directionTimer = 0.0f;

    float dx;
    float dy;
    GameObject player;

    // Use this for initialization
    void Start()
    {
        village = GetComponentInParent<VillageScript>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        directionTimer -= Time.deltaTime;

        switch (state)
        {
            case 0: // wander
                if (village.IsPanicking())
                {
                    state = 3;
                }
                else
                {
                    if (directionTimer <= 0.0f)
                    {
                        NewDestination();
                        directionTimer = Random.Range(1.0f, 3.0f);
                    }

                    dx = (direction.x * wanderSpeed * Time.deltaTime);
                    dy = (direction.y * wanderSpeed * Time.deltaTime);
                    transform.position = new Vector3(transform.position.x + dx, transform.position.y + dy, transform.position.z);
                }
                break;
            case 3: // panicscatter
                PanicDestination();
                dx = (direction.x * panicSpeed * Time.deltaTime);
                dy = (direction.y * panicSpeed * Time.deltaTime);
                transform.position = new Vector3(transform.position.x + dx, transform.position.y + dy, transform.position.z);
                break;
        }

        BoundCheck();
    }

    void NewDestination()
    {
        if (Random.Range(0, 3) == 0)
        {
            direction.x = 0;
            direction.y = 0;
            return;
        }

        direction.x = Random.Range(-1.0f, 1.0f);
        direction.y = Random.Range(-1.0f, 1.0f);

        direction.Normalize();
    }

    void PanicDestination(bool oldDest = false)
    {
        direction = player.transform.position - transform.position;
        direction.Normalize();
    }

    void BoundCheck()
    {
        if (state == 3)
            return;


        if (state == 0)
        {
            if (transform.position.x < village.GetComponentInChildren<Transform>().FindChild("WanderRangeL").position.x)
                NewDestination();
            else if (transform.position.x > village.GetComponentInChildren<Transform>().FindChild("WanderRangeR").position.x)
                NewDestination();
            else if (transform.position.y < village.GetComponentInChildren<Transform>().FindChild("WanderRangeB").position.y)
                NewDestination();
        }
        else if (transform.position.y < village.GetComponentInChildren<Transform>().FindChild("WaterBound").position.y)
            NewDestination();

        if (transform.position.y > village.GetComponentInChildren<Transform>().FindChild("VolcanoBound").position.y)
            NewDestination();

    }
}
