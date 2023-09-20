using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CekFiturAktiv : MonoBehaviour
{
    [SerializeField] private GameObject MessageFeature;
    [SerializeField] private GameObject ColoringFeature;

    void Start()
    {
        GetFeatureActive();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetFiturAktiv(int value)
    {
        PlayerPrefs.SetInt("featureValue", value);
        GetFeatureActive();
    }

    public void GetFeatureActive()
    {
        int featureValue = PlayerPrefs.GetInt("featureValue");

        if(featureValue == 0)
        {
            MessageFeature.SetActive(false);
            ColoringFeature.SetActive(true);
        }
        else if(featureValue == 1)
        {
            ColoringFeature.SetActive(false);
            MessageFeature.SetActive(true);
        }
    }
}
