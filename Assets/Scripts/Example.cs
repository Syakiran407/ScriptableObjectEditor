using UnityEngine;

public class Example : MonoBehaviour
{

    [SerializeField]
    public RuntimeEnumData runtimeEnumData;

    void Start()
    {
        runtimeEnumData.AddValue("Red");
        runtimeEnumData.AddValue("Green");
        runtimeEnumData.AddValue("Blue");

        int redValue = runtimeEnumData.GetValue("Red");
        int greenValue = runtimeEnumData.GetValue("Green");
        int blueValue = runtimeEnumData.GetValue("Blue");

        Debug.Log("Red Value: " + redValue);
        Debug.Log("Green Value: " + greenValue);
        Debug.Log("Blue Value: " + blueValue);
    }
}
