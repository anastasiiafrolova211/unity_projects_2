using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using RosMessageTypes.Std;
using TMPro;

public class MissionNarrator : MonoBehaviour
{

    public string narratorTopic = "/mission_narrator";

    public TextMeshProUGUI narratorText;
    public int maxLines = 10;

    private ROSConnection ros;
    private string fullText = "";

    void Start()
    {
        ros = ROSConnection.GetOrCreateInstance();
        ros.Subscribe<StringMsg>(narratorTopic, NarratorCallback);
    }

    void NarratorCallback(StringMsg msg)
    {
        AppendLine(msg.data);
    }

    void AppendLine(string line)
    {
        fullText += $"• {line}\n";

        // Keep only last 10 lines
        string[] lines = fullText.Split('\n');
        if (lines.Length > maxLines)
        {
            fullText = string.Join("\n", lines, lines.Length - maxLines - 1, maxLines);
        }

        if (narratorText != null)
            narratorText.text = fullText;
    }
}

