using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnRandomizer : MonoBehaviour
{
    [SerializeField] private GameObject leftSpawners;
    [SerializeField] private GameObject upSpawners;
    [SerializeField] private GameObject rightSpawners;
    [SerializeField] private GameObject downSpawners;

    //0 Left 1 Up 2 Right 3 Down
    private int currSpawner;

    IEnumerator turnOn(GameObject spawner)
    {
        var sNum = Random.Range(0, 3);

        switch (sNum)
        {
            case 1:
                spawner.transform.GetChild(0).GetComponent<trafficSpawner>().shouldSpawn = true;
                break;
            case 2:
                spawner.transform.GetChild(1).GetComponent<trafficSpawner>().shouldSpawn = true;
                break;
            case 3:
                spawner.transform.GetChild(0).GetComponent<trafficSpawner>().shouldSpawn = true;
                spawner.transform.GetChild(1).GetComponent<trafficSpawner>().shouldSpawn = true;
                break;
        }

        yield return new WaitForSeconds(Random.Range(2, 6));

        spawner.transform.GetChild(0).GetComponent<trafficSpawner>().shouldSpawn = false;
        spawner.transform.GetChild(1).GetComponent<trafficSpawner>().shouldSpawn = false;
    }


    IEnumerator randomizeSpawners()
    {
        while (true)
        {
            for (int i = 0; i < Random.Range(1,5); i++)
            {
                currSpawner = Random.Range(0, 4);
                switch (currSpawner)
                {
                    case 0:
                        StartCoroutine(turnOn(leftSpawners));
                        break;
                    case 1:
                        StartCoroutine(turnOn(upSpawners));
                        break;
                    case 2:
                        StartCoroutine(turnOn(rightSpawners));
                        break;
                    case 3:
                        StartCoroutine(turnOn(downSpawners));
                        break;
                }
            }
            yield return new WaitForSeconds(Random.Range(4, 8));
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(randomizeSpawners());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartAgain()
    {
        StartCoroutine(randomizeSpawners());
    }


}
