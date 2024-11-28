using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public GameObject night;
    public GameObject day;
    public Material DayskyMaterial;
    public Material NightskyMaterial;

    private void Start()
    {
        night.SetActive(false);
        RenderSettings.skybox = DayskyMaterial;
    }
    void OnTriggerEnter(Collider other)
    {
        if (!night.activeSelf)
        {
            day.SetActive(false);
            night.SetActive(true);
            RenderSettings.skybox = NightskyMaterial;
        }
        else
        {
            day.SetActive(true);
            night.SetActive(false);
            RenderSettings.skybox = DayskyMaterial;
        }
    }
}
