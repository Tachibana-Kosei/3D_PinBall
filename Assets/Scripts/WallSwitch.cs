using System.Collections;
using System.Collections.Generic;
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

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        wallSwitch.GetComponent<MainSystemScript>().AddScore(750,"WallSwitch Score");
        YellowLight.GetComponent<LightScript>().SetLight(true);
    }
}
