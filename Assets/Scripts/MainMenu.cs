using UnityEngine;


public class MainMenu : MonoBehaviour
{
    public AudioSource buttonClick;

    private void Start()
    {
        
    }

    public void OnStartDown()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Gameplay");
    }
}
