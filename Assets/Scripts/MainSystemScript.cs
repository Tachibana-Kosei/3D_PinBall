using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MainSystemScript : MonoBehaviour {
	private int life = 30;
	private long score = 0;
	private GameObject spowner;
	private GameObject canvas;
	public GameObject ballPrefab;
	private Text lifeText;
	private Text scoreText;
	private float gameTime_whole=0f;
	private float gameTime_nowPlay=0f;
	private bool onPlaying=false;

	private void Start() {
		spowner = GameObject.Find("BallSpowner");
		canvas = GameObject.Find("Canvas");
		lifeText = GetChildGameObject(canvas, "LifeText").GetComponent<Text>();
		scoreText = GetChildGameObject(canvas, "ScoreText").GetComponent<Text>();
		BallSpown();
	}

	private void Update() {
		scoreText.text = "Score:" + score.ToString();
		lifeText.text = "Life:" + life.ToString();
		if (Input.GetKeyDown(KeyCode.F2)) {
			BallSpown();
		}
		if (onPlaying) {
			gameTime_nowPlay += Time.deltaTime;
			gameTime_whole += Time.deltaTime;
		}
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
		AddScore(10000, "Crash Bonus");
		life -= 1;
		onPlaying = false;
		gameTime_nowPlay = 0f;
		if (life > 0) {
			BallSpown();
		} else if (life == 0) {
			Gameover();
		}
	}

	//ゲームオーバー処理
	public void Gameover() {
		Debug.Log("Gameover!! Score:" + score);
		Debug.Log("Play time: " + gameTime_whole);
	}
}