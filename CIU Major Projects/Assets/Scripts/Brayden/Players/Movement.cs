using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InputType { PC, Arcade }

[System.Serializable]
public class InputMap
{
    [SerializeField] public string playerYAxis;
    [SerializeField] public string playerXAxis;
    [SerializeField] public KeyCode button1;
    [SerializeField] public KeyCode button2;
    [SerializeField] public KeyCode button3;
    [SerializeField] public KeyCode button4;
}

[System.Serializable]
public class PlayerInput
{
    [SerializeField] public Vector2 playerAxis;
    [SerializeField] public bool button1;
    [SerializeField] public bool button2;
    [SerializeField] public bool button3;
    [SerializeField] public bool button4;
}

public class Movement : MonoBehaviour
{
    public InputType inputType = InputType.PC;
    public SAE.ArcadeMachine.PlayerColorId playerColorId;

    public InputMap inputMap;
    public PlayerInput playerInput;

    public float moveSpeed, regSpeed, turnDelay, maxTailLength,
        maxWaterLength, timer, maxTimer, rTime, tTime;
    
    private bool canTurn;

    public Rigidbody2D rb;
    public Transform tailStart;

    public GameObject water, myObject;

    // Sprites
    public SpriteRenderer spriteRenderer;
    public Sprite headR, headL, headD,headU;

    //tail part
    public GameObject currentTail, sideTail, topTail;

    //Consumables
    public ConsumableSpawner consumableSpawnerScript;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        currentTail = sideTail;

        //SAE.ArcadeMachine.playerPressedButton += this.PlayerPressedButton;
        //SAE.ArcadeMachine.playerHeldButton += this.PlayerHeldButton;
        //SAE.ArcadeMachine.playerReleasedButton += this.PlayerReleasedButton;
        //SAE.ArcadeMachine.playerJoystickAxisChanged += this.PlayerJoystickAxisChanged;
        //SAE.ArcadeMachine.configurationFinished += this.ConfigurationFinsihed;
    }

    // Update is called once per frame
    void Update()
    {
        //controlls
        turnDelay -= 1 * Time.deltaTime;
        if (turnDelay <= 0)
        {
            canTurn = true;
        }

        GetInputs();
        ProcessMovement();

        /*
        if (myObject.tag == "Player1")
        {
            Player1Move();
        }

        if (myObject.tag == "Player2")
        {
            Player2Move();
        }

        if (myObject.tag == "Player3")
        {
            Player3Move();
        }

        if (myObject.tag == "Player4")
        {
            Player4Move();
        }

        */

        //MAKE TAIL PARTS
        timer -= 1 * Time.deltaTime;
        if (timer <= 0)
        {
            MakeTail();
        }

        //Rat 
        rTime -= 1 * Time.deltaTime;
        if (rTime >= 0)
        {
            moveSpeed = 5;
        }

        if (rTime <= 0)
        {
            moveSpeed = regSpeed;
        }

        tTime -= 1 * Time.deltaTime;

        if (tTime >= 0)
        {
            maxWaterLength += 5;
        }

        if (GameObject.FindGameObjectsWithTag("Tail").Length >= maxTailLength)
        {
            Destroy(GameObject.FindWithTag("Tail"));
        }

        if (GameObject.FindGameObjectsWithTag("Water").Length >= maxWaterLength)
        {
            Destroy(GameObject.FindWithTag("Water"));
        }
    }

    /*
    [SerializeField] public string playerAxis;
    [SerializeField] public KeyCode button1;
    [SerializeField] public KeyCode button2;
    [SerializeField] public KeyCode button3;
    [SerializeField] public KeyCode button4;
{
    [SerializeField] public Vector2 playerAxis;
    [SerializeField] public bool button1;
    [SerializeField] public bool button2;
    [SerializeField] public bool button3;
    [SerializeField] public bool button4;

        */
    public void GetInputs()
    {
        if (inputType == InputType.PC)
        {
            playerInput.playerAxis.x = Input.GetAxis(inputMap.playerXAxis);
            playerInput.playerAxis.y = Input.GetAxis(inputMap.playerYAxis);
            playerInput.button1 = Input.GetKeyDown(inputMap.button1);
            playerInput.button2 = Input.GetKeyDown(inputMap.button2);
            playerInput.button3 = Input.GetKeyDown(inputMap.button3);
            playerInput.button4 = Input.GetKeyDown(inputMap.button4);
        }
        else if (inputType == InputType.Arcade)
        {
            playerInput.playerAxis = SAE.ArcadeMachine.input.PlayerJoystickAxis(playerColorId);
            playerInput.button1 = SAE.ArcadeMachine.input.PlayerPressingButton(playerColorId, 1);
            playerInput.button2 = SAE.ArcadeMachine.input.PlayerPressingButton(playerColorId, 2);
            playerInput.button3 = SAE.ArcadeMachine.input.PlayerPressingButton(playerColorId, 3);
            playerInput.button4 = SAE.ArcadeMachine.input.PlayerPressingButton(playerColorId, 4);
        }
    }


    public void ProcessMovement()
    {
        if (!canTurn) { return; }

        // Up
        if (playerInput.playerAxis.y < 0)
        {
            spriteRenderer.sprite = headU;
            currentTail = topTail;
            rb.velocity = new Vector2(0, moveSpeed);
            canTurn = false;
            turnDelay = .2f;
        }
        //Down
        else if (playerInput.playerAxis.y > 0)
        {
            spriteRenderer.sprite = headD;
            currentTail = topTail;
            rb.velocity = new Vector2(0, -moveSpeed);
            canTurn = false;
            turnDelay = .2f;
        }

        //Left
        if (playerInput.playerAxis.x < 0)
        {
            spriteRenderer.sprite = headL;
            currentTail = sideTail;
            rb.velocity = new Vector2(-moveSpeed, 0);
            canTurn = false;
            turnDelay = .2f;
        }
        //Right
        else if (playerInput.playerAxis.x > 0)
        {
            spriteRenderer.sprite = headR;
            currentTail = sideTail;
            rb.velocity = new Vector2(moveSpeed, 0);
            canTurn = false;
            turnDelay = .2f;
        }

    }

    /*
    void Player1Move()
    {
        //UP
        if (Input.GetKey(KeyCode.W) && canTurn == true)
        {
            //transform.rotation = Quaternion.Euler(0, 0, 90);
            spriteRenderer.sprite = headU;
            currentTail = topTail;
            rb.velocity = new Vector2(0, moveSpeed);
            canTurn = false;
            turnDelay = .2f;
        }
        //Left
        if (Input.GetKey(KeyCode.A) && canTurn == true)
        {
            //transform.rotation = Quaternion.Euler(0, 0, 180);
            spriteRenderer.sprite = headL;
            currentTail = sideTail;
            rb.velocity = new Vector2(-moveSpeed, 0);
            canTurn = false;
            turnDelay = .2f;
        }
        //Down
        if (Input.GetKey(KeyCode.S) && canTurn == true)
        {
            //transform.rotation = Quaternion.Euler(0, 0, -90);
            spriteRenderer.sprite = headD;
            currentTail = topTail;
            rb.velocity = new Vector2(0, -moveSpeed);
            canTurn = false;
            turnDelay = .2f;
        }
        //Right
        if (Input.GetKey(KeyCode.D) && canTurn == true)
        {
            //transform.rotation = Quaternion.Euler(0, 0, 0);
            spriteRenderer.sprite = headR;
            currentTail = sideTail;
            rb.velocity = new Vector2(moveSpeed, 0);
            canTurn = false;
            turnDelay = .2f;
        }
    }

    void Player2Move()
    {
        //UP
        if (Input.GetKey(KeyCode.T) && canTurn == true)
        {
            //transform.rotation = Quaternion.Euler(0, 0, 90);
            spriteRenderer.sprite = headU;
            currentTail = topTail;
            rb.velocity = new Vector2(0, moveSpeed);
            canTurn = false;
            turnDelay = .2f;
        }
        //Left
        if (Input.GetKey(KeyCode.F) && canTurn == true)
        {
            //transform.rotation = Quaternion.Euler(0, 0, 180);
            spriteRenderer.sprite = headL;
            currentTail = sideTail;
            rb.velocity = new Vector2(-moveSpeed, 0);
            canTurn = false;
            turnDelay = .2f;
        }
        //Down
        if (Input.GetKey(KeyCode.G) && canTurn == true)
        {
            //transform.rotation = Quaternion.Euler(0, 0, -90);
            spriteRenderer.sprite = headD;
            currentTail = topTail;
            rb.velocity = new Vector2(0, -moveSpeed);
            canTurn = false;
            turnDelay = .2f;
        }
        //Right
        if (Input.GetKey(KeyCode.H) && canTurn == true)
        {
            //transform.rotation = Quaternion.Euler(0, 0, 0);
            spriteRenderer.sprite = headR;
            currentTail = sideTail;
            rb.velocity = new Vector2(moveSpeed, 0);
            canTurn = false;
            turnDelay = .2f;
        }
    }

    void Player3Move()
    {
        //UP
        if (Input.GetKey(KeyCode.I) && canTurn == true)
        {
            //transform.rotation = Quaternion.Euler(0, 0, 90);
            spriteRenderer.sprite = headU;
            currentTail = topTail;
            rb.velocity = new Vector2(0, moveSpeed);
            canTurn = false;
            turnDelay = .2f;
        }
        //Left
        if (Input.GetKey(KeyCode.J) && canTurn == true)
        {
            //transform.rotation = Quaternion.Euler(0, 0, 180);
            spriteRenderer.sprite = headL;
            currentTail = sideTail;
            rb.velocity = new Vector2(-moveSpeed, 0);
            canTurn = false;
            turnDelay = .2f;
        }
        //Down
        if (Input.GetKey(KeyCode.K) && canTurn == true)
        {
            //transform.rotation = Quaternion.Euler(0, 0, -90);
            spriteRenderer.sprite = headD;
            currentTail = topTail;
            rb.velocity = new Vector2(0, -moveSpeed);
            canTurn = false;
            turnDelay = .2f;
        }
        //Right
        if (Input.GetKey(KeyCode.L) && canTurn == true)
        {
            //transform.rotation = Quaternion.Euler(0, 0, 0);
            spriteRenderer.sprite = headR;
            currentTail = sideTail;
            rb.velocity = new Vector2(moveSpeed, 0);
            canTurn = false;
            turnDelay = .2f;
        }
    }

    void Player4Move()
    {
        //UP
        if (Input.GetKey(KeyCode.UpArrow) && canTurn == true)
        {
            //transform.rotation = Quaternion.Euler(0, 0, 90);
            spriteRenderer.sprite = headU;
            currentTail = topTail;
            rb.velocity = new Vector2(0, moveSpeed);
            canTurn = false;
            turnDelay = .2f;
        }
        //Left
        if (Input.GetKey(KeyCode.LeftArrow) && canTurn == true)
        {
            //transform.rotation = Quaternion.Euler(0, 0, 180);
            spriteRenderer.sprite = headL;
            currentTail = sideTail;
            rb.velocity = new Vector2(-moveSpeed, 0);
            canTurn = false;
            turnDelay = .2f;
        }
        //Down
        if (Input.GetKey(KeyCode.DownArrow) && canTurn == true)
        {
            //transform.rotation = Quaternion.Euler(0, 0, -90);
            spriteRenderer.sprite = headD;
            currentTail = topTail;
            rb.velocity = new Vector2(0, -moveSpeed);
            canTurn = false;
            turnDelay = .2f;
        }
        //Right
        if (Input.GetKey(KeyCode.RightArrow) && canTurn == true)
        {
            //transform.rotation = Quaternion.Euler(0, 0, 0);
            spriteRenderer.sprite = headR;
            currentTail = sideTail;
            rb.velocity = new Vector2(moveSpeed, 0);
            canTurn = false;
            turnDelay = .2f;
        }
    }
    */




    void MakeTail()
    {
        Instantiate(currentTail, tailStart.position, Quaternion.identity);
        //tail.GetComponent<LayeringSystem>().parentGameObject = GetComponent<SpriteRenderer>();
        Instantiate(water, tailStart.position, Quaternion.identity);
        //myWater.GetComponent<LayeringSystem>().parentGameObject = tail.GetComponent<SpriteRenderer>();
        timer = maxTimer;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Egg")
        {
            Grow();
            print("egg eaten");
            Destroy(collision.gameObject);
            consumableSpawnerScript.consumableCurrentCount--;
        }
        
        if (collision.gameObject.tag == "Insect")
        {
            Destroy(collision.gameObject);
            Grow();
            Insect();
            consumableSpawnerScript.consumableCurrentCount--;
        }
        
        if (collision.gameObject.tag == "Rat")
        {
            Destroy(collision.gameObject);
            Grow();
            Rat();
            consumableSpawnerScript.consumableCurrentCount--;
        }
    }

    void Grow()
    {
        maxTailLength += 1;
        maxWaterLength += 1;
    }

    void Insect()
    {
        rTime = 3;
        print("bug eaten");
    }

    void Rat()
    {
        maxWaterLength += 3;
        print("rat eaten");
    }

    // Event handlers.
    private void PlayerPressedButton(SAE.ArcadeMachine.PlayerColorId playerId, int buttonId)
    {
        Debug.Log("PlayerPressedButton: " + playerId.ToString() + "  " + buttonId);
    }
    private void PlayerHeldButton(SAE.ArcadeMachine.PlayerColorId playerId, int buttonId)
    {
        Debug.Log("PlayerHeldButton: " + playerId.ToString() + "  " + buttonId);
    }
    private void PlayerReleasedButton(SAE.ArcadeMachine.PlayerColorId playerId, int buttonId)
    {
        Debug.Log("PlayerReleasedButton: " + playerId.ToString() + "  " + buttonId);
    }
    private void PlayerJoystickAxisChanged(SAE.ArcadeMachine.PlayerColorId playerId, Vector2 axis)
    {
        Debug.Log("PlayerJoystickAxisChanged: " + playerId.ToString() + "  " + axis);
    }
    private void ConfigurationFinsihed()
    {
        Debug.Log("ConfigurationFinsihed!");
    }
}
