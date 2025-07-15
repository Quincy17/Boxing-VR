using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDummy : MonoBehaviour
{
    public float punchForceThreshold = 3.0f; // kecepatan minimum untuk dianggap pukulan
    public Animator animator; // opsional, kalau pakai animasi

    private void OnCollisionEnter(Collision collision)
    {
        // Cek jika yang menabrak punya tag "PlayerHand"
        if (collision.gameObject.CompareTag("PlayerHand"))
        {
            Rigidbody handRb = collision.gameObject.GetComponent<Rigidbody>();
            if (handRb != null)
            {
                float punchForce = handRb.velocity.magnitude;

                if (punchForce > punchForceThreshold)
                {
                    Debug.Log("Pukulan masuk! Kekuatan: " + punchForce);

                    // Tambahkan logika reaksi dummy
                    // Contoh: mainkan animasi terkena pukulan
                    if (animator != null)
                    {
                        animator.SetTrigger("Hit");
                    }

                    // Tambah efek partikel / suara di sini jika mau
                }
            }
        }
    }
}