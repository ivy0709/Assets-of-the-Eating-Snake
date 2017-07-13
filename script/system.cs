using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class system : MonoBehaviour {

    private GameObject lastBody;

    public GameObject BodyPrefab;
    public List<GameObject> BodyList = new List<GameObject>();


	// Use this for initialization
	void Start () {
        lastBody = GameObject.Find("head");
        BodyList.Add(lastBody);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void CreateBody()
    {
        lastBody = (GameObject)Instantiate(BodyPrefab, BodyList[BodyList.Count - 1].transform.position, Quaternion.identity);
        lastBody.gameObject.GetComponent<body>().TheLast = BodyList[BodyList.Count - 1];
        lastBody.gameObject.GetComponent<body>().Idx = BodyList.Count;
        BodyList.Add(lastBody);
    }
}
