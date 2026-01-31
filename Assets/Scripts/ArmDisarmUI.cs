using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ArmDisarmUI : MonoBehaviour
{
    public ArmDisarmPublisher publisher;
    public Button button;                  
    public TextMeshProUGUI buttonText;   

    void Start()
    {
        UpdateUI();
        button.onClick.AddListener(OnButtonClicked);
    }

    public void OnButtonClicked()
    {
        publisher.ToggleArmDisarm();
        UpdateUI();
    }

    void UpdateUI()
    {
        if (publisher.isArmed)
        {
            buttonText.text = "Disarm";
            button.image.color = Color.paleVioletRed;
        }
        else
        {
            buttonText.text = "Arm";
            button.image.color = Color.lightGreen;
        }
    }
}
