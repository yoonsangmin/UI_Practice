using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Manager_Script : MonoBehaviour
{
    [SerializeField] private InputField input_name;
    string player_name;
    public int gold, crystal;

    // Start is called before the first frame update
    void Start()
    {
        player_name = "";
        GameObject.Find("Canvas").transform.Find("StartPanel").transform.Find("SP_Button").GetComponent<Button>().interactable = false;
        GameObject.Find("Canvas").transform.Find("ShopPanel").gameObject.SetActive(false);
        ResetStartPanel();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Start_Button()
    {
        GameObject Start_Panel = GameObject.Find("Canvas").transform.Find("StartPanel").gameObject;
        GameObject Name_Panel = GameObject.Find("Canvas").transform.Find("NamePanel").gameObject;

        if (Name_Panel.activeSelf == false)
        {
            if(player_name == "")
                Name_Panel.SetActive(true);
            else
                GameObject.Find("Canvas").transform.Find("LevelPanel").gameObject.SetActive(true);
            Start_Panel.SetActive(false);
            ResetStartPanel();
        }
    }
    public void Volume_Button()
    {
        GameObject SL_obj = GameObject.Find("Canvas").transform.Find("StartPanel").transform.Find("SE_Button").transform.Find("VO_Button").transform.Find("Slider").gameObject;

        if (SL_obj.activeSelf == true)
        {
            SL_obj.SetActive(false);
        }
        else if (SL_obj.activeSelf == false)
        {
            SL_obj.SetActive(true);
        }
    }
    public void Setting_Button()
    {
        GameObject VO_obj = GameObject.Find("Canvas").transform.Find("StartPanel").transform.Find("SE_Button").transform.Find("VO_Button").gameObject;

        if (VO_obj.activeSelf == true)
        {
            VO_obj.SetActive(false);
        }
        else if (VO_obj.activeSelf == false)
        {
            VO_obj.SetActive(true);
        }
    }
    public void Share_Button()
    {
        GameObject FB_obj = GameObject.Find("Canvas").transform.Find("StartPanel").transform.Find("SH_Button").transform.Find("FB_Button").gameObject;
        GameObject TW_obj = GameObject.Find("Canvas").transform.Find("StartPanel").transform.Find("SH_Button").transform.Find("TW_Button").gameObject;

        if (FB_obj.activeSelf == true)
        {
            FB_obj.SetActive(false);
            TW_obj.SetActive(false);
        }
        else if (FB_obj.activeSelf == false)
        {
            FB_obj.SetActive(true);
            TW_obj.SetActive(true);
        }
    }
    public void GoToTW()
    {
        Application.OpenURL("https://twitter.com/explore");
    }
    public void GoToFB()
    {
        Application.OpenURL("https://www.facebook.com/");
    }
    public void Shop_Button()
    {
        GameObject Shop_Panel = GameObject.Find("Canvas").transform.Find("ShopPanel").gameObject;

        if (Shop_Panel.activeSelf == false)
        {
            Shop_Panel.SetActive(true);
            ResetStartPanel();
            InactiveStartPanel();
        }
    }
    public void Shop_Close_Button()
    {
        GameObject Shop_Panel = GameObject.Find("Canvas").transform.Find("ShopPanel").gameObject;
        
        Shop_Panel.SetActive(false);
        ActiveStartPanel();
    }

    void ResetStartPanel()
    {
        GameObject Start_Panel = GameObject.Find("Canvas").transform.Find("StartPanel").gameObject;

        Start_Panel.transform.Find("SE_Button").transform.Find("VO_Button").transform.Find("Slider").gameObject.SetActive(false);
        Start_Panel.transform.Find("SE_Button").transform.Find("VO_Button").gameObject.SetActive(false);
        Start_Panel.transform.Find("SH_Button").transform.Find("FB_Button").gameObject.SetActive(false);
        Start_Panel.transform.Find("SH_Button").transform.Find("TW_Button").gameObject.SetActive(false);
    }
    void InactiveStartPanel()
    {
        GameObject Start_Panel = GameObject.Find("Canvas").transform.Find("StartPanel").gameObject;

        Start_Panel.transform.Find("SE_Button").GetComponent<Button>().interactable = false;
        Start_Panel.transform.Find("SH_Button").GetComponent<Button>().interactable = false;
        Start_Panel.transform.Find("SP_Button").GetComponent<Button>().interactable = false;
    }
    void ActiveStartPanel()
    {
        GameObject Start_Panel = GameObject.Find("Canvas").transform.Find("StartPanel").gameObject;

        Start_Panel.transform.Find("SE_Button").GetComponent<Button>().interactable = true;
        Start_Panel.transform.Find("SH_Button").GetComponent<Button>().interactable = true;
        Start_Panel.transform.Find("SP_Button").GetComponent<Button>().interactable = true;
    }
    public void SetName()
    {
        if (input_name.text == "")
            Debug.Log("name is empty");
        else
        {
            player_name = input_name.text;
            Debug.Log("Input name : " + player_name);
            GameObject.Find("Canvas").transform.Find("NamePanel").gameObject.SetActive(false);
            GameObject.Find("Canvas").transform.Find("LevelPanel").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("StartPanel").transform.Find("SP_Button").GetComponent<Button>().interactable = true;
            GameObject.Find("Canvas").transform.Find("ShopPanel").transform.Find("NameText").GetComponent<TextMeshProUGUI>().text = player_name;
            RefreshGold();
        }
    }
    public void Level_Close_Panel()
    {
        GameObject.Find("Canvas").transform.Find("LevelPanel").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("StartPanel").gameObject.SetActive(true);
    }
    void RefreshGold()
    {
        GameObject.Find("Canvas").transform.Find("ShopPanel").transform.Find("GD_Image").transform.Find("GDText").GetComponent<TextMeshProUGUI>().text = ": " + gold;
        GameObject.Find("Canvas").transform.Find("ShopPanel").transform.Find("DI_Image").transform.Find("DiaText").GetComponent<TextMeshProUGUI>().text = ": " + crystal;
    }
    public void B1_Button()
    {
        gold -= 130;
        crystal += 16;
        RefreshGold();
    }
    public void B2_Button()
    {
        gold -= 1300;
        crystal += 166;
        RefreshGold();
    }
    public void B3_Button()
    {
        gold -= 13000;
        crystal += 1666;
        RefreshGold();
    }
}