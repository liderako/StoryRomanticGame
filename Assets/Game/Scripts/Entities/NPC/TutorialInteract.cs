using Game.Scripts.UI.Tutorials;
using System;
using RPGBatler.Player;
using UnityEngine;

namespace RPGBatler.NPC
{
    public class TutorialInteract : MonoBehaviour
    {
        [SerializeField]
        private HintView TutorialHint;

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<PersonController>() != null)
            {
                this.TutorialHint.ChangeStateHint(true);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.GetComponent<PersonController>() != null)
            {
                this.TutorialHint.ChangeStateHint(false);
            }
        }
    }
}