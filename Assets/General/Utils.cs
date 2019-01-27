using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils
{
    
    private static Utils instance;
    public static Utils Instance 
    {
        get 
        {
            if(instance == null) instance = new Utils();
            return instance;
        }
    }

    private Camera camera;

    public Utils()
    {
        camera = Camera.main;
    }

    public Vector2 GetCameraSize()
    {
        if(camera == null) camera = Camera.main;
        float vertical = camera.orthographicSize;
        float horizotal = vertical * camera.aspect;

        return new Vector2(horizotal, vertical);
    }

}
