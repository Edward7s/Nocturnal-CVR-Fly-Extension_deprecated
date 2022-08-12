using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx;
using UnityEngine;

namespace Nocturnal
{
    [BepInPlugin("org.bepinex.plugins.Nocturnal.Fly", "Nocturnal Fly Extention", "1.1.0.0")]
    public class Main : BaseUnityPlugin
    {
        public void Awake() => StartCoroutine(WaitForUi());      
        private static IEnumerator WaitForUi()
        {
            while (GameObject.Find("/Cohtml") == null)
                yield return null;
            new GameObject("Fly Extention N").AddComponent<UpdateManager>().gameObject.transform.parent = GameObject.Find("/Cohtml").transform;       
        }
    }
  
}
