using UnityEngine;

/// <summary>
/// 表示するボタン(UIではなくオブジェクト)
/// </summary>
public class DisplayButton : MonoBehaviour
{
    [SerializeField] private GameObject[] displayFloors;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out BeingPulledCharacter character))
        {
            foreach(GameObject displayFloor in displayFloors)
            {
                displayFloor.SetActive(true);
            }
            this.gameObject.SetActive(false);
        }
    }
}
