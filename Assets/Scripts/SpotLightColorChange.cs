using UnityEngine;

public class SpotLightColorChanger : MonoBehaviour
{
    [SerializeField] private GameObject[] spotLights;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSpotLightColor(Color m_color)
    {
        foreach (var spot in spotLights)
        {
            spot.GetComponent<Light>().color = m_color;
        }
    }
}
