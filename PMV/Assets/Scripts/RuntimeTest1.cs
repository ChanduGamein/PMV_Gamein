using ReadyPlayerMe;
using UnityEngine;


 public class RuntimeTest1 : MonoBehaviour    {
    [SerializeField]
    private string AvatarURL = "https://d1a370nemizbjq.cloudfront.net/28aa3030-18ce-428d-b0f1-5491e98f3b85.glb";
    [SerializeField] private string AvatarURL2 = "https://d1a370nemizbjq.cloudfront.net/209a1bc2-efed-46c5-9dfd-edc8a1d9cbe4.glb";
     private AvatarLoader avatarLoader;
     private GameObject avatar;

    private void Start()
        {
            Debug.Log($"Started loading avatar. [{Time.timeSinceLevelLoad:F2}]");
            AvatarLoader avatarLoader = new AvatarLoader();
        if (AvatarHolderManager.instance.MaleAvatar) {
            avatarLoader.LoadAvatar(AvatarURL, OnAvatarImported, OnAvatarLoaded);
        } else {
            avatarLoader.LoadAvatar(AvatarURL2, OnAvatarImported, OnAvatarLoaded);

        }
    }

    private void OnAvatarImported(GameObject avatar)
        {
            Debug.Log($"Avatar imported. [{Time.timeSinceLevelLoad:F2}]");
    }

    private void OnAvatarLoaded(GameObject avatar, AvatarMetaData metaData)
    {
            this.avatar = avatar;
            Debug.Log($"Avatar loaded. [{Time.timeSinceLevelLoad:F2}]\n\n{metaData}");
        AvatarHolderManager.instance.avatar = this.avatar;
        AvatarHolderManager.instance.LoadMetaverseScene();
        Debug.Log(avatar.GetComponent<Animator>().avatar.name);
       
    }
 }

