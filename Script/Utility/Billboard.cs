using UnityEngine;
using System.Collections;

namespace VArch.SDK.Utility
{
    public class Billboard : MonoBehaviour
    {
        [SerializeField]
        private Camera referenceCamera;

        private Vector3 initRot;

        [SerializeField]
        private bool invertDirection;

        [SerializeField]
        private bool x;

        [SerializeField]
        private bool y;

        [SerializeField]
        private bool z;

        private void Start()
        {
            if (!referenceCamera)
            {
                referenceCamera = Camera.main;
            }
        }

        void Awake()
        {
            initRot = transform.localRotation.eulerAngles;
        }

        //Orient the camera after all movement is completed this frame to avoid jittering
        void LateUpdate()
        {
            Vector3 dir = referenceCamera.transform.position - transform.position;
            Vector3 invertPos = referenceCamera.transform.position - (2 * dir);

            transform.LookAt(invertDirection ? invertPos : referenceCamera.transform.position, -transform.forward);

            Vector3 newRot = transform.localRotation.eulerAngles;

            transform.localRotation = Quaternion.Euler(
                    x ? newRot.x : initRot.x,
                    y ? newRot.y : initRot.y,
                    z ? newRot.z : initRot.z
                );
        }
    }
}