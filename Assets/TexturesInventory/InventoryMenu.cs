using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InventoryMenu : MonoBehaviour {

	public GameObject itemFrame;
	public Color iconActive, iconNotActive;
	public enum IconFilter {all, weapon, potion,armor};
	public IconFilter iconFilter;
	public InventoryIcon[] icons;
    GameObject tmp;

    List<ItemFrame> listItemFrame=new List<ItemFrame>();
    RectTransform item_frame_rt, tmp_rt, rect_trans;
    ItemFrame tmpIF;
    PlayerInventory playerInventory;
    void Awake ()
    {
        playerInventory = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PlayerInventory>();
        item_frame_rt = itemFrame.GetComponent<RectTransform>();
        //rect_trans = gameObject.GetComponent<RectTransform>();
    }   
    void Start ()
    {
        updateMenu();
    }
	
    public void updateMenu()
    {
	   //disableIcons();
		//activeIcons(0);
        listItemFrame.Clear();
        for (int i = 0; i < playerInventory.inventory.Count; ++i)
        {
            tmp = GameObject.Instantiate(itemFrame);
            tmp.transform.SetParent(gameObject.transform);
            tmp_rt = tmp.GetComponent<RectTransform>();
            tmp_rt.localScale = item_frame_rt.localScale;
            tmp_rt.anchoredPosition = item_frame_rt.anchoredPosition;
            tmp_rt.anchoredPosition += new Vector2(0, (item_frame_rt.rect.height + 1.5f) * -i);
            tmpIF = tmp.GetComponent<ItemFrame>();
			//Debug.Log(playerInventory.inventory[i].name);
			//Debug.Log(playerInventory.inventory[i].value);
            tmpIF.name = playerInventory.inventory[i].name;
            tmpIF.value = playerInventory.inventory[i].value;
            tmpIF.item=playerInventory.inventory[i];
            tmpIF.setValues();
            tmp.SetActive(true);
            gameObject.SetActive(true);
            listItemFrame.Add(tmpIF);
            //Debug.Log("updateuje menu");
        }
        itemFrame.SetActive(false);
        //rect_trans.sizeDelta = new Vector2(0, (item_frame_rt.rect.height + 1.5f) * pi.inventory.Count);
       // rect_trans.anchoredPosition += new Vector2(0, -(item_frame_rt.rect.height + 1.5f) * pi.inventory.Count / 2);
    
    }
	public void disableIcons()
	{
		foreach (InventoryIcon ic in icons)
		{
			ic.changeColor(iconNotActive);
		}
	}
    public void disableFrame()
	{
		foreach (ItemFrame frame in listItemFrame)
		{
			frame.changeColor(Color.white);
		}
	}
	public void activeIcons(int iconNumber)
	{
		icons[iconNumber].changeColor(iconActive);
	}

}
