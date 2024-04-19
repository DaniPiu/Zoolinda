using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene("Menu");
    }

    public void FecharJogo()
    {
        Application.Quit();
    }
}
