using UnityEngine;
using TMPro;

public class Dropdown : MonoBehaviour
{
    public RectTransform container;
    public bool isOpen;
    public int boardSize = -7;
    private LightUp LightUpManager;

    void Start()
    {
        container = transform.Find("container").GetComponent<RectTransform>();
        isOpen = false;
        LightUpManager = GameObject.Find("GameManager").GetComponent<LightUp>();
        LightUpManager.currentPack = -7;
        LightUpManager.boardSize = -7;
    }

    void Update()
    {
        Vector3 scale = container.localScale;
        scale.y = Mathf.Lerp(scale.y, isOpen ? 1 : 0, Time.deltaTime * 12);
        container.localScale = scale;
    }

    public void DropdownOptions(string op)
    {
        switch (op)
        {
            case "7x7":
                if (isOpen == false)
                {
                    isOpen = true;
                    transform.Find("Text").GetComponent<TextMeshProUGUI>().text = "7x7";
                }
                else
                {
                    boardSize = -7;
                    LightUpManager.currentPack = -7;
                    isOpen = false;
                    transform.Find("Text").GetComponent<TextMeshProUGUI>().text = "7x7";
                    LightUpManager.boardSize = boardSize;
                }
                break;
            case "10x10":
                boardSize = -10;
                LightUpManager.currentPack = -10;
                isOpen = false;
                transform.Find("Text").GetComponent<TextMeshProUGUI>().text = "10x10";
                LightUpManager.boardSize = boardSize;
                break;
            case "12x12":
                boardSize = -12;
                LightUpManager.currentPack = -12;
                isOpen = false;
                transform.Find("Text").GetComponent<TextMeshProUGUI>().text = "12x12";
                LightUpManager.boardSize = boardSize;
                break;
            case "14x14":
                boardSize = -14;
                LightUpManager.currentPack = -14;
                isOpen = false;
                transform.Find("Text").GetComponent<TextMeshProUGUI>().text = "14x14";
                LightUpManager.boardSize = boardSize;
                break;
        }
        switch (boardSize)
        {
            case -7: VerifyTimeTrialMinutesSolvedByBoard(LightUpManager.TimeTrial7x7Solved); break;
            case -10: VerifyTimeTrialMinutesSolvedByBoard(LightUpManager.TimeTrial10x10Solved); break;
            case -12: VerifyTimeTrialMinutesSolvedByBoard(LightUpManager.TimeTrial12x12Solved); break;
            case -14: VerifyTimeTrialMinutesSolvedByBoard(LightUpManager.TimeTrial14x14Solved); break;
        }
    }

    public void CloseDropdown()
    {
        isOpen = false;
        switch (boardSize)
        {
            case -7:
                transform.Find("Text").GetComponent<TextMeshProUGUI>().text = "7x7";
                break;
            case -10:
                transform.Find("Text").GetComponent<TextMeshProUGUI>().text = "10x10";
                break;
            case -12:
                transform.Find("Text").GetComponent<TextMeshProUGUI>().text = "12x12";
                break;
            case -14:
                transform.Find("Text").GetComponent<TextMeshProUGUI>().text = "14x14";
                break;
        }
    }

    private void VerifyTimeTrialMinutesSolvedByBoard(int[] op)
    {
        if (op[0] != 0) GameObject.Find("timeTrial/minute1Button/solved1MinText").GetComponent<TextMeshProUGUI>().text = op[0].ToString();
        else GameObject.Find("timeTrial/minute1Button/solved1MinText").GetComponent<TextMeshProUGUI>().text = "-";
        if (op[1] != 0) GameObject.Find("timeTrial/minute2Button/solved2MinText").GetComponent<TextMeshProUGUI>().text = op[1].ToString();
        else GameObject.Find("timeTrial/minute2Button/solved2MinText").GetComponent<TextMeshProUGUI>().text = "-";
        if (op[2] != 0) GameObject.Find("timeTrial/minute4Button/solved4MinText").GetComponent<TextMeshProUGUI>().text = op[2].ToString();
        else GameObject.Find("timeTrial/minute4Button/solved4MinText").GetComponent<TextMeshProUGUI>().text = "-";
        if (op[3] != 0) GameObject.Find("timeTrial/minute8Button/solved8MinText").GetComponent<TextMeshProUGUI>().text = op[3].ToString();
        else GameObject.Find("timeTrial/minute8Button/solved8MinText").GetComponent<TextMeshProUGUI>().text = "-";
    }
}

/*
 * isOpen ? 1 : 0
 * if (isOpen == true)
 *   return 1;
 * else
 *   return 0;
*/