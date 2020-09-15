using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiPoints : MonoBehaviour
{
    public Text pointText;
    [SerializeField] public int pointInt { get; private set;}

    public void AddPoints(int points) 
    {
        pointInt += points;
        pointText.text = pointInt.ToString();
    }
    public void ResetPoints() 
    {
        pointInt = 0;
        pointText.text = pointInt.ToString();
    }
}
