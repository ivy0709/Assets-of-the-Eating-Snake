using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class system : MonoBehaviour {

    private GameObject lastBody;
    //private GameObject curBody;

    public GameObject BodyPrefab;
    public int CurBodyCounts;

	// Use this for initialization
	void Start () {
        lastBody = GameObject.Find("head");
        CurBodyCounts = 1;
    }
	// Update is called once per frame
	void Update () {
		
	}

    public void CreateBody()
    {
        GameObject curBody;
        Vector3 newPos = new Vector3(lastBody.transform.position.x, lastBody.transform.position.y, lastBody.transform.position.z);
        curBody = (GameObject)Instantiate(BodyPrefab, newPos, Quaternion.identity);
        curBody.gameObject.GetComponent<body>().TheLast = lastBody;
        curBody.gameObject.GetComponent<body>().Idx = ++CurBodyCounts;
        lastBody = curBody;
    }
}
