using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowControl : MonoBehaviour {
    
    GameObject rocks;
	void Start () {
        if(gameObject.tag== "BackGround")
        {
            gameObject.GetComponent<Renderer>().
                sharedMaterial.SetFloat("_SnowRank", 0.00f);
        }
        else if(gameObject.GetComponent<Renderer>() != null)
            gameObject.GetComponent<Renderer>().
                sharedMaterial.SetFloat("_SnowRank", 0.0f);
    }
	void Update () {
		
	}
}
