using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public GameObject night;
    public GameObject day;

    private void Start()
    {
        night.SetActive(false);
    }
    void OnTriggerEnter(Collider other)
    {
        if (!night.activeSelf)
        {
            day.SetActive(false);
            night.SetActive(true);
        }
        else
        {
            day.SetActive(true);
            night.SetActive(false);
        }
    }
}
