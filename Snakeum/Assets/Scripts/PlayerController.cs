using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
   
  
    [Header("Vector Settings")]
    [SerializeField] float _verticalSpeed;
    [SerializeField] float _horizontalSpeed;
    [SerializeField] Vector3 _moveDirection;

    [Header("Look Settings")]
    [SerializeField] float _lookLimitX=60;// fps oyunlar� i�in 60 veya 45 tir
    [SerializeField] float _lookSpeed;// fare hasasiyeti
    [SerializeField] float _rotationX;// x eksenindeki rotasyonnumuz kamera ve g�vdeyi birlikte d�nd�rmek i�in


    [Header("References Settings")]
    private Camera _camera;
    private CharacterController _characterController;


    [Header("Move Settings")]
    [SerializeField] float _walkSpeed;
    [SerializeField] float _runSpeed;
    [SerializeField] bool _isruning;

    [Header("Jump Settings")]
    [SerializeField] float _jumpForce;
    [SerializeField] float _gravity;
    [SerializeField] float _gravityDirectionPower;


    private void Awake()
    {
        // refarans al�yoruz
        _camera = Camera.main;
        _characterController = GetComponent<CharacterController>();

        // fareyi kililiyoruz ve gizliyoruz
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovementCalculate();
        Jump();
        Look();

        // karakterin y sini yani a�a�� yukar� de�erini gravityi direction powera e�itliyoruz e�er z�plam�yorsak yani gravity etkili olacak ama y de�eri 0 olacak
        _moveDirection.y = _gravityDirectionPower;

        // hareket veriyoruz time delta time olmadan yapma yoksa karakter u�ar
        _characterController.Move(_moveDirection * Time.deltaTime);
    }

    private void MovementCalculate()
    {
        // local transformun ileri geri sa�� solunu al�yor
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        // hareket h�z�m�z� bakt���m�z y�ne e�itliyoruz
        _moveDirection = (forward * _verticalSpeed) + (right * _horizontalSpeed);


        // ko�ma kontrolu
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _isruning = true;

        }
        else
        {
            _isruning = false;
        }
        // ko�muyorsa y�r�tme kontrol�
        if (_isruning)
        {
            _verticalSpeed = _runSpeed * Input.GetAxis("Vertical");
            _horizontalSpeed = _runSpeed * Input.GetAxis("Horizontal");
        }
        else
        {
            _verticalSpeed = _walkSpeed * Input.GetAxis("Vertical");
            _horizontalSpeed = _walkSpeed * Input.GetAxis("Horizontal");
        }
    }
    private void Jump()
    {
        if (_characterController.isGrounded)
        {
          ;

            // graviti direction power asl�nda yer �ekiminin tersine hareket uyguluyor bunu jump forcetan al�yor gravity direction power� gravitiden ��akr�nca z�pl�yor k�saca
            _gravityDirectionPower = -_gravity * Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _gravityDirectionPower = _jumpForce;
            }
        }
        else
        {
            _gravityDirectionPower -= _gravity * Time.deltaTime;

        }
    }
    private void Look()
    {
        _rotationX += -Input.GetAxis("Mouse Y") * _lookSpeed;
        _rotationX = Mathf.Clamp(_rotationX, -_lookLimitX, _lookLimitX);
        _camera.transform.localRotation = Quaternion.Euler(_rotationX, 0, 0);

        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * _lookSpeed, 0);
    }

}
