using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class AvatarHolderManager : MonoBehaviour {

    public static AvatarHolderManager instance {

        get; set;
    }
    public GameObject avatar;
    public bool MaleAvatar;
    [SerializeField] TMP_Dropdown AvatarSlectionDropDown;
    [SerializeField] GameObject RuntimeTestObject;
    private void Awake() {
        if (instance == null) {
            instance = this;

            DontDestroyOnLoad(this.gameObject);

        } else {
            Destroy(this.gameObject);

        }
    }

    // Update is called once per frame
    void Update() {

    }
    public void LoadMetaverseScene() {
        StartCoroutine(_SceneLoading());
    }

    IEnumerator _SceneLoading() {
        avatar.transform.SetParent(this.transform);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(1);

    }
    public void _AvatarSlectionDropDown() {
        if (AvatarSlectionDropDown.value == 1) {
            MaleAvatar = true;
        } else {
            MaleAvatar = false;

        }
        if (RuntimeTestObject!=null) {
            RuntimeTestObject.SetActive(true);
        }
        AvatarSlectionDropDown.gameObject.SetActive(false);
    }
}
