using System.Collections;
using System.Collections.Generic;
using Lights;
using UnityEngine;

public class WallSwitch : MonoBehaviour
{
    [SerializeField] GameObject wallSwitch;

    [SerializeField] GameObject YellowLight;

    // Start is called before the first frame update
    void Start()
    {
        wallSwitch = GameObject.Find("MainSystem");
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            wallSwitch.GetComponent<MainSystemScript>().AddScore(750, "WallSwitch Score");
            YellowLight.GetComponent<LightScript>().SetLight(true);
        }
    }
}
