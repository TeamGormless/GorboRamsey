using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class CharacterMovementController : MonoBehaviour
{
    public bool CanMove { get; private set; } = true;

    public KeyCode MoveFowardKey;
    public KeyCode MoveRightKey;
    public KeyCode MoveBackKey;
    public KeyCode MoveLeftKey;

    public float MoveSpeed;

    private NavMeshAgent navMeshAgent;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        DoMoveControls();
    }

    private void DoMoveControls()
    {
        if (Input.GetKey(MoveFowardKey))
            MoveCharacter(Vector3.forward);
        if (Input.GetKey(MoveRightKey))
            MoveCharacter(Vector3.right);
        if (Input.GetKey(MoveBackKey))
            MoveCharacter(Vector3.back);
        if (Input.GetKey(MoveLeftKey))
            MoveCharacter(Vector3.left);
    }

    private void SetCanMove(bool set)
    {
        CanMove = set;
    }

    private void MoveCharacter(Vector3 v)
    {
        if (CanMove) {
            navMeshAgent.Move((v * MoveSpeed)* Time.deltaTime);
            RotateCharacterTowardsVector(v);
        }
    }

    private void RotateCharacterTowardsVector(Vector3 v)
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(v), Time.deltaTime * 20f);
    }
}
