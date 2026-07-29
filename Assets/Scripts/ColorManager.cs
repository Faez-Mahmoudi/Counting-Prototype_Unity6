using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ColorManager : MonoBehaviour
{
    [SerializeField] private GameObject playerOne;
    [SerializeField] private GameObject playerTwo;

    [SerializeField] private TextMeshProUGUI[] leftSideTexts;
    [SerializeField] private TextMeshProUGUI[] rightSideTexts;

    [SerializeField] private Button[] leftSideButtons;
    [SerializeField] private Button[] rightSideButtons;

    [SerializeField] private SpotLightColorChanger leftSpotLight;
    [SerializeField] private SpotLightColorChanger rightSpotLight;

    [SerializeField] private Material[] playerMats;
    [SerializeField] private Material[] emissiveMats;

    [SerializeField] private Color[] playerColors;

    [SerializeField] private GameObject[] leftGameStartPanels;
    [SerializeField] private GameObject[] rightGameStartPanels;

    [SerializeField] private GameObject[] leftSides;
    [SerializeField] private GameObject[] rightSides;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        leftSpotLight = GameObject.Find("LeftSpotLights").GetComponent<SpotLightColorChanger>();
        rightSpotLight = GameObject.Find("RightSpotLights").GetComponent<SpotLightColorChanger>();
        SetColor(1, MainManager.Instance.rightUiColorNumber);
        SetColor(2, MainManager.Instance.leftUiColorNumber);
    }

    public void SetColor(int ID, int colorNumber)
    {
        if (ID == 1)
        {
            MainManager.Instance.rightUiColorNumber = colorNumber;

            MainManager.Instance.rightUiColor = playerColors[colorNumber];
            MySetColorFunction(playerOne, rightGameStartPanels, rightSides, rightSpotLight, rightSideTexts, rightSideButtons, playerColors[colorNumber], MainManager.Instance.rightUiColor, playerMats[colorNumber], emissiveMats[colorNumber]);
        }
        else if (ID == 2)
        {
            MainManager.Instance.leftUiColorNumber = colorNumber;

            MainManager.Instance.leftUiColor = playerColors[colorNumber];
            MySetColorFunction(playerTwo, leftGameStartPanels, leftSides, leftSpotLight, leftSideTexts, leftSideButtons, playerColors[colorNumber], MainManager.Instance.leftUiColor, playerMats[colorNumber], emissiveMats[colorNumber]);
        }  
    }

    private void MySetColorFunction(GameObject player,GameObject[] panels, GameObject[] sides, SpotLightColorChanger spot, TextMeshProUGUI[] texts, Button[] buttons, Color color,Color mainColor, Material mat, Material emMat)
    {
        player.GetComponent<Renderer>().material = mat;
        player.GetComponent<Light>().color = color;
        spot.SetSpotLightColor(color, emMat);

        foreach (var s in sides)
            s.GetComponent<Renderer>().material = emMat;

        foreach (var t in texts)
            t.color = mainColor;

        foreach (var b in buttons)
        {
            Image img = b.GetComponent<Image>();
            img.color = mainColor;
        }

        foreach (var p in panels)
        {
            Image imgPanel = p.GetComponent<Image>();
            imgPanel.color = mainColor;   
        }
    } 
}