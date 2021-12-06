using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trafficSpawner : MonoBehaviour
{

    public GameObject car1;
    public GameObject car2;
    public GameObject car3;
    public GameObject car4;

    public GameObject spawn1;
    public GameObject spawn2;
    public GameObject spawn3;
    public GameObject spawn4;

    public Transform spawnerBox;

    private bool canSpawn = true;
    public bool shouldSpawn = false;

    private Vector3 spPos;
    public int direction = 0;
    private int dir;

    public float speedY = 5f;
    public float speedB = 4f;
    public float speedR = 6f;
    public float speedW = 3f;

    private IEnumerator SpawnCar()
    {
        while (true)
        {
            if (canSpawn && shouldSpawn)
            {
                int rand = Random.Range(1, 5);

                switch (direction)
                {
                    case 0:
                        dir = 0;
                        break;
                    case 1:
                        dir = 90;
                        break;
                    case 2:
                        dir = 180;
                        break;
                    case 3:
                        dir = 270;
                        break;
                }

                switch (rand)
                {
                    case 1: // if a is an integer
                        spPos = spawn1.transform.position;
                        var carT1 = Instantiate(car1, spPos, Quaternion.Euler(new Vector3(0, dir, 0)));
                        carT1.GetComponent<carAgent01>().speed = speedY;
                        carT1.GetComponent<carAgent01>().breakPower = 1f;
                        //carT1.GetComponent<carAgent01>().dir = direction;
                        break;
                    case 2: // if a is a string
                        spPos = spawn2.transform.position;
                        var carT2 = Instantiate(car2, spPos, Quaternion.Euler(new Vector3(0, dir, 0)));
                        carT2.GetComponent<carAgent01>().speed = speedB;
                        carT2.GetComponent<carAgent01>().breakPower = 1f;
                        //carT2.GetComponent<carAgent01>().dir = direction;
                        break;
                    case 3:
                        spPos = spawn3.transform.position;
                        var carT3 = Instantiate(car3, spPos, Quaternion.Euler(new Vector3(0, dir, 0)));
                        carT3.GetComponent<carAgent01>().speed = speedR;
                        carT3.GetComponent<carAgent01>().breakPower = 1f;
                        //carT3.GetComponent<carAgent01>().dir = direction;
                        break;
                    case 4:
                        spPos = spawn4.transform.position;
                        var carT4 = Instantiate(car4, spPos, Quaternion.Euler(new Vector3(0, dir, 0)));
                        carT4.GetComponent<carAgent01>().speed = speedW;
                        carT4.GetComponent<carAgent01>().breakPower = 1f;
                        //carT4.GetComponent<carAgent01>().dir = direction;
                        break;
                }
            }
            yield return new WaitForSeconds(2);
        }
    }

    // Start is called before the first frame update
    IEnumerator Start()
    {
        //Instantiate(car);
        yield return StartCoroutine(SpawnCar());
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit freeSpace;
        Debug.DrawRay(spawnerBox.position, spawnerBox.right * 6f, Color.red);
        
        if (Physics.Raycast(spawnerBox.position, spawnerBox.right, out freeSpace, 6f))
        {
            canSpawn = false;
        }
        else
        {
            canSpawn = true;
        }

    }
}
