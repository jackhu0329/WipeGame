using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFrame
{
    public class StainEntity : GameEntityBase
    {
        private int hp = 3;
        private ParticleSystem particleObj;
        public void Awake()
        {
            
            //transform.GetComponent<Outline>().enabled = false;
        }
        public override void EntityDispose()
        {

        }

        public void Update()
        {
            if (hp == 0)
            {
               /* GameEventCenter.DispatchEvent("ParticleStart",transform.position);
                GameEventCenter.DispatchEvent("GetScore");
                GameEventCenter.DispatchEvent("Del");
                GameEventCenter.DispatchEvent<AudioSelect>("PlayAudio", AudioSelect.GetScore);
                Destroy(this.gameObject);*/
            }
        }

        public void OnTriggerEnter(Collider other)
        {
            Debug.Log(other.name);
            if(other.name == "Wipe_1")
            {
                //Destroy(this.gameObject);
                //transform.GetComponent<Outline>().enabled = true;
            }
        }

        public void OnTriggerExit(Collider other)
        {
            /*if (other.name == "Wipe_1")
            {
                transform.GetComponent<Outline>().enabled = false;
                GameEventCenter.DispatchEvent<AudioSelect>("PlayAudio", AudioSelect.Success);
                hp--;
            }*/
        }

        public void OnTriggerStay(Collider other)
        {


        }

    }
}


