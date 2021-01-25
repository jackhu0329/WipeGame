using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using GameFrame;

namespace GameFrame
{
    public class StainTask : TaskBase
    {
        private GameObject objStain,objWipe;
        private GameObject Spawn;

        private int stainCount = 0;

        private float high, mid, low;


        // Start is called before the first frame update
        public override IEnumerator TaskInit()
        {
            Debug.Log("TaskInit start");
            Spawn = GameObject.Find("Spawn");
            //objCup = GameEntityManager.Instance.GetCurrentSceneRes<MainSceneRes>().Cup.gameObject;
            objStain = GameEntityManager.Instance.GetCurrentSceneRes<MainSceneRes>().Stain.gameObject;
            objWipe = GameEntityManager.Instance.GetCurrentSceneRes<MainSceneRes>().Wipe.gameObject;

            GameEventCenter.AddEvent("GenerateStain", GenerateStain);
            GameEventCenter.AddEvent("GenerateWipe", GenerateWipe);
            GameEventCenter.AddEvent("Clean", Clean);

            Init();
            yield return null;
        }

        //public void 
        public override IEnumerator TaskStart()
        {


            yield return null;
        }


        public override IEnumerator TaskStop()
        {
            yield return null;
        }

        void SpawnLevel1()
        {
            for(int i = 0; i < 4; i++)
            {
                SpawnStain();

            }
        }

        void Init()
        {
            GenerateWipe();
            GenerateStain();
        }

        void SpawnStain()
        {
            Debug.Log("SpawnStain start");
            float biasX = Random.Range(-10, 10);
            float biasY = Random.Range(-10, 10);
            float biasZ = 0.5f;

            /*Vector3 p = new Vector3(Spawn1.transform.position.x+ biasX, Spawn1.transform.position.y+ biasY, Spawn1.transform.position.z+ biasZ);
            GameObject obj;
            Debug.Log(Random.Range(0, 4));
            obj.transform.eulerAngles = new Vector3(-90, 0, 0);*/
        }

        void GenerateStain()
        {
            float biasZ = Random.Range(0, 3);
            for (int x = 0; x < 22; x++)
            {
                float bias = Random.Range(-0.09f, 0.09f);

                GameObject.Instantiate(objStain, new Vector3(Spawn.transform.position.x-0.09f*x, Spawn.transform.position.y -0.18f , Spawn.transform.position.z  + biasZ*0.2f+ bias), Quaternion.identity);
                stainCount++;
            }


        }

        void GenerateWipe()
        {

            GameObject.Instantiate(objWipe, new Vector3(Spawn.transform.position.x-2.5f , Spawn.transform.position.y , Spawn.transform.position.z ), Quaternion.identity);

        }



        void Clean()
        {
            stainCount--;

            if (stainCount == 0)
            {
                GenerateStain();
                GameEventCenter.DispatchEvent<AudioSelect>("PlayAudio", AudioSelect.GetScore);
                GameEventCenter.DispatchEvent<bool>("MotionSuccess", true);
                GameEventCenter.DispatchEvent("GetScore");
                GameEventCenter.DispatchEvent("ResetHand");
                //GenerateWipe();
            }
        }





    }
}


