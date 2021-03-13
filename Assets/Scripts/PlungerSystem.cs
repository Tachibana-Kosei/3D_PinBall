using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlungerSystem : MonoBehaviour
{
    GameObject Plunger;
    float power = 0.1f;
    float maxPower = 30.0f;
    public Rigidbody rd;
    Vector3 sp;
    float speed = 0.0f;
    public float maxSpeed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody>();
        sp = this.transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))//押してる時
        {
            if (this.power < maxPower)
            {
                this.transform.position += new Vector3(0, -0.006f, -0.008f);//位置

                this.power *= 1.02f;//力
            }
            else if (this.power >= maxPower) this.power = maxPower;
        }
        if (Input.GetKeyUp(KeyCode.Space))//離したとき
        {
            GetComponent<Rigidbody>().MovePosition(sp);
            //rd.velocity = new Vector3(0, 1.0f, 1.7f)*10.0f;
        }
    }

}
