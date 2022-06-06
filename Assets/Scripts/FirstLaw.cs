using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class FirstLaw : MonoBehaviour
{
    [SerializeField] Text panelText;
    [SerializeField] GameObject kilo;
    [SerializeField] GameObject halfKilo;
    [SerializeField] GameObject quarterKilo;
    public double offset = 1;
    float currKilo;
    float currHalfKilo;
    float currQuarterKilo;
    float InitialY, NewY;
    float distance, InitialDistance;
    void Start()
    {
        currKilo = kilo.transform.position.y;
        currHalfKilo = halfKilo.transform.position.y;
        currQuarterKilo = quarterKilo.transform.position.y;
        //InitialY = Camera.main.WorldToScreenPoint(quarterKilo.transform.position).y / Screen.height;
        InitialY = quarterKilo.transform.position.y;
        //NewY = Camera.main.WorldToScreenPoint(quarterKilo.transform.position).y / Screen.height;
        NewY = quarterKilo.transform.position.y;
        InitialDistance = Vector3.Distance(kilo.transform.position, quarterKilo.transform.position);
        distance = Vector3.Distance(kilo.transform.position, quarterKilo.transform.position);

        InvokeRepeating("UltraFunction", 1f, 0.2f);
    }

    void UltraFunction() {
        if (Mathf.Abs(distance-InitialDistance) > 1)
        {
            panelText.text = "Dynamic";
        }
        else
        {
            panelText.text = "Static";
        }
        InitialDistance = distance;
        distance = Vector3.Distance(kilo.transform.position, quarterKilo.transform.position);
        //NewY = Camera.main.WorldToScreenPoint(quarterKilo.transform.position).y / Screen.height;
        //NewY = quarterKilo.transform.position.y;

    }
    void Update()
    {
        /*if (Mathf.Abs(kilo.transform.position.z - currKilo) > offset ||
            Mathf.Abs(halfKilo.transform.position.z - currHalfKilo) > offset ||
            Mathf.Abs(quarterKilo.transform.position.z - currQuarterKilo) > offset)
        {
            panelText.text = "Dynamic";
        }
        else {
            panelText.text = "Static";
        }*/
        
        currKilo = kilo.transform.position.y;
        currHalfKilo = halfKilo.transform.position.y;
        currQuarterKilo = quarterKilo.transform.position.y;

        //var tString = "y = " + System.Math.Round(y, 3);
        //var tString2 = "y = " + System.Math.Round(y, 4);

    }
}
