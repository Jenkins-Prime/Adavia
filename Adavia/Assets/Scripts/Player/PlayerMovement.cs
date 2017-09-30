using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rBody;

    [SerializeField]
    private float walkingSpeed;

    [SerializeField]
    private Inventory inventory;

    private bool isWalking;

    private Vector2 facingDirection;

    private int randomchance;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rBody = GetComponent<Rigidbody2D>();
    }




    void Update ()
    {
        Movement(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
	}

    private void Movement(float xDirection, float yDirection)
    {
        isWalking = false;

        if (xDirection < 0.0f || xDirection > 0.0f)
        {
            rBody.velocity = new Vector2(xDirection, rBody.velocity.y).normalized * walkingSpeed;
            isWalking = true;
            facingDirection = new Vector2(xDirection, 0.0f);

        }

        if (yDirection < 0.0f || yDirection > 0.0f)
        {
            rBody.velocity = new Vector2(rBody.velocity.x, yDirection).normalized * walkingSpeed;
            isWalking = true;
            facingDirection = new Vector2(0.0f, yDirection);
        }

        if (xDirection <= 0.0f && xDirection >= 0.0f)
        {
            rBody.velocity = new Vector2(0.0f, rBody.velocity.y);
        }

        if (yDirection <= 0.0f && yDirection >= 0.0f)
        {
            rBody.velocity = new Vector2(rBody.velocity.x, 0.0f);
            
        }

        animator.SetFloat("xSpeed", xDirection);
        animator.SetFloat("ySpeed", yDirection);
        animator.SetFloat("xDirection", facingDirection.x);
        animator.SetFloat("yDirection", facingDirection.y);
        animator.SetBool("isWalking", isWalking);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Item"))
        {
            DropItem();
        }
    }

    private void DropItem()
    {
        int dropChance = Random.Range(0, 3);
        GameObject tempItem = Instantiate(ItemDatabase.instance.item);
        

        switch (dropChance)
        {
            case 0:
                GenerateWeapon(tempItem);
                break;

            case 1:
                GenerateArmour(tempItem);
                break;

            case 2:
                GenerateConsumable(tempItem);
                break;
        }
    }

    private void GenerateWeapon(GameObject tempItem)
    {
        tempItem.AddComponent<ItemSystem>();
        ItemSystem weapon = tempItem.GetComponent<ItemSystem>();
        randomchance = Random.Range(0, ItemDatabase.instance.ItemContainer.Weapons.Count);
        weapon.Item = ItemDatabase.instance.ItemContainer.Weapons[randomchance];
        inventory.AddItem(weapon);
        Destroy(tempItem);
    }

    private void GenerateArmour(GameObject tempItem)
    {
        tempItem.AddComponent<ItemSystem>();
        ItemSystem armour = tempItem.GetComponent<ItemSystem>();
        randomchance = Random.Range(0, ItemDatabase.instance.ItemContainer.Armour.Count);
        armour.Item = ItemDatabase.instance.ItemContainer.Armour[randomchance];
        inventory.AddItem(armour);
        Destroy(tempItem);
    }

    private void GenerateConsumable(GameObject tempItem)
    {
        tempItem.AddComponent<ItemSystem>();
        ItemSystem consumable = tempItem.GetComponent<ItemSystem>();
        randomchance = Random.Range(0, ItemDatabase.instance.ItemContainer.Consumables.Count);
        consumable.Item = ItemDatabase.instance.ItemContainer.Consumables[randomchance];
        inventory.AddItem(consumable);
        Destroy(tempItem);
    }
}
