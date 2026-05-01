using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Main_scene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}