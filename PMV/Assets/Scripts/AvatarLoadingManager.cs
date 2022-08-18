using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarLoadingManager : MonoBehaviour
{
    [SerializeField] GameObject MalePlayerGrp,FemalePlayerGrp;
    [SerializeField] GameObject Avatar,MaleDefaultAvatar,FemaleDefaultAvatar;
    [SerializeField] GameObject CameraTemp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (AvatarHolderManager.instance != null && Avatar==null) {
            if (AvatarHolderManager.instance.MaleAvatar) {
                Destroy(MaleDefaultAvatar.gameObject);

                Avatar = AvatarHolderManager.instance.avatar;
                if (Avatar.GetComponent<Animator>() != null) Avatar.GetComponent<Animator>().enabled = false;
                Avatar.transform.SetParent(MalePlayerGrp.transform);
                Avatar.transform.localPosition = Vector3.zero;
                // PlayerGrp.GetComponent<Animator>().enabled = false;
                MalePlayerGrp.SetActive(false);

            } else {
                Destroy(FemaleDefaultAvatar.gameObject);

                Avatar = AvatarHolderManager.instance.avatar;
                if (Avatar.GetComponent<Animator>() != null) Avatar.GetComponent<Animator>().enabled = false;
                Avatar.transform.SetParent(FemalePlayerGrp.transform);
                Avatar.transform.localPosition = Vector3.zero;
                // PlayerGrp.GetComponent<Animator>().enabled = false;
                FemalePlayerGrp.SetActive(false);

            }

        }
        if (Avatar!=null && !MalePlayerGrp.activeInHierarchy && AvatarHolderManager.instance.MaleAvatar) {
            StartCoroutine(EnableMalePlayerObject());
        }else if (Avatar!=null && !FemalePlayerGrp.activeInHierarchy && !AvatarHolderManager.instance.MaleAvatar) {
            StartCoroutine(EnableFemalePlayerObject());
        }
    }
    IEnumerator EnableMalePlayerObject() {
        yield return new WaitForSeconds(2f);
        MalePlayerGrp.SetActive(true);
        CameraTemp.SetActive(false);
    }
    IEnumerator EnableFemalePlayerObject() {
        yield return new WaitForSeconds(2f);
        FemalePlayerGrp.SetActive(true);
        CameraTemp.SetActive(false);

    }
}
