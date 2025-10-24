using UnityEngine;

public class RaycastControl : MonoBehaviour
{
    [SerializeField] float _raycastDistance;
    [SerializeField] GameObject _ýnteractableUI;
    [SerializeField] bool _uýController;
    private Camera _camera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastController();
    }
    private void RaycastController()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, _raycastDistance))
        {
            if (hit.collider.TryGetComponent(out IInteractable interactableObject))
            {
                _uýController=true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactableObject.Interact();
                }
                if (_uýController)
                {
                    _ýnteractableUI.gameObject.SetActive(true);
                }
            }

        }

        else
        {
            _uýController = false;
            Invoke(nameof(Delayer), 0.5f);

        }

    }
    private void Delayer()
    {

        if (!_uýController)
        {
        _ýnteractableUI.gameObject.SetActive(false);
        }

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        if (_camera != null)
        {
            Gizmos.color = Color.green;

            // raycastin nerden baþlayýp nereye vardýðýný kontrol ediyoruz
            Vector3 _endPoint = _camera.transform.position + _camera.transform.forward * _raycastDistance;
            Gizmos.DrawLine(_camera.transform.position, _endPoint);
        }
    }


}
