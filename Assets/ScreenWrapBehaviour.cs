using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Code modified from
 * https://github.com/tutsplus/screen-wrapping-unity
 * Using the tutorial https://gamedevelopment.tutsplus.com/articles/create-an-asteroids-like-screen-wrapping-effect-with-unity--gamedev-15055
 * For advanced wrapping
 * */

public class ScreenWrapBehaviour : MonoBehaviour{	


	Renderer[] renderers;

	//bool isWrappingX = false;
	//bool isWrappingY = false;

	// We use ghosts in advanced wrapping to create a nice wrapping illusion
	Transform[] extraMeebs = new Transform[8];

	float screenWidth;
	float screenHeight;

	void Start()
	{
		// Fetch all the renderers that display ship graphics.
		// In the demo we only have one mesh for the ship and thus
		// only one renderer.
		// We could have a complicated ship, made out of several meshes
		// and this would fetch all the renderers.
		// We use the renderer(s) so we can check if the ship is
		// visible or not.
		renderers = GetComponentsInChildren<Renderer>();

		var cam = Camera.main;

		// We need the screen width in world units, relative to the ship.
		// To do this, we transform viewport coordinates of the screen edges to 
		// world coordinates that lie on on the same Z-axis as the player.
		//
		// Viewport coordinates are screen coordinates that go from 0 to 1, ie
		// x = 0 is the coordinate of the left edge of the screen, while,
		// x = 1 is the coordinate of the right edge of the screen.
		// Similarly,
		// y = 0 is the bottom screen edge coordinate, while
		// y = 1 is the top screen edge coordinate.
		//
		// Which gives us this:
		// (0, 0) is the bottom left corner, to
		// (1, 1) is the top right corner.
		var screenBottomLeft = cam.ViewportToWorldPoint(new Vector3(0, 0, transform.position.z));
		var screenTopRight = cam.ViewportToWorldPoint(new Vector3(1, 1, transform.position.z));

		// The width is then equal to difference between the rightmost and leftmost x-coordinates
		screenWidth = screenTopRight.x - screenBottomLeft.x;
		// The height, similar to above is the difference between the topmost and the bottom yycoordinates
		screenHeight = screenTopRight.y - screenBottomLeft.y;

		// Create a eights ship for the illusion of a nice wrapping effect
		CreateExtraMeebs();

	}

	// Update is called once per frame
	void Update()
	{	
		AdvancedScreenWrap();

	}

	void AdvancedScreenWrap()
	{	
		// Move to separate function
		var isVisible = false;
		foreach(var renderer in renderers)
		{
			if(renderer.isVisible)
			{
				isVisible = true;
				break;
			}
		}

		if(!isVisible)
		{
			SwapMeebs();
		}
	}

	void CreateExtraMeebs()
	{
		for(int i = 0; i < 8; i++)
		{
			// Ghost ships should be a copy of the main ship
			extraMeebs[i] = Instantiate(transform, Vector3.zero, Quaternion.identity) as Transform;

			// But without the screen wrapping component
			DestroyImmediate(extraMeebs[i].GetComponent<ScreenWrapBehaviour>());
		}

		PositionExtraMeebs();
	}

	void PositionExtraMeebs()
	{
		// All ghost positions will be relative to the ships (this) transform,
		// so let's star with that.
		var ghostPosition = transform.position;

		// We're positioning the ghosts clockwise behind the edges of the screen.
		// Let's start with the far right.
		ghostPosition.x = transform.position.x + screenWidth;
		ghostPosition.y = transform.position.y;
		extraMeebs[0].position = ghostPosition;

		// Bottom-right
		ghostPosition.x = transform.position.x + screenWidth;
		ghostPosition.y = transform.position.y - screenHeight;
		extraMeebs[1].position = ghostPosition;

		// Bottom
		ghostPosition.x = transform.position.x;
		ghostPosition.y = transform.position.y - screenHeight;
		extraMeebs[2].position = ghostPosition;

		// Bottom-left
		ghostPosition.x = transform.position.x - screenWidth;
		ghostPosition.y = transform.position.y - screenHeight;
		extraMeebs[3].position = ghostPosition;

		// Left
		ghostPosition.x = transform.position.x - screenWidth;
		ghostPosition.y = transform.position.y;
		extraMeebs[4].position = ghostPosition;

		// Top-left
		ghostPosition.x = transform.position.x - screenWidth;
		ghostPosition.y = transform.position.y + screenHeight;
		extraMeebs[5].position = ghostPosition;

		// Top
		ghostPosition.x = transform.position.x;
		ghostPosition.y = transform.position.y + screenHeight;
		extraMeebs[6].position = ghostPosition;

		// Top-right
		ghostPosition.x = transform.position.x + screenWidth;
		ghostPosition.y = transform.position.y + screenHeight;
		extraMeebs[7].position = ghostPosition;

		// All ghost ships should have the same rotation as the main ship
		for(int i = 0; i < 8; i++)
		{
			extraMeebs[i].rotation = transform.rotation;
		}
	}

	void SwapMeebs()
	{
		// When the main ship is off screen we want to teleport it to
		// the position of the ghost that is currently on screen.
		// A ghost is on screen if its position is
		// between -screenWidth and +screenWidth along the X axis
		// and
		// between -screenHeight and +screenHeight along the Y axis,
		// so we'll look for that.

		foreach(var amoeba in extraMeebs)
		{
			if (amoeba.position.x < screenWidth && amoeba.position.x > -screenWidth &&
				amoeba.position.y < screenHeight && amoeba.position.y > -screenHeight)
			{
				transform.position = amoeba.position;

				// We found the one we needed,
				// no need to iterate through the loop anymore
				// so we break
				break;
			}
		}

		// Reposition the ghost ships because we changed the player ship position
		PositionExtraMeebs();
	}


}