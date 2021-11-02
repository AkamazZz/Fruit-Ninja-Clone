using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Blade blade = other.GetComponent<Blade>();
        if (!blade)
        {
            return;
        }
        FindObjectOfType<GameManager>().OnBombHit();
    }
}
