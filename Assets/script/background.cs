using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //使用UI
using UnityEngine.SceneManagement;

public class background : MonoBehaviour
{
	public GameObject Emeny; // 宣告物件，名稱Emeny
	public float time; // 宣告浮點數，名稱time

	// 計分版
	public Text ScoreText; // 宣告一個ScoreText的text
	public int Score = 0; // 宣告一整數 Score
	public static background Instance; // 設定Instance，讓其他程式能讀取GameFunction裡的東西

	public GameObject GameTitle; //宣告GameTitle物件
	public GameObject GameOverTitle; //宣告GameOverTitle物件
	public GameObject PlayButton; //宣告PlayButton物件
	public bool IsPlaying = false; // 宣告IsPlaying 的布林資料，並設定初始值false

	public GameObject RestartButton; //宣告RestartButto的物件
	public GameObject QuitButton; //宣告QuitButton的物件
	public GameObject UsernameText;
	public GameObject PasswordText;
	public GameObject ToastBox;

	private string token = "";

	// Start is called before the first frame update
	void Start()
	{
		Instance = this;
		GameTitle.SetActive(true);
		GameOverTitle.SetActive(false);
		RestartButton.SetActive(false);
		QuitButton.SetActive(false);
		UsernameText.SetActive(true);
		PasswordText.SetActive(true);
	}

	// Update is called once per frame
	void Update()
	{
		monsterHandle();
	}

	public void AddScore(int addScore = 10)
	{
		Score += addScore; // 分數+10
		ScoreText.text = "Score: " + Score; // 更改ScoreText的內容
	}

	public void GameStart()
	{
		string usernameString = UsernameText.GetComponentInChildren<InputField>().text;
		string passwordString = PasswordText.GetComponentInChildren<InputField>().text;
		string token = GameServer.LoginServer(usernameString, passwordString);
		Debug.Log(token);
		if (token != "")
		{
			this.token = token;
			Toast.alert(ToastBox, "Login Done!");
			changeUIToPlay();
		}
		else
		{
			Toast.alert(ToastBox, "Login Fail!");
		}
	}

	public void changeUIToPlay()
	{
		IsPlaying = true; //設定IsPlaying為true，代表遊戲正在進行中
		GameTitle.SetActive (false); //不顯示GameTitle
		PlayButton.SetActive (false); //不顯示PlayButton
		QuitButton.SetActive (false); //不顯示QuitButton
		UsernameText.SetActive(false);
		PasswordText.SetActive(false);
	}

	public void ResetGame() //RestartButton的功能
	{
		// restart scene
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void QuitGame() //QuitButton的功能
	{
		Application.Quit(); //離開應用程式
	}


	public void GameOver() //GameOver的Function
	{
		IsPlaying = false; //IsPlaying設定成false，停止產生外星人
		GameOverTitle.SetActive(true); //設定為ture，顯示GameOverTitle
		RestartButton.SetActive(true); //RestartButton設定成顯示
		QuitButton.SetActive(true); //QuitButton設定成顯示

		// send score to server
		GameServer.sendScoreToServer(token, Score);
	}

	private void monsterHandle()
	{
		time += Time.deltaTime; //時間增加
		if (time > 0.5f && IsPlaying == true) //如果時間大於0.5(秒)
		{
			// 宣告位置pos，Random.Range(-2.5f,2.5f)代表X是2.5到-2.5之間隨機
			Vector3 pos = new Vector3(Random.Range(-5f, 5f), 4.5f, 0);

			// 產生敵人
			Instantiate(Emeny, pos, transform.rotation);

			//時間歸零
			time = 0f;
		}
	}
}


