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
    RectTransform item_frame_rt, tmp_rt, rect_trans;
    ItemFrame tmpIF;
    PlayerInventory pi;
    void Awake ()
    {
        pi = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PlayerInventory>();
        item_frame_rt = itemFrame.GetComponent<RectTransform>();
        //rect_trans = gameObject.GetComponent<RectTransform>();
    }   
    void Start ()
    {
		//disableIcons();
		//activeIcons(0);
        for (int i = 0; i < pi.inventory.Count; ++i)
        {
            tmp = GameObject.Instantiate(itemFrame);
            tmp.transform.SetParent(gameObject.transform);
            tmp_rt = tmp.GetComponent<RectTransform>();
            tmp_rt.localScale = item_frame_rt.localScale;
            tmp_rt.anchoredPosition = item_frame_rt.anchoredPosition;
            tmp_rt.anchoredPosition += new Vector2(0, (item_frame_rt.rect.height + 1.5f) * -i);
            tmpIF = tmp.GetComponent<ItemFrame>();
			Debug.Log(pi.inventory[i].name);
			Debug.Log(pi.inventory[i].value);
            tmpIF.name = pi.inventory[i].name;
            tmpIF.value = pi.inventory[i].value;
            tmpIF.setValues();
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
	public void activeIcons(int iconNumber)
	{
		icons[iconNumber].changeColor(iconActive);
	}

}
