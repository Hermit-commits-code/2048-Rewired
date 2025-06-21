using Godot;
using System;

public partial class Node : Godot.Node
{
    public override void _Ready()
    {
        // This method is called when the node is added to the scene.
        GD.Print("Node is ready!");
    }
    public override void _Process(double delta)
    {
        // This method is called every frame.
        GD.Print("Processing frame with delta: " + delta);
    }
}
