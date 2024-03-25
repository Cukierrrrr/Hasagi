using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sky : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    private float blue = 0.78f; 
    private bool reverse = false;

    
    void Update()
    {
        _camera.backgroundColor = new Color(0.478f, 0.447f, blue);

        if (reverse)
        {
            blue += 0.0001f;
        }
        else
        {
            blue -= 0.0001f;
        }

        if(blue >= 0.9f)
        {
            reverse = false;
        }
        else if(blue <= 0.7f)
        {
            reverse = true;
        }
        
    }
}
