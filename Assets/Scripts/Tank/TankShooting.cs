using UnityEngine;
using UnityEngine.UI;

public class TankShooting : MonoBehaviour
{
    public int m_PlayerNumber = 1;
    public Rigidbody m_Shell;
    public Transform m_FireTransform;
    public AudioSource m_ShootingAudio;
    public AudioClip m_ChargingClip;
    public AudioClip m_FireClip;

    public GameObject m_TurretObject;

    public float m_FireRate;
    public float m_ShellSpeed;

    private string m_FireButton;
    private float nextFireTime;



    private void Start()
    {
        m_FireButton = "Fire" + m_PlayerNumber;
    }


    private void Update()
    {
        if (Input.GetButton(m_FireButton))
        {
            Fire(m_FireRate);
        }

        if (m_TurretObject != null)
        {
            // Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            // Plane p = new Plane(Vector3.up, m_TurretObject.transform.position);
            // if (p.Raycast(mouseRay, out float hitDist))
            // {
            //     Vector3 hitPoint = mouseRay.GetPoint(hitDist);
            //     m_TurretObject.transform.LookAt(hitPoint);
            // }
            m_TurretObject.transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0));
        }


    }


    public void Fire(float fireRate)
    {
        if (Time.time <= nextFireTime) return;

        nextFireTime = Time.time + fireRate;

        Rigidbody shellInstance =
            Instantiate(m_Shell, m_FireTransform.position, m_FireTransform.rotation) as Rigidbody;
        shellInstance.velocity = m_ShellSpeed * m_FireTransform.forward;

        m_ShootingAudio.clip = m_FireClip;
        m_ShootingAudio.Play();
    }

}