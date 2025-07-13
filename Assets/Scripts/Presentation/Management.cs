using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using GuaresQuest.UI;
using Infrastructure;
using Sirenix.OdinInspector;

public class Management : MonoBehaviour
{
   
    private float _points;
    private float _record;
    [BoxGroup("Text Mesh Pro"), Required]
    public TextMeshProUGUI pointsText, recordText;
    private Controls _controls;
    private PointsSystem _pointsSystem;
    private int _scene;
    
    public static Management Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); 
            return;
        }
        Instance = this;

    }

    void Start()
    {
        Time.timeScale = 1;
        _scene = SceneManager.GetActiveScene().buildIndex;
        _pointsSystem = new PointsSystem(_points, _record, pointsText, recordText);
        _pointsSystem.Initialize();
        _controls = new Controls(_scene);
    }

    public void SetUpFinishGame() => _pointsSystem.SetUpFinishGame();
    public void ReloadScene() => _controls.Play();
    public void CloseGame() => _controls.Quit();
    private void Update()=> _pointsSystem.GameTimer();
    
   



   
}
