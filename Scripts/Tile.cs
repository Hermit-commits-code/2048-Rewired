using Godot;
using System;

public partial class Tile : Polygon2D
{
	// The value of the tile, e.g., 2, 4, 8, etc.
	private int value = 0;

	// REference to the label that the tile contains
	private Label label;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	// Function to get the value of the tile
	public int GetValue()
	{
		return value;
	}

	// Function to set the value of the tile
	public void SetValue(int newValue)
	{
		value = newValue;
		UpdateLabel();
	}

	// Function to update the label with the current value
	public void UpdateLabel()
	{
		label = GetNode<Label>("Label");
		label.Text = value.ToString();
	}
}
