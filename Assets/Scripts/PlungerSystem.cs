using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlungerSystem : MonoBehaviour {

	public Rigidbody rd;
	Vector3 sp;
	float speed = 0.0f;
	float time = 0.0f;
	public float maxSpeed = 10.0f;
	public float power = 10.0f;
	SpringJoint springJoint;

	// Start is called before the first frame update
	void Start() {
		rd = GetComponent<Rigidbody>();
		sp = transform.position;
		springJoint = GetComponent<SpringJoint>();
		//var SpringJoint = GetComponent<SpringJoint>;

	}
	// Update is called once per frame
	void Update() {
		Debug.Log(springJoint.currentForce);
		//var SpringJoint = GetComponent<SpringJoint>;
		if (Input.GetKey(KeyCode.Space))//押してる時
		{
			//SpringJoint.enabled = false;
			if (time < 10.0f) {
				transform.position += new Vector3(0, -0.2f, -0.34f);//位置
				time += 0.1f;
			}
		}
		if (Input.GetKeyUp(KeyCode.Space))//離したとき
		{
			//GetComponent<Rigidbody>().MovePosition(sp);
			//Vector3 force = new Vector3(0, 1.0f * power, 1.7f * power);
			//rd.AddForce(force, ForceMode.Impulse);
			//SpringJoint.enabled = true;
			time = 0.0f;
		}
	}
}
