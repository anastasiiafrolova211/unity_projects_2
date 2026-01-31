using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using RosMessageTypes.Geometry;

public class CheckPressed : MonoBehaviour
{
    public string topic = "/bluerov1/cmd_vel";
    public int forwardSpeed = 1;
    public int angularSpeed = 5;

    private ROSConnection ros;

    void Start()
    {
        ros = ROSConnection.GetOrCreateInstance();
        ros.RegisterPublisher<TwistMsg>(topic);
    }

    void Update()
    {
        TwistMsg twist = new TwistMsg();

        // for surge
        if (Input.GetKey(KeyCode.W))
        {
            twist.linear.x = forwardSpeed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            twist.linear.x = -forwardSpeed;
        }
        else
        {
            twist.linear.x = 0.0f;
        }

        //for yaw
        if (Input.GetKey(KeyCode.A))
        {
            twist.angular.z = angularSpeed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            twist.angular.z = -angularSpeed;
        }
        else
        {
            twist.angular.z = 0.0f;
        }

        twist.linear.y = 0;
        twist.linear.z = 0;
        twist.angular.x = 0;
        twist.angular.y = 0;
        

        ros.Publish(topic, twist);
    }
}
