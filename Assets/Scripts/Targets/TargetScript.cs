using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TargetScript : MonoBehaviour
{
    private Vector3 startPosition;
    public bool isGetUp = true;
    private BoxCollider boxCollider;
    private MainSystemScript mainSystemScript;

    private void Awake()
    {
        
        boxCollider = GetComponent<BoxCollider>();
        mainSystemScript = GameObject.FindWithTag("MainSystem").GetComponent<MainSystemScript>();
        startPosition = transform.position;
        Debug.Log(transform.parent.parent.name+name+startPosition);
        SetState(true);
    }

    private void Start()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            SetState(false);
        }
    }
    public void SetState(bool isGetUp)
    {
        this.isGetUp = isGetUp;
        boxCollider.isTrigger = !isGetUp;
        Vector3 setPosition;
        if (isGetUp)
        {
            setPosition = new Vector3(startPosition.x, startPosition.y, startPosition.z);
        }
        else
        {
            mainSystemScript.audioSource.PlayOneShot(mainSystemScript.targetSound);
            var lossyScale = transform.lossyScale;
            setPosition = new Vector3(startPosition.x, startPosition.y - lossyScale.y * 0.4f * Mathf.Sqrt(3),startPosition.z + lossyScale.y * 0.4f);
        }

        transform.position = setPosition;
    }
}
