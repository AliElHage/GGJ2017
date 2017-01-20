using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

// Deriving the Purchaser class from IStoreListener enables it to receive messages from Unity Purchasing.

public class Purchaser : MonoBehaviour, IStoreListener
{
    private static IStoreController m_StoreController;          // The Unity Purchasing system.
    private static IExtensionProvider m_StoreExtensionProvider; // The store-specific Purchasing subsystems.

    // Product identifiers for all products capable of being purchased: 
    // "convenience" general identifiers for use with Purchasing, and their store-specific identifier 
    // counterparts for use with and outside of Unity Purchasing. Define store-specific identifiers 
    // also on each platform's publisher dashboard (iTunes Connect, Google Play Developer Console, etc.)

    // General product identifiers for the consumable, non-consumable, and subscription products.
    // Use these handles in the code to reference which product to purchase. Also use these values 
    // when defining the Product Identifiers on the store. Except, for illustration purposes, the 
    // kProductIDSubscription - it has custom Apple and Google identifiers. We declare their store-
    // specific mapping to Unity Purchasing's AddProduct, below.
    public static string kProductIDMooMooJuiceConsumable = "MooMooJuice_consumable"; //Consumable
    public static string kProductIDMegaMooMooJuiceConsumable = "MegaMooMooJuice_consumable";
    public static string kProductIDBullCoatConsumable = "BullCoat_consumable";
    public static string kProductIDCowBellConsumable = "CowBell_consumable";
    public static string kProductIDXCubeAmount = "CubeAmount1_consumable"; //Cubes are the currency
    public static string kProductIDYCubeAmount = "CubeAmount2_consumable";
    public static string kProductIDZCubeAmount = "CubeAmount3_consumable";
    public static string kProductIDMachineGunUpgrade1 = "MachineGunUpgrade1"; //non-consumable
    public static string kProductIDMachineGunUpgrade2 = "MachineGunUpgrade2";
    public static string kProductIDLaserUpgrade1 = "LaserUpgrade1";
    public static string kProductIDLaserUpgrade2 = "LaserUpgrade2";
    public static string kProductIDGrenadeLauncherUpgrade1 = "GrenadeLauncherUpgrade1";
    public static string kProductIDGrenadeLauncherUpgrade2 = "GrenadeLauncherUpgrade2";
    public static string kProductIDTowerUpgrade1 = "TowerUpgrade1";
    public static string kProductIDTowerUpgrade2 = "TowerUpgrade2";
    public static string kProductIDSubscription = "subscription"; //subscription

    // Apple App Store-specific product identifier for the subscription product. MUST BE IDENTICAL TO ID ON ITUNES CONNECT.
    private static string kProductNameAppleMooMooJuice = "Moo-Moo_Juice"; //consumable
    private static string kProductNameAppleMegaMooMooJuice = "Mega_Moo-Moo_Juice";
    private static string kProductNameAppleBullCoat = "Bull_Coat";
    private static string kProductNameAppleCowBell = "Cow_Bell";
    private static string kProductNameAppleXCubeAmount = "X_Amount_Cubes";
    private static string kProductNameAppleYCubeAmount = "Y_Amount_Cubes";
    private static string kProductNameAppleZCubeAmount = "Z_Amount_Cubes";
    private static string kProductNameAppleMachineGunUpgrade1 = "Machine_Gun_Upgrade_1"; //non-consumable
    private static string kProductNameAppleMachineGunUpgrade2 = "Machine_Gun_Upgrade_2";
    private static string kProductNameAppleLaserUpgrade1 = "Laser_Upgrade_1";
    private static string kProductNameAppleLaserUpgrade2 = "Laser_Upgrade_2";
    private static string kProductNameAppleGrenadeLauncherUpgrade1 = "Grenade_Launcher_Upgrade_1";
    private static string kProductNameAppleGrenadeLauncherUpgrade2 = "Grenade_Launcher_Upgrade_2";
    private static string kProductNameAppleTowerUpgrade1 = "Tower_Upgrade_1";
    private static string kProductNameAppleTowerUpgrade2 = "Tower_Upgrade_2";
    private static string kProductNameAppleSubscription = "com.unity3d.subscription.new"; //subscription

    // Google Play Store-specific product identifier subscription product. MUST BE IDENTICAL TO ID ON ANDROID DEV CONSOLE.
    private static string kProductNameGooglePlayMooMooJuice = "Moo-Moo_Juice"; //consumable
    private static string kProductNameGooglePlayMegaMooMooJuice = "Mega_Moo-Moo_Juice";
    private static string kProductNameGooglePlayBullCoat = "Bull_Coat";
    private static string kProductNameGooglePlayCowBell = "Cow_Bell";
    private static string kProductNameGooglePlayXCubeAmount = "X_Amount_Cubes";
    private static string kProductNameGooglePlayYCubeAmount = "Y_Amount_Cubes";
    private static string kProductNameGooglePlayZCubeAmount = "Z_Amount_Cubes";
    private static string kProductNameGooglePlayMachineGunUpgrade1 = "Machine_Gun_Upgrade_1"; //non-consumable
    private static string kProductNameGooglePlayMachineGunUpgrade2 = "Machine_Gun_Upgrade_2";
    private static string kProductNameGooglePlayLaserUpgrade1 = "Laser_Upgrade_1";
    private static string kProductNameGooglePlayLaserUpgrade2 = "Laser_Upgrade_2";
    private static string kProductNameGooglePlayGrenadeLauncherUpgrade1 = "Grenade_Launcher_Upgrade_1";
    private static string kProductNameGooglePlayGrenadeLauncherUpgrade2 = "Grenade_Launcher_Upgrade_2";
    private static string kProductNameGooglePlayTowerUpgrade1 = "Tower_Upgrade_1";
    private static string kProductNameGooglePlayTowerUpgrade2 = "Tower_Upgrade_2";
    private static string kProductNameGooglePlaySubscription = "com.unity3d.subscription.original";

    void Start()
    {
        // If we haven't set up the Unity Purchasing reference
        if (m_StoreController == null)
        {
            // Begin to configure our connection to Purchasing
            InitializePurchasing();
        }
    }

    public void InitializePurchasing()
    {
        // If we have already connected to Purchasing ...
        if (IsInitialized())
        {
            // ... we are done here.
            return;
        }

        // Create a builder, first passing in a suite of Unity provided stores.
        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

        // Add a product to sell / restore by way of its identifier, associating the general identifier
        // with its store-specific identifiers.
        builder.AddProduct(kProductIDMooMooJuiceConsumable,ProductType.Consumable, new IDs() { { kProductNameAppleMooMooJuice, AppleAppStore.Name }, { kProductNameGooglePlayMooMooJuice, GooglePlay.Name } });
        builder.AddProduct(kProductIDMegaMooMooJuiceConsumable, ProductType.Consumable, new IDs() { { kProductNameAppleMegaMooMooJuice, AppleAppStore.Name }, { kProductNameGooglePlayMegaMooMooJuice, GooglePlay.Name } });
        builder.AddProduct(kProductIDBullCoatConsumable, ProductType.Consumable, new IDs() { { kProductNameAppleBullCoat, AppleAppStore.Name }, { kProductNameGooglePlayBullCoat, GooglePlay.Name } });
        builder.AddProduct(kProductIDCowBellConsumable, ProductType.Consumable, new IDs() { { kProductNameAppleCowBell, AppleAppStore.Name }, { kProductNameGooglePlayCowBell, GooglePlay.Name } });
        builder.AddProduct(kProductIDXCubeAmount, ProductType.Consumable, new IDs() { { kProductNameAppleXCubeAmount, AppleAppStore.Name }, { kProductNameGooglePlayXCubeAmount, GooglePlay.Name } });
        builder.AddProduct(kProductIDYCubeAmount, ProductType.Consumable, new IDs() { { kProductNameAppleYCubeAmount, AppleAppStore.Name }, { kProductNameGooglePlayYCubeAmount, GooglePlay.Name } });
        builder.AddProduct(kProductIDZCubeAmount, ProductType.Consumable, new IDs() { { kProductNameAppleZCubeAmount, AppleAppStore.Name }, { kProductNameGooglePlayZCubeAmount, GooglePlay.Name } });
        // Continue adding the non-consumable product.
        builder.AddProduct(kProductIDMachineGunUpgrade1, ProductType.NonConsumable, new IDs() { { kProductNameAppleMachineGunUpgrade1, AppleAppStore.Name }, { kProductNameGooglePlayMachineGunUpgrade1, GooglePlay.Name } });
        builder.AddProduct(kProductIDMachineGunUpgrade2, ProductType.NonConsumable, new IDs() { { kProductNameAppleMachineGunUpgrade2, AppleAppStore.Name }, { kProductNameGooglePlayMachineGunUpgrade2, GooglePlay.Name } });
        builder.AddProduct(kProductIDLaserUpgrade1, ProductType.NonConsumable, new IDs() { { kProductNameAppleLaserUpgrade1, AppleAppStore.Name }, { kProductNameGooglePlayLaserUpgrade1, GooglePlay.Name } });
        builder.AddProduct(kProductIDLaserUpgrade2, ProductType.NonConsumable, new IDs() { { kProductNameAppleLaserUpgrade2, AppleAppStore.Name }, { kProductNameGooglePlayLaserUpgrade2, GooglePlay.Name } });
        builder.AddProduct(kProductIDGrenadeLauncherUpgrade1, ProductType.NonConsumable, new IDs() { { kProductNameAppleGrenadeLauncherUpgrade1, AppleAppStore.Name }, { kProductNameGooglePlayGrenadeLauncherUpgrade1, GooglePlay.Name } });
        builder.AddProduct(kProductIDGrenadeLauncherUpgrade2, ProductType.NonConsumable, new IDs() { { kProductNameAppleGrenadeLauncherUpgrade2, AppleAppStore.Name }, { kProductNameGooglePlayGrenadeLauncherUpgrade2, GooglePlay.Name } });
        builder.AddProduct(kProductIDTowerUpgrade1, ProductType.NonConsumable, new IDs() { { kProductNameAppleTowerUpgrade1, AppleAppStore.Name }, { kProductNameGooglePlayTowerUpgrade1, GooglePlay.Name } });
        builder.AddProduct(kProductIDTowerUpgrade2, ProductType.NonConsumable, new IDs() { { kProductNameAppleTowerUpgrade2, AppleAppStore.Name }, { kProductNameGooglePlayTowerUpgrade2, GooglePlay.Name } });
        // And finish adding the subscription product. Notice this uses store-specific IDs, illustrating
        // if the Product ID was configured differently between Apple and Google stores. Also note that
        // one uses the general kProductIDSubscription handle inside the game - the store-specific IDs 
        // must only be referenced here. 
        builder.AddProduct(kProductIDSubscription, ProductType.Subscription, new IDs(){
            { kProductNameAppleSubscription, AppleAppStore.Name },
            { kProductNameGooglePlaySubscription, GooglePlay.Name },
        });

        // Kick off the remainder of the set-up with an asynchrounous call, passing the configuration 
        // and this class' instance. Expect a response either in OnInitialized or OnInitializeFailed.
        UnityPurchasing.Initialize(this, builder);
    }


    private bool IsInitialized()
    {
        // Only say we are initialized if both the Purchasing references are set.
        return m_StoreController != null && m_StoreExtensionProvider != null;
    }

    // CONSUMABLES //

    public void BuyMooMooJuice()
    {
        // Buy the consumable product using its general identifier. Expect a response either 
        // through ProcessPurchase or OnPurchaseFailed asynchronously.
        BuyProductID(kProductIDMooMooJuiceConsumable);
    }


    public void BuyMegaMooMooJuice()
    {
        BuyProductID(kProductIDMegaMooMooJuiceConsumable);
    }


    public void BuyBullCoat()
    {
        BuyProductID(kProductIDBullCoatConsumable);
    }


    public void BuyCowBell()
    {
        BuyProductID(kProductIDCowBellConsumable);
    }


    public void BuyXCubeAmount()
    {
        BuyProductID(kProductIDXCubeAmount);
    }


    public void BuyYCubeAmount()
    {
        BuyProductID(kProductIDYCubeAmount);
    }


    public void BuyZCubeAmount()
    {
        BuyProductID(kProductIDZCubeAmount);
    }

    // NON-CONSUMABLES //

    public void BuyMachineGunUpgrade1()
    {
        // Buy the non-consumable product using its general identifier. Expect a response either 
        // through ProcessPurchase or OnPurchaseFailed asynchronously.
        BuyProductID(kProductIDMachineGunUpgrade1);
    }


    public void BuyMachineGunUpgrade2()
    {
        BuyProductID(kProductIDMachineGunUpgrade2);
    }


    public void BuyLaserUpgrade1()
    {
        BuyProductID(kProductIDLaserUpgrade1);
    }


    public void BuyLaserUpgrade2()
    {
        BuyProductID(kProductIDLaserUpgrade2);
    }


    public void BuyGrenadeLauncherUpgrade1()
    {
        BuyProductID(kProductIDGrenadeLauncherUpgrade1);
    }


    public void BuyGrenadeLauncherUpgrade2()
    {
        BuyProductID(kProductIDGrenadeLauncherUpgrade2);
    }


    public void BuyTowerUpgrade1()
    {
        BuyProductID(kProductIDTowerUpgrade1);
    }


    public void BuyTowerUpgrade2()
    {
        BuyProductID(kProductIDTowerUpgrade2);
    }


    public void BuySubscription()
    {
        // Buy the subscription product using its the general identifier. Expect a response either 
        // through ProcessPurchase or OnPurchaseFailed asynchronously.
        // Notice how we use the general product identifier in spite of this ID being mapped to
        // custom store-specific identifiers above.
        BuyProductID(kProductIDSubscription);
    }


    void BuyProductID(string productId)
    {
        // If Purchasing has been initialized ...
        if (IsInitialized())
        {
            // ... look up the Product reference with the general product identifier and the Purchasing 
            // system's products collection.
            Product product = m_StoreController.products.WithID(productId);

            // If the look up found a product for this device's store and that product is ready to be sold ... 
            if (product != null && product.availableToPurchase)
            {
                Debug.Log(string.Format("Purchasing product asychronously: '{0}'", product.definition.id));
                // ... buy the product. Expect a response either through ProcessPurchase or OnPurchaseFailed 
                // asynchronously.
                m_StoreController.InitiatePurchase(product);
            }
            // Otherwise ...
            else
            {
                // ... report the product look-up failure situation  
                Debug.Log("BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase");
            }
        }
        // Otherwise ...
        else
        {
            // ... report the fact Purchasing has not succeeded initializing yet. Consider waiting longer or 
            // retrying initiailization.
            Debug.Log("BuyProductID FAIL. Not initialized.");
        }
    }


    // Restore purchases previously made by this customer. Some platforms automatically restore purchases, like Google. 
    // Apple currently requires explicit purchase restoration for IAP, conditionally displaying a password prompt.
    public void RestorePurchases()
    {
        // If Purchasing has not yet been set up ...
        if (!IsInitialized())
        {
            // ... report the situation and stop restoring. Consider either waiting longer, or retrying initialization.
            Debug.Log("RestorePurchases FAIL. Not initialized.");
            return;
        }

        // If we are running on an Apple device ... 
        if (Application.platform == RuntimePlatform.IPhonePlayer ||
            Application.platform == RuntimePlatform.OSXPlayer)
        {
            // ... begin restoring purchases
            Debug.Log("RestorePurchases started ...");

            // Fetch the Apple store-specific subsystem.
            var apple = m_StoreExtensionProvider.GetExtension<IAppleExtensions>();
            // Begin the asynchronous process of restoring purchases. Expect a confirmation response in 
            // the Action<bool> below, and ProcessPurchase if there are previously purchased products to restore.
            apple.RestoreTransactions((result) => {
                // The first phase of restoration. If no more responses are received on ProcessPurchase then 
                // no purchases are available to be restored.
                Debug.Log("RestorePurchases continuing: " + result + ". If no further messages, no purchases available to restore.");
            });
        }
        // Otherwise ...
        else
        {
            // We are not running on an Apple device. No work is necessary to restore purchases.
            Debug.Log("RestorePurchases FAIL. Not supported on this platform. Current = " + Application.platform);
        }
    }


    //  
    // --- IStoreListener
    //

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        // Purchasing has succeeded initializing. Collect our Purchasing references.
        Debug.Log("OnInitialized: PASS");

        // Overall Purchasing system, configured with products for this application.
        m_StoreController = controller;
        // Store specific subsystem, for accessing device-specific store features.
        m_StoreExtensionProvider = extensions;
    }


    public void OnInitializeFailed(InitializationFailureReason error)
    {
        // Purchasing set-up has not succeeded. Check error for reason. Consider sharing this reason with the user.
        Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);
    }


    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
    {
        // A consumable product has been purchased by this user.
        if (String.Equals(args.purchasedProduct.definition.id, kProductIDConsumable, StringComparison.Ordinal))
        {
            Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
            // The consumable item has been successfully purchased, add 100 coins to the player's in-game score.
            ScoreManager.score += 100;
        }
        // Or ... a non-consumable product has been purchased by this user.
        else if (String.Equals(args.purchasedProduct.definition.id, kProductIDNonConsumable, StringComparison.Ordinal))
        {
            Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
            // TODO: The non-consumable item has been successfully purchased, grant this item to the player.
        }
        // Or ... a subscription product has been purchased by this user.
        else if (String.Equals(args.purchasedProduct.definition.id, kProductIDSubscription, StringComparison.Ordinal))
        {
            Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
            // TODO: The subscription item has been successfully purchased, grant this to the player.
        }
        // Or ... an unknown product has been purchased by this user. Fill in additional products here....
        else
        {
            Debug.Log(string.Format("ProcessPurchase: FAIL. Unrecognized product: '{0}'", args.purchasedProduct.definition.id));
        }

        // Return a flag indicating whether this product has completely been received, or if the application needs 
        // to be reminded of this purchase at next app launch. Use PurchaseProcessingResult.Pending when still 
        // saving purchased products to the cloud, and when that save is delayed. 
        return PurchaseProcessingResult.Complete;
    }


    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        // A product purchase attempt did not succeed. Check failureReason for more detail. Consider sharing 
        // this reason with the user to guide their troubleshooting actions.
        Debug.Log(string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}", product.definition.storeSpecificId, failureReason));
    }
    
}

