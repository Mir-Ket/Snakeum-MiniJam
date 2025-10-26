using UnityEngine;

public class RightObjectController : MonoBehaviour,IInteractable
{

    [SerializeField] GameObject _nextSceneObject;
    [SerializeField] AudioSource _audioSource;
    public void Interact()
    {
        RightObject();
    }
    private void RightObject()
    {
        Debug.Log("AAAAAAAA");
        _nextSceneObject.SetActive(true);
        _audioSource.Play();
    }
}
