using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseManager : MonoBehaviour
{
    [SerializeField] private Transform cursorTrans;

    private InputSettings controls;

    [SerializeField] private SoundManager sm;
    [SerializeField] private Transform characterPos;
    [SerializeField] private Transform characterPos2;
    private Transform activeCharacter;

    private Vector3 gone;

    private Vector2 currentPos, targetPos, startPos;

    private bool isMoving;
    private bool active;
    private bool allyTurn;
    private bool battling;

    private float cursorSpeed = 0.1f;
    private float speedUp;
    private float acceleratedSpeed = 0.05f;
    private float movementTimer;

    private int blueHP, redHP;

    float test = 0f;

    private char[,] mapData;

    private void Awake()
    {
        controls = new InputSettings();
    }
    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        currentPos = cursorTrans.position;
        targetPos = currentPos;

        allyTurn = true;
        battling = false;

        blueHP = redHP = 20;

        gone = new Vector3(100f, 100f);

    }

    // Update is called once per frame
    void Update()
    {
        if (!isMoving)
        {
            startPos = currentPos;
            StartCoroutine(MoveCursor());

            if (currentPos != startPos)
            {
                //Cursor move SFX
                //sm.PlayCursorMove();
            }
            
        }

        MoveCharacter();
        Battle();
    }

    private bool ValidatePosition(Vector2 pos)
    {
        //Debug.Log(pos.x + "    " + pos.y);
        if (pos.x > 37 || pos.x < 1 || pos.y > 27 || pos.y < 1)
            return false;
        return true;
    }

    private IEnumerator MoveCursor()
    {
        isMoving = true;

        float time = 0f;

        Vector2 inputVector = controls.Cursor.Movement.ReadValue<Vector2>();

        speedUp = controls.Cursor.Sprint.ReadValue<float>();

        float movementTime = cursorSpeed - (speedUp * acceleratedSpeed);

        inputVector = new Vector2(Mathf.Round(inputVector.x), Mathf.Round(inputVector.y));

        currentPos = cursorTrans.position;
        targetPos = currentPos + inputVector;



        // Movement debug coordinates
        // Debug.Log(currentPos + "    " + inputVector + "      " + targetPos);

        if (ValidatePosition(targetPos))
        {
            while (time < movementTime)
            {
                cursorTrans.position = Vector3.Lerp(currentPos, targetPos, (time / movementTime));
                time += Time.deltaTime;

                yield return null;
            }

            cursorTrans.position = targetPos;
            //Debug.Log(cursorTrans.transform.position);
        }

        isMoving = false;

        
        //Debug.Log(mapData[(int) transform.position.x, (int) transform.position.y]);
    }

    private void MoveCharacter()
    {
        if (controls.Cursor.Select.ReadValue<float>() == 1 && movementTimer == 0 && battling == false)
        {
            movementTimer = 100;

            if (allyTurn)
            {
                activeCharacter = characterPos;
            }
            else
            {
                activeCharacter = characterPos2;
            }

            Vector3 newPos = new Vector3(Mathf.Floor(cursorTrans.transform.position.x), Mathf.Floor(cursorTrans.transform.position.y), activeCharacter.transform.position.z);

            float distance = Vector2.Distance(new Vector2(newPos.x, newPos.y), new Vector2(activeCharacter.transform.position.x, activeCharacter.transform.position.y));

            if (distance < 4)
            {
                activeCharacter.transform.position = newPos;
            }

            allyTurn = !allyTurn;
            //Debug.Log(allyTurn);

            //Debug.Log(distance + " squares");

            //Debug.Log(transform.position.);
            //characterPos.transform.position = new Vector3(Mathf.Floor(cursorTrans.transform.position.x), Mathf.Floor(cursorTrans.transform.position.y), characterPos.transform.position.z);
            //Debug.Log(characterPos.transform.position.ToString() + "P2");
        }

        movementTimer -= 1;

        if (movementTimer < 0)
            movementTimer = 0;
    }

    private void Battle()
    {
        float xDist = characterPos.transform.position.x - characterPos2.transform.position.x;
        float yDist = characterPos.transform.position.y - characterPos2.transform.position.y;
        float totalDistance = Mathf.Abs(xDist) + Mathf.Abs(yDist);
        int num = 0;
        while (num == 0 || num == 9)
        {
            num = Random.Range(0, 9);
        }

        if (totalDistance == 1 && movementTimer == 0)
        {
            movementTimer = 250;
            battling = true;
            if (allyTurn)
            {
                blueHP -= num;
                if (blueHP <= 0)
                {
                    blueHP = 0;
                    characterPos.transform.position = gone;
                }
                Debug.Log("Blue takes " + num + " damage! " + blueHP + " HP remain!");
            }
            else
            {
                redHP -= num;
                if (redHP <= 0)
                {
                    redHP = 0;
                    characterPos2.transform.position = gone;
                }
                Debug.Log("Red takes " + num + " damage! " + redHP + " HP remain!");
            }
            allyTurn = !allyTurn;
        }
        else
        {
            battling = false;
        }
    }

    /*
    private void moveCursor()
    {
        float x, y;

        x = Mouse.current.position.x.ReadValue();
        y = Mouse.current.position.y.ReadValue();

        mousePosition = cam.ScreenToWorldPoint(new Vector3(x, y, 1f));

        x = (int)mousePosition.x + .5f;
        y = (int)mousePosition.y + .5f;

        mousePosition.x = x;
        mousePosition.y = y;

        Debug.Log(x + "  " + y);

        cursorTrans.position = mousePosition;
    }
    */
}
