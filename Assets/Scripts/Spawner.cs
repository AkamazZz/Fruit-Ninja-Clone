using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _fruitToSpawn;
    [SerializeField] private GameObject _bombPrefab;
    [SerializeField] private int _chanceToSpawnBomb = 10;
    [SerializeField] private int _numOfSpawnPlaces = 1;
    [SerializeField] private List<Transform> _spawnPlaces;
    [SerializeField] private float _minSpawnRate = 0.3f;
    [SerializeField] private float _maxSpawnRate = 1f;
    [SerializeField] private float _minForce = 10f;
    [SerializeField] private float _maxForce = 20f;

    // Start is called before the first frame update
    private void createSpawnPlaces()
    {
        _spawnPlaces = new List<Transform>();
       
        for (int i = 0; i < _numOfSpawnPlaces; i++)
        {
            GameObject val = new GameObject();
            val.transform.position = new Vector3(Random.Range(-13, 10), -10, 0); // X Y Z
            val.transform.rotation =  Quaternion.Euler(0, 0f, Random.Range(-25f, 25f));
            val.transform.name = $"Spawn Place {(i+1)}";
            _spawnPlaces.Add(val.transform);

        }
    }
    
    void Start()
    {
        createSpawnPlaces();
        StartCoroutine(SpawnFruits());
    }

    private GameObject GetFruitOrBomb()
    {
        float randomRange = Random.Range(0, 100);
        if(randomRange <= _chanceToSpawnBomb)
        {
            return _bombPrefab;
        }
        else
        {
            return _fruitToSpawn[Random.Range(0,_fruitToSpawn.Length)];
        }
    }
    private void isEqualToPrevious(ref int CurNumber, int prevNumber, int lenght)
    {
        if(prevNumber == CurNumber && CurNumber != lenght)
        {
                CurNumber += 1;
        }else if (prevNumber == CurNumber && CurNumber == lenght)
        {
            CurNumber = 0;
        }
        
    }
    private IEnumerator SpawnFruits()
    {
        int placeListLenght = _spawnPlaces.Count;
        int previousPlace = -1;
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(_minSpawnRate, _maxSpawnRate));
            int placeToUse = Random.Range(0, placeListLenght);
            isEqualToPrevious(ref placeToUse, previousPlace, placeListLenght);
            Transform place = _spawnPlaces[placeToUse];
            GameObject prefabToSpawn = GetFruitOrBomb();
            GameObject spawnObject = Instantiate(prefabToSpawn, place.transform.position, prefabToSpawn.transform.rotation);
            spawnObject.GetComponent<Rigidbody>().AddForce(place.up * Random.Range(_minForce,_maxForce), ForceMode.Impulse);
            Debug.Log("Brih");
            Destroy(spawnObject,6);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
