using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monster : MonoBehaviour
{
	public GameObject explo; //宣告一個名為explo的物件
	public GameObject bigexplo; //宣告一個名為explo的物件

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		gameObject.transform.position += new Vector3(0, -0.01f, 0);
	}

	void OnTriggerEnter2D(Collider2D col) //名為col的觸發事件
	{
		if (col.tag == "Player" || col.tag == "Bullet" ) //如果碰撞的標籤是Ship或Bullet
		{
			Destroy(col.gameObject); //消滅碰撞的物件
			Destroy(gameObject); //消滅物件本身
			if (col.tag == "Bullet") //如果碰撞的標籤是Ship
			{
				Instantiate(explo, col.gameObject.transform.position, col.gameObject.transform.rotation);
				//在碰撞物件的位置產生爆炸，也就是在太空船的位置產生爆炸
			}
			if (col.tag == "Player") //如果碰撞的標籤是Ship
			{
				Instantiate(bigexplo, col.gameObject.transform.position, col.gameObject.transform.rotation);
				//在碰撞物件的位置產生爆炸，也就是在太空船的位置產生爆炸
			}
		}

	}
}
