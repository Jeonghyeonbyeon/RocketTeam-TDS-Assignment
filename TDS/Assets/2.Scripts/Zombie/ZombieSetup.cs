using UnityEngine;

public class ZombieSetup : MonoBehaviour
{
    [Header("Parts")]
    [SerializeField] private SpriteRenderer head;
    [SerializeField] private SpriteRenderer body;
    [SerializeField] private SpriteRenderer armL;
    [SerializeField] private SpriteRenderer armR;
    [SerializeField] private SpriteRenderer legL;
    [SerializeField] private SpriteRenderer legR;

    public void Setup(ZombieData data)
    {
        if (!data) return;

        if (!string.IsNullOrEmpty(data.DisplayName))
            gameObject.name = data.DisplayName;

        if (head) head.sprite = data.Parts.Head;
        if (body) body.sprite = data.Parts.Body;
        if (armL) armL.sprite = data.Parts.ArmL;
        if (armR) armR.sprite = data.Parts.ArmR;
        if (legL) legL.sprite = data.Parts.LegL;
        if (legR) legR.sprite = data.Parts.LegR;

        if (head) head.color = data.Tint;
        if (body) body.color = data.Tint;
        if (armL) armL.color = data.Tint;
        if (armR) armR.color = data.Tint;
        if (legL) legL.color = data.Tint;
        if (legR) legR.color = data.Tint;

        transform.localScale = Vector3.one * data.Scale;

        if (TryGetComponent(out Rigidbody2D rb))
        {
            rb.mass = data.Mass;
            rb.gravityScale = data.GravityScale;
            rb.drag = data.LinearDrag;
            rb.angularDrag = data.AngularDrag;
            rb.interpolation = RigidbodyInterpolation2D.Interpolate;
            rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        }
    }
}