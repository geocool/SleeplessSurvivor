using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeShopController : MonoBehaviour {

    Animator animator;
    public GameObject shopTrigger;
    public GameObject upgradeCamera;
    public GameObject upgradeCanvas;
    public GameObject hudCanvas;

    private UpgradeCameraController upgradeCameraController;
    private UpgradeShopTrigger upgradeShopTrigger;
    private bool shopActive = false;


    // Use this for initialization
    void Start()
    {
        animator = GameObject.Find("HUDCanvas").GetComponent<Animator>();
        upgradeShopTrigger = shopTrigger.GetComponent<UpgradeShopTrigger>();
        upgradeShopTrigger.UpgradeShopEnteredAreaEvent += showInfo;
        upgradeShopTrigger.UpgradeShopExitedAreaEvent += hideInfo;

        upgradeCameraController = upgradeCamera.GetComponent<UpgradeCameraController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
         if(Input.GetButtonDown("Action") && !shopActive && upgradeShopTrigger.isTriggered) {
            Debug.Log("Get To the shop");
            upgradeCamera.SetActive(true);
            upgradeCanvas.SetActive(true);
            hudCanvas.SetActive(false);
            shopActive = true;
        } else if (shopActive && Input.GetButtonDown("Back")) {
            upgradeCamera.SetActive(false);
            upgradeCanvas.SetActive(false);
            hudCanvas.SetActive(true);
            shopActive = false;
        }
    }

    void showInfo()
    {
        animator.SetTrigger("ShowInfo");
    }

    void hideInfo()
    {
        animator.SetTrigger("HideInfo");
    }
}
