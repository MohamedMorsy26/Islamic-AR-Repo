using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextChangerScript : MonoBehaviour
{
    public TextAsset jsonFile;
    public TMPro.TMP_Text TitleText;
    public TMPro.TMP_Text Time_Text;
    public TMPro.TMP_Text Location_Text;
    public TMPro.TMP_Text Constructor_Text;
    public GameObject LockButton;
    public GameObject TextPanel;
    bool isLocked = false;
    bool SeeText = false;
    Monuments MonumentsInJSONFile;
    Monument CurrentMonument;
    // Start is called before the first frame update
    void Start()
    {
        MonumentsInJSONFile = JsonUtility.FromJson<Monuments>(jsonFile.text);
        isLocked = false;
    }

    public void ChangeToImageText(string MonumentName){
        SeeText = true;
        foreach (Monument m in MonumentsInJSONFile.monuments) {
            if (m.name.Equals(MonumentName)) {
                CurrentMonument = m;
            }
        }
        TitleText.text = CurrentMonument.name;
        Time_Text.text = CurrentMonument.time;
        Constructor_Text.text = CurrentMonument.constructor;
        Location_Text.text = CurrentMonument.location;
        LockButton.SetActive(true);
        TextPanel.SetActive(true);
    }
    public void RemoveText(){
        if (!isLocked) {
            SeeText = false;
            TitleText.text = "Scan a monument";
            Time_Text.text = "";
            Location_Text.text = "";
            Constructor_Text.text = "";
            TextPanel.SetActive(false);
        }
        
    }
    public void LockButtonFunctionality() {
        if (SeeText){
            isLocked = true;
        }
    }
    public void ClearButtonFunctionality() {
        isLocked = false;
        RemoveText();
    }
    public void VisitWikipediaLink() {
        if (SeeText){
            Application.OpenURL(CurrentMonument.wikipediaLink);
        }
    }
}
