using UnityEngine;

public class RightObjectController : MonoBehaviour,IInteractable
{
    [SerializeField] GameObject _nextSceneObject;
    public void Interact()
    {
        RightObject();
    }
    private void RightObject()
    {
        Debug.Log("AAAAAAAA");
        _nextSceneObject.SetActive(true);
    }
}
