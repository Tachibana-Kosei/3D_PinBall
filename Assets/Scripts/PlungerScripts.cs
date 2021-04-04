using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlungerScripts : MonoBehaviour {
	float power;
	public float maxPower = 100f;
	[SerializeField]List<Rigidbody> ballList;
	bool ballReady;

	void Start() {
		//powerSlider.minValue = 0.0f;
		//powerSlider.maxValue = this.maxPower;
		ballList = new List<Rigidbody>();
	}


	void Update() {
		if (ballReady) {
			//powerSlider.gameObject.SetActive(true);
		} else {
			//powerSlider.gameObject.SetActive(false);
		}


		ballList.RemoveAll(x=>x==null);
		//powerSlider.value = power;
		if (ballList.Count > 0) {
			ballReady = true;
			if (Input.GetKey(KeyCode.Space)) {
				if (power <= maxPower) {
					power += 2000 * Time.deltaTime;
				}
			}
			if (Input.GetKeyUp(KeyCode.Space)) {
				GetComponent<AudioSource>().Play();
				foreach (Rigidbody r in ballList) {
					r.AddForce(0, power, power * Mathf.Sqrt(3f));
				}
			}
		} else {
			ballReady = false;
			power = 0f;
		}
	}


	private void OnTriggerEnter(Collider t) {
		if (t.gameObject.CompareTag("Ball")) {
			ballList.Add(t.gameObject.GetComponent<Rigidbody>());
		}
	}

	private void OnTriggerExit(Collider t) {
		if (t.gameObject.CompareTag("Ball")) {
			ballList.Remove(t.gameObject.GetComponent<Rigidbody>());
			power = 0f;
		}
	}
}
