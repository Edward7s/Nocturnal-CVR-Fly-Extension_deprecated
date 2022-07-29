using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using ABI_RC.Systems.MovementSystem;
using ABI_RC.Core.Savior;
using ABI_RC.Core;

namespace Nocturnal
{
    internal class UpdateManager : MonoBehaviour
    {
        private float _time { get; set; }
        private int _flyCount { get; set; }
        private bool _isFlyng { get; set; }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton1))
                _flyCount++;
            if (_isFlyng)
            {
                if (Input.GetKey(KeyCode.Q))
                    RootLogic.Instance.localPlayerRoot.transform.position -= RootLogic.Instance.localPlayerRoot.transform.up / 30;
                if (Input.GetKey(KeyCode.E))
                    RootLogic.Instance.localPlayerRoot.transform.position += RootLogic.Instance.localPlayerRoot.transform.up / 30;

            }
            if (_flyCount == 0) return;
            _time += Time.smoothDeltaTime;
            if (_time > 0.7f)
            {
                _flyCount = 0;
                _time = 0;
            }
            else if (_flyCount > 1)
            {
                _isFlyng = !MovementSystem.Instance.flying;
                MovementSystem.Instance.ChangeFlight(!MovementSystem.Instance.flying);
                _flyCount = 0;
                _time = 0;
            }
        }
    }
}
