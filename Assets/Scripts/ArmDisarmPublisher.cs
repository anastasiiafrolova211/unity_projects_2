using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using RosMessageTypes.Std;

public class ArmDisarmPublisher : MonoBehaviour
{
    ROSConnection ros;
    public string topicName = "/bluerov/arm_disarm";

    public bool isArmed = false;

    void Start()
    {
        ros = ROSConnection.GetOrCreateInstance();
        ros.RegisterPublisher<BoolMsg>(topicName);
    }

    public void PublishArmDisarm(bool arm)
    {
        isArmed = arm;
        BoolMsg msg = new BoolMsg(isArmed);
        ros.Publish(topicName, msg);
        Debug.Log($"[ArmDisarmPublisher] Published: {isArmed}");
    }

    public void ToggleArmDisarm()
    {
        PublishArmDisarm(!isArmed);
    }
}
