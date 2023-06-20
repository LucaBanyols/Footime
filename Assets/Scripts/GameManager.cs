using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject Left_Player;
    public GameObject Left_BonusFreezeActive;
    public GameObject Right_Player;
    public GameObject Right_BonusFreezeActive;

    public static GameObject ball;

    public static GameObject PlayerGoalText;

    public static float Left_Player_Speed = 3.0f;
    public static float Right_Player_Speed = 3.0f;

    private Sprite Left_playersprite;
    private Sprite Right_playersprite;

    private CharacterController Left_Controller;
    private CharacterController Right_Controller;

    public static int PlayerScore1 = 0;
	public static int PlayerScore2 = 0;
    public static GameObject PlayerLeftScore;
	public static GameObject PlayerRightScore;

    public static GameObject BonusSpawnPointUp;
    public static GameObject BonusSpawnPointMiddle;
    public static GameObject BonusSpawnPointDown;

    private static bool isScore = false;
    private static bool playerWin = false;

	public GUISkin layout;

    public static GameObject scoreCountDown;
    private static float countdownTimerDuration;
    private static float countdownTimerStartTime;

    void Start()
    {
        PlayerScore1 = 0;
        PlayerScore2 = 0;
        playerWin = false;
        isScore = false;
        CountdownTimerReset(4);
        ball = GameObject.FindGameObjectWithTag("Ball");
        PlayerGoalText = GameObject.FindGameObjectWithTag("PlayerGoalText");
        PlayerLeftScore = GameObject.FindGameObjectWithTag("PlayerLeftScore");
        PlayerRightScore = GameObject.FindGameObjectWithTag("PlayerRightScore");
        scoreCountDown = GameObject.FindGameObjectWithTag("scoreCountDown");
        BonusSpawnPointUp = GameObject.FindGameObjectWithTag("BonusSpawnPointUp");
        BonusSpawnPointMiddle = GameObject.FindGameObjectWithTag("BonusSpawnPointMiddle");
        BonusSpawnPointDown = GameObject.FindGameObjectWithTag("BonusSpawnPointDown");
        Left_playersprite = Left_Player.GetComponent<SpriteRenderer>().sprite;
        Right_playersprite = Right_Player.GetComponent<SpriteRenderer>().sprite;

        Left_Player.GetComponent<SpriteRenderer>().sprite = Left_playersprite;
        Right_Player.GetComponent<SpriteRenderer>().sprite = Right_playersprite;
    }

    void Update()
    {
        if (isScore == false)
        {
            if (Right_BonusFreezeActive.activeSelf == false)
            {
                Vector3 moveLeftPlayer = new Vector3(Input.GetAxis("HorizontalPlayer1"), Input.GetAxis("VerticalPlayer1"), 0 );
                moveLeftPlayer = moveLeftPlayer * Time.deltaTime * Left_Player_Speed;
                Left_Player.transform.position = Left_Player.transform.position + moveLeftPlayer;

                if (moveLeftPlayer != Vector3.zero)
                {
                    gameObject.transform.forward = moveLeftPlayer;
                }
            }

            if (Left_BonusFreezeActive.activeSelf == false)
            {
                Vector3 moveRightPlayer = new Vector3(Input.GetAxis("HorizontalPlayer2"), Input.GetAxis("VerticalPlayer2"), 0 );
                moveRightPlayer = moveRightPlayer * Time.deltaTime * Right_Player_Speed;
                Right_Player.transform.position = Right_Player.transform.position + moveRightPlayer;

                if (moveRightPlayer != Vector3.zero)
                {
                    gameObject.transform.forward = moveRightPlayer;
                }
            }
        }
        else
        {
            if (playerWin == false)
            {
                string timerMessage = "";
                int timeLeft = (int)CountdownTimerSecondsRemaining();
                if (timeLeft >= 0)
                {
                    timerMessage = timeLeft.ToString();
                    scoreCountDown.GetComponent<TMP_Text>().text = timerMessage;
                    if (timeLeft > 1)
                    {
                        Left_Player.transform.position = new Vector3(-7.2f, 0.0f, 0.0f);
                        Right_Player.transform.position = new Vector3(7.2f, 0.0f, 0.0f);
                    }
                }
                else
                {
                    PlayerGoalText.GetComponent<TMP_Text>().text = "";
                    scoreCountDown.GetComponent<TMP_Text>().text = "";
                    ball.GetComponent<Ball>().resetBall();
                    isScore = false;
                }
            }
        }
    }
    
    static void CountdownTimerReset(float delayInSeconds)
    {
        countdownTimerDuration = delayInSeconds;
        countdownTimerStartTime = Time.time;
    }

    float CountdownTimerSecondsRemaining()
    {
        float elapsedSeconds = Time.time - countdownTimerStartTime;
        float timeLeft = countdownTimerDuration - elapsedSeconds;
        return timeLeft;
    }

	public static void Score(string wallID)
    {
        if (isScore == false)
        {
            ball.GetComponent<Ball>().speed = 0.0f;
            CountdownTimerReset(4);
            if (wallID == "RightGoal")
            {
                PlayerScore1++;
                PlayerGoalText.GetComponent<TMP_Text>().text = "PLAYER 1 SCORE !!";
                PlayerLeftScore.GetComponent<TMP_Text>().text = PlayerScore1.ToString();
            }
            else
            {
                PlayerScore2++;
                PlayerGoalText.GetComponent<TMP_Text>().text = "PLAYER 2 SCORE !!";
                PlayerRightScore.GetComponent<TMP_Text>().text = PlayerScore2.ToString();
            }

            if (PlayerScore1 >= 3)
            {
                PlayerGoalText.GetComponent<TMP_Text>().text = "PLAYER 1 WIN !!";
                playerWin = true;
            }
            if (PlayerScore2 >= 3)
            {
                PlayerGoalText.GetComponent<TMP_Text>().text = "PLAYER 2 WIN !!";
                playerWin = true;
            }
            BonusSpawnPointUp.GetComponent<SpawnBonus>().DestroyBonus();
            BonusSpawnPointUp.GetComponent<SpawnBonus>().RespawnBonus();
            BonusSpawnPointMiddle.GetComponent<SpawnBonus>().RespawnBonus();
            BonusSpawnPointDown.GetComponent<SpawnBonus>().RespawnBonus();
            isScore = true;
        }
	}
}