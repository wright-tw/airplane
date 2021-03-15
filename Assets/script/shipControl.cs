using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipControl : MonoBehaviour
{
    public GameObject Bullet;
    public float time; //宣告浮點數，名稱time
    public float fireSpeed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.moveHandle();
        this.fireHandle();
    }

    private void moveHandle()
    {
        if (Input.GetKey(KeyCode.RightArrow)) {
            gameObject.transform.position += new Vector3(0.1f, 0, 0);
        }

        if (Input.GetKey(KeyCode.LeftArrow)) {
            gameObject.transform.position -= new Vector3(0.1f, 0, 0);
        }
    }

    private void fireHandle() 
    {
        // 連發
        time += Time.deltaTime; //時間增加
        
        if (Input.GetKey(KeyCode.Space))
        {
            if (time > fireSpeed)
            {
                Vector3 pos = gameObject.transform.position + new Vector3(0, 0.3f, 0);
                Instantiate(Bullet, pos, gameObject.transform.rotation);

                //時間歸零
                time = 0f;
            }
        }

        if (time > 10f) 
        {
            time = 0f;
        }
    }
}
