The project works only when Unity and Stonefish are running simultaneously.

All topic names follow the Stonefish BlueROV names, except for the camera output, which is published from Unity.

The Unity side acts as a visualization UI, and interaction layer while Stonefish provides the physics simulation.

Velocity parameters are tuned for joystick control. Keyboard input (W/A/S/D) is intentionally not supported: keyboard input is too reactive. 
Gains were calibrated for joystick input only -> for correct behavior, use a joystick.

This setup was designed to:
Implement real ROV operation as closely as possible
Enable realistic testing of 3D localization 
