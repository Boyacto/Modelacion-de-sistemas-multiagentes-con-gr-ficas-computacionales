using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class priorityLights : MonoBehaviour
{
    [SerializeField] private GameObject TLL;
    [SerializeField] private GameObject TLU;
    [SerializeField] private GameObject TLR;
    [SerializeField] private GameObject TLD;

    private bool left1 = false;
    private bool left2 = false;
    private bool up1 = false;
    private bool up2 = false;
    private bool right1 = false;
    private bool right2 = false;
    private bool down1 = false;
    private bool down2 = false;

    private int priorityL = 0;
    private int priorityU = 0;
    private int priorityR = 0;
    private int priorityD = 0;

    IEnumerator changeColor(GameObject light)
    {
        TLL.SetActive(true);
        TLU.SetActive(true);
        TLR.SetActive(true);
        TLD.SetActive(true);

        light.SetActive(false);

        yield return new WaitForSeconds(3);
    }

    IEnumerator changeLight()
    {
        while (true)
        {
            if (left1) { priorityL += 1; }
            if (left2) { priorityL += 1; }

            if (!left1 && !left2) { priorityL = 0; }

            if (up1) { priorityU += 1; }
            if (up2) { priorityU += 1; }

            if (!up1 && !up2) { priorityU = 0; }

            if (right1) { priorityR += 1; }
            if (right2) { priorityR += 1; }

            if (!right1 && !right2) { priorityR = 0; }

            if (down1) { priorityD += 1; }
            if (down2) { priorityD += 1; }

            if (!down1 && !down2) { priorityD = 0; }

            if (priorityL >= priorityU && priorityL >= priorityR && priorityL >= priorityD && priorityL >0)
            {
                priorityL = 0;
                priorityU += 1;
                priorityR += 1;
                priorityD += 1;
                StartCoroutine(changeColor(TLL));
}
            else if (priorityU >= priorityR && priorityU >= priorityD && priorityU > 0)
            {
                priorityL += 1;
                priorityU = 0;
                priorityR += 1;
                priorityD += 1;
                StartCoroutine(changeColor(TLU));
            }
            else if (priorityR >= priorityD && priorityR > 0)
            {
                priorityL += 1;
                priorityU += 1;
                priorityR = 0;
                priorityD += 1;
                StartCoroutine(changeColor(TLR));
            }
            else if(priorityD > 0)
            {
                priorityL += 1;
                priorityU += 1;
                priorityR += 1;
                priorityD = 0;
                StartCoroutine(changeColor(TLD));
            }


            yield return new WaitForSeconds(8);
        }   
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(changeLight());
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(TLL.transform.position + new Vector3(0,-0.75f, 0.5f), TLL.transform.forward * 3f, Color.blue);
        Debug.DrawRay(TLL.transform.position + new Vector3(0, -0.75f, -0.5f), TLL.transform.forward * 3f, Color.blue);
        Debug.DrawRay(TLU.transform.position + new Vector3(0.5f, -0.75f, 0), TLU.transform.forward * 3f, Color.blue);
        Debug.DrawRay(TLU.transform.position + new Vector3(-0.5f, -0.75f, 0), TLU.transform.forward * 3f, Color.blue);
        Debug.DrawRay(TLR.transform.position + new Vector3(0, -0.75f, 0.5f), TLR.transform.forward * 3f, Color.blue);
        Debug.DrawRay(TLR.transform.position + new Vector3(0, -0.75f, -0.5f), TLR.transform.forward * 3f, Color.blue);
        Debug.DrawRay(TLD.transform.position + new Vector3(0.5f, -0.75f, 0), TLD.transform.forward * 3f, Color.blue);
        Debug.DrawRay(TLD.transform.position + new Vector3(-0.5f, -0.75f, 0), TLD.transform.forward * 3f, Color.blue);

        RaycastHit carHere;

        if (Physics.Raycast(TLL.transform.position + new Vector3(0, -0.75f, 0.5f), TLL.transform.forward, out carHere, 3f))
        {
            left1 = true;
        }
        else
        {
            left1 = false;
        }

        if (Physics.Raycast(TLL.transform.position + new Vector3(0, -0.75f, -0.5f), TLL.transform.forward, out carHere, 3f))
        {
            left2 = true;
        }
        else
        {
            left2 = false;
        }

        if (Physics.Raycast(TLU.transform.position + new Vector3(0.5f, -0.75f, 0), TLU.transform.forward, out carHere, 3f))
        {
            up1 = true;
        }
        else
        {
            up1 = false;
        }

        if (Physics.Raycast(TLU.transform.position + new Vector3(-0.5f, -0.75f, 0), TLU.transform.forward, out carHere, 3f))
        {
            up2 = true;
        }
        else
        {
            up2 = false;
        }

        if (Physics.Raycast(TLR.transform.position + new Vector3(0, -0.75f, 0.5f), TLR.transform.forward, out carHere, 3f))
        {
            right1 = true;
        }
        else
        {
             right1 = false;
        }

        if (Physics.Raycast(TLR.transform.position + new Vector3(0, -0.75f, -0.5f), TLR.transform.forward, out carHere, 3f))
        {
            right2 = true;
        }
        else
        {
            right2 = false;
        }

        if (Physics.Raycast(TLD.transform.position + new Vector3(0.5f, -0.75f, 0), TLD.transform.forward, out carHere, 3f))
        {
            down1 = true;
        }
        else
        {
            down1 = false;
        }

        if (Physics.Raycast(TLD.transform.position + new Vector3(-0.5f, -0.75f, 0), TLD.transform.forward, out carHere, 3f))
        {
            down2 = true;
        }
        else
        {
            down2 = false;
        }


    }
}

