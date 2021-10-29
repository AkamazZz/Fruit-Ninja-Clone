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
    [SerializeField] private int _scoreAmount;
    private GameManager _gameManager;

    public void CreateSlicedFruit()
    {
        GameObject instance = Instantiate(_slicedFruitPrefab, transform.position, transform.rotation);
        Rigidbody[] rigidBodyOnSliced = instance.transform.GetComponentsInChildren<Rigidbody>();


        foreach(Rigidbody body in rigidBodyOnSliced)
        {
            body.transform.rotation = Random.rotation;
            body.AddExplosionForce(Random.Range(500, 1000), transform.position, _explosionRadius);
        }
        _gameManager.IncreaseScore(_scoreAmount);
        Destroy(gameObject);
        Destroy(instance, 4);
    }

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }
    /* private void OnTriggerEnter2D(Collider2D collision)
     {
         Blade blade = collision.GetComponent<Blade>();
         if (!blade)
         {
             return;
         }
         CreateSlicedFruit();
     }*/
    private void OnTriggerEnter(Collider collision)
    {
        Blade blade = collision.GetComponent<Blade>();
        if (!blade)
        {
            return;
        }
        CreateSlicedFruit();
    }
}
