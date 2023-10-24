using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float speedcoin;
    private Vector3 rotation;

    // Start is called before the first frame update
    void Start()
    {
        rotation = new Vector3(45,0,0);

        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(rotation * speedcoin *Time.deltaTime);
        
    }
}
