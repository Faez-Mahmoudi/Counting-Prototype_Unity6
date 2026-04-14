using UnityEngine;

public class DigitalNumber : MonoBehaviour
{
    [SerializeField] private GameObject[] digitalLamps;
    [SerializeField] private Material matUnlit;
    [SerializeField] private Material matLit;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Renderer renderer = digitalLamps[0].GetComponent<Renderer>();
        //cubeMaterial = renderer.material;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            ShowNumber(1);
    }

    public void ShowNumber(int n)
    {
        foreach (var item in digitalLamps)
        {
            item.GetComponent<Renderer>().material = matUnlit;
        }

        switch (n)
        {
            case 0:
            {
                foreach (var item in digitalLamps)
                {
                    item.GetComponent<Renderer>().material = matLit;
                }
                digitalLamps[1].GetComponent<Renderer>().material = matUnlit;
                break;
            }
            case 1:
            {
                digitalLamps[3].GetComponent<Renderer>().material = matLit;
                digitalLamps[4].GetComponent<Renderer>().material = matLit;
                break;
            }
        }
    }
}
