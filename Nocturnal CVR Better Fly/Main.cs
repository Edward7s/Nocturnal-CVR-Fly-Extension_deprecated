using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MelonLoader;
using UnityEngine;

namespace Nocturnal
{
    public class Main : MelonMod
    {
        public override void OnApplicationStart() => MelonCoroutines.Start(WaitForUi());      
        private static IEnumerator WaitForUi()
        {
            while (GameObject.Find("/Cohtml") == null)
                yield return null;
            new GameObject("Fly Extention N").AddComponent<UpdateManager>().gameObject.transform.parent = GameObject.Find("/Cohtml").transform;       
        }

    }
  
}
