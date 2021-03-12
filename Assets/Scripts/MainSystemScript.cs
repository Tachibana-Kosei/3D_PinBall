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
	private GameObject canvas;
	private Text lifeText;
	private Text scoreText;

	public GameObject ballPrefab;
	void Start() {
		spowner = GameObject.Find("BallSpowner");
		canvas = GameObject.Find("Canvas");
		lifeText = GetChildGameObject(canvas, "LifeText").GetComponent<Text>();
		scoreText = GetChildGameObject(canvas, "ScoreText").GetComponent<Text>();
		BallSpown();
	}

	private void Update() {
		scoreText.text = "Score:" + score.ToString();
		lifeText.text = "Life:" + life.ToString();
	}
	private GameObject GetChildGameObject(GameObject parentGameObject, String childName) {
		return parentGameObject.transform.GetComponentsInChildren<Transform>(true).ToList().FirstOrDefault(value => value.name == childName).gameObject;
	}
	//ボールをスタート地点に生成するメソッド
	public void BallSpown() {
		Instantiate(ballPrefab, spowner.transform.position, Quaternion.identity);
	}
	//引数の数字の分スコアに加算するメソッド。
	public void AddScore(int addPoint) {
		score += addPoint;
		Debug.Log("Add Score:" + addPoint + ", Now Score:" + score);
	}
	//AddScoreのオーバーロード。第2引数に文字列を入れることでデバッグ出力にコメントを入れられる
	public void AddScore(int addPoint, String comment) {
		score += addPoint;
		Debug.Log("Add Score:" + addPoint + ", Now Score:" + score + ", Comment:\"" + comment + "\"");
	}
	//引数の数字の分ライフを増やすメソッド。
	public void AddLife(int addNum) {
		life += addNum;
		Debug.Log("Add Life:" + addNum + ", Now Life:" + life);
	}
	//クラッシュ処理
	public void Crash() {
		if (life > 1) {
			life -= 1;
			AddScore(10000, "Crash Bonus");
			BallSpown();
		} else if (life == 1) {
			life -= 1;
			Gameover();
		}
	}
	//ゲームオーバー処理
	public void Gameover() {
		Debug.Log("Gameover!! Score:" + score);
	}
}
