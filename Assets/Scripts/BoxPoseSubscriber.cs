using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using RosMessageTypes.Geometry;
using TMPro;

public class BoxPoseSubscriber : MonoBehaviour
{

    public string topicName = "/box_pose";

    public TextMeshProUGUI textOutput;

    private ROSConnection ros;

    void Start()
    {
        ros = ROSConnection.GetOrCreateInstance();
        ros.Subscribe<PoseStampedMsg>(topicName, PoseCallback);
    }

    void PoseCallback(PoseStampedMsg msg)
    {
        float x = (float)msg.pose.position.x;
        float y = (float)msg.pose.position.y;
        float h = (float)msg.pose.position.z;

        if (textOutput != null)
        {
            textOutput.text =
                $"Topic: {topicName}\n" +
                $"x: {x:F1} px\n" +
                $"y: {y:F1} px\n" +
                $"h: {h:F1} px";
        }
    }
}

