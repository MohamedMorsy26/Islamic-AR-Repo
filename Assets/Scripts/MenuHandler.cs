using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Vuforia;
using UnityEngine.SceneManagement;
public class MenuHandler : MonoBehaviour
{
    public void URL(string url)
    {
        Application.OpenURL(url);
    }

    public void SceneHandler(int i)
    {
        SceneManager.LoadScene(i);
    }

    void Update()
    {
        CalculateDistance();
    }
    public void CalculateDistance()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("Hit");
            Debug.Log(hit.distance);

        }
        else
        {
            Debug.Log("miss");
        }
    }
}
