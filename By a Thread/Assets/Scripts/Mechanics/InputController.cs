using UnityEngine;

public class InputController {
    public int playerNumber;

    public InputController(int playerNumber) {
        this.playerNumber = playerNumber;
    }
    public float getHorizontalAxis() {
        if (playerNumber == 1) {
            return Input.GetAxis("Horizontal");
        } else {
            return Input.GetAxis("HorizontalAlternate");
        }
    }

    public bool getJumpButton() {
        if (playerNumber == 1) {
            return Input.GetButton("Jump");
        } else {
            return Input.GetButton("JumpAlternate");
        }
    }

    public bool getDown() {
        if (playerNumber == 1) {
            return Input.GetKey(KeyCode.DownArrow);
        } else {
            return Input.GetKey(KeyCode.S);
        }
    }

    public bool getUp() {
        if (playerNumber == 1) {
            return Input.GetKey(KeyCode.UpArrow);
        } else {
            return Input.GetKey(KeyCode.W);
        }
    }
}
