using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MainSystemScript : MonoBehaviour
{
    private const int maxLife = 30;
    private int life = maxLife;
    private long score = 0;
    [SerializeField] private GameObject spawner;
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private Text lifeText;
    [SerializeField] private Text scoreText;
    public Text timeNow;
    public Text timeWhole;
    private float gameTimeWhole = 0f;
    private float gameTimeNowPlay = 0f;
    public GameState gameState;
    private float deployedTime;
    private bool replayable = false;
    private const float ReplayableTime = 15f;
    public int fieldMultiplyRate = 1;
    public int awardMultiplyRate = 1;
    public bool jackpotEnable = false;
    public bool bonusEnable = false;
    public bool bonusHold = false;
    private long jackpotScore = 0;
    private long bonusScore = 0;
    public List<ControllerBasicScript> controllers;

    public enum GameState
    {
        OnStandby,
        ReDeploying,
        Playing
    }

    private void Start()
    {
        OnStandby();
    }

    private void OnStandby()
    {
        gameState = GameState.OnStandby;
        CanvasUpdate();
        controllers.ForEach(x => x.ResetMethod());
        if (life > 0)
        {
            BallSpawn();
        }
        else if (life == 0)
        {
            GameOver();
        }
    }

    //ボールをスタート地点に生成するメソッド
    private void BallSpawn()
    {
        Instantiate(ballPrefab, spawner.transform.position, Quaternion.identity);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F2))
        {
            GameReset();
        }

        if (gameState == GameState.Playing)
        {
            gameTimeNowPlay += Time.deltaTime;
            gameTimeWhole += Time.deltaTime;
            CanvasUpdate();
        }
    }

    public void Deployed()
    {
        if (gameState != GameState.Playing)
        {
            gameState = GameState.Playing;
            deployedTime = gameTimeNowPlay;
            Debug.Log("Deployed time: " + deployedTime);
        }
    }

    private void CanvasUpdate()
    {
        scoreText.text = "Score: " + score;
        lifeText.text = "Life: " + life;
        timeNow.text = "Time(now): " + gameTimeNowPlay.ToString("0.0");
        timeWhole.text = "Time(whole): " + gameTimeWhole.ToString("0.0");
    }

    //引数の数字の分スコアに加算するメソッド。第2引数に文字列を入れることでデバッグ出力にコメントを入れられる
    public void AddScore(long addPoint, string comment = "")
    {
        long actuallyAddPoint = addPoint * fieldMultiplyRate;
        score += actuallyAddPoint;
        if (jackpotEnable) jackpotScore = actuallyAddPoint;
        if (bonusEnable) bonusScore = actuallyAddPoint;
        Debug.Log("Add Score:" + actuallyAddPoint + ", Now Score:" + score + ", Comment:\"" + comment + "\"");
    }

    public void AwardJackpot()
    {
        AddScore(jackpotScore * awardMultiplyRate, "Jackpot Awarded");
        jackpotScore = 0;
    }

    public void AwardBonus()
    {
        AddScore(bonusScore * awardMultiplyRate, "Bonus Awarded");
    }

    //引数の数字の分ライフを増やすメソッド。
    public void AddLife(int addNum, string comment = "")
    {
        life += addNum;
        Debug.Log("Add Life:" + addNum + ", Now Life:" + life + ", Comment:\"" + comment + "\"");
    }

    //クラッシュ処理
    public void Crash()
    {
        bool replayableByTime = gameTimeNowPlay - deployedTime <= ReplayableTime;
        if (replayableByTime || replayable)
        {
            //リプレイ処理
            gameState = GameState.ReDeploying;
            BallSpawn();
            if (replayableByTime)
            {
                Debug.Log("Re-Deploy");
            }
            else
            {
                Debug.Log("Replay ball");
                replayable = false;
            }
        }
        else
        {
            //クラッシュ処理
            AddScore(10000, "Crash Bonus, Now play time:" + gameTimeNowPlay);
            life -= 1;
            OnStandby();
            gameTimeNowPlay = 0f;
            jackpotEnable = false;
            jackpotScore = 0;
            if (!bonusHold)
            {
                bonusScore = 0;
            }

            bonusHold = false;
        }
    }

    //ゲームオーバー処理
    private void GameOver()
    {
        Debug.Log("GameOver!! Score:" + score);
        Debug.Log("Play time: " + gameTimeWhole);
    }


    private void GameReset()
    {
        Destroy(GameObject.FindWithTag("Ball"));
        life = maxLife;
        score = 0;
        gameTimeWhole = 0f;
        gameTimeNowPlay = 0f;
        replayable = false;
        fieldMultiplyRate = 1;
        awardMultiplyRate = 1;
        jackpotEnable = false;
        bonusEnable = false;
        bonusHold = false;
        jackpotScore = 0;
        bonusScore = 0;

        OnStandby();
    }
}
