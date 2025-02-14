using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Cell : MonoBehaviour
{
    [SerializeField]
    private GameObject _LeftW;

    [SerializeField]
    private GameObject _RightW;

    [SerializeField]
    private GameObject _FrontW;

    [SerializeField]
    private GameObject _BackW;

    [SerializeField]
    private GameObject Unvisited;


    public bool IsVisited { get; private set; }
    
    public void Visit()
    {
        IsVisited = true;
        Unvisited.SetActive(false);
    }

    public void ClearLeftW() {  _LeftW.SetActive(false); }
    public void ClearRightW() { _RightW.SetActive(false); }
    public void ClearFrontW() { _FrontW.SetActive(false); }
    public void ClearBackW() { _BackW.SetActive(false); }

}