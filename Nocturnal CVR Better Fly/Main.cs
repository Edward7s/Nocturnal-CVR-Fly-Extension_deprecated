using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Nocturnal
{
#if ML
    using MelonLoader;
    public class Main : MelonMod
    {
        public static MelonPreferences_Entry<bool> jump;
        public static MelonPreferences_Entry<bool> keys;
        public static MelonPreferences_Entry<KeyCode> up;
        public static MelonPreferences_Entry<KeyCode> down;
        public override void OnApplicationStart()
        {
            MelonPreferences_Category Category = MelonPreferences.CreateCategory("NocturnalFly");
            jump = Category.CreateEntry("DobbleJump", true);
            keys = Category.CreateEntry("UpDownKeys", true);
            up = Category.CreateEntry("UpKey", KeyCode.E);
            down = Category.CreateEntry("DownKey", KeyCode.Q);
            MelonCoroutines.Start(WaitForUi());
        }
#else
    using BepInEx;
    using BepInEx.Configuration;
    [BepInPlugin("org.bepinex.plugins.Nocturnal.Fly", "Nocturnal Fly Extention", "1.1.0.0")]
    public class Main : BaseUnityPlugin
    {
        public static ConfigEntry<bool> jump;
        public static ConfigEntry<bool> keys;
        public static ConfigEntry<KeyCode> up;
        public static ConfigEntry<KeyCode> down;
        public void Awake()
        {
            jump = Config.Bind("Nocturnal.Fly", "Nocturnal.Fly.Jump", true);
            keys = Config.Bind("Nocturnal.Fly", "Nocturnal.Fly.Keys", true);
            up = Config.Bind("Nocturnal.Fly", "Nocturnal.Fly.Up", KeyCode.E);
            down = Config.Bind("Nocturnal.Fly", "Nocturnal.Fly.Down", KeyCode.Q);
            StartCoroutine(WaitForUi());
        }
#endif
        private static IEnumerator WaitForUi()
        {
            while (GameObject.Find("/Cohtml") == null)
                yield return null;
            new GameObject("Fly Extention N").AddComponent<UpdateManager>().gameObject.transform.parent = GameObject.Find("/Cohtml").transform;       
        }

    }
  
}
