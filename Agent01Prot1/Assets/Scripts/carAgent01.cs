using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carAgent01 : MonoBehaviour
{

    public GameObject carObj;
    private Transform car;
    public Transform driver;
    public float timer = 0.5f;
    public float breakingRay = 5f;

    public float visionRay = 10f;

    public float maxSpeed = 5f;

    public float speed = 5f;

    public float minSpeed = 5f;

    public float spacingSpeed = 3f;

    public float breakPower = 0.003f;

    public float speedDelta = 0.05f;

    public bool curveState = false;
    public bool curveCenterState = false;

    public float dirCar = 0f;
    public float dirCurve = 0f;

    public bool isCurve = false;

    //0 Right 1 Left 2 Up 3 Down
    //public float dir = 0;

    Vector3 oldPos;
    float totalDistance = 0;

    // Start is called before the first frame update
    void Start()
    {
        car = carObj.transform;
        oldPos = transform.position;
        minSpeed = speed;
        maxSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 distanceVector = transform.position - oldPos;
        float distanceThisFrame = distanceVector.magnitude;
        totalDistance += distanceThisFrame;
        oldPos = transform.position;

        if(totalDistance > 40)
        {
            Destroy(carObj);
        }

        Debug.DrawRay(driver.position, driver.forward * breakingRay*0.5f, Color.red);
        //Debug.DrawRay(car.position, car.right * breakingRay * 1.2f, Color.blue);
        //Debug.DrawRay(car.position, car.right * breakingRay * 2f, Color.yellow);

        car.Translate(new Vector3(-speed, 0, 0) * Time.deltaTime);
        /*
        switch (dir)
        {
            case 0:
                car.Translate(new Vector3(-speed, 0, 0) * Time.deltaTime);
                break;
            case 1:
                car.Translate(new Vector3(speed, 0, 0) * Time.deltaTime);
                break;
            case 2:
                car.Translate(new Vector3(0, 0, -speed) * Time.deltaTime);
                break;
            case 3:
                car.Translate(new Vector3(0, 0, speed) * Time.deltaTime);
                break;
        }*/

        

        RaycastHit hitBreaks;

        RaycastHit hitSlow;

        RaycastHit hitSpeedUp;

        RaycastHit hitSpacing;

        if (curveState == true || curveCenterState ==true)
        {
            float dirCar = car.GetComponent<Transform>().rotation.y;

            if(dirCar-dirCurve == 0)
            {
                speed = 1f;
                if (curveState == true)
                {
                car.transform.Rotate(0f, 90f, 0f, Space.Self);
                curveState = false;
                }
                else
                {
                    car.transform.Rotate(0f, -90f, 0f, Space.Self);
                    curveCenterState = false;
                }
            }
                    
        }
        if (!Physics.Raycast(driver.position, driver.forward, out hitSpeedUp, breakingRay * 0.3f))
        {
            if (speed < maxSpeed)
            {
                speed += speedDelta;
            }

            if (speed > maxSpeed)
            {
                speed = maxSpeed;
            }
        }
        else
        {
            if (Physics.Raycast(driver.position, driver.forward, out hitSpacing, breakingRay * 0.25f))
            {
                minSpeed = 0;
                if (speed > minSpeed)
                {
                    speed -= breakPower;
                }

                if (speed < minSpeed)
                {
                    speed = minSpeed;
                }
            }
            else
            {
                /*if (Physics.Raycast(driver.position, driver.forward, out hitSlow, (breakingRay * 1.5f)) && (hitSlow.collider.tag == "car") && speed > hitSlow.collider.gameObject.GetComponent<carAgent01>().speed)
                {
                    minSpeed = hitSlow.collider.gameObject.GetComponent<carAgent01>().speed;


                    if (minSpeed == 0)
                    {
                        speed = spacingSpeed;
                    }
                    else
                    {
                        if (speed > minSpeed)
                        {
                            speed -= breakPower;
                        }

                        if (speed < minSpeed)
                        {
                            speed = minSpeed;
                        }
                    }
                }*/

                if (Physics.Raycast(driver.position, driver.forward, out hitBreaks, breakingRay * 1.4f) && speed > spacingSpeed /*&& (hitSlow.collider.tag != "car")*/)
                {
                    if (speed > spacingSpeed)
                    {
                        speed -= breakPower;
                    }

                    if (speed < spacingSpeed)
                    {
                        speed = spacingSpeed;
                    }
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        float rand = Random.Range(0f, 1f);
        if (rand >= 0.5f && !isCurve)
        {
            dirCurve = other.GetComponent<Transform>().rotation.y;
            if (other.gameObject.CompareTag("curve"))
            {
                curveState = true;
            }
            else if (other.gameObject.CompareTag("curveCenter"))
            {
                curveCenterState = true;
            }
            isCurve = true;
        }


       // if (other.gameObject.CompareTag("curveIn"))
       // {
       //     // random entre 0 a 1.  30%
       //     curveState = true;
       // }
       // if (other.gameObject.CompareTag("curveOut"))
       // {
       //     curveState = false;
       // }
        else
                {
            Debug.Log("Hit");
            if (other.gameObject.CompareTag("car"))
            {
                Debug.Log("Trigger On the car: ");
                //Destroy(carObj);
                //Application.Quit();
            }
        }


    }


}
