using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class SolidAttackDamageArea : MonoBehaviour
{
    public SolidAttack parent;
    public GameObject bounceOffEffectPrefab;
    public string shieldImpactFXEventPath = "event:/FX/Player/FX-ShieldImpact";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player") && (parent.state == 1 || parent.state == 2) && !GameManager.instance.player.GetComponent<PlayerDash>().isDashing)
        {
            collision.GetComponent<PlayerHealth>().TakeDamage(parent.damage);
        }
        if (collision.tag.Equals("PlayerShield"))
        {
            parent.targetPos = GridManager.instance.GetPhaseInitialPosition() + new Vector2(parent.endX * GridManager.instance.gridSize.x, parent.endY * GridManager.instance.gridSize.y);
            parent.state = 2;
            parent.delayTimer = 0; 
            EventInstance shieldImpactFX;
            shieldImpactFX = RuntimeManager.CreateInstance(shieldImpactFXEventPath);
            if (SettingManager.instance != null)
            {
                shieldImpactFX.setVolume(SettingManager.instance.overAllVolume * SettingManager.instance.soundEffectVolume);
            }
            shieldImpactFX.start(); 
            
            if (bounceOffEffectPrefab != null)
            {
                if (GameManager.instance.player.GetComponent<PlayerGridMovement>().isPlayerFacingRight)
                {
                    GameObject effect = Instantiate(bounceOffEffectPrefab, GameManager.instance.player.transform.position + new Vector3(GridManager.instance.gridSize.x * 0.5f, 0, 0), Quaternion.identity);
                    effect.transform.rotation = Quaternion.Euler(0, 0, 0);
                    var main = effect.GetComponentInChildren<ParticleSystem>().main;
                    main.startRotationZ = new ParticleSystem.MinMaxCurve(0.0f);
                }
                else
                {
                    GameObject effect = Instantiate(bounceOffEffectPrefab, GameManager.instance.player.transform.position - new Vector3(GridManager.instance.gridSize.x * 0.5f, 0, 0), Quaternion.identity);
                    effect.transform.rotation = Quaternion.Euler(0, 0, 180);
                    var main = effect.GetComponentInChildren<ParticleSystem>().main;
                    main.startRotationZ = new ParticleSystem.MinMaxCurve(180.0f);
                }
            }
        }
    }
}
