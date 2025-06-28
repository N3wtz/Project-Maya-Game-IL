using UnityEngine;

public class FindItemBatik : MonoBehaviour
{
    public GameObject[] items;     // List item
    public float maxDistance = 2f; // Jarak maksimum untuk hilangkan item

    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach (GameObject item in items)
            {
                if (item.activeSelf) // cek kalau item masih aktif
                {
                    float distance = Vector3.Distance(player.transform.position, item.transform.position);
                    if (distance <= maxDistance)
                    {
                        item.SetActive(false);
                        Debug.Log("Item berhasil dihilangkan!");
                        break; // hanya hilangkan 1 item per spasi
                    }
                }
            }

            // Cek kalau semua item sudah hilang
            bool allGone = true;
            foreach (GameObject item in items)
            {
                if (item.activeSelf)
                {
                    allGone = false;
                    break;
                }
            }

            if (allGone)
            {
                Debug.Log("Sukses! Semua item sudah hilang.");
                // Bisa tambahkan tampil UI sukses di sini
            }
        }
    }
}