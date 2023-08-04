using UnityEngine;

public class MenuFallingScript : MonoBehaviour
{
    //Min and max for player pos
    [SerializeField] float _minY = -0.541f, _maxY = 3f;
    [SerializeField] float _minX = -0.241f, _maxX = 0.247f;

    //Min and max for player scale
    [SerializeField] float _minScaleY = 0.00560757f, _maxScaleY = 0.0137812f;
    [SerializeField] float _minScaleX = 0.00360757f, _maxScaleX = 0.0137812f;

    //Aspect ratio variables
    float _originalScaleX;
    float _aspectRatio;

    //Move speed
    [SerializeField] float _movesSpeed =0.5f;

    //Rotation Variables
    [SerializeField] float _rotationSpeed = 90f;
    float _currentRotationZ;

    //Player Vectors
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
        _position.y -= _movesSpeed * Time.deltaTime; //Make cube fall
        
        if (_position.y < _minY) //Reset params when cube reaches threshold
        {
            _position.y = _maxY;
            _position.x = Random.Range(_minX, _maxX); //Reset X pos

            _originalScaleX = Random.Range(_minScaleX, _maxScaleX); //Reset X scale
        }
        
        _currentRotationZ += _rotationSpeed * Time.deltaTime; //Increment the rotation speed
        _currentRotationZ %= 360f; //Clam rotation between 0 - 360

        float newScaleY = _originalScaleX * _aspectRatio; // Calculate the corresponding scale.y to maintain aspect ratio

        //Apply position, scale, and rotation
        transform.position = _position;
        transform.localScale = new Vector3(_originalScaleX, newScaleY, transform.localScale.z);
        transform.rotation = Quaternion.Euler(0f, 0f, _currentRotationZ);
    }
}
