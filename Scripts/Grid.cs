using Godot;
using System;

public partial class Grid : Node2D
{
	// private empty array to hold the tiles
	private Tile[,] grid;

	// grid access to the Packed Scene to aribtrarily instantiate tiles
	private PackedScene sceneTile;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// Load the PackedScene for the Tile
		sceneTile = ResourceLoader.Load<PackedScene>("res://Scenes/Tile.tscn");
		// Initialize the grid with a size of 4x4
		grid = new Tile[4, 4];
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	// Method to create a tile at a specific position
	private void PopulateStartingTiles()
	{
		// Create a random object
		Random rand = new Random();
		// Two sets of random numbers to determine the position of the tile
		Vector2 tile1coords = new Vector2(rand.Next(0, 4), rand.Next(0, 4));
		Vector2 tile2coords = new Vector2(rand.Next(0, 4), rand.Next(0, 4));
		// Check to make sure the two tiles are not the same
		while (tile1coords.X == tile2coords.X && tile1coords.Y == tile2coords.Y)
		{
			tile1coords = new Vector2(rand.Next(0, 4), rand.Next(0, 4));
			// Generate a new random position for the second tile
			// until it is different from the first
			// This ensures that we have two distinct starting tiles
			tile2coords = new Vector2(rand.Next(0, 4), rand.Next(0, 4));
		}
		// Create the first tile at the random position
		Tile tile1 = sceneTile.Instantiate<Tile>() as Tile;
	}
}
