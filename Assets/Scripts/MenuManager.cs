﻿using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Button menuButton;
    [SerializeField] private GameObject menuOverlay;
    [SerializeField] private GameObject settingsMenu;
    

    private void Awake()
    {
        menuButton.onClick.AddListener(OpenSettings);
    }

    private void OpenSettings()
    {
        menuOverlay.SetActive(true);
        settingsMenu.SetActive(true);
    }
}