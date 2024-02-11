using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parController : MonoBehaviour
{
    Transform cam; // Main Cam
    Vector3 camStartPos;
    float distance; // dist b/w camera start and current pos

    GameObject[] backgrounds;
    Material[] mat;
    float[] backSpeed;
    float furtherstBack;

    [Range(0.01f,0.05f)]
    public float parallaxSpeed;


    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.transform;
        camStartPos = cam.position; // Initialise camStartPos

        int backCount = transform.childCount;
        mat = new Material[backCount];
        backSpeed = new float[backCount];
        backgrounds = new GameObject[backCount];

        for (int i = 0; i <backCount; i++)
        {
            backgrounds[i] = transform.GetChild(i).gameObject;
            mat[i] = backgrounds[i].GetComponent<Renderer>().material;
        }

        BackSpeedCalculate(backCount);
    }

    void BackSpeedCalculate(int backCount)
    {
        for (int i = 0; i <backCount; i++)  // finds furthest background
        {
            if ((backgrounds[i].transform.position.z - cam.position.z) > furtherstBack)
            {
                furtherstBack = backgrounds[i].transform.position.z - cam.position.z;
            }
        }

        for (int i = 0; i <backCount; i++)  // set background speeds
        {
            backSpeed[i] = 1 - (backgrounds[i].transform.position.z - cam.position.z) / furtherstBack;
        }
    }

    
    // LateUpdate is called after all Update functions have been called. 
    // This is useful to order script execution. 
    // For example a follow camera should always be implemented in LateUpdate 
    // because it tracks objects that might have moved inside Update.
    private void LateUpdate()
    {
        distance = cam.position.x - camStartPos.x;
        transform.position = new Vector3(cam.position.x, transform.position.y, 0);

        for (int i = 0; i < backgrounds.Length; i++)
        {
            float speed = backSpeed[i] * parallaxSpeed;
            mat[i].SetTextureOffset("_MainTex", new Vector2(distance, 0) * speed);
        }
    }
}
