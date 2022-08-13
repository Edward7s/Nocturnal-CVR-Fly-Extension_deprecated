using UnityEngine;
using ABI_RC.Systems.MovementSystem;
using ABI_RC.Core;
using ABI.CCK.Components;
using ABI_RC.Core.Savior;
using Valve.VR;
using System;

namespace Nocturnal
{
    internal class UpdateManager : MonoBehaviour
    {
        private float _time { get; set; }
        private int _flyCount { get; set; }

        private bool _isToggled { get; set; } = true;
        void Update()
        {
            if (CVRInputManager.Instance.jump && _isToggled)
            {
                _isToggled = false;
                _flyCount++;
            }
            else if (!CVRInputManager.Instance.jump) _isToggled = true;
            if (MovementSystem.Instance.flying)
            {
                if (Input.GetKey(KeyCode.Q))
                    RootLogic.Instance.localPlayerRoot.transform.position -= RootLogic.Instance.localPlayerRoot.transform.up / (CVRInputManager.Instance.sprint ? 20 : 50);
                if (Input.GetKey(KeyCode.E))
                    RootLogic.Instance.localPlayerRoot.transform.position += RootLogic.Instance.localPlayerRoot.transform.up / (CVRInputManager.Instance.sprint ? 20 : 50);
            }
            if (_flyCount == 0) return;
            _time += Time.smoothDeltaTime;
            if (_time > 0.25f)
            {
                _flyCount = 0;
                _time = 0;
                _isToggled = true;
            }
            else if (_flyCount > 1)
            {
                MovementSystem.Instance.ChangeFlight(!MovementSystem.Instance.flying);
                _flyCount = 0;
                _time = 0;
            }
        }
    }
}
