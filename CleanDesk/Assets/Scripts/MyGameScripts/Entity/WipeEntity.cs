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
            GameEventCenter.DispatchEvent("AddStain");
            originP = transform.position;
            transform.eulerAngles = new Vector3(-83.638f, 0, 0);
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void AddStain()
        {
            stainCount++;
            used = true;
        }

        private void OnTriggerExit(Collider other)
        {
            if(other.name == "Stain(Clone)")
            {
                stainCount--;
                Destroy(other.gameObject);
            }

            if (stainCount == 0)
            {
                GameEventCenter.DispatchEvent("GenerateStain");
            }
        }
    }
}

