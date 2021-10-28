using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Type
{
    Banana,
    Apple,
    Watermelon,
    Coconut,
    Kiwi,
    Orange,
    Lemon,
    Pineapple
}

public class Fruit : MonoBehaviour
{
    [SerializeField] private GameObject _slicedFruitPrefab;
    [SerializeField] private float _explosionRadius = 5f;
    [SerializeField] private Type _type;
    public void CreateSlicedFruit()
    {
        GameObject instance = Instantiate(_slicedFruitPrefab, transform.position, transform.rotation);
        Rigidbody[] rigidBodyOnSliced = instance.transform.GetComponentsInChildren<Rigidbody>();


        foreach(Rigidbody body in rigidBodyOnSliced)
        {
            body.transform.rotation = Random.rotation;
            body.AddExplosionForce(Random.Range(500, 1000), transform.position, _explosionRadius);
        }
        Destroy(gameObject);
        Destroy(instance, 4);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreateSlicedFruit();
        }
    }
}
