using UnityEngine;

public class Reader : MonoBehaviour, IInteractable
{
    [SerializeField] AudioSource _readerAudio;
    public void Interact()
    {
        ReaderControl();
    }

    private void ReaderControl()
    {
        _readerAudio.Play();
    }
}
