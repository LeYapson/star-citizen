using Godot;

public partial class CelestialBody : RigidBody3D
{
	private const float G = 6.6743e-2f; // Gravitational constant

    [Export] public Vector3 initial_velocity = Vector3.Zero;
    [Export] public bool is_sun = false;

    public override void _Ready()
    {
        LinearVelocity = initial_velocity;
        Globals.CelestialBodies.Add(this);
    }

    public override void _Process(double delta)
    {
        if (!is_sun)
        {
            Gravity(delta);
        }
        else
        {
            LinearVelocity = Vector3.Zero;
        }
    }

    private void Gravity(float delta)
    {
        foreach (Node3D otherbody in Globals.CelestialBodies)
        {
            if (otherbody != this)
            {
                float otherbodyMass = otherbody.Mass;
                Vector3 direction = Translation - otherbody.Translation;
                float distance = direction.Length();

                float forceMag = G * (Mass * otherbodyMass);
                Vector3 force = direction.Normalized() * forceMag;

                AddCentralForce(-force);
            }
        }
    }
}