using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightTabs : MonoBehaviour
{
    public static bool WindowIsOpen { get; private set; }
    [SerializeField]
    private List<GameObject> _windows;

    private void Start()
    {
        CloseAllWindows();
    }
    public void OpenClose(int tabNum)
    {
        if ((tabNum < 0) || _windows.Count <= tabNum)
        {
            Debug.LogWarning("Window not init!");
            return;
        }

        if (_windows[tabNum].activeSelf)
        {
            _windows[tabNum].gameObject.SetActive(false);
        }
        else
        {
            CloseAllWindows();
            _windows[tabNum].SetActive(true);
            WindowIsOpen = true;
        }
    }

    public void CloseAllWindows()
    {
        foreach (var tab in _windows)
        {
            tab.gameObject.SetActive(false);
        }
        WindowIsOpen = false;
    }  
}
