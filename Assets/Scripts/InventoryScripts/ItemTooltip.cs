using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;

public class ItemTooltip : MonoBehaviour
{
    public Text itemTypeText;
    public Text itemGradeText;
    public Text itemNameText;
    public Text itemDescriptionText;
    public Text Price;
    public Text RequiredText;
    public Text equipItemText;
    public Image itemImage;

    //사용한 이유
    //문자열 안에서 + 를 계속 호출하게 될 경우 새로운 문자열 객체를 생성하지만
    //StringBuilder를 사용하게 되면 내부에서 작업이 이뤄지기 때문에
    //여러번의 문자열을 읽어온다면 +를 사용하는 것 보다 StringBuilder를 사용하는게
    //성능면에서 이점이 있다.
    private StringBuilder stateBuilder;
    private StringBuilder RequiredBuilder;

    private void Start()
    {
        stateBuilder = new StringBuilder();        
        RequiredBuilder = new StringBuilder();
        gameObject.SetActive(false);
    }
    public void ShowTooltip(ItemInfo itemInfo)
    {
        stateBuilder.Length = 0;//툴팁이 호출되기 전 값을 0으로 초기화
        //다형성을 통해 버츄얼로 만든 메소드를 오버라이드를 통해 값을 가져옴
        itemInfo.ShowMyInfo(stateBuilder);
        itemInfo.ShowMyInfo(RequiredBuilder);
        itemTypeText.text = itemInfo.itemType.ToString();
        itemGradeText.text = itemInfo.itemGrade.ToString();
        itemNameText.text = itemInfo.name;
        itemDescriptionText.text = "아이템 설명\n" + itemInfo.itemDescription;
        Price.text = itemInfo.price.ToString();

        RequiredText.text = RequiredBuilder.ToString();
        itemImage.sprite = itemInfo.itemSprite;

        //if (itemInfo is EquipItem equipItem || itemInfo is Armor armor || itemInfo is ConsumItem consumItem)
        //{
        //    itemInfo.ShowMyInfo(stateBuilder);
        //    equipItemText.text = stateBuilder.ToString();
        //}
        equipItemText.text = stateBuilder.ToString();

        gameObject.SetActive(true);
        gameObject.GetComponent<Image>().raycastTarget = false;
        SetRaycastTargetForAllChildren(gameObject, false);
    }
    public void HideTooltip()
    {
        gameObject.SetActive(false);
    }

    public void SetRaycastTargetForAllChildren(GameObject parent, bool value)
    {
        Text[] childImages = parent.GetComponentsInChildren<Text>();

        foreach (var img in childImages)
        {
            img.raycastTarget = value;
        }
    }
    
}