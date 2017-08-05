using UnityEngine;

public class Snow : MonoBehaviour {
    
    Renderer snowRenderer;
    SnowControl snowControl;
    float time = 0.0f;
	void Start () {
        snowControl = GameObject.Find("SnowControl").GetComponent<SnowControl>();
        snowRenderer = gameObject.GetComponent<Renderer>();
        if (gameObject.GetComponent<Renderer>() != null)
            snowRenderer.sharedMaterial.SetFloat("_SnowRank", 0.0f);
    }
	void Update () {
        Time.timeScale = snowControl.time + 1;
        time += Time.deltaTime + snowControl.time / 50;
        if (gameObject.tag == "BackGround")
        {
            snowRenderer.sharedMaterial.SetFloat("_SnowRank", time / 8000);
        }
        else if (gameObject.GetComponent<Renderer>() != null)
            snowRenderer.sharedMaterial.SetFloat("_SnowRank", time / 500);
    }
}
