using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Purchasing;
using TMPro;

public class IAPManager : MonoBehaviour, IStoreListener
{
    public static IAPManager instance;

    private static IStoreController m_StoreController;
    private static IExtensionProvider m_StoreExtensionProvider;

    //Step 1 create your products
    private string unlockAllPacks = "---";

    private string mania30x30 = "---";
    private string mania35x35 = "---";
    private string mania40x40 = "---";
    private string mania45x45 = "---";
    private string mania50x50 = "---";
    private string extremeJumbo = "---";
    private string interval2 = "---";
    private string extremeInterval = "---";
    private string jumboRectangle2 = "---";
    private string mirror4Way = "---";
    private string rotational4Way = "---";
    private string extremeNoSymmetry = "---";
    private string kids = "---";

    private string hints5 = "---";
    private string hints20 = "---";
    private string hints100 = "---";

    private string themeWater = "---";
    private string themeAkari = "---";
    private string themeLightOut = "---";
    private string themeExplosive = "---";
    private string themeMedieval = "---";
    private string unlockAllThemes = "---";

    private LightUp LightUpManager;
    public GameObject store, fromStore, freePlay, purchaseSuccessfulPopUp;
    private string[] packsNames =
    {
        "classicPackButton", "7x7ManiaButton", "10x10ManiaButton", "12x12ManiaButton", "14x14ManiaButton",
        "25x25ManiaButton", "30x30ManiaButton", "35x35ManiaButton", "40x40ManiaButton", "45x45ManiaButton",
        "50x50ManiaButton", "extremeJumboPackButton", "intervalPackButton", "intervalPack2Button", "extremeIntervalButton",
        "towerPackButton", "rectanglePackButton", "extremePackButton", "jumboPackButton", "jumboRectangleButton",
        "jumboRectangle2Button", "4-wayMirrorPackButton", "4-wayRotationalPackButton", "extremeNoSymmetryPackButton", "kidsPackButton"
    };
    private bool[] premiumPacksUnlocked;

    public GameObject getHintsPopUp;
    public Button viewAdButton;
    public TextMeshProUGUI hintsText;


    public void InitializePurchasing()
    {
        if (IsInitialized()) { return; }
        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

        builder.AddProduct(unlockAllPacks, ProductType.NonConsumable);

        builder.AddProduct(mania30x30, ProductType.NonConsumable);
        builder.AddProduct(mania35x35, ProductType.NonConsumable);
        builder.AddProduct(mania40x40, ProductType.NonConsumable);
        builder.AddProduct(mania45x45, ProductType.NonConsumable);
        builder.AddProduct(mania50x50, ProductType.NonConsumable);
        builder.AddProduct(extremeJumbo, ProductType.NonConsumable);
        builder.AddProduct(interval2, ProductType.NonConsumable);
        builder.AddProduct(extremeInterval, ProductType.NonConsumable);
        builder.AddProduct(jumboRectangle2, ProductType.NonConsumable);
        builder.AddProduct(mirror4Way, ProductType.NonConsumable);
        builder.AddProduct(rotational4Way, ProductType.NonConsumable);
        builder.AddProduct(extremeNoSymmetry, ProductType.NonConsumable);
        builder.AddProduct(kids, ProductType.NonConsumable);

        builder.AddProduct(hints5, ProductType.Consumable);
        builder.AddProduct(hints20, ProductType.Consumable);
        builder.AddProduct(hints100, ProductType.Consumable);

        builder.AddProduct(themeWater, ProductType.NonConsumable);
        builder.AddProduct(themeAkari, ProductType.NonConsumable);
        builder.AddProduct(themeLightOut, ProductType.NonConsumable);
        builder.AddProduct(themeExplosive, ProductType.NonConsumable);
        builder.AddProduct(themeMedieval, ProductType.NonConsumable);
        builder.AddProduct(unlockAllThemes, ProductType.NonConsumable);

        UnityPurchasing.Initialize(this, builder);
    }


    private bool IsInitialized()
    {
        return m_StoreController != null && m_StoreExtensionProvider != null;
    }


    public void BuyUnlockAllPacks()
    {
        BuyProductID(unlockAllPacks);
    }
    public void BuyMania30x30()
    {
        BuyProductID(mania30x30);
    }
    public void BuyMania35x35()
    {
        BuyProductID(mania35x35);
    }
    public void BuyMania40x40()
    {
        BuyProductID(mania40x40);
    }
    public void BuyMania45x45()
    {
        BuyProductID(mania45x45);
    }
    public void BuyMania50x50()
    {
        BuyProductID(mania50x50);
    }
    public void BuyExtremeJumbo()
    {
        BuyProductID(extremeJumbo);
    }
    public void BuyInterval2()
    {
        BuyProductID(interval2);
    }
    public void BuyExtremeInterval()
    {
        BuyProductID(extremeInterval);
    }
    public void BuyJumboRectangle2()
    {
        BuyProductID(jumboRectangle2);
    }
    public void BuyMirror4Way()
    {
        BuyProductID(mirror4Way);
    }
    public void BuyRotational4Way()
    {
        BuyProductID(rotational4Way);
    }
    public void BuyExtremeNoSymmetry()
    {
        BuyProductID(extremeNoSymmetry);
    }
    public void BuyKids()
    {
        BuyProductID(kids);
    }
    public void BuyHints5()
    {
        BuyProductID(hints5);
    }
    public void BuyHints20()
    {
        BuyProductID(hints20);
    }
    public void BuyHints100()
    {
        BuyProductID(hints100);
    }
    public void BuyThemeWater()
    {
        BuyProductID(themeWater);
    }
    public void BuyThemeAkari()
    {
        BuyProductID(themeAkari);
    }
    public void BuyThemeLightOut()
    {
        BuyProductID(themeLightOut);
    }
    public void BuyThemeExplosive()
    {
        BuyProductID(themeExplosive);
    }
    public void BuyThemeMedieval()
    {
        BuyProductID(themeMedieval);
    }
    public void BuyUnlockAllThemes()
    {
        BuyProductID(unlockAllThemes);
    }

    public void SavePlayer()
    {
        LightUpManager.SavePlayer();
    }

    private void VerifyIAPUnlock(int i)
    {
        LightUpManager.packsUnlocked[i] = true;
        SavePlayer();
        GameObject.Find("/CanvasStatic/store/container/Packs/" + packsNames[i]).transform.SetParent(GameObject.Find("/CanvasStatic/store/").transform, true);
        LightUpManager.UnloadStore();
        GameObject.Find("/CanvasStatic/store/" + packsNames[i]).SetActive(false);
        LightUpManager.LoadStore();
        LightUpManager.CanvasGroupChangerActive(true, purchaseSuccessfulPopUp);
        switch (i)
        {
            case 6: premiumPacksUnlocked[0] = true; break;
            case 7: premiumPacksUnlocked[1] = true; break;
            case 8: premiumPacksUnlocked[2] = true; break;
            case 9: premiumPacksUnlocked[3] = true; break;
            case 10: premiumPacksUnlocked[4] = true; break;
            case 11: premiumPacksUnlocked[5] = true; break;
            case 13: premiumPacksUnlocked[6] = true; break;
            case 14: premiumPacksUnlocked[7] = true; break;
            case 20: premiumPacksUnlocked[8] = true; break;
            case 21: premiumPacksUnlocked[9] = true; break;
            case 22: premiumPacksUnlocked[10] = true; break;
            case 23: premiumPacksUnlocked[11] = true; break;
            case 24: premiumPacksUnlocked[12] = true; break;
        }
        FindObjectOfType<AudioManager>().Play("confirmation_002");
    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
    {
        if (String.Equals(args.purchasedProduct.definition.id, unlockAllPacks, StringComparison.Ordinal))
        {
            int packID = 0;
            LightUpManager.packsUnlocked[6] = true;
            LightUpManager.packsUnlocked[7] = true;
            LightUpManager.packsUnlocked[8] = true;
            LightUpManager.packsUnlocked[9] = true;
            LightUpManager.packsUnlocked[10] = true;
            LightUpManager.packsUnlocked[11] = true;
            LightUpManager.packsUnlocked[13] = true;
            LightUpManager.packsUnlocked[14] = true;
            LightUpManager.packsUnlocked[20] = true;
            LightUpManager.packsUnlocked[21] = true;
            LightUpManager.packsUnlocked[22] = true;
            LightUpManager.packsUnlocked[23] = true;
            LightUpManager.packsUnlocked[24] = true;
            SavePlayer();
            for (int i=0; i<13; i++)
            {
                if (premiumPacksUnlocked[i] == false)
                {
                    switch (i)
                    {
                        case 0: packID = 6; break;
                        case 1: packID = 7; break;
                        case 2: packID = 8; break;
                        case 3: packID = 9; break;
                        case 4: packID = 10; break;
                        case 5: packID = 11; break;
                        case 6: packID = 13; break;
                        case 7: packID = 14; break;
                        case 8: packID = 20; break;
                        case 9: packID = 21; break;
                        case 10: packID = 22; break;
                        case 11: packID = 23; break;
                        case 12: packID = 24; break;
                    }
                    GameObject.Find("/CanvasStatic/store/container/Packs/" + packsNames[packID]).transform.SetParent(GameObject.Find("/CanvasStatic/store/").transform, true);
                }
            }
            LightUpManager.UnloadStore();
            for (int i = 0; i < 13; i++)
            {
                if (premiumPacksUnlocked[i] == false)
                {
                    switch (i)
                    {
                        case 0: packID = 6; break;
                        case 1: packID = 7; break;
                        case 2: packID = 8; break;
                        case 3: packID = 9; break;
                        case 4: packID = 10; break;
                        case 5: packID = 11; break;
                        case 6: packID = 13; break;
                        case 7: packID = 14; break;
                        case 8: packID = 20; break;
                        case 9: packID = 21; break;
                        case 10: packID = 22; break;
                        case 11: packID = 23; break;
                        case 12: packID = 24; break;
                    }
                    GameObject.Find("/CanvasStatic/store/" + packsNames[packID]).SetActive(false);
                }
            }
            GameObject.Find("/CanvasStatic/store/unlockAllPacksButton").SetActive(false);
            LightUpManager.LoadStore();
            LightUpManager.CanvasGroupChangerActive(true, purchaseSuccessfulPopUp);
            for (int i = 0; i < 13; i++)
                premiumPacksUnlocked[i] = true;
            FindObjectOfType<AudioManager>().Play("confirmation_002");
        }
        else if (String.Equals(args.purchasedProduct.definition.id, mania30x30, StringComparison.Ordinal))
        {
            VerifyIAPUnlock(6);
        }
        else if (String.Equals(args.purchasedProduct.definition.id, mania35x35, StringComparison.Ordinal))
        {
            VerifyIAPUnlock(7);
        }
        else if (String.Equals(args.purchasedProduct.definition.id, mania40x40, StringComparison.Ordinal))
        {
            VerifyIAPUnlock(8);
        }
        else if (String.Equals(args.purchasedProduct.definition.id, mania45x45, StringComparison.Ordinal))
        {
            VerifyIAPUnlock(9);
        }
        else if (String.Equals(args.purchasedProduct.definition.id, mania50x50, StringComparison.Ordinal))
        {
            VerifyIAPUnlock(10);
        }
        else if (String.Equals(args.purchasedProduct.definition.id, extremeJumbo, StringComparison.Ordinal))
        {
            VerifyIAPUnlock(11);
        }
        else if (String.Equals(args.purchasedProduct.definition.id, interval2, StringComparison.Ordinal))
        {
            VerifyIAPUnlock(13);
        }
        else if (String.Equals(args.purchasedProduct.definition.id, extremeInterval, StringComparison.Ordinal))
        {
            VerifyIAPUnlock(14);
        }
        else if (String.Equals(args.purchasedProduct.definition.id, jumboRectangle2, StringComparison.Ordinal))
        {
            VerifyIAPUnlock(20);
        }
        else if (String.Equals(args.purchasedProduct.definition.id, mirror4Way, StringComparison.Ordinal))
        {
            VerifyIAPUnlock(21);
        }
        else if (String.Equals(args.purchasedProduct.definition.id, rotational4Way, StringComparison.Ordinal))
        {
            VerifyIAPUnlock(22);
        }
        else if (String.Equals(args.purchasedProduct.definition.id, extremeNoSymmetry, StringComparison.Ordinal))
        {
            VerifyIAPUnlock(23);
        }
        else if (String.Equals(args.purchasedProduct.definition.id, kids, StringComparison.Ordinal))
        {
            VerifyIAPUnlock(24);
        }
        else if (String.Equals(args.purchasedProduct.definition.id, hints5, StringComparison.Ordinal))
        {
            VerifyHints(5);
        }
        else if (String.Equals(args.purchasedProduct.definition.id, hints20, StringComparison.Ordinal))
        {
            VerifyHints(20);
        }
        else if (String.Equals(args.purchasedProduct.definition.id, hints100, StringComparison.Ordinal))
        {
            VerifyHints(100);
        }
        else if (String.Equals(args.purchasedProduct.definition.id, themeWater, StringComparison.Ordinal))
        {
            VerifyThemes(0);
        }
        else if (String.Equals(args.purchasedProduct.definition.id, themeAkari, StringComparison.Ordinal))
        {
            VerifyThemes(1);
        }
        else if (String.Equals(args.purchasedProduct.definition.id, themeLightOut, StringComparison.Ordinal))
        {
            VerifyThemes(2);
        }
        else if (String.Equals(args.purchasedProduct.definition.id, themeExplosive, StringComparison.Ordinal))
        {
            VerifyThemes(3);
        }
        else if (String.Equals(args.purchasedProduct.definition.id, themeMedieval, StringComparison.Ordinal))
        {
            VerifyThemes(4);
        }
        else if (String.Equals(args.purchasedProduct.definition.id, unlockAllThemes, StringComparison.Ordinal))
        {
            LightUpManager.themeUnlocked0 = 1;
            LightUpManager.themeUnlocked1 = 1;
            LightUpManager.themeUnlocked2 = 1;
            LightUpManager.themeUnlocked3 = 1;
            LightUpManager.themeUnlocked4 = 1;
            LightUpManager.SavePlayer();
            purchaseSuccessfulPopUp.gameObject.SetActive(true);
            FindObjectOfType<AudioManager>().Play("confirmation_002");
            GameEvents.current.ThemeBoughtTriggerEnter();
            GameObject.Find("/CanvasStatic/themes/waterThemeButton/lockImage").SetActive(false);
            GameObject.Find("/CanvasStatic/themes/akariThemeButton/lockImage").SetActive(false);
            GameObject.Find("/CanvasStatic/themes/lightOutThemeButton/lockImage").SetActive(false);
            GameObject.Find("/CanvasStatic/themes/explosiveThemeButton/lockImage").SetActive(false);
            GameObject.Find("/CanvasStatic/themes/medievalThemeButton/lockImage").SetActive(false);
            GameObject.Find("/CanvasStatic/themes/unlockAllThemesButton").SetActive(false);
        }
        else
        {
            Debug.Log("Purchase Failed");
        }
        return PurchaseProcessingResult.Complete;
    }

    private void VerifyThemes(int themeID)
    {
        string themeUnlockedText = "";
        switch (themeID)
        {
            case 0: LightUpManager.themeUnlocked0 = 1; break;
            case 1: LightUpManager.themeUnlocked1 = 1; break;
            case 2: LightUpManager.themeUnlocked2 = 1; break;
            case 3: LightUpManager.themeUnlocked3 = 1; break;
            case 4: LightUpManager.themeUnlocked4 = 1; break;
        }        
        LightUpManager.SavePlayer();
        purchaseSuccessfulPopUp.gameObject.SetActive(true);
        FindObjectOfType<AudioManager>().Play("confirmation_002");
        switch (themeID)
        {
            case 0: themeUnlockedText = "waterThemeButton"; break;
            case 1: themeUnlockedText = "akariThemeButton"; break;
            case 2: themeUnlockedText = "lightOutThemeButton"; break;
            case 3: themeUnlockedText = "explosiveThemeButton"; break;
            case 4: themeUnlockedText = "medievalThemeButton"; break;
        }
        GameObject.Find("/CanvasStatic/themes/" + themeUnlockedText + "/lockImage").SetActive(false);
        if (LightUpManager.themeUnlocked0 == 1 && LightUpManager.themeUnlocked1 == 1 && LightUpManager.themeUnlocked2 == 1 &&
            LightUpManager.themeUnlocked3 == 1 && LightUpManager.themeUnlocked4 == 1)
            GameObject.Find("/CanvasStatic/themes/unlockAllThemesButton").SetActive(false);
        GameEvents.current.ThemeBoughtTriggerEnter();
    }

    private void VerifyHints(int bought)
    {
        LightUpManager.hints += bought;
        LightUpManager.boughtHints = true;
        LightUpManager.SavePlayer();
        getHintsPopUp.gameObject.SetActive(false);
        viewAdButton.gameObject.SetActive(false);
        purchaseSuccessfulPopUp.gameObject.SetActive(true);
        FindObjectOfType<AudioManager>().Play("confirmation_002");
        hintsText.text = LightUpManager.hints + " x";
        GameEvents.current.HintsBoughtTriggerEnter();
        GameEvents.current.AdsRemovedTriggerEnter();
    }

    private void Awake()
    {
        TestSingleton();
    }

    void Start()
    {
        if (m_StoreController == null) { InitializePurchasing(); }
        LightUpManager = GameObject.Find("GameManager").GetComponent<LightUp>();
        premiumPacksUnlocked = new bool[13];
        if (LightUpManager.packsUnlocked[6] == true) premiumPacksUnlocked[0] = true;
        if (LightUpManager.packsUnlocked[7] == true) premiumPacksUnlocked[1] = true;
        if (LightUpManager.packsUnlocked[8] == true) premiumPacksUnlocked[2] = true;
        if (LightUpManager.packsUnlocked[9] == true) premiumPacksUnlocked[3] = true;
        if (LightUpManager.packsUnlocked[10] == true) premiumPacksUnlocked[4] = true;
        if (LightUpManager.packsUnlocked[11] == true) premiumPacksUnlocked[5] = true;
        if (LightUpManager.packsUnlocked[13] == true) premiumPacksUnlocked[6] = true;
        if (LightUpManager.packsUnlocked[14] == true) premiumPacksUnlocked[7] = true;
        if (LightUpManager.packsUnlocked[20] == true) premiumPacksUnlocked[8] = true;
        if (LightUpManager.packsUnlocked[21] == true) premiumPacksUnlocked[9] = true;
        if (LightUpManager.packsUnlocked[22] == true) premiumPacksUnlocked[10] = true;
        if (LightUpManager.packsUnlocked[23] == true) premiumPacksUnlocked[11] = true;
        if (LightUpManager.packsUnlocked[24] == true) premiumPacksUnlocked[12] = true;
    }

    private void TestSingleton()
    {
        if (instance != null) { Destroy(gameObject); return; }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void BuyProductID(string productId)
    {
        if (IsInitialized())
        {
            Product product = m_StoreController.products.WithID(productId);
            if (product != null && product.availableToPurchase)
            {
                Debug.Log(string.Format("Purchasing product asychronously: '{0}'", product.definition.id));
                m_StoreController.InitiatePurchase(product);
            }
            else
            {
                Debug.Log("BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase");
            }
        }
        else
        {
            Debug.Log("BuyProductID FAIL. Not initialized.");
        }
    }

    public void RestorePurchases()
    {
        if (!IsInitialized())
        {
            Debug.Log("RestorePurchases FAIL. Not initialized.");
            return;
        }

        if (Application.platform == RuntimePlatform.IPhonePlayer ||
            Application.platform == RuntimePlatform.OSXPlayer)
        {
            Debug.Log("RestorePurchases started ...");

            var apple = m_StoreExtensionProvider.GetExtension<IAppleExtensions>();
            apple.RestoreTransactions((result) => {
                Debug.Log("RestorePurchases continuing: " + result + ". If no further messages, no purchases available to restore.");
            });
        }
        else
        {
            Debug.Log("RestorePurchases FAIL. Not supported on this platform. Current = " + Application.platform);
        }
    }

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        Debug.Log("OnInitialized: PASS");
        m_StoreController = controller;
        m_StoreExtensionProvider = extensions;
    }


    public void OnInitializeFailed(InitializationFailureReason error)
    {
        Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        Debug.Log(string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}", product.definition.storeSpecificId, failureReason));
    }
}