using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VArch.SDK.Geometry;
using VArch.SDK.Utility;

namespace VArch.SDK.UI
{
    public class Tipbox : MonoBehaviour
    {
        [SerializeField]
        private GameObject tipboxUI;

        [SerializeField]
        private bool displayFromDistance;

        [SerializeField]
        private float displayDistance;

        private GameObject player;

        // Start is called before the first frame update
        void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player");

            if (!player)
            {
                throw new MissingReferenceException("Object with tag Player not found");
            }

            DisplayTipbox(false);
        }

        // Update is called once per frame
        void Update()
        {
            if (displayFromDistance)
            {
                DisplayTipbox(Measure.HorizontalDistance(player.transform.position, transform.position) < displayDistance);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag.Equals("Controller"))
            {
                DisplayTipbox(true);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag.Equals("Controller"))
            {
                DisplayTipbox(false);
            }
        }

        private void DisplayTipbox(bool display)
        {
            tipboxUI.SetActive(display);
        }

        public void SetActive(bool active)
        {
            displayFromDistance = active;
            tipboxUI.SetActive(active);
        }
    }
}