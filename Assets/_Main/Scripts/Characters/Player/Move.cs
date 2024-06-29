using UnityEngine;
using UnityEngine.AI;

public class Move : MonoBehaviour
{
    [SerializeField] private LayerMask navMeshLayerMask;

    private NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        PlayerInput.OnClickPerformed += PlayerInput_OnClickPerformed;
    }

    private void PlayerInput_OnClickPerformed(object sender, Vector3 mousePosition)
    {
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, float.MaxValue, navMeshLayerMask))
        {
            agent.SetDestination(hitInfo.point);
        }
    }
}
