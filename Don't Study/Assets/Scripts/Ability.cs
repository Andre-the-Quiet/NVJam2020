using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ability : MonoBehaviour
{
    public Image abilityImage;
    public float cooldown = 5f;
    bool isCooldown = false;
    public KeyCode AbilityKey;
    public Animator AbilityAnimator;

    public AudioClip AbilitySound;
    public AudioSource Myaudio;
    public PlayerController MyCharacter;

    // Start is called before the first frame update
    void Start()
    {
        abilityImage.fillAmount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        UseAbility();
    }

    void UseAbility()
    {
        if (Input.GetKey(AbilityKey) && isCooldown == false)
        {
            isCooldown = true;
            abilityImage.fillAmount = 0;
            Myaudio.PlayOneShot(AbilitySound);
            AbilityAnimator.SetTrigger("Start");
            StartCoroutine(SpeedBoost());
            
            
        }
        if (isCooldown)
        {
            abilityImage.fillAmount += 1 / cooldown * Time.fixedDeltaTime;

            if(abilityImage.fillAmount >= 1)
            {
                abilityImage.fillAmount = 1;
                isCooldown = false;
            }
        }
    }
    IEnumerator SpeedBoost()
    {
        MyCharacter.MovementSpeed = 16f;
        yield return new WaitForSeconds(2f);
        MyCharacter.MovementSpeed = 8f;
    }
}
