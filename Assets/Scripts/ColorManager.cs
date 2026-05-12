using UnityEngine;

public class ColorManager : MonoBehaviour
{
    [SerializeField] private GameObject playerOne;
    [SerializeField] private GameObject playerTwo;
    
    [SerializeField] private Material[] playerMats;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
        }
        else if (ID == 2)
        {
            playerTwo.GetComponent<Renderer>().material = playerMats[colorNumber];
        }
        
    }
}
