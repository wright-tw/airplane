using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background : MonoBehaviour
{
	public GameObject Emeny; //宣告物件，名稱Emeny
	public float time; //宣告浮點數，名稱time

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		this.monsterHandle();
	}

	private void monsterHandle()
	{
		time += Time.deltaTime; //時間增加
		if (time > 0.5f) //如果時間大於0.5(秒)
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
