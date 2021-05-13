using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    Transform pos;
    bool test;
    // Start is called before the first frame update
    void Start()
    {
        //transform.position = new Vector3()
        pos = transform;
        test = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (test)
        {
            pos.position = new Vector3(pos.position.x, pos.position.y - 10, pos.position.z);
            test = !test;
        }
    }
}
