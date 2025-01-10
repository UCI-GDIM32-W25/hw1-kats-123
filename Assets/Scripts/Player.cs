using System.Numerics;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 1.0f;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private GameObject _plantPrefab;
    [SerializeField] private int _numSeeds = 5; 
    [SerializeField] private PlantCountUI _plantCountUI;

    private int _numSeedsLeft;
    private int _numSeedsPlanted;

    private void Start ()
    {
        _numSeedsLeft = _numSeeds;
    }

    private void Update()
    {
        float playerX = Input.GetAxis("Horizontal") * _speed;
        float playerY = Input.GetAxis("Vertical") * _speed;

        transform.position = transform.position +
        new UnityEngine.Vector3(playerX * Time.deltaTime, playerY * Time.deltaTime, 0);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            PlantSeed();
        }
    }

    public void PlantSeed ()
    {
        if (_numSeedsLeft > 0 && _numSeedsPlanted < 5)
        {
            UnityEngine.Vector3 playerSpawn = transform.position;
            Instantiate(_plantPrefab, playerSpawn, UnityEngine.Quaternion.identity);
            _numSeedsLeft -= 1;
            _numSeedsPlanted += 1;
            _plantCountUI.UpdateSeeds(_numSeedsLeft, _numSeedsPlanted);

        } else {
            print("No more seeds left");

        }
    }

}
