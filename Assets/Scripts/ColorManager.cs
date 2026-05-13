using UnityEngine;

public class ColorManager : MonoBehaviour
{
    [SerializeField] private GameObject playerOne;
    [SerializeField] private GameObject playerTwo;

    [SerializeField] private SpotLightColorChanger leftSpotLight;
    [SerializeField] private SpotLightColorChanger rightSpotLight;
    
    [SerializeField] private Material[] playerMats;
    [SerializeField] private Color[] playerColors;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        leftSpotLight = GameObject.Find("LeftSpotLights").GetComponent<SpotLightColorChanger>();
        rightSpotLight = GameObject.Find("RightSpotLights").GetComponent<SpotLightColorChanger>();
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
            rightSpotLight.SetSpotLightColor(playerColors[colorNumber]);
        }
        else if (ID == 2)
        {
            playerTwo.GetComponent<Renderer>().material = playerMats[colorNumber];
            playerTwo.GetComponent<Light>().color = playerColors[colorNumber];
            leftSpotLight.SetSpotLightColor(playerColors[colorNumber]);
        }
        
    }
}
