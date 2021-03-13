using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperL : MonoBehaviour
{
    [SerializeField] float rotateSpd;
    [SerializeField] int rotateTime;
    [SerializeField] int timeFromLastMove = 0;
    [SerializeField] string moveKey;
    [SerializeField] bool movingUp = false;
    bool moveModeChanged = false;
    [SerializeField] Vector3 center;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = center;
        rb.maxAngularVelocity = Mathf.Abs(rotateSpd);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(moveKey))
        {
            if (timeFromLastMove < 0) timeFromLastMove = 1;
            moveModeChanged = !movingUp;
            movingUp = true;
        }
        if (Input.GetKeyUp(moveKey))
        {
            if (timeFromLastMove > rotateTime) timeFromLastMove = rotateTime - 1;
            moveModeChanged = movingUp;
            movingUp = false;
        }

    }
    void FixedUpdate()
    {

        if ((timeFromLastMove < rotateTime && timeFromLastMove > 0) || moveModeChanged)
        {
            moveModeChanged = false;
            if (movingUp)
            {
                //回転回数のカウント
                timeFromLastMove++;
            }
            else
            {
                //上と同じ
                timeFromLastMove--;
            }
            //角速度を書きかえて回転
            rb.angularVelocity = new Vector3(0, 0, movingUp ? -rotateSpd : rotateSpd);
        }
        else
        {
            //回転の停止
            rb.angularVelocity = Vector3.zero;
        }
    }
}