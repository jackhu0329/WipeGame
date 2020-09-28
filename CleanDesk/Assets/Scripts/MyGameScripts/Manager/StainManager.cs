using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StainManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Stain;
    private Vector3 originP,temp;
    float bias;
    void Start()
    {
        originP = transform.position;
        temp = originP;
        //Instantiate(Stain, new Vector3(temp.x, temp.y, temp.z), Quaternion.identity);
    
        for(int x = 0; x < 16; x++)
        {
            bias = Random.Range(-0.06f, 0.06f);
            Debug.Log(bias);
            Instantiate(Stain, new Vector3(temp.x, temp.y, temp.z+ bias), Quaternion.identity);
            temp.x -= 0.09f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
