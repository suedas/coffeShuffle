using UnityEngine;

public class SwerveMovement : MonoBehaviour
{
    [SerializeField] private float swerveSpeed = .5f;
    [SerializeField] private float maxSwerveAmount = 2;
    [SerializeField] private float maxHorizontalDistance = 2;

    private float deltaPos;
    private float lastMousePosX;

    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastMousePosX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0))
        {
            deltaPos = Input.mousePosition.x - lastMousePosX;
            lastMousePosX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            deltaPos = 0;
        }

        var swerve = Time.deltaTime * swerveSpeed * deltaPos;
        swerve = Mathf.Clamp(swerve, -maxSwerveAmount, maxSwerveAmount);

        var x = transform.position.x + swerve;
        if (x < maxHorizontalDistance && x > -maxHorizontalDistance)
            transform.Translate(swerve, 0, 0);
    }
}
