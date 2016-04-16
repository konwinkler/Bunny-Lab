using System;
using UnityEngine;

public class AI
{
	internal World world;

	public AI (World world)
	{
		this.world = world;	
	}

	public void act(Actor actor, GameState state)
	{
		Debug.Log("Ai act start");
		MovementRange range = state.movementMode.movementRange;


		if (range.validMovementTiles.Count == 0) {
			Debug.Log ("No reachable tiles for ai");
			state.nextTurn ();
		}

		int target = UnityEngine.Random.Range(0, range.validMovementTiles.Count);
		Tile targetTile = range.validMovementTiles [target];

		state.currentMode.click (targetTile);
	}
}

