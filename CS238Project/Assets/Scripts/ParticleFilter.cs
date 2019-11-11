﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleFilter : MonoBehaviour
{
    // Random seed
    const int SEED = 1337; 

    // World boundary
    static float X_LEFT_BOUND = -10.0f;
    static float X_RIGHT_BOUND = 10.0f;
    static float Y_LOWER_BOUND = -5.0f;
    static float Y_UPPER_BOUND = 5.0f;

    // Particle properties
    public int num_particles = 100;
    public GameObject particlePrefab;
    private GameObject[] _beliefStates;
    private GameObject _particleParent;
    private float _lidar_precision_radians;

    // Lidar
    private Lidar _lidar_script;

    // Start is called before the first frame update
    void Start()
    {
        // Set random seed
        Random.InitState(SEED);

        // Get Lidar script
        _lidar_script = GetComponent<Lidar>();
        _lidar_precision_radians = _lidar_script.GetLidarPrecisionRadians();

        // Initialize particles
        _beliefStates = new GameObject[num_particles];
        _particleParent = new GameObject();
        _particleParent.name = gameObject.name + "_particleParent";
        for (int i = 0; i < num_particles; i++) {
            //Uniformly sample particles in the world
            float x = Random.Range(X_LEFT_BOUND, X_RIGHT_BOUND);
            float y = Random.Range(Y_LOWER_BOUND, Y_UPPER_BOUND);
            GameObject particle = Instantiate(particlePrefab, new Vector3(x, y, -2), Quaternion.identity);
            particle.transform.SetParent(_particleParent.transform);
            _beliefStates[i] = particle;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateBelief();
    }

    // Update belief state with new particles
    void UpdateBelief() {
        // Get observation from Lidar
        float[] agent_obseration = _lidar_script.GetDistanceObservation();
        
        
    }
}