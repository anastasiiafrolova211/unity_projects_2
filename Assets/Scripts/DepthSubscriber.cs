using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using RosMessageTypes.Std;

public class DepthSubscriber : MonoBehaviour
{
    public string topicName = "/bluerov2/global_position/rel_alt";
    public float depth;
    public TMPro.TextMeshProUGUI depthText;

    void Start()
    {
        ROSConnection ros = ROSConnection.GetOrCreateInstance();
        ros.Subscribe<Float64Msg>(topicName, DepthCallback);
    }

    void DepthCallback(Float64Msg msg)
    {
        depth = (float)msg.data;
        if (depthText != null)
            depthText.text = $"Depth: \n {-depth:F2} meters";
    }
}
