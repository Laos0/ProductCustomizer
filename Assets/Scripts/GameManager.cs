using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour {

    /// <summary>
    /// Holds all the items in the store
    /// </summary>
    List<Item> items;
    List<Item> blades;
    List<Item> topHandles;
    List<Item> handles;

    int currentBladeIndex;
    int currentHandleIndex;
    int currentTopHandleIndex;

    public List<GameObject> weapon3DPrefabs;
    GameObject temp3DBlade, temp3DHandle, temp3DTopHandle;
    public GameObject weaponContainer;

    public Text coinTxt;
    public Text priceTxt;
    public int coins;
    public int bladePrice, topHandlePrice, handlePrice, totalPrice;

    public ItemView itemView;

    public Text floatingText;

    public Text itemNameTxt;

    public GameObject confirmPrompt;
    private bool isConfirm;
    private bool isBack;

	// Use this for initialization
	void Start () {
        blades = new List<Item>();
        topHandles = new List<Item>();
        handles = new List<Item>();
        loadJsonData();
        sortItemsToCategory();
        //displayItem(blades[1]);
        getNextBlade();
        getNextHandle();
        getNextTopHandle();
        coinTxt.text = "5000";
        coins = int.Parse(coinTxt.text);
        hidePrompt();
        //confirmPrompt.GetComponent<Canvas>().enabled = false;
    }

    /// <summary>
    /// Loads json data and parse it to real item object
    /// </summary>
    void loadJsonData()
    {
        string jsonData = loadTxtFile("ItemDatabase");
        // Json data gets parse to real ItemWrapper
        ItemWrapper iWrapper = JsonUtility.FromJson<ItemWrapper>(jsonData);
        Debug.Log(iWrapper.items.Count);
        items = iWrapper.items;
        iWrapper.items.ForEach(item =>
        {
            Debug.Log(item.ToString());
        });
    }

    /// <summary>
    /// Loads a textfile under a resource folder that I created, which has to be called "Resources"
    /// </summary>
    /// <param name="filePath"></param>
    /// <returns></returns>
    string loadTxtFile(string filePath)
    {
        // Load in file and store it in jsonFile
        TextAsset jsonFile = Resources.Load<TextAsset>(filePath);
        return jsonFile.text;
    }

    void sortItemsToCategory()
    {
        if(items != null && items.Count > 0)
        {
            // Push items to the correct item array
            items.ForEach(item =>
            {
                if(item.itemType == ItemType.BLADE)
                {
                    blades.Add(item);
                }else if(item.itemType == ItemType.TOP_HANDLE)
                {
                    topHandles.Add(item);
                }
                else if(item.itemType == ItemType.HANDLE)
                {
                    handles.Add(item);
                }
            });

        }
        else
        {
            throw new UnityException("Failed to sort, item is null or empty.");
        }
    }

    void displayItemStats(Item item)
    {
        itemView.displayItemStats(item);
    }

    //----------------------------------------- NEXT BUTTONS -----------------------------------------------------
    public void getNextBlade()
    {
        Item item = null;
        currentBladeIndex++;
        if(currentBladeIndex >= blades.Count) // reset the index when it goes out of bound of blades, when it reaches the end
        {
            currentBladeIndex = 0;
        }
        item = blades[currentBladeIndex];
        show3DBlade(item);
        displayItemStats(item);
        setBladePrice(item);
        //return item;
    }

    public void getNextTopHandle()
    {
        Item item = null;
        currentTopHandleIndex++;
        if (currentTopHandleIndex >= topHandles.Count) // reset the index when it goes out of bound of blades, when it reaches the end
        {
            currentTopHandleIndex = 0;
        }
        item = topHandles[currentTopHandleIndex];
        show3DTopHandle(item);
        displayItemStats(item);
        setTopHandlePrice(item);
        //return item;
    }

    public void getNextHandle()
    {
        Item item = null;
        currentHandleIndex++;
        if (currentHandleIndex >= handles.Count) // reset the index when it goes out of bound of handles, when it reaches the end
        {
            currentHandleIndex = 0;
        }
        item = handles[currentHandleIndex];
        show3DHandle(item);
        displayItemStats(item);
        setHandlePrice(item);
        //return item;
    }
    // ------------------------------------------ END OF NEXT BUTTONS --------------------------------------------------
    // ------------------------------------------ PREVIOUS BUTTONS ----------------------------------------------------
    public void getPrviousBlade()
    {
        Item item = null;
        currentBladeIndex--;
        if (currentBladeIndex <= 0) // reset the index when it goes out of bound of blades, when it reaches the end
        {
            currentBladeIndex = blades.Count - 1;
        }
        item = blades[currentBladeIndex];
        show3DBlade(item);
        displayItemStats(item);
        setBladePrice(item);
        //return item;
    }

    public void getTopHandle()
    {
        // get previous 
        Item item = null;
        currentTopHandleIndex--;
        if (currentTopHandleIndex <= 0) // reset the index when it goes out of bound of blades, when it reaches the end
        {
            currentTopHandleIndex = topHandles.Count - 1;
        }
        item = topHandles[currentTopHandleIndex];
        show3DTopHandle(item);
        displayItemStats(item);
        setTopHandlePrice(item);
        //return item;
    }

    public void getPrviousHandle()
    {
        Item item = null;
        currentHandleIndex--;
        if (currentHandleIndex < 0) // reset the index when it goes out of bound of blades, when it reaches the end
        {
            currentHandleIndex = handles.Count - 1;
        }
        item = handles[currentHandleIndex];
        show3DHandle(item);
        displayItemStats(item);
        setHandlePrice(item);
        //return item;
    }

    // ------------------------------------------ END OF PREVIOUS BUTTONS----------------------------------------------
    public void show3DBlade(Item item)
    {
        destroyCurrentBlade();
        int id = item.id;
        string bladeId = "blade_" + id;

        // foreach(object, => {})
        for(int i = 0; i < weapon3DPrefabs.Count; i++)
        {
            if(weapon3DPrefabs[i].name == bladeId)
            {
                temp3DBlade = weapon3DPrefabs[i];
                break;
            }
        }
        temp3DBlade = Instantiate(temp3DBlade, weaponContainer.transform.position, weaponContainer.transform.rotation);
        temp3DBlade.transform.position = new Vector3();
        temp3DBlade.transform.SetParent(weaponContainer.transform);
        changeItemNameColor(item);

    }

    public void show3DTopHandle(Item item)
    {
        destroyCurrentTopHandle();
        int id = item.id;
        string topHandleId = "handle_top_" + id;

        // foreach(object, => {})
        for (int i = 0; i < weapon3DPrefabs.Count; i++)
        {
            if (weapon3DPrefabs[i].name == topHandleId)
            {
                temp3DTopHandle = weapon3DPrefabs[i];
                break;
            }
        }
        temp3DTopHandle = Instantiate(temp3DTopHandle, weaponContainer.transform.position, weaponContainer.transform.rotation);
        temp3DTopHandle.transform.position = new Vector3();
        temp3DTopHandle.transform.SetParent(weaponContainer.transform);
        changeItemNameColor(item);
    }

    public void show3DHandle(Item item)
    {
        destroyCurrentHandle();
        int id = item.id;
        string handleId = "handle_" + id;

        // foreach(object, => {})
        for (int i = 0; i < weapon3DPrefabs.Count; i++)
        {
            if (weapon3DPrefabs[i].name == handleId)
            {
                temp3DHandle = weapon3DPrefabs[i];
                break;
            }
        }
        temp3DHandle = Instantiate(temp3DHandle, weaponContainer.transform.position, weaponContainer.transform.rotation);
        temp3DHandle.transform.position = new Vector3();
        temp3DHandle.transform.SetParent(weaponContainer.transform);
        changeItemNameColor(item);
    }

    private void destroyCurrentBlade()
    {
        if(temp3DBlade != null)
        {
            Destroy(temp3DBlade);
        }
    }

    private void destroyCurrentHandle()
    {
        if (temp3DHandle != null)
        {
            Destroy(temp3DHandle);
        }
    }

    private void destroyCurrentTopHandle()
    {
        if (temp3DTopHandle != null)
        {
            Destroy(temp3DTopHandle);
        }
    }

    private void setBladePrice(Item item)
    {
        bladePrice = blades[currentBladeIndex].cost;
        updateWepPrice();
    }

    private void setTopHandlePrice(Item item)
    {
        topHandlePrice = topHandles[currentTopHandleIndex].cost;
        updateWepPrice();
    }

    private void setHandlePrice(Item item)
    {
        handlePrice = handles[currentHandleIndex].cost;
        updateWepPrice();
        //Debug.Log(handlePrice);
    }

    private void setTotalPrice()
    {
        totalPrice = bladePrice + topHandlePrice + handlePrice;
    }

    public void buyWeapon()
    {
        //Debug.Log("HIT HERE");
        showPrompt();

        isConfirm = false;
        isBack = false;
        
    }

    public void convertIntToStr()
    {
        coinTxt.text = coins.ToString();
    }

    public void resetWep()
    {
        currentBladeIndex = 0;
        currentTopHandleIndex = 0;
        currentHandleIndex = 0;
        getNextBlade();
        getNextTopHandle();
        getNextHandle();
        coinTxt.text = "5000";
        coins = int.Parse(coinTxt.text);
    }

    private void showFloatingText()
    {
        floatingText.GetComponent<Text>().enabled = true;
        Invoke("disableText", 1);
    }

    private void disableText()
    {
        floatingText.GetComponent<Text>().enabled = false;
    }

    private void updateWepPrice()
    {
        setTotalPrice();
        priceTxt.text = totalPrice.ToString();
    }

    private void changeItemNameColor(Item item)
    {
        if(item.rarity == 3)
        {
            itemNameTxt.color = new Color(128, 0, 128);
        }else if(item.rarity == 2)
        {
            itemNameTxt.color = new Color(0,141,255,255);
        }
        else
        {
            itemNameTxt.color = Color.white;
        }
    }

    public void isConfirmBtn()
    {
        isConfirm = true;
        setTotalPrice();
        //Debug.Log(totalPrice);
        if (coins < totalPrice)
        {
            showFloatingText();
            //Debug.Log("You Don't Have Enough Coins!");
        }
        else
        {
            coins = coins - totalPrice;
            coinTxt.text = coins.ToString();
        }
        hidePrompt();
    }

    public void isBackBtn()
    {
        isBack = true;
        hidePrompt();
    }

    public void hidePrompt()
    {
        confirmPrompt.GetComponent<Canvas>().enabled = false;

    }

    public void showPrompt()
    {
        confirmPrompt.GetComponent<Canvas>().enabled = true;
    }
}
