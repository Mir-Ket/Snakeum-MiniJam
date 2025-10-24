using UnityEngine;

public class RaycastControl : MonoBehaviour
{
    [SerializeField] float _raycastDistance;
    [SerializeField] GameObject _�nteractableUI;
    [SerializeField] bool _u�Controller;
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
                _u�Controller=true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactableObject.Interact();
                }
                if (_u�Controller)
                {
                    _�nteractableUI.gameObject.SetActive(true);
                }
            }

        }

        else
        {
            _u�Controller = false;
            Invoke(nameof(Delayer), 0.5f);

        }

    }
    private void Delayer()
    {

        if (!_u�Controller)
        {
        _�nteractableUI.gameObject.SetActive(false);
        }

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        if (_camera != null)
        {
            Gizmos.color = Color.green;

            // raycastin nerden ba�lay�p nereye vard���n� kontrol ediyoruz
            Vector3 _endPoint = _camera.transform.position + _camera.transform.forward * _raycastDistance;
            Gizmos.DrawLine(_camera.transform.position, _endPoint);
        }
    }


}
