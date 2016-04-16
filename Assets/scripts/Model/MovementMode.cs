using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class MovementMode : GameMode
{
    private World world;
    public MovementRange movementRange { get; internal set; }
	private Action notifyEndTurn;

    public MovementMode(World world)
    {
        this.world = world;
        movementRange = new MovementRange(world);
    }

    public void click(Tile tile)
    {
        if (movementRange.validMovementTiles.Contains(tile))
        {
			Actor actor = world.gameState.currentActor;
			actor.registerFinishedMoving (endAction);
            world.gameState.currentActor.move(tile);
        }
    }

	void endAction (Actor actor)
	{
		actor.unregisterFinishedMoving (endAction);
		notifyEndTurn ();
	}

    public void updateMousePosition(Tile tile)
    {
        //nothing
    }

    public void end()
    {
        movementRange.clear();
    }

    public void start()
    {
        movementRange.newMovementRange(world.gameState.currentActor);
    }


    public void registerFinishedAction(Action callback)
    {
		notifyEndTurn += callback;
    }

	public void unregisterFinishedAction (Action callback)
	{
		notifyEndTurn -= callback;
	}

	public void destroy ()
	{
		movementRange.clear ();
		notifyEndTurn = null;
	}
}
