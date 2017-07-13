using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class body : MonoBehaviour {

    private head theHead;
    public GameObject TheLast;

    public Vector3 LastPosition;
    public int Idx;

    // Use this for initialization
    void Start()
    {
        theHead = GameObject.Find("head").GetComponent<head>();
        LastPosition = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
		if(theHead.clock > theHead.interval)
        {
            if (TheLast.tag == "body")
            {
                transform.position = TheLast.GetComponent<body>().LastPosition;
            }
            else
            {
                transform.position = theHead.LastPosition;
            }
            
        }
        else
        {
            LastPosition = transform.position;
        }
	}
}
