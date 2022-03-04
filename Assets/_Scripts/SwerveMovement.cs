using UnityEngine;
using DG.Tweening;

public class SwerveMovement : MonoBehaviour
{
    //[SerializeField] private float swerveSpeed = .5f;
    //[SerializeField] private float maxSwerveAmount = 2;
    //[SerializeField] private float maxHorizontalDistance = 2;
    public Transform coffe;
    public Transform rightParent,leftParent;

    private float deltaPos;
    private float lastMousePosX;
    public Sequence seq;

    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastMousePosX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0))
        {
            deltaPos = Input.mousePosition.x - lastMousePosX;
            //lastMousePosX = Input.mousePosition.x;
            if (deltaPos<0)
            {
               
                lastMousePosX = Input.mousePosition.x;
                if (coffe.transform.CompareTag("sag"))
                {
                    seq = DOTween.Sequence();
                    coffe.transform.tag="sol";
                    coffe.transform.DOKill();
                    coffe.SetParent(leftParent);
                    Vector3 left = new Vector3(0.02f, 1.03f, 0);
                    seq.Join(coffe.transform.DOLocalJump(left, 12 - coffe.localPosition.y, 1, 0.5f).SetEase(Ease.OutCubic).Join(coffe.transform.DOLocalRotate(new Vector3(0, 0,360), 0.2f)));
                    Debug.Log("sol");

                }



            }
            else if (deltaPos>0)
            { //ikinci kez sað olduðunda titreme oluyor
                lastMousePosX = Input.mousePosition.x;
                seq = DOTween.Sequence();
                if (coffe.transform.CompareTag("sol"))
                {
                    coffe.transform.tag = "sag";
                    coffe.transform.DOKill();
                    coffe.SetParent(rightParent);
                    Vector3 right = new Vector3(0.02f, 1.03f, 0);
                    seq.Join(coffe.transform.DOLocalJump(right, 12-coffe.localPosition.y, 1, 0.5f).SetEase(Ease.OutCubic).Join(coffe.transform.DOLocalRotate(new Vector3(0, 0, 360), 0.2f)));
                    Debug.Log("sag");
                }
                
             
            }
            
        }
        else if (Input.GetMouseButtonUp(0))
        {
            deltaPos = 0;
        }
       

        //var swerve = Time.deltaTime * swerveSpeed * deltaPos;
        //swerve = Mathf.Clamp(swerve, -maxSwerveAmount, maxSwerveAmount);

        //var x = transform.position.x + swerve;
        //if (x < maxHorizontalDistance && x > -maxHorizontalDistance)
        //    transform.Translate(swerve, 0, 0);


    }
    private void Update()
    {
     
    }
}
