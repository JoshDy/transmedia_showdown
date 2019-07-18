using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScreenResolution : MonoBehaviour {

    public bool maintainWidth = true; //Makes sure that the width of the scene adjusts to the resolution the player is using
    [Range(-1, 1)] //Sets the range of the integer below to between -1 and 1
    public int adaptPosition;

    float defaultWidth; //Stores the default width of the camera view
    float defaultHeight; //Stores the default height of the camera view

    Vector3 cameraPos; //Stores the position of the camera

    // Use this for initialization
    void Start()
    {

        cameraPos = Camera.main.transform.position; //Sets the position of the camera

        defaultHeight = Camera.main.orthographicSize; //Sets the height of the camera view
        defaultWidth = Camera.main.orthographicSize * Camera.main.aspect; //Sets the width of the camera view

    }

    // Update is called once per frame
    void Update()
    {

        if (maintainWidth) //Adjusts the height of the camera depending on the width of the resolution
        {

            Camera.main.orthographicSize = defaultWidth / Camera.main.aspect;
            Camera.main.transform.position = new Vector3(cameraPos.x, adaptPosition * (defaultHeight - Camera.main.orthographicSize), cameraPos.z);

        }

        else //Changes the width if it does not fit to the current resolution
        {

            Camera.main.transform.position = new Vector3(adaptPosition * (defaultWidth - Camera.main.orthographicSize * Camera.main.aspect), cameraPos.y, cameraPos.z);

        }

    }
}
