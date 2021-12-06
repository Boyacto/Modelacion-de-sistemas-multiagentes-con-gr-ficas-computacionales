using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trafficLight : MonoBehaviour
{
    [SerializeField] private GameObject TLL;
    [SerializeField] private GameObject TLU;
    [SerializeField] private GameObject TLR;
    [SerializeField] private GameObject TLD;

    //0 Left 1 Up 2 Right 3 Down
    private int currLight;
    private int nextLight;

    IEnumerator turnRed()
    {
        switch (currLight)
        {
            case 0:
                TLL.SetActive(true);
                break;
            case 1:
                TLU.SetActive(true);
                break;
            case 2:
                TLR.SetActive(true);
                break;
            case 3:
                TLD.SetActive(true);
                break;
        }
        yield return new WaitForSeconds(10);
    }

    IEnumerator changeTrafficLight()
    {
        while (true)
        {
            StartCoroutine(turnRed());
            
            while (nextLight == currLight)
            {
                nextLight = Random.Range(0, 4);
            }

            currLight = nextLight;

            switch (currLight)
            {
                case 0:
                    TLL.SetActive(false);
                    break;
                case 1:
                    TLU.SetActive(false);
                    break;
                case 2:
                    TLR.SetActive(false);
                    break;
                case 3:
                    TLD.SetActive(false);
                    break;
            }

            yield return new WaitForSeconds(10);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        currLight = Random.Range(0, 4);

        StartCoroutine(changeTrafficLight());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
