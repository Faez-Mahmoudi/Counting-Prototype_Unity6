using UnityEngine;

public class ColorManager : MonoBehaviour
{
    [SerializeField] private GameObject playerOne;
    [SerializeField] private GameObject playerTwo;

    [SerializeField] private SpotLightColorChanger leftSpotLight;
    [SerializeField] private SpotLightColorChanger rightSpotLight;
    
    [SerializeField] private Material[] playerMats;
    [SerializeField] private Material[] emissiveMats;
    [SerializeField] private Color[] playerColors;
    [SerializeField] private GameObject[] leftSides;
    [SerializeField] private GameObject[] rightSides;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        leftSpotLight = GameObject.Find("LeftSpotLights").GetComponent<SpotLightColorChanger>();
        rightSpotLight = GameObject.Find("RightSpotLights").GetComponent<SpotLightColorChanger>();
        SetColor(1, 4);
        SetColor(2, 2);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetColor(int ID, int colorNumber)
    {
        if (ID == 1)
        {
            playerOne.GetComponent<Renderer>().material = playerMats[colorNumber];
            playerOne.GetComponent<Light>().color = playerColors[colorNumber];
            rightSpotLight.SetSpotLightColor(playerColors[colorNumber], emissiveMats[colorNumber]);

            foreach (var side in rightSides)
            {
                side.GetComponent<Renderer>().material = emissiveMats[colorNumber];
            }
        }
        else if (ID == 2)
        {
            playerTwo.GetComponent<Renderer>().material = playerMats[colorNumber];
            playerTwo.GetComponent<Light>().color = playerColors[colorNumber];
            leftSpotLight.SetSpotLightColor(playerColors[colorNumber], emissiveMats[colorNumber]);

            foreach (var side in leftSides)
            {
                side.GetComponent<Renderer>().material = emissiveMats[colorNumber];
            }
        }
        
    }
}
