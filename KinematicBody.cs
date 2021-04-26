using Godot;
using System;

public class KinematicBody : Godot.KinematicBody
{
    [Export]
    public int movespeed = 2;
    public override void _PhysicsProcess(float delta)
    {
        var motion = new Vector3();
        motion.x = Input.GetActionStrength("move_right") - Input.GetActionStrength("move_left");
        motion.y = Input.GetActionStrength("move_up") - Input.GetActionStrength("move_down");
        motion.z = Input.GetActionStrength("move_forward") - Input.GetActionStrength("move_back");
        MoveAndCollide(motion.Normalized() * movespeed * delta);
    }
}