using UnityEngine.Networking;
using Newtonsoft.Json;
using UnityEngine;

public class GameServer: MonoBehaviour
{
	public static string domain = "http://127.0.0.1:1234";
	public static string loginUrl = "/reg-or-login";
	public static string scoreUrl = "/score";

	public static string LoginServer(string username, string password)
	{
		// 做表單參數
		WWWForm form = new WWWForm();
		form.AddField("username", username);
		form.AddField("password", password);

		string response = firePostRequest(domain + loginUrl, form);
		var responseData = JsonConvert.DeserializeObject<LoginResponse>(response);
		if (responseData.code == 1)
		{
			Debug.Log("RegDone");
			return responseData.data.token;
		}
		else
		{
			Debug.LogError("RegStatusError");
			return "";
		}

	}

	public static bool sendScoreToServer(string token, int score)
	{
		// 做表單參數
		WWWForm form = new WWWForm();
		form.AddField("token", token);
		form.AddField("score", score);

		string response = firePostRequest(domain + scoreUrl, form);

		var responseData = JsonConvert.DeserializeObject<EmptyDataResponse>(response);
		if (responseData.code == 1)
		{
			Debug.Log("sendScoreDone");
			return true;
		}
		else
		{
			Debug.LogError("sendScoreError");
			return false;
		}
	}

	protected static string firePostRequest(string url, WWWForm form)
	{
		// 製作請求物件
		UnityWebRequest request =  UnityWebRequest.Post(url, form);
		request.SendWebRequest();

		// 等待回覆
		while (! request.isDone) {}

		// 檢測有無網路錯誤
		if (
		    request.result == UnityWebRequest.Result.ConnectionError ||
		    request.result == UnityWebRequest.Result.ProtocolError
		) {
			Debug.LogError (request.error);
			return "";
		}

		// 處理回覆
		string response = request.downloadHandler.text;
		Debug.Log(response);

		return response;
	}
}