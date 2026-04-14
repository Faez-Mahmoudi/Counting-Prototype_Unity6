using UnityEngine;

public class DigitalNumber : MonoBehaviour
{
    [SerializeField] private GameObject[] digitalLamps;
    [SerializeField] private Material matUnlit;
    [SerializeField] private Material matLit;
    
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
                ShowNumber(8);
                digitalLamps[1].GetComponent<Renderer>().material = matUnlit;
                break;
            }
            case 1:
            {
                digitalLamps[3].GetComponent<Renderer>().material = matLit;
                digitalLamps[4].GetComponent<Renderer>().material = matLit;
                break;
            }
            case 2:
            {
                ShowNumber(8);
                digitalLamps[5].GetComponent<Renderer>().material = matUnlit;
                digitalLamps[4].GetComponent<Renderer>().material = matUnlit;
                break;
            }
            case 3:
            {
                ShowNumber(8);
                digitalLamps[5].GetComponent<Renderer>().material = matUnlit;
                digitalLamps[6].GetComponent<Renderer>().material = matUnlit;
                break;
            }
            case 4:
            {
                digitalLamps[1].GetComponent<Renderer>().material = matLit;
                digitalLamps[3].GetComponent<Renderer>().material = matLit;
                digitalLamps[4].GetComponent<Renderer>().material = matLit;
                digitalLamps[5].GetComponent<Renderer>().material = matLit;
                break;
            }
            case 5:
            {
                ShowNumber(8);
                digitalLamps[3].GetComponent<Renderer>().material = matUnlit;
                digitalLamps[6].GetComponent<Renderer>().material = matUnlit;
                break;
            }
            case 6:
            {
                ShowNumber(8);
                digitalLamps[3].GetComponent<Renderer>().material = matUnlit;
                break;
            }
            case 7:
            {
                digitalLamps[0].GetComponent<Renderer>().material = matLit;
                digitalLamps[3].GetComponent<Renderer>().material = matLit;
                digitalLamps[4].GetComponent<Renderer>().material = matLit;
                break;
            }
            case 8:
            {
                foreach (var item in digitalLamps)
                {
                    item.GetComponent<Renderer>().material = matLit;
                }
                break;
            }
            case 9:
            {
                ShowNumber(8);
                digitalLamps[6].GetComponent<Renderer>().material = matUnlit;
                break;
            }
        }
    }
}
