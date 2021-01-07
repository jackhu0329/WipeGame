using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StainManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Stain;
    private Vector3 originP,temp;
    float[] positionZ;
    float bias;
    void Start()
    {
        originP = transform.position;
        temp = originP;
        //Instantiate(Stain, new Vector3(temp.x, temp.y, temp.z), Quaternion.identity);
        positionZ = new float[3];
        positionZ[0] = 3.2f;
        positionZ[1] = 3f;
        positionZ[2] = 2.8f;
        GenerateStain();
        GameEventCenter.AddEvent("GenerateStain", GenerateStain);
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(Random.Range(0, 3));
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GenerateStain();
        }
    }

    void  GenerateStain()
    {
        float biasZ = positionZ[Random.Range(0, 3)];
        temp.z = biasZ;
        for (int x = 0; x < 22; x++)
        {
            bias = Random.Range(-0.06f, 0.06f);
            //Debug.Log(bias);
            Instantiate(Stain, new Vector3(temp.x, temp.y+0.45f, temp.z -6+ bias), Quaternion.identity);
            temp.x -= 0.09f;
        }

        temp = originP;
    }
}
