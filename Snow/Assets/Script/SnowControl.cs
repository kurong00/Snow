using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SnowControl : MonoBehaviour {

    public Slider timeRank;
    [HideInInspector]
    public float time = 0.0f;

    public void ClearSnow()
    {
        SceneManager.LoadScene("Main");
    }

    public void UpdateTime()
    {
        time = timeRank.value;
    }

    public void Quit()
    {
        Application.Quit();
    }

}
