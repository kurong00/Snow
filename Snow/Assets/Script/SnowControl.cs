using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SnowControl : MonoBehaviour {
    
    Renderer snowRenderer;
    float time = 0.0f;
	void Start () {
        snowRenderer = gameObject.GetComponent<Renderer>();
        if (gameObject.GetComponent<Renderer>() != null)
            snowRenderer.sharedMaterial.SetFloat("_SnowRank", 0.0f);
    }
	void Update () {
        time += Time.deltaTime;
        if (gameObject.tag == "BackGround")
        {
            snowRenderer.sharedMaterial.SetFloat("_SnowRank", time / 8000);
        }
        else if (gameObject.GetComponent<Renderer>() != null)
            snowRenderer.sharedMaterial.SetFloat("_SnowRank", time / 500);
    }

    public void ClearSnow()
    {
        SceneManager.LoadScene("Main");
    }

    public void AddSnowRank()
    {
        Time.timeScale = 2;
    }
}
