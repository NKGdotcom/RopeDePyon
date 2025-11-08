using UnityEngine;

/// <summary>
/// プレイヤーの位置を保存
/// </summary>
public class PreservationOfCharacter : MonoBehaviour
{
    [SerializeField] private GameObject character;
    private Vector3 preservationPos;
    private Quaternion idleCharacterQuaternion;

    public void PreservationPos()
    {
        preservationPos = character.transform.position;
        idleCharacterQuaternion = character.transform.rotation;
    }
    /// <summary>
    /// 元の位置、状態に戻る
    /// </summary>
    public void ReturnFormerPos()
    {
        character.transform.position = preservationPos;
        character.transform.rotation = idleCharacterQuaternion;
        character.GetComponent<Rigidbody2D>().linearVelocity = Vector3.zero;
    }
}
