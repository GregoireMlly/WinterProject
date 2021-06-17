using System;
using UnityEngine;
using Mirror;
using System.Collections;


[RequireComponent(typeof(PlayerSetup))]
public class Player : NetworkBehaviour
{
    [SyncVar]
    private bool _isDead = false; 
    public bool isDead
    {
        get { return _isDead;  }
        protected set { _isDead = value; }
    }

    [SerializeField] 
    private float maxHealth = 30f;
    
    [SyncVar]
    private float currentHealth;

    [SerializeField] 
    private Behaviour[] disableOnDeath;

    [SerializeField] 
    private GameObject[] disableGameObjectsOnDeath;
    
    private bool[] wasEnabledOnStart;

   [SerializeField] 
    private GameObject deathEffect;

    public void Setup()
    {
        // Changement de caméra
        /*
        GameManager.instance.SetSceneCameraActive(false);
        GetComponent<PlayerSetup>().playerUIInstance.SetActive(true); 
        */
        
        CmdBroadcastNewPlayerSetup();
    }

    [Command]
    private void CmdBroadcastNewPlayerSetup()
    {
        RpcSetupPlayerOnAllClient();
    }

    [ClientRpc]
    private void RpcSetupPlayerOnAllClient()
    {
        wasEnabledOnStart = new bool[disableOnDeath.Length];
        for (int i = 0; i < disableOnDeath.Length; i++)
        {

            wasEnabledOnStart[i] = disableOnDeath[i].enabled;
        }
        
        SetDefaults();
    }

    public void SetDefaults()
    {
        isDead = false;
        currentHealth = maxHealth;
        
        // Ré-Active les scripts du joueur
        for (int i = 0; i < disableOnDeath.Length; i++)
        {
            disableOnDeath[i].enabled = wasEnabledOnStart[i];
        }
        
        // Ré-active les gameobjects du joueur
        for (int i = 0; i < disableGameObjectsOnDeath.Length; i++)
        {
            disableGameObjectsOnDeath[i].SetActive(true);
        }

        // Ré-active le collider du joueur
        Collider col = GetComponent<Collider>();
        if (col != null)
        {
            col.enabled = true;
        }
    }

    private IEnumerator Respawn()
    {
        yield return new WaitForSeconds(GameManager.instance.matchSettings.respawnTimer);
        
        Transform spawnPoint = NetworkManager.singleton.GetStartPosition();
        transform.position = spawnPoint.position;
        transform.rotation = spawnPoint.rotation;
        
        // Changement de caméra
        /*
        GameManager.instance.SetSceneCameraActive(false);
        GetComponent<PlayerSetup>().playerUIInstance.SetActive(true); 
        */ 
        
        SetDefaults();
    }

    private void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            RpcTakeDamage(999);
        }
    }

    [ClientRpc]
    public void RpcTakeDamage(float amount)
    {
        if (isDead)
        {
            return;
        }
        
        currentHealth -= amount;
        Debug.Log(transform.name + " a maintenant : " + currentHealth + " points de vie.");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        isDead = true;

        // Désactive les components du joueur lors de la mort
        for (int i = 0; i < disableOnDeath.Length; i++)
        {
            disableOnDeath[i].enabled = false;
        }
        
        // Désactive les gameobjects du joueur lors de la mort
        for (int i = 0; i < disableGameObjectsOnDeath.Length; i++)
        {
            disableGameObjectsOnDeath[i].SetActive(false);
        }
        
        Collider col = GetComponent<Collider>();
        if (col != null)
        {
            col.enabled = false;
        }
        
        // Aparition du système de particules de mort
        GameObject _gfxIns = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(_gfxIns, 3f);
        
        Debug.Log(transform.name + " a été éliminé.");

        StartCoroutine(Respawn());
    }
}
