using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject SpawnersL;
    [SerializeField] GameObject SpawnersR;
    [SerializeField] GameObject SpawnersU;
    [SerializeField] GameObject SpawnersD;

    [SerializeField] GameObject Buildings;
    [SerializeField] GameObject Buttons;

    [SerializeField] GameObject tRandomizer;

    [SerializeField] GameObject Cam1;
    [SerializeField] GameObject Cam2;

    private float speed;

    [SerializeField] GameObject tLightManager;

    [SerializeField] Text sY;
    [SerializeField] Text sR;
    [SerializeField] Text sB;
    [SerializeField] Text sW;

    void Start()
    {
        sY.text = SpawnersL.transform.GetChild(0).GetComponent<trafficSpawner>().speedY.ToString();
        sR.text = SpawnersL.transform.GetChild(0).GetComponent<trafficSpawner>().speedR.ToString();
        sB.text = SpawnersL.transform.GetChild(0).GetComponent<trafficSpawner>().speedB.ToString();
        sW.text = SpawnersL.transform.GetChild(0).GetComponent<trafficSpawner>().speedW.ToString();
    }

    public IEnumerator turnOn(GameObject spawner)
    {
        spawner.transform.GetChild(0).GetComponent<trafficSpawner>().shouldSpawn = true;
        spawner.transform.GetChild(1).GetComponent<trafficSpawner>().shouldSpawn = true;


        yield return new WaitForSeconds(2);

        spawner.transform.GetChild(0).GetComponent<trafficSpawner>().shouldSpawn = false;
        spawner.transform.GetChild(1).GetComponent<trafficSpawner>().shouldSpawn = false;
    }


    public void SpawnLeft()
    {
        StartCoroutine(turnOn(SpawnersL));
    }


    public void SpawnRight()
    {
        StartCoroutine(turnOn(SpawnersR));
    }

    public void SpawnUp()
    {
        StartCoroutine(turnOn(SpawnersU));
    }

    public void SpawnDown()
    {
        StartCoroutine(turnOn(SpawnersD));
    }

    public void OnOffBuildings()
    {
        if (Buildings.activeSelf == true)
        {
            Buildings.SetActive(false);
        }
        else
        {
            Buildings.SetActive(true);
        }
    }

    public void OnOffButtons()
    {
        if (Buttons.activeSelf == true)
        {
            Buttons.SetActive(false);
        }
        else
        {
            Buttons.SetActive(true);
        }
    }

    public void OnOffTRandomizer()
    {   /*
        if (tRandomizer.GetComponent<spawnRandomizer>().enabled == true)
        {
            tRandomizer.GetComponent<spawnRandomizer>().enabled = false;

            SpawnersL.transform.GetChild(0).GetComponent<trafficSpawner>().shouldSpawn = false;
            SpawnersL.transform.GetChild(1).GetComponent<trafficSpawner>().shouldSpawn = false;

            SpawnersR.transform.GetChild(0).GetComponent<trafficSpawner>().shouldSpawn = false;
            SpawnersR.transform.GetChild(1).GetComponent<trafficSpawner>().shouldSpawn = false;

            SpawnersU.transform.GetChild(0).GetComponent<trafficSpawner>().shouldSpawn = false;
            SpawnersU.transform.GetChild(1).GetComponent<trafficSpawner>().shouldSpawn = false;

            SpawnersD.transform.GetChild(0).GetComponent<trafficSpawner>().shouldSpawn = false;
            SpawnersD.transform.GetChild(1).GetComponent<trafficSpawner>().shouldSpawn = false;

        }
        else
        {
            tRandomizer.GetComponent<spawnRandomizer>().enabled = true;
        }*/

        if (tRandomizer.activeSelf == true)
        {
            tRandomizer.SetActive(false);

            SpawnersL.transform.GetChild(0).GetComponent<trafficSpawner>().shouldSpawn = false;
            SpawnersL.transform.GetChild(1).GetComponent<trafficSpawner>().shouldSpawn = false;

            SpawnersR.transform.GetChild(0).GetComponent<trafficSpawner>().shouldSpawn = false;
            SpawnersR.transform.GetChild(1).GetComponent<trafficSpawner>().shouldSpawn = false;

            SpawnersU.transform.GetChild(0).GetComponent<trafficSpawner>().shouldSpawn = false;
            SpawnersU.transform.GetChild(1).GetComponent<trafficSpawner>().shouldSpawn = false;

            SpawnersD.transform.GetChild(0).GetComponent<trafficSpawner>().shouldSpawn = false;
            SpawnersD.transform.GetChild(1).GetComponent<trafficSpawner>().shouldSpawn = false;

        }
        else
        {
            tRandomizer.SetActive(true);
            tRandomizer.GetComponent<spawnRandomizer>().StartAgain();

        }

    }

    public void camSwap()
    {
        if (Cam1.activeSelf == true)
        {
            Cam1.SetActive(false);
            Cam2.SetActive(true);
        }
        else
        {
            Cam1.SetActive(true);
            Cam2.SetActive(false);
        }
    }


    public void changeSpeedYellow()
    {
        /*
        SpawnersL.transform.GetChild(0).GetComponent<trafficSpawner>().speedY = speed;
        SpawnersL.transform.GetChild(1).GetComponent<trafficSpawner>().speedY = speed;

        SpawnersR.transform.GetChild(0).GetComponent<trafficSpawner>().speedY = speed;
        SpawnersR.transform.GetChild(1).GetComponent<trafficSpawner>().speedY = speed;

        SpawnersU.transform.GetChild(0).GetComponent<trafficSpawner>().speedY = speed;
        SpawnersU.transform.GetChild(1).GetComponent<trafficSpawner>().speedY = speed;

        SpawnersD.transform.GetChild(0).GetComponent<trafficSpawner>().speedY = speed;
        SpawnersD.transform.GetChild(1).GetComponent<trafficSpawner>().speedY = speed;
        */
    }

    public void RandomPrioritySwitch()
    {
        if (tLightManager.GetComponent<trafficLight>().enabled)
        {
            tLightManager.GetComponent<trafficLight>().enabled = false;
            tLightManager.GetComponent<priorityLights>().enabled = true;
        }
        else
        {
            tLightManager.GetComponent<trafficLight>().enabled = true;
            tLightManager.GetComponent<priorityLights>().enabled = false;
        }
    }

    public void updateSpeed()
    {
        sY.text = SpawnersL.transform.GetChild(0).GetComponent<trafficSpawner>().speedY.ToString();
        sR.text = SpawnersL.transform.GetChild(0).GetComponent<trafficSpawner>().speedR.ToString();
        sB.text = SpawnersL.transform.GetChild(0).GetComponent<trafficSpawner>().speedB.ToString();
        sW.text = SpawnersL.transform.GetChild(0).GetComponent<trafficSpawner>().speedW.ToString();
    }

    public void plusY()
    {
        SpawnersL.transform.GetChild(0).GetComponent<trafficSpawner>().speedY += 1;
        SpawnersL.transform.GetChild(1).GetComponent<trafficSpawner>().speedY += 1;

        SpawnersR.transform.GetChild(0).GetComponent<trafficSpawner>().speedY += 1;
        SpawnersR.transform.GetChild(1).GetComponent<trafficSpawner>().speedY += 1;

        SpawnersU.transform.GetChild(0).GetComponent<trafficSpawner>().speedY += 1;
        SpawnersU.transform.GetChild(1).GetComponent<trafficSpawner>().speedY += 1;

        SpawnersD.transform.GetChild(0).GetComponent<trafficSpawner>().speedY += 1;
        SpawnersD.transform.GetChild(1).GetComponent<trafficSpawner>().speedY += 1;

        updateSpeed();
    }

    public void minusY()
    {
        SpawnersL.transform.GetChild(0).GetComponent<trafficSpawner>().speedY -= 1;
        SpawnersL.transform.GetChild(1).GetComponent<trafficSpawner>().speedY -= 1;

        SpawnersR.transform.GetChild(0).GetComponent<trafficSpawner>().speedY -= 1;
        SpawnersR.transform.GetChild(1).GetComponent<trafficSpawner>().speedY -= 1;

        SpawnersU.transform.GetChild(0).GetComponent<trafficSpawner>().speedY -= 1;
        SpawnersU.transform.GetChild(1).GetComponent<trafficSpawner>().speedY -= 1;

        SpawnersD.transform.GetChild(0).GetComponent<trafficSpawner>().speedY -= 1;
        SpawnersD.transform.GetChild(1).GetComponent<trafficSpawner>().speedY -= 1;

        updateSpeed();
    }

    public void plusR()
    {
        SpawnersL.transform.GetChild(0).GetComponent<trafficSpawner>().speedR += 1;
        SpawnersL.transform.GetChild(1).GetComponent<trafficSpawner>().speedR += 1;

        SpawnersR.transform.GetChild(0).GetComponent<trafficSpawner>().speedR += 1;
        SpawnersR.transform.GetChild(1).GetComponent<trafficSpawner>().speedR += 1;

        SpawnersU.transform.GetChild(0).GetComponent<trafficSpawner>().speedR += 1;
        SpawnersU.transform.GetChild(1).GetComponent<trafficSpawner>().speedR += 1;

        SpawnersD.transform.GetChild(0).GetComponent<trafficSpawner>().speedR += 1;
        SpawnersD.transform.GetChild(1).GetComponent<trafficSpawner>().speedR += 1;

        updateSpeed();
    }

    public void minusR()
    {
        SpawnersL.transform.GetChild(0).GetComponent<trafficSpawner>().speedR -= 1;
        SpawnersL.transform.GetChild(1).GetComponent<trafficSpawner>().speedR -= 1;

        SpawnersR.transform.GetChild(0).GetComponent<trafficSpawner>().speedR -= 1;
        SpawnersR.transform.GetChild(1).GetComponent<trafficSpawner>().speedR -= 1;

        SpawnersU.transform.GetChild(0).GetComponent<trafficSpawner>().speedR -= 1;
        SpawnersU.transform.GetChild(1).GetComponent<trafficSpawner>().speedR -= 1;

        SpawnersD.transform.GetChild(0).GetComponent<trafficSpawner>().speedR -= 1;
        SpawnersD.transform.GetChild(1).GetComponent<trafficSpawner>().speedR -= 1;

        updateSpeed();
    }

    public void plusB()
    {
        SpawnersL.transform.GetChild(0).GetComponent<trafficSpawner>().speedB += 1;
        SpawnersL.transform.GetChild(1).GetComponent<trafficSpawner>().speedB += 1;

        SpawnersR.transform.GetChild(0).GetComponent<trafficSpawner>().speedB += 1;
        SpawnersR.transform.GetChild(1).GetComponent<trafficSpawner>().speedB += 1;

        SpawnersU.transform.GetChild(0).GetComponent<trafficSpawner>().speedB += 1;
        SpawnersU.transform.GetChild(1).GetComponent<trafficSpawner>().speedB += 1;

        SpawnersD.transform.GetChild(0).GetComponent<trafficSpawner>().speedB += 1;
        SpawnersD.transform.GetChild(1).GetComponent<trafficSpawner>().speedB += 1;

        updateSpeed();
    }

    public void minusB()
    {
        SpawnersL.transform.GetChild(0).GetComponent<trafficSpawner>().speedB -= 1;
        SpawnersL.transform.GetChild(1).GetComponent<trafficSpawner>().speedB -= 1;

        SpawnersR.transform.GetChild(0).GetComponent<trafficSpawner>().speedB -= 1;
        SpawnersR.transform.GetChild(1).GetComponent<trafficSpawner>().speedB -= 1;

        SpawnersU.transform.GetChild(0).GetComponent<trafficSpawner>().speedB -= 1;
        SpawnersU.transform.GetChild(1).GetComponent<trafficSpawner>().speedB -= 1;

        SpawnersD.transform.GetChild(0).GetComponent<trafficSpawner>().speedB -= 1;
        SpawnersD.transform.GetChild(1).GetComponent<trafficSpawner>().speedB -= 1;

        updateSpeed();
    }

    public void plusW()
    {
        SpawnersL.transform.GetChild(0).GetComponent<trafficSpawner>().speedW += 1;
        SpawnersL.transform.GetChild(1).GetComponent<trafficSpawner>().speedW += 1;

        SpawnersR.transform.GetChild(0).GetComponent<trafficSpawner>().speedW += 1;
        SpawnersR.transform.GetChild(1).GetComponent<trafficSpawner>().speedW += 1;

        SpawnersU.transform.GetChild(0).GetComponent<trafficSpawner>().speedW += 1;
        SpawnersU.transform.GetChild(1).GetComponent<trafficSpawner>().speedW += 1;

        SpawnersD.transform.GetChild(0).GetComponent<trafficSpawner>().speedW += 1;
        SpawnersD.transform.GetChild(1).GetComponent<trafficSpawner>().speedW += 1;

        updateSpeed();
    }

    public void minusW()
    {
        SpawnersL.transform.GetChild(0).GetComponent<trafficSpawner>().speedW -= 1;
        SpawnersL.transform.GetChild(1).GetComponent<trafficSpawner>().speedW -= 1;

        SpawnersR.transform.GetChild(0).GetComponent<trafficSpawner>().speedW -= 1;
        SpawnersR.transform.GetChild(1).GetComponent<trafficSpawner>().speedW -= 1;

        SpawnersU.transform.GetChild(0).GetComponent<trafficSpawner>().speedW -= 1;
        SpawnersU.transform.GetChild(1).GetComponent<trafficSpawner>().speedW -= 1;

        SpawnersD.transform.GetChild(0).GetComponent<trafficSpawner>().speedW -= 1;
        SpawnersD.transform.GetChild(1).GetComponent<trafficSpawner>().speedW -= 1;

        updateSpeed();
    }

}
