using UnityEngine;

public static class Settings 
{

    // Player Movement 
    public const float runningSpeed = 5.333f;
    public const float walkingSpeed = 2.666f;

    // Player Animation Parameters 
    public static int xInput;
    public static int yInput;
    public static int isWalking;
    public static int isRunning;
    public static int toolEffect;
    public static int isUsingToolRight;
    public static int isUsingToolLeft;
    public static int isUsingToolUp;
    public static int isUsingToolDown;
    public static int isLiftingToolRight;
    public static int isLiftingToolLeft;
    public static int isLiftingToolUp;
    public static int isLiftingToolDown;
    public static int isSwingToolRight;
    public static int isSwingToolLeft;
    public static int isSwingToolUp;
    public static int isSwingToolDown;
    public static int isPickingRight;
    public static int isPickingLeft;
    public static int isPickingUp;
    public static int isPickingDown;

    // Shared Animation Parameters
    public static int isIdleUp;
    public static int isIdleDown;
    public static int isIdleLeft;
    public static int isIdleRight;

    // static constructor
    static Settings()
    {
         // Player Animation Parameters 
        xInput = Animator.StringToHash("xInput");
        yInput = Animator.StringToHash("yInput");
        isWalking = Animator.StringToHash("isWalking");
        isRunning = Animator.StringToHash("isRunning");
        toolEffect = Animator.StringToHash("toolEffect");
        isUsingToolRight = Animator.StringToHash("isUsingToolRight");
        isUsingToolLeft = Animator.StringToHash("isUsingToolLeft");
        isUsingToolUp = Animator.StringToHash("isUsingToolUp");
        isUsingToolDown = Animator.StringToHash("isUsingToolDown");
        isLiftingToolRight = Animator.StringToHash("isLiftingToolRight");
        isLiftingToolLeft = Animator.StringToHash("isLiftingToolLeft");
        isLiftingToolUp = Animator.StringToHash("isLiftingToolUp");
        isLiftingToolDown = Animator.StringToHash("isLiftingToolDown");
        isSwingToolRight = Animator.StringToHash("isSwingingToolRight");
        isSwingToolLeft = Animator.StringToHash("isSwingingToolLeft");
        isSwingToolUp = Animator.StringToHash("isSwingingToolUp");
        isSwingToolDown = Animator.StringToHash("isSwingingToolDown");
        isPickingRight = Animator.StringToHash("isPickingRight");
        isPickingLeft = Animator.StringToHash("isPickingLeft");
        isPickingUp = Animator.StringToHash("isPickingUp");
        isPickingDown = Animator.StringToHash("isPickingDown");

        // Shared Animation Parameters
        isIdleUp = Animator.StringToHash("idleUp");
        isIdleDown = Animator.StringToHash("idleDown");
        isIdleLeft = Animator.StringToHash("idleLeft");
        isIdleRight = Animator.StringToHash("idleRight");
        
    }
}

// This code defines a static class called "Settings" which contains a bunch of static variables.
// These variables are used to store the hash values of different animation parameters for a player character in a Unity game.
// The class also has a static constructor that gets called when the class is first loaded,
// which sets the values of all the variables by calling the UnityEngine.Animator.StringToHash() method on various strings representing the names of the animation parameters.
// These hash values can be used to quickly and efficiently reference the animation parameters in the game's code.
