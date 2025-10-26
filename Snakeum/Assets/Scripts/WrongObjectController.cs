using UnityEngine;
using UnityEngine.SceneManagement;

public class WrongObjectController : MonoBehaviour,IInteractable
{
    [SerializeField] GameObject _wrongObject;
    [SerializeField] AudioSource _audioSource;


    public void Interact()
    {
        WrongObject();
    }

    private void WrongObject()
    { 
        _wrongObject.SetActive(false);
        _audioSource.Play();
        Invoke(nameof(Delay), 5f);
    }
    private void Delay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
