using System;
using UnityEngine;

namespace Turok
{
    public class OjosDinosaurio : MonoBehaviour
    {
        public Transform transOjos;

        public Action<Transform> OnFoundObject;

        public float rangoVision;
        public float radio;
        private LayerMask capaPlayer = 1 << 8;

        public void VerEntorno()
        {
            RaycastHit hit;
            if (Physics.SphereCast(transOjos.position, radio, transOjos.forward, out hit, rangoVision, capaPlayer, QueryTriggerInteraction.Ignore))
            {
                OnFoundObject(hit.transform);
            }
        }
    }
}

