using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Game.Scripts.UI.Interface;
using UnityEngine.UI;
using VIDE_Data; 

namespace Game.Scripts.UI
{
    public class DialogView : MonoBehaviour, IInteractableDialogView
    {
        [SerializeField] private GameObject dialogueContainer;
        [SerializeField] private GameObject NPC_Container;
        [SerializeField] private GameObject playerContainer;
        [SerializeField] private GameObject itemPopUp;

        [SerializeField] private Text NPC_Text;
        [SerializeField] private Text NPC_label;
        [SerializeField] private Image NPCSprite;
        [SerializeField] private GameObject playerChoicePrefab;
        [SerializeField] private Image playerSprite;
        [SerializeField] private Text playerLabel;

        private void Awake()
        {
            
        }

        private void Start()
        {
        }

        private void BeginDialog()
        {
            // NPC_Text.text = "";
            // NPC_label.text = "";
            // playerLabel.text = "";
            //
            // VD.OnActionNode += ActionHandler;
            // VD.OnNodeChange += UpdateUI;
            // VD.OnEnd += EndDialogue;
            //
            // VD.BeginDialogue(dialogue);
            //
            // dialogueContainer.SetActive(true); 
        }

        public void Interact(VIDE_Assign assign)
        {
            Debug.Log("all fine");
        }
    }
}