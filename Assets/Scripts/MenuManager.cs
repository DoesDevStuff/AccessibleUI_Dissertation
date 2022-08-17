using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Button menuButton;
    [SerializeField] private GameObject menuOverlay;
    [SerializeField] private GameObject settingsPopupMenu;
    
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button returnToMenuButton;
    [SerializeField] private Button exitButton;
    
    [SerializeField] string mainMenuScene;
    [HideInInspector] public bool isPaused;

    [SerializeField] private Scene startScene;
    
    
    [SerializeField] private GameObject settingsMenu;
    

    private void Awake()
    {
        menuButton.onClick.AddListener(OpenSettingsPopup);
        
        resumeButton.onClick.AddListener(ResumeGame);
        settingsButton.onClick.AddListener(OpenSettings);
        returnToMenuButton.onClick.AddListener(ReturnToMain);
        exitButton.onClick.AddListener(ExitGame);
    }

    private void OpenSettings()
    {
        settingsMenu.SetActive(true);
    }

    private void ResumeGame()
    {
        settingsPopupMenu.SetActive(false);
        menuOverlay.SetActive(false);
        
        isPaused = false;
        Time.timeScale = 1f;
    }

    private void ExitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                OpenSettingsPopup();

            }
        }
    }

    private void OpenSettingsPopup()
    {
        isPaused = true;
        settingsPopupMenu.SetActive(true);
        menuOverlay.SetActive(true);
        Time.timeScale = 0f; // freeze the game scene
    }

    private void ReturnToMain()
    {
        Time.timeScale = 1f; // set timescale back to 1 or normal
        SceneManager.LoadScene(mainMenuScene);
    }
}
