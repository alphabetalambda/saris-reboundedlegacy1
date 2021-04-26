using Godot;
using System;

public class saris : KinematicBody2D
{
    [Export]
    public int movespeed = 250;
    public int movespeedneg = -250;
    public Vector2 vol;
    public override void _PhysicsProcess(float delta)
    {
        var motion = new Vector2();
        motion.x = Input.GetActionStrength("move_right") - Input.GetActionStrength("move_left");
        motion.y = Input.GetActionStrength("move_down") - Input.GetActionStrength("move_up");
        vol = ((motion.Normalized() * 5) + vol);
        if (vol.x > movespeed)
        {
            vol.x = 250;
        }
        if (vol.x < movespeedneg)
        {
            vol.x = -250;
        }
        if (vol.y > movespeed)
        {
            vol.y = 250;
        }
        if (vol.y < movespeedneg)
        {
            vol.y = -250;
        }
        float horizontalmov = Input.GetActionStrength("move_right") + Input.GetActionStrength("move_left");
        float verticalmove = motion.y = Input.GetActionStrength("move_down") + Input.GetActionStrength("move_up");
        if (horizontalmov == 0f)
        {
            if(vol.x > 0)
            {
                vol.x = vol.x - 25;
            }
            else
            {
                vol.x = vol.x + 25;
            }
        }
        if (verticalmove == 0f)
        {
            if (vol.y > 0)
            {
                vol.y = vol.y - 25;
            }
            else
            {
                vol.y = vol.y + 25;
            }
        }
        MoveAndCollide( vol * delta);
    }
}
