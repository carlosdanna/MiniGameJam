using UnityEngine;
using System.Collections;

public class Shark_Blava_VillagerLogic : MonoBehaviour
{

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
    float jumpUp;
    float jumpDown;
    float runLeft;
    float runRight;
    float dx;
    float dy;

    // Use this for initialization
    void Start()
    {
        village = GetComponentInParent<VillageScript>();
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
                    if (Random.Range(0, 4) == 0 )
                    {
                        GetComponent<AudioSource>().volume = Random.Range(0.5f, 1.0f);
                        GetComponent<AudioSource>().pitch = Random.Range(0.5f, 1.5f);
                        GetComponent<AudioSource>().PlayDelayed(Random.Range(0.0f, 3.0f));
                    }




                    directionTimer = 0.0f;
                    int newState = Random.Range(0, 100);

                    if (newState < 10)
                    {
                        runRight = transform.position.x + 1.0f;
                        runLeft = transform.position.x - 1.0f;
                        state = 2;
                    }
                    else if (newState < 30)
                    {
                        jumpUp = transform.position.y + 0.2f;
                        jumpDown = transform.position.y;
                        state = 1;
                    }
                    else
                    {
                        PanicDestination(false);
                        state = 3;
                    }
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
            case 1: // panicjump
                if (transform.position.y > jumpUp)
                    direction = new Vector2(0.0f, -1.0f);
                else if (transform.position.y < jumpDown)
                    direction = new Vector2(0.0f, 1.0f);

                dy = (direction.y * jumpSpeed * Time.deltaTime);
                transform.position = new Vector3(transform.position.x, transform.position.y + dy, transform.position.z);
                break;
            case 2: // panicrun
                if (transform.position.x > runRight)
                    direction = new Vector2(-1.0f, 0.0f);
                else if (transform.position.x < runLeft)
                    direction = new Vector2(1.0f, 0.0f);

                dx = (direction.x * panicSpeed * Time.deltaTime);
                transform.position = new Vector3(transform.position.x + dx, transform.position.y, transform.position.z);
                break;
            case 3: // panicscatter
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

    void PanicDestination(bool oldDest)
    {
        float dangerX = Random.Range(20.0f, 50.0f);
        if (oldDest)
        {
            if (direction.x < 0)
                dangerX *= -1.0f;
        }
        else if (Random.Range(0, 2) == 0)
            dangerX *= -1.0f;

        float dangerY = Random.Range(village.GetComponentInChildren<Transform>().FindChild("WaterBound").position.y, village.GetComponentInChildren<Transform>().FindChild("VolcanoBound").position.y);

        direction = new Vector2(dangerX, dangerY);
        direction.Normalize();
    }

    void BoundCheck()
    {
        if (state == 3)
        {
            PanicDestination(true);
            return;
        }


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
