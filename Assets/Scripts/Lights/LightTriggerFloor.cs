using System.Collections;
using System.Collections.Generic;
using Lights;
using UnityEngine;

public class LightTriggerFloor : MonoBehaviour
{
    GameObject gameobject;
    private GameObject mainSystem;
    private MainSystemScript mainSystemScript;

    void Start()
    {
        gameobject = transform.parent.gameObject;
        mainSystem = GameObject.FindGameObjectWithTag("MainSystem");
        mainSystemScript = mainSystem.GetComponent<MainSystemScript>();
    }

    //動作
    void OnTriggerEnter(Collider t)
    {
        if (t.gameObject.CompareTag("Ball"))
        {
            //ライトの点滅
            gameobject.GetComponent<LightScript>().ToggleLight();
            //得点
            mainSystemScript.AddScore(2000);
            //効果音
            GetComponent<AudioSource>().Play();
        }
    }
}
