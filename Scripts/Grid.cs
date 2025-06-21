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

		// Populate the grid with starting tiles
		PopulateStartingTiles();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public override void _Input(InputEvent @event)
	{
		// Check if the event is a key press
		if (@event.IsActionPressed("up"))
		{
			MoveTiles("up");
		}
		if (@event.IsActionPressed("down"))
		{
			MoveTiles("down");
		}
		if (@event.IsActionPressed("left"))
		{
			MoveTiles("left");
		}
		if (@event.IsActionPressed("right"))
		{
			MoveTiles("right");
		}
	}

	// Skeleton of move tile function
	private bool MoveTiles(String direction)
	{
		GD.Print("MoveTiles() called." + direction);
		bool movementOccurred = false;

		return movementOccurred;
	}

	//  utility method
	// to get the tile at a specific position
	private Vector2 ArrayToTileCoords(Vector2 arrayCoords)
	{
		// Convert the array coordinates to tile coordinates
		return new Vector2(arrayCoords.X * 115 + 15,
			arrayCoords.Y * 115 + 15);
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
		// Set the position of the first tile
		tile1.Position = ArrayToTileCoords(tile1coords);
		AddChild(tile1);

		// Create the second tile at the random position
		Tile tile2 = sceneTile.Instantiate<Tile>() as Tile;
		// Set the position of the second tile
		tile2.Position = ArrayToTileCoords(tile2coords);
		AddChild(tile2);

		// Store the tiles in the grid array
		grid[(int)tile1coords.X, (int)tile1coords.Y] = tile1;
		grid[(int)tile2coords.X, (int)tile2coords.Y] = tile2;
	}
}
