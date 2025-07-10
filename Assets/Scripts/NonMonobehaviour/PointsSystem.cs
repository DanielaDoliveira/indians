using TMPro;
using UnityEngine;

namespace GuaresQuest.UI
{
    public class PointsSystem
    {
        
        private float Points {get; set;}
        private float Record {get; set;}
        private TextMeshProUGUI PointsText { get; set;}
        private TextMeshProUGUI RecordText { get; set;}

        public PointsSystem(float points, float record, TextMeshProUGUI pointsText, TextMeshProUGUI recordText)
        {
            Points = points;
            Record = record;
            PointsText = pointsText;
            RecordText = recordText;
        }

        public void Initialize()
        {
            Points = 0;
            Record = PlayerPrefs.GetFloat("RECORD");
            PointsText.text = GetPointsText;
        }
        private string GetPointsText => Points.ToString("F1");
        
        public void SetUpFinishGame()
        {
            if (Points > Record) SaveRecord();
            RecordText.text = PlayerPrefs.GetFloat("RECORD").ToString("F1");
        }
        
        public void GameTimer()
        {
            Points += Time.deltaTime;
            PointsText.text = GetPointsText;

        }
        public void SaveRecord() => PlayerPrefs.SetFloat("RECORD",Points);

    }
}