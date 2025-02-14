using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FAKScript : MonoBehaviour
{
    
    public TextMeshProUGUI BulletText;

    void SetNumber(int number)
    {
        BulletText.text = number + "/" + 5;
    }
}
