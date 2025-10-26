using UnityEngine;
using UnityEngine.SceneManagement;

public class WrongObjectController : MonoBehaviour,IInteractable
{
    [SerializeField] GameObject _wrongObject;

    public void Interact()
    {
        WrongObject();
    }

    private void WrongObject()
    { 
        _wrongObject.SetActive(false);

        Invoke(nameof(Delay), 5f);
    }
    private void Delay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
