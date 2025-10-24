using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject _aboutUI;
    [SerializeField] GameObject _escUI;
    [SerializeField] bool _showUI;
    [SerializeField] bool _escControl;

    private void Update()
    {
        EscUI();
    }
    public void StartUI()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("Startttt");
    }
    public void AboutUI()
    {
        _showUI = !_showUI;
        if (_showUI)
        {
            Debug.Log("about1");
            _aboutUI.SetActive(true);
        }
        else if (!_showUI)
        {
            Debug.Log("about2");
            _aboutUI.SetActive(false);
        }
    }
    public void ExitUI()
    {
        Application.Quit();
        Debug.Log("Exitttt");
    }
    public void RestarUI()
    {
        _escControl = !_escControl;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("restarttt");

    }
    public void MainMenuUI()
    {
        SceneManager.LoadScene("StartScene");
    }
    public void EscUI()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _escControl = !_escControl;
            if (_escControl)
            {
                _escUI.SetActive(true);
                //Time.timeScale = 0f;
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;

            }
            else if (!_escControl)
            {
                _escUI.SetActive(false);
                //Time.timeScale = 1f;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }
}
