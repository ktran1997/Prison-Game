using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {
	
	public Text text;
	private enum States {
		cell, mirror,sheets_0, lock_0, cell_mirror, sheets_1, lock_1, corridor_0, corridor_1, corridor_2, corridor_3, stairs_0, 
		stairs_1, stairs_2, floor, closet_door, in_closet, courtyard, freedom
	};
	private States myState;
	// Use this for initialization
	void Start () {
		myState = States.cell;
	}
	
	// Update is called once per frame
	void Update () {
		print(myState);
		if(myState == States.cell) { cell(); }
		else if(myState == States.sheets_0) { sheets_0(); }
		else if(myState == States.sheets_1) { sheets_1(); }
		else if(myState == States.lock_0) { lock_0(); }
		else if(myState == States.lock_1) { lock_1(); }
		else if(myState == States.mirror) { mirror(); }
		else if(myState == States.cell_mirror) { cell_mirror(); }
		else if(myState == States.corridor_0) { corridor_0(); }
		else if(myState == States.corridor_1) { corridor_1(); }
		else if(myState == States.corridor_2) { corridor_2(); }
		else if(myState == States.corridor_3) { corridor_3(); }
		else if(myState == States.stairs_0) { stairs_0(); }
		else if(myState == States.stairs_1) { stairs_1(); }
		else if(myState == States.stairs_2) { stairs_2(); }
		else if(myState == States.floor) { floor(); }
		else if(myState == States.closet_door) { closet_door(); }
		else if(myState == States.in_closet) { in_closet(); }
		else if(myState == States.courtyard) { courtyard(); }
		else if(myState == States.freedom) { freedom(); }
	}
	#region state handler methods
	void cell() {
		text.text = "You are in a prison cell, and you want to escape. There are " + 
					"some dirty sheets on the bed, a mirror on the wall, and the door " + 
					"is locked from the outside.\n" + 
					"Press S to view Sheets.\n" + 
					"Press M to view Mirror.\n" +
					"Press L to view Lock.";
		if(Input.GetKeyDown(KeyCode.S)) { myState = States.sheets_0; }
		else if(Input.GetKeyDown(KeyCode.M)) { myState = States.mirror; }
		else if(Input.GetKeyDown(KeyCode.L)) { myState = States.lock_0; }
	}
	void mirror() {
		text.text = "The dirty old mirror on the wall seems loose.\n\n" +
					"Press T to take off the mirror.\n" + 
					"Press R to keep looking around the cell.";
		if(Input.GetKeyDown(KeyCode.R)) { myState = States.cell; }
		else if(Input.GetKeyDown(KeyCode.T)) { myState = States.cell_mirror; }
	}
	void cell_mirror() {
		text.text = "You are still in your cell, and you STILL want to escape! There are " +
					"some dirty sheets on the bed, a mark where the mirror was, " +
					"and that pesky door is still there, and firmly locked!\n\n" +
					"Press S to go take a look at your Sheets.\n" +
					"Press L view Lock.";
		if(Input.GetKeyDown(KeyCode.L)) { myState = States.lock_1; }
		else if(Input.GetKeyDown(KeyCode.S)) { myState = States.sheets_1; }
	}
	void sheets_0() {
		text.text = "You can't believe you sleep in these things. Surely it's \n" +
					"time somebody changed them. The pleasures of prison life, " +
					"I guess.\n\n" +
					"Press R to continue roaming your cell.";
		if(Input.GetKeyDown(KeyCode.R)) { myState = States.cell; }
	}
	void sheets_1() {
		text.text = "Holding a mirror in your hand doesn't make the sheets look " +
					"any better.\n\n" +
					"Press R to continue roaming the cell.";
		if(Input.GetKeyDown(KeyCode.R)) { myState = States.cell_mirror; }
	}
	void lock_0() {
		text.text = "This is one of those button locks. You have no idea what the " +
					"combination is. You wish you could somehow see where the dirty " +
					"fingerprints were, maybe that would help.\n\n" +
					"Press R to keep looking for the key.";
		if(Input.GetKeyDown(KeyCode.R)) { myState = States.cell; }
	}
	void lock_1() {
		text.text = "You carefully put the mirror through the bars, and turn it around " +
					"so you can see the lock. You can just make out the fingerprints around " +
					"the buttons. You press the dirty buttons, and hear a click.\n\n" +
					"Press C to go thorugh the corridor.\n" +
					"Press R to continue roaming your cell.";
		if(Input.GetKeyDown(KeyCode.C)) { myState = States.corridor_0; }
		else if(Input.GetKeyDown(KeyCode.R)) { myState = States.cell_mirror; }
	}
	
	void corridor_0() {
		text.text = "When you go through the corridor, you enter a large empty room.\n" +
					"You can either go up the stairs, go through the closet door, " +
					"or inspect the room.\n" +
					"Press S to up the stairs.\n" +
					"Press I to inspect the room.\n" +
					"Press C to go through the closet door.";
		if(Input.GetKeyDown(KeyCode.S)) { myState = States.stairs_0; }
		else if(Input.GetKeyDown(KeyCode.I)) { myState = States.floor; }
		else if(Input.GetKeyDown(KeyCode.C)) { myState = States.closet_door; }
	}
	void corridor_1() {
		text.text = "You now have a hairclip, you can either go up the stairs or " +
					"use the hairclip to go through the closet door lock.\n" +
					"Press S to go up the stairs.\n" +
					"Press C to pick the closet door.";
		if(Input.GetKeyDown(KeyCode.S)) { myState = States.stairs_1; }
		else if(Input.GetKeyDown(KeyCode.C)) { myState = States.in_closet; }
	}
	void corridor_2() {
		text.text = "When you come back through the corridor, you can either " +
					"go up the stairs or return to the closet.\n" +
					"Press S to go up the stairs.\n" +
					"Press C to return to the closet.";
		if(Input.GetKeyDown(KeyCode.S)) { myState = States.stairs_2; }
		else if(Input.GetKeyDown(KeyCode.C)) { myState = States.in_closet; } 
	}
	void corridor_3() {
		text.text = "You now have the janitor suit on.\n" +
					"You can either take the janitor suit off and " +
					"put it back in the closet, or " +
					"you can go up the stairs.\n" +
					"Press C to go back to the closet.\n" +
					"Press S to go up the stairs.";
		if(Input.GetKeyDown(KeyCode.C)) { myState = States.in_closet; }
		else if(Input.GetKeyDown(KeyCode.S)) { myState = States.courtyard; }
	}
	void stairs_0() {
		text.text = "When you go up the stairs, you find a the whole floor is " +
					"full of officers.\n" +
					"Press G to run to the exit.\n" +
					"Press R to return to the empty room.";
		if(Input.GetKeyDown(KeyCode.R)) { myState = States.corridor_0; }
		else if(Input.GetKeyDown(KeyCode.G)) { myState = States.cell; }
	}
	void stairs_1() {
		text.text = "You have a hairclip but it can't help you go through the " +
					"room full of officers.\n" +
					"Press R to return to the empty room.\n" +
					"Press G to run to the exit.";
		if(Input.GetKeyDown(KeyCode.R)) { myState = States.corridor_1; }
		else if(Input.GetKeyDown(KeyCode.G)) { myState = States.cell; } 
	}
	void stairs_2() {
		text.text = "When you go up the stairs, you still see that the whole floor is " +
					"full of officers.\n" +
					"Press G to run to the exit.\n" +
					"Press R to return to the empty room.";
		if(Input.GetKeyDown(KeyCode.R)) { myState = States.corridor_2; }
		else if(Input.GetKeyDown(KeyCode.G)) { myState = States.cell; }
	}
	void floor() {
		text.text = "As you are looking through the room, you see something shiny.\n" +
					"When you look closer you notice it is a hairclip.\n" +
					"Press T to take the hairclip.\n" +
					"Press R to continue inspecting the corridor.";
		if(Input.GetKeyDown(KeyCode.T)) { myState = States.corridor_1; }
		else if(Input.GetKeyDown(KeyCode.R)) { myState = States.corridor_0; }
	}
	void closet_door() {
		text.text = "When you try and go through the closet door, " +
					"you notice the door is locked.\n" +
					"Press R to go back to the middle of the room.\n";
		if(Input.GetKeyDown(KeyCode.R)) { myState = States.corridor_0; }
	}
	void in_closet() {
		text.text = "When you enter the closet, you notice a janitor suit.\n" +
					"Press P to put on the janitor suit.\n" +
					"Press R to return to the empty room.";
		if(Input.GetKeyDown(KeyCode.P)) { myState = States.corridor_3; }
		else if(Input.GetKeyDown(KeyCode.R)) { myState = States.corridor_2; }
	}
	void courtyard() {
		text.text = "When you enter the courtyard, the officers are minding there " +
					"own buisiness. You know that you can sneak through to freedom!\n" +
					"Press F to go towards freedom.\n" +
					"Press R to return to the empty room.";
		if(Input.GetKeyDown(KeyCode.F)) { myState = States.freedom; }
		else if(Input.GetKeyDown(KeyCode.R)) { myState = States.corridor_3; }
	}
	void freedom() {
		text.text = "You are now free!\n" +
					"Press P to play again.";
		if(Input.GetKeyDown(KeyCode.P)) { myState = States.cell; }
	}
	#endregion
}