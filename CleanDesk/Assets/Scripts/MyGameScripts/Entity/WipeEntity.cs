using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFrame
{
    public class WipeEntity : GameEntityBase
    {
        private Vector3 originP;
        private bool used = false;
        private int stainCount = 0;
        public override void EntityDispose()
        {

        }

        // Start is called before the first frame update
        void Awake()
        {
            
            GameEventCenter.AddEvent("ResetWipe", ResetWipe);
            originP = transform.position;
            transform.eulerAngles = new Vector3(-83.638f, 0, 0);
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void AddStain()
        {
            Debug.Log("XXX");
            stainCount++;
            used = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log(other.name);
            if (other.name == "Stain(Clone)")
            {
                stainCount--;
                GameEventCenter.DispatchEvent("Clean");
                GameEventCenter.DispatchEvent<AudioSelect>("PlayAudio", AudioSelect.Success);
                Destroy(other.gameObject);
            }

            //Debug.Log(stainCount);
            /*if (stainCount == 0)
            {
                GameEventCenter.DispatchEvent("GenerateStain");
            }*/
        }


        private void ResetWipe()
        {
            transform.position = originP;
        }
    }
}

