
# Making Minecraft

## Part 1

### Ground

  1. Create ground plane
  2. Scale ground plane: `(16,1,16)`
  3. Position ground plane: `(0,-0.5,0)`

### Cube
  4. Create cube (Maybe call it "block" instead of "cube"?)
  5. Drag cube to Assets (to make it a "prefab")
  6. Create cube material in Assets
  7. Set material color to something like brown
  8. Assign material to cube prefab mesh renderer
  9. Save scene (and note the new scene Asset)
  10. Drag a couple cube prefabs into the scene
  11. Manually set the position coords to be integer? (e.g., `(5,0,0)`,
      `(-5,0,3)`, `(2,0,-2)`)
  12. Add script `MineBlock.cs` to collider for cube prefab
  13. Implement `OnMouseDown`. Just `Debug.Log` a message to console to start
      with. Use `gameObject.name`.
  14. Then `Destroy(gameObject);` on mouse down.

### Item Drop
  15. Create Cube called ItemDrop.
  16. Scale it: (0.5,0.5,0.5)
  17. Rotate it: (15,0,5) or whatever
  17. Turn off shadows?
  18. Drag to Assets to make it a prefab
  19. Hide the source GameObject ItemDrop.
  20. Click prefab ItemDrop.
  21. Give it the CubeMaterial. (Or create a new material for it?)
  22. In MineBlock.cs, add public GameObject itemDropPrefab;
  22. Drag prefab to itemDropPrefab field of Cube prefab.
  23. OnMouseDown, Instantiate( itemDropPrefab, transform.position,
      itemDropPrefab.transform.rotation); // or maybe define the rotation here
      programmatically?

## Part 2

### First Person Character Controller
  1. Import FirstPersonCharacter from Standard Assets. Also import dependencies
     CrossPlatformInput and Utility.
  2. Drag FirstPersonCharacter into the scene and remove the old "Main Camera"
     -- the FirstPersonCharacter contains its own camera. (It is under
     Assets/Standard
     Assets/Characters/FirstPersonCharacter/Prefabs/FPSController)
  3. Add MouseLock.cs script to FPSController.
  4. Change FPSController transform.scale to (0.5,0.9,0.5) so player can fit
     down into a one block hole (eventually) and through a two block height
     passage.
  5. Change radius of collider from 0.5 to 1 maybe? So item collection is
     triggered more easily.
  6. Optional: Change mouse cursor to look like crosshairs:
     1. Create a 16x16 png image of cross hairs.
     2. Append .bytes extension to the file name.
     3. In MouseLock.cs, public TextAsset crossHairsRaw; private Texture2D
        crossHairs;
     4. In Start, crossHairs = new Texture2D(16,16);
        crossHairs.LoadImage(crossHairsRaw.bytes);
     5. In LockCursor(), Cursor.SetCursor( crossHairs, new Vector2(8,8),
        CursorMode.Auto);
     6. In UnlockCursor(), Cursor.SetCursor( null, Vector2.zero,
        CursorMode.Auto); (Note cursor may not change back to original when
        running in the Unity Game View. Build and run to test.)

### Item Drop Trigger
  1. Enable Is Trigger on ItemDrop prefab.
  3. Change tag on FPSController to "Player".
  2. Add ItemDrop.cs script to ItemDrop prefab.
  4. In ItemDrop.cs OnTriggerEnter, if collider.tag == "Player", Destroy
     ItemDrop game object.
  4. Need FPSController to have a collider? (Does not appear so.)
  5. TODO: Add block to inventory. Prerequisite: Inventory mechanism...

### Sound effect when mining a block.
  1. add a .wav file to Assets
  2. In MineBlock.cs, public AudioClip mineSound;
  3. Assign .wav file to that mineSound field in inspector.
  4. In MineBlock.cs OnMouseDown(), before Destroy(gameObject),
     AudioSource.PlayClipAtPoint( mineSound, transform.position);
     // Note that declaring an AudioSource object to assign the clip and then
     // .Play() will not work before a Destroy because the Audio will be
     // aborted when its game object is destroyed.

### Sound effect when collecting a dropped item
  1. Same as for sound effect when mining a block
  2. Play the clip in the OnTrigger() function.

### Adjust walking volume?
  1. Click on the FPSController game object (not the prefab?)
  2. Adjust volume slider under the Audio Source component
  3. About 0.25 seems good. Basically do not want the walking sound to drown out
     the mining and collectin sounds.

### Poor man&rsquo;s terrain generation
  1. Add SpawnBlocks.cs script to Plane game object.
  2. public GameObject block;
  3. Drag cube prefab into block field
  4. Loops in Start() to Instantiate blocks in a pattern of some sort. Could be
     random height at each plane coord. Or a sinusoidal ripple pattern might be
     nice.
  5. Modify initial position of FPSController to be at (x,z) origin and at y
     value above the highest possible block at (x,z)=(0,0).

## Optional Stuff

### Optional: outline the blocks on focus
  1. create empty GameObject called BoxOutline (or maybe BlockOutline)
  2. create cube as child of empty -- call it "line"
  2. turn off shadows (cast and receive)
  3. scale line: (0.015,1,0.015)
  4. position it
  5. duplicate and position three more in that direction
  6. rotate, duplicate, and position for next set of four edges
  7. repeat for final set of four edges
  8. drag into Assets to make it a prefab
  9. create Material, color black, add to BoxOutline prefab.
  10. In MineBlock.cs, add public GameObject boxOutlinePrefab, private
      GameObject boxOutline, and Renderer[] wireFrame array.
  11. Drag BoxOutline prefab to the public boxOutlinePrefab field in the
      inspector
  12. In Start, instantiate the BoxOutline prefab, get the Renderers of all the
      children (lines/wires), and disable rendering on all of them.
  13. OnMouseEnter, enable rendering on all the wires
  14. OnMouseExit, disable rendering on all the wires
  15. OnMouseDown, Destroy(boxOutline);

