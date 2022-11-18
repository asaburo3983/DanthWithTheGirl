using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRota : MonoBehaviour
{
    public Vector3 rota;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(rota);
    }
}
