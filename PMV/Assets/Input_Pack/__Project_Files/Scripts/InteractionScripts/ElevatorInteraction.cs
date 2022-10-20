using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorInteraction : InteractableObject
{
    public override void OnInteraction(InteractionType interactionType, string tag, bool isStay = false)
    {
        if (interactionType == InteractionType.enter)
        {
            Scene1Manager.Instance.player.SetInteraction(() => {
                Scene1Manager.Instance.player.GetComponent<ThirdPersonController>().enabled = false;
                Scene1Manager.Instance.player.transform.SetParent(this.transform);
                Scene1Manager.Instance.Elevator.SetTrigger("Level1");
                StartCoroutine(ResetPlayer());  
            }, "Enter");
        }
        if (interactionType == InteractionType.exit)
        {
           

            Scene1Manager.Instance.player.HideInteractionUI();
        }
    }
    IEnumerator ResetPlayer()
    {
        yield return new WaitForSeconds(2f);
        Scene1Manager.Instance.Floor1Panel.SetActive(true);
        Scene1Manager.Instance.player.GetComponent<ThirdPersonController>().enabled = true;
        Scene1Manager.Instance.player.transform.parent = null;

    }

}
