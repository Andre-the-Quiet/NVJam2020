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
        }
        if (isCooldown)
        {
            abilityImage.fillAmount += 1 / cooldown * Time.deltaTime;

            if(abilityImage.fillAmount >= 1)
            {
                abilityImage.fillAmount = 1;
                isCooldown = false;
            }
        }
    }
}
