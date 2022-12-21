using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    private ParticleSystem _particleSystem;
    private void Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();
    }
    void Update()
    {
        if (!_particleSystem.isPlaying) Destroy(gameObject);
    }
}
