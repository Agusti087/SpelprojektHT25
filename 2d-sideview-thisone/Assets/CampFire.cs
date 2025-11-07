    using UnityEngine;

    public class CampFire : MonoBehaviour
    {
        [SerializeField] private MainPlayer player;
        [SerializeField] private float warmRange = 5f;
        [SerializeField] private float maxWarmMultiplier = -4f;
        [SerializeField] private int requiredLogs = 3;
        [SerializeField] private float burnTime = 30f;
        //[SerializeField] private FireBarBehaviour fireBar;

        [SerializeField] private int maxRefills = 3;
        private int refillCount = 0;

        private bool isLit = false;
        private float burnTimer = 0f;
        private float baselineColdIncrease;

        public void SetPlayer(MainPlayer player)
        {
            this.player = player;
        }

        public MainPlayer Player => player;

        private FireBarBehaviour fireBar;

        void Start()
        {
            // Find the FireHealth object in the scene
            GameObject fireHealthObj = GameObject.Find("FireHealth");
            if (fireHealthObj != null)
            {
                fireBar = fireHealthObj.GetComponent<FireBarBehaviour>();
                if (fireBar != null)
                    fireBar.SetMaxBurnTime(burnTime);
                else
                    Debug.LogError("FireHealth object does not have a FireBarBehaviour!");
            }
            else
            {
                Debug.LogError("FireHealth object not found in the scene!");
            }

            baselineColdIncrease = player != null ? player.ColdIncrease : 1f;
        }


        void Update()
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);

            if (Input.GetKeyDown(KeyCode.Q) && distance <= warmRange)
            {
                if (!isLit)
                    TryLightFire();
                else
                    TryAddLogs();
            }

            if (isLit)
            {
                burnTimer -= Time.deltaTime;
                if (burnTimer <= 0f)
                {
                    isLit = false;
                    burnTimer = 0f;
                }
            }

            if (isLit && distance <= warmRange)
                player.ColdIncrease = maxWarmMultiplier;
            else
                player.ColdIncrease = baselineColdIncrease;

            fireBar?.SetBurnTime(burnTimer);
        }

        private void TryLightFire()
        {
            if (player.Logs >= requiredLogs)
            {
                player.Logs -= requiredLogs;
                isLit = true;
                burnTimer = burnTime;
                fireBar?.SetMaxBurnTime(burnTime);
                refillCount = 0;
            }
        }

        private void TryAddLogs()
        {
            if (refillCount >= maxRefills)
            {
                Destroy(gameObject);
                return;
            }

            if (player.Logs <= 0 && requiredLogs > 0)
                return;

            if (player.Logs > 0)
                player.Logs--;

            float addedBurnTime = burnTime / Mathf.Max(1, requiredLogs);
            burnTimer += addedBurnTime;
            burnTimer = Mathf.Min(burnTimer, burnTime);

            if (!isLit && burnTimer > 0f)
                isLit = true;

            fireBar?.SetBurnTime(burnTimer);

            refillCount++;
        }
    }
