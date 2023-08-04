using UnityEngine;

public class MenuFallingScript : MonoBehaviour
{
    //Min and max for player pos
    [Header("Position Clamp Parameters")]
    [Tooltip("Set min value for the Y position of the falling cube.")]
    [SerializeField] float _minY = -0.541f;
    [Tooltip("Set max value for the Y position of the falling cube.")]
    [SerializeField] float _maxY = 3f;
    [Tooltip("Set min value for the X position of the falling cube.")]
    [SerializeField] float _minX = -0.241f;
    [Tooltip("Set max value for the X position of the falling cube.")]
    [SerializeField] float _maxX = 0.247f;

    //Min and max for player scale
    [Header("Scale Clamp Parameters")]
    [Tooltip("Set min values for the Y scale of the falling cube.")]
    [SerializeField] float _minScaleY = 0.00560757f;
    [Tooltip("Set max values for the Y scale of the falling cube.")]
    [SerializeField] float _maxScaleY = 0.0137812f;
    [Tooltip("Set min values for the X scale of the falling cube.")]
    [SerializeField] float _minScaleX = 0.00360757f;
    [Tooltip("Set max values for the X scale of the falling cube.")]
    [SerializeField] float _maxScaleX = 0.0137812f;

    //Move speed
    [Header("Cube Fall Speed")]
    [Tooltip("Set the speed at which the cube falls.")]
    [SerializeField] float _moveSpeed =0.5f;

    //Rotation Variables
    [Header("Cube Rotation Speed")]
    [Tooltip("Set the speed at which the cube rotates.")]
    [SerializeField] float _rotationSpeed = 90f;
    float _currentRotationZ;

    //Aspect ratio variables
    const float _maxRotationAngle = 360f;
    float _originalScaleX;
    float _aspectRatio;

    //Cache position
    Vector2 _position;
    
    private void Start()
    {
        //Set random _position at the start of game
        _position = transform.position;
        _position.x = Random.Range(_minX, _maxX);

        _originalScaleX = Random.Range(_minScaleX, _maxScaleX); //Set random scale at the start of game
        _aspectRatio = transform.localScale.y / transform.localScale.x; //calculation to maintain aspect raio
    }

    //Update is called once per frame
    void Update()
    {
        _position.y -= _moveSpeed * Time.deltaTime; //Make cube fall
        
        if (_position.y < _minY) //Reset params when cube reaches threshold
        {
            _position.y = _maxY;
            _position.x = Random.Range(_minX, _maxX); //Reset X pos

            _originalScaleX = Random.Range(_minScaleX, _maxScaleX); //Reset X scale
        }
        
        _currentRotationZ += _rotationSpeed * Time.deltaTime; //Increment the rotation speed
        _currentRotationZ %= _maxRotationAngle; //Clam rotation between 0 - 360

        float newScaleY = _originalScaleX * _aspectRatio; // Calculate the corresponding scale.y to maintain aspect ratio

        //Apply position, scale, and rotation
        transform.position = _position;
        transform.localScale = new Vector3(_originalScaleX, newScaleY, transform.localScale.z);
        transform.rotation = Quaternion.Euler(0f, 0f, _currentRotationZ);
    }
}
