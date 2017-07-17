using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class head : MonoBehaviour {

    /// <summary>
    /// 每隔多长事件运动一次，关卡变难就减少
    /// </summary>
    public float interval = 0.3F;
    public float clock = 0.0F;
    public Vector3 LastPosition;


    private system ss;
    /// <summary>
    /// 每次移动 移动的距离 固定不变的
    /// </summary>
    private float step = 0.6F; 
    private struct direction
    {
       public int x;
       public int y;
    }
    private direction curDir;
    // Use this for initialization
    void Start () {
        // 找到主摄像头下面的 system脚本函数 
        ss = GameObject.Find("Main Camera").gameObject.GetComponent<system>();


        curDir.x = 0;
        curDir.y = 1;
        step = GetComponent<SpriteRenderer>().sprite.bounds.size.x * transform.localScale.x;
        LastPosition = transform.position;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.W))
        {
			if (curDir.y == -1 && ss.CurBodyCounts > 1)
				return;
            curDir.x = 0;
            curDir.y = 1;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
			if (curDir.y == 1 && ss.CurBodyCounts > 1)
				return;			
            curDir.x = 0;
            curDir.y = -1;
        }
        else if(Input.GetKeyDown(KeyCode.A))
        {
			if (curDir.x == 1 && ss.CurBodyCounts > 1)
				return;
            curDir.x = -1;
            curDir.y = 0;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
			if (curDir.x == -1 && ss.CurBodyCounts > 1)
				return;
            curDir.x = 1;
            curDir.y = 0;
        }
        move();
	}

    private void move()
    {
        // 到达间隔的时间 
        if(clock > interval)
        {
            transform.position = new Vector3(transform.position.x + step*curDir.x,transform.position.y + step * curDir.y,0);
            clock = 0.0F;
        }
        else
        {
            LastPosition = transform.position;
            clock += Time.deltaTime;
        }
        
    }



    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "food")
        {
            float rx, ry;
            while (true)
            {
                rx = Random.Range(-11, 11);
                ry = Random.Range(-3, 3);
                if (Mathf.Abs(Vector3.Distance(new Vector3(rx, ry, 0), transform.position)) > 2)
                    break;
            }
            other.transform.position = new Vector3(rx, ry, 0);
            ss.CreateBody();
        }
        if (other.gameObject.tag == "body" && other.gameObject.GetComponent<body>().Idx > 2)
            SceneManager.LoadScene("main");
        if (other.gameObject.tag == "rock")
            SceneManager.LoadScene("main");
    }
}
