using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBehaviour : MonoBehaviour
{
    public DecayScript decay;
    public float decayRate;
    // Start is called before the first frame update
    void Start()
    {
        decay = FindObjectOfType<DecayScript>();
    }

    // Update is called once per frame
    void Update()
    {
        decay.health -= decayRate;
    }
}
