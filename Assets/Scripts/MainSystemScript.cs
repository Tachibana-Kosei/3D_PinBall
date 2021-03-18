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
	public GameObject ballPrefab;
	public Text lifeText;
	public Text scoreText;
	public Text time_now;
	public Text time_whole;
	private float gameTime_whole = 0f;
	private float gameTime_nowPlay = 0f;
	private GameState gameState;
	private float deployedTime;
	public bool replayable = false;
	private readonly float replayableTime = 15f;
	public int fieldMultiplyRate = 1;
	public int bonusMultiplyRate = 1;
	public bool jackpotEnable = false;
	public bool bonusEnable = false;
	public bool bonusHold = false;
	private long jackpotScore = 0;
	private long bonusScore = 0;
	public List<ControllerBasicScript> controllers;

	private enum GameState {
		OnStandby, ReDeploying, Playing
	}

	private void Start() {
		spowner = GameObject.Find("BallSpowner");
		OnStandby();
	}

	public void OnStandby() {
		gameState = GameState.OnStandby;
		CanvasUpdate();
		controllers.ForEach(x => x.Reset());
		if (life > 0) {
			BallSpown();
		} else if (life == 0) {
			Gameover();
		}
	}

	//ボールをスタート地点に生成するメソッド
	public void BallSpown() {
		Instantiate(ballPrefab, spowner.transform.position, Quaternion.identity);
	}

	private void Update() {
		if (Input.GetKeyDown(KeyCode.F2)) {
			BallSpown();
		}
		if (gameState != GameState.OnStandby) {
			gameTime_nowPlay += Time.deltaTime;
			gameTime_whole += Time.deltaTime;
			CanvasUpdate();
		}
	}

	public void Deployed() {
		if (gameState != GameState.Playing) {
			gameState = GameState.Playing;
			deployedTime = gameTime_nowPlay;
			Debug.Log("Deployed time: " + deployedTime);
		}
	}

	public void CanvasUpdate() {
		scoreText.text = "Score: " + score;
		lifeText.text = "Life: " + life;
		time_now.text = "Time(now): " + gameTime_nowPlay.ToString("0.0");
		time_whole.text = "Time(whole): " + gameTime_whole.ToString("0.0");
	}

	//引数の数字の分スコアに加算するメソッド。第2引数に文字列を入れることでデバッグ出力にコメントを入れられる
	public void AddScore(int addPoint, string comment) {
		int actualyAddPoint = addPoint * fieldMultiplyRate;
		score += actualyAddPoint;
		if (jackpotEnable) jackpotScore = actualyAddPoint;
		if (bonusEnable) bonusScore = actualyAddPoint;
		Debug.Log("Add Score:" + actualyAddPoint + ", Now Score:" + score + ", Comment:\"" + comment + "\"");
	}

	//AddScoreのオーバーロード。
	public void AddScore(int addPoint) {
		AddScore(addPoint, "");
	}

	//引数の数字の分ライフを増やすメソッド。
	public void AddLife(int addNum) {
		life += addNum;
		Debug.Log("Add Life:" + addNum + ", Now Life:" + life);
	}

	//コメントを入れられるオーバーロードメソッド。
	public void AddLife(int addNum, string comment) {
		life += addNum;
		Debug.Log("Add Life:" + addNum + ", Now Life:" + life + ", Comment:\"" + comment + "\"");
	}

	//クラッシュ処理
	public void Crash() {
		if (gameTime_nowPlay - deployedTime <= replayableTime || replayable) {//リプレイ処理
			Debug.Log("Re-Deploy");
			gameState = GameState.ReDeploying;
			BallSpown();
		} else {//クラッシュ処理
			AddScore(10000, "Crash Bonus, Now play time:" + gameTime_nowPlay);
			life -= 1;
			OnStandby();
			gameTime_nowPlay = 0f;
			jackpotEnable = false;
			jackpotScore = 0;
			if (!bonusHold) { bonusScore = 0; }
			bonusHold = false;
		}
	}

	//ゲームオーバー処理
	public void Gameover() {
		Debug.Log("Gameover!! Score:" + score);
		Debug.Log("Play time: " + gameTime_whole);
	}
}