using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class MainSystemScript : MonoBehaviour {
	private int life = 3;
	private long score = 0;
	private GameObject spowner;

	public GameObject ballPrefab;
	void Start() {
		spowner = GameObject.Find("BallSpowner");
		BallSpown();
	}

	public void Crash() {
		life -= 1;
		if (life > 0) {
			BallSpown();
		} else {
			Gameover();
		}
	}

	public void BallSpown() {
		Instantiate(ballPrefab, spowner.transform.position, Quaternion.identity);
	}

	public void Gameover() {
		Debug.Log("Gameover!! Score:" + score);
	}
	public void AddScore(int addPoint) {
		Debug.Log("Add Score:" + addPoint);
		score += addPoint;
	}
	public void AddLife(int addNum) {
		life += addNum;
	}
}
