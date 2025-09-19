using UnityEngine;

[CreateAssetMenu(fileName = "ZombieData", menuName = "OS/Zombie Data", order = 0)]
public class ZombieData : ScriptableObject
{
    [Header("Identity")]
    [SerializeField] private string id = "zombie_default";
    [SerializeField] private string displayName = "Zombie";
    public string Id => id;
    public string DisplayName => displayName;

    [Header("Stats")]
    [SerializeField, Min(1)] private int maxHP = 10;
    [SerializeField, Min(0)] private int attackDamage = 1;
    [SerializeField, Min(0.1f)] private float attackCooldown = 0.7f;
    [SerializeField, Min(0.1f)] private float attackRange = 1.2f;
    public int MaxHP => maxHP;
    public int AttackDamage => attackDamage;
    public float AttackCooldown => attackCooldown;
    public float AttackRange => attackRange;

    [Header("Movement")]
    [SerializeField, Range(0.3f, 6f)] private float moveSpeed = 2.2f;
    public float MoveSpeed => moveSpeed;

    [Header("Pile (쌓임/흐름)")]
    [SerializeField, Range(0.5f, 2.5f)] private float stopRadius = 1.3f;
    [SerializeField, Range(0f, 8f)] private float climbPulse = 3.0f;
    [SerializeField, Range(0.1f, 2f)] private float pulseCooldown = 0.5f;
    [SerializeField, Range(0f, 2f)] private float lateralBias = 0.6f;
    public float StopRadius => stopRadius;
    public float ClimbPulse => climbPulse;
    public float PulseCooldown => pulseCooldown;
    public float LateralBias => lateralBias;

    [Header("Physics 2D")]
    [SerializeField, Min(0.1f)] private float mass = 1f;
    [SerializeField, Min(0f)] private float gravityScale = 0.8f;
    [SerializeField, Min(0f)] private float linearDrag = 0.3f;
    [SerializeField, Min(0f)] private float angularDrag = 0.6f;
    public float Mass => mass;
    public float GravityScale => gravityScale;
    public float LinearDrag => linearDrag;
    public float AngularDrag => angularDrag;

    [Header("Appearance")]
    [SerializeField] private Color tint = Color.white;
    [SerializeField, Range(0.5f, 2.5f)] private float scale = 1f;
    public Color Tint => tint;
    public float Scale => scale;

    [System.Serializable]
    public struct PartSprites
    {
        [SerializeField] private Sprite head;
        [SerializeField] private Sprite body;
        [SerializeField] private Sprite armL;
        [SerializeField] private Sprite armR;
        [SerializeField] private Sprite legL;
        [SerializeField] private Sprite legR;

        public Sprite Head => head;
        public Sprite Body => body;
        public Sprite ArmL => armL;
        public Sprite ArmR => armR;
        public Sprite LegL => legL;
        public Sprite LegR => legR;
    }

    [SerializeField] private PartSprites parts;
    public PartSprites Parts => parts;

    [Header("Spawn")]
    [SerializeField, Min(1)] private int spawnWeight = 1;
    public int SpawnWeight => spawnWeight;

    private void OnValidate()
    {
        attackRange = Mathf.Max(0.1f, attackRange);
        stopRadius = Mathf.Max(0.1f, stopRadius);

        if (attackRange < stopRadius * 0.8f)
            attackRange = stopRadius;
    }
}