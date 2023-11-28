using Godot;

public partial class Globals : Node
{
	 private Node player;
    private Camera3D camera;
    private bool isPaused;
    public System.Collections.Generic.List<RigidBody3D> CelestialBodies = new();
    private const float gravitationalConstant = 0.0000000000674f;

    public override void _Ready()
    {
        player = GetNode<Node>("PlayerNodePath"); // Replace "PlayerNodePath" with the actual path to your player node
        camera = GetNode<Camera3D>("res://scripts/Camera.cs"); // Replace "CameraNodePath" with the actual path to your camera node
        isPaused = false;
        CelestialBodies = new System.Collections.Generic.List<RigidBody3D>();
    }
}