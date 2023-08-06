using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class CharacterShopUI : MonoBehaviour
{
    [Header("Layout Settings")]
    [SerializeField] float itemSpacing = 0.5f; 
    float itemHeight; 


    [Header("UI Elements")]
    Image selectedCharacterIcon; 

    [SerializeField]  Transform shopMenu; 
    [SerializeField]  Transform shopItemsContainer; 
    [SerializeField] GameObject itemPrefab; 

    [Space(20)]
    [SerializeField] CharacterShopDatabase characterDB;

    [Space(20)]
    [Header("Main Menu")]
    // Image mainMenuCharacterImage; 
    

    [Space(20)]
    [Header("Animation Stuff")]
    [SerializeField] Animator NoCoinsAnim;

    int newSelectedItemIndex = 0; 
    int previousSelectedItemIndex = 0; 

   
    void Start()
    {
       //GameDataManager.SetSelectedCharacter(characterDB.GetCharacter(index), index);
    
       
        GenerateShopItemsUI();
        SetSelectedCharacter();        
        SelectItemUI (GameDataManager.GetSelectedCharacterIndex()); 
        ChangePlayerSkin ();
    }
    void SetSelectedCharacter()
    {
        int index = GameDataManager.GetSelectedCharacterIndex(); 
        GameDataManager.SetSelectedCharacter(characterDB.GetCharacter(index), index);       
    }
    void GenerateShopItemsUI()
    {
        for (int i = 0; i < GameDataManager.GetAllPurchasedCharacter().Count; i++)
        {
            int purchasedCharacterIndex = GameDataManager.GetPurchasedCharacter(i);
            characterDB.PurchaseCharacter(purchasedCharacterIndex); 
        }

        itemHeight = shopItemsContainer.GetChild(0).GetComponent<RectTransform>().sizeDelta.y;
        Destroy(shopItemsContainer.GetChild(0).gameObject);
        shopItemsContainer.DetachChildren(); 

        for (int i = 0; i < characterDB.CharactersCount; i++)
        {
            Character character = characterDB.GetCharacter(i);
            CharacterItemUI uiItem = Instantiate(itemPrefab,shopItemsContainer).GetComponent <CharacterItemUI>();
           
           uiItem.SetItemPosition(Vector2.down * i * (itemHeight + itemSpacing));
           uiItem.gameObject.name = "Item" + i + "-" + character.name;
           
            uiItem.SetCharacterName(character.name);
            uiItem.SetCharacterPrice(character.price); 
            uiItem.SetCharacterImage(character.image); 

            if(character.isPurchased)
            {
                uiItem.SetCharAsPurchased(); 
                uiItem.OnItemSelected(i, OnItemSelected);
            }
            else 
            {
                uiItem.SetCharacterPrice(character.price);
                uiItem.OnItemPurchase(i, OnItemPurchase); 
            }

            shopItemsContainer.GetComponent<RectTransform>().sizeDelta = 
            Vector2.up * ((itemHeight + itemSpacing) * characterDB.CharactersCount + itemSpacing);

        }
    }
   
    void ChangePlayerSkin ()
	{
		Character character = GameDataManager.GetSelectedCharacter ();
		if (character.image != null) {
			//Change Main menu's info (image & text)
			//mainMenuCharacterImage.sprite = character.image;                                                                                                                          // Main menu character image
			//Set selected Character Image at the top of shop menu
			//selectedCharacterIcon.sprite = GameDataManager.GetSelectedCharacter ().image;
		}
        else
        {
            return;
        }
	}
    void OnItemSelected(int index)
    {      
        SelectItemUI(index);
        GameDataManager.SetSelectedCharacter(characterDB.GetCharacter(index), index); 
        ChangePlayerSkin ();
        Debug.Log("Selected character index is " + index);
    }

    void SelectItemUI(int itemIndex)
    {
        previousSelectedItemIndex = newSelectedItemIndex;
        newSelectedItemIndex = itemIndex; 

        CharacterItemUI prevUiItem = GetItemUI(previousSelectedItemIndex);
        CharacterItemUI newUiItem = GetItemUI(newSelectedItemIndex);

        prevUiItem.DeselectItem();
        newUiItem.SelectItem(); 

    }
    CharacterItemUI GetItemUI(int index)
    {
        return shopItemsContainer.GetChild(index).GetComponent<CharacterItemUI>(); 
    }

    void OnItemPurchase(int index)
    {
        Character character = characterDB.GetCharacter(index); 
        CharacterItemUI uiItem = GetItemUI(index); 

        if(GameDataManager.CanSpendCoins(character.price))
        {
            GameDataManager.SpendCoins(character.price);

            GameSharedUI.instance.UpdateCoinsUIText(); 
            characterDB.PurchaseCharacter(index); 

            uiItem.SetCharAsPurchased(); 
            uiItem.OnItemSelected(index, OnItemSelected);

            GameDataManager.AddPurchasedCharacter(index); 
        }
        else 
        {
            NoCoinsAnim.SetTrigger("NoCoins");
            Debug.Log("not enopugh coins !!"); 
        }
    }

}
