using UnityEngine;

public class PurchaseButton : MonoBehaviour
{
    public enum PurchaseType
    {
        unlockAllPacks, mania30x30, mania35x35, mania40x40, mania45x45, mania50x50, extremeJumbo, interval2,
        extremeInterval, jumboRectangle2, mirror4Way, rotational4Way, extremeNoSymmetry, kids, hints5, hints20, hints100
    };
    public PurchaseType purchaseType;

    public void ClickPurchaseButton()
    {
        switch (purchaseType)
        {
            case PurchaseType.unlockAllPacks:
                IAPManager.instance.BuyUnlockAllPacks();
                break;
            case PurchaseType.mania30x30:
                IAPManager.instance.BuyMania30x30();
                break;
            case PurchaseType.mania35x35:
                IAPManager.instance.BuyMania35x35();
                break;
            case PurchaseType.mania40x40:
                IAPManager.instance.BuyMania40x40();
                break;
            case PurchaseType.mania45x45:
                IAPManager.instance.BuyMania45x45();
                break;
            case PurchaseType.mania50x50:
                IAPManager.instance.BuyMania50x50();
                break;
            case PurchaseType.extremeJumbo:
                IAPManager.instance.BuyExtremeJumbo();
                break;
            case PurchaseType.interval2:
                IAPManager.instance.BuyInterval2();
                break;
            case PurchaseType.extremeInterval:
                IAPManager.instance.BuyExtremeInterval();
                break;
            case PurchaseType.jumboRectangle2:
                IAPManager.instance.BuyJumboRectangle2();
                break;
            case PurchaseType.mirror4Way:
                IAPManager.instance.BuyMirror4Way();
                break;
            case PurchaseType.rotational4Way:
                IAPManager.instance.BuyRotational4Way();
                break;
            case PurchaseType.extremeNoSymmetry:
                IAPManager.instance.BuyExtremeNoSymmetry();
                break;
            case PurchaseType.kids:
                IAPManager.instance.BuyKids();
                break;
            case PurchaseType.hints5:
                IAPManager.instance.BuyHints5();
                break;
            case PurchaseType.hints20:
                IAPManager.instance.BuyHints20();
                break;
            case PurchaseType.hints100:
                IAPManager.instance.BuyHints100();
                break;
        }
    }
}
