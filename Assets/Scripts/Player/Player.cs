using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerController controller;
    public PlayerCondition condition;

    public ItemData itemData;
    public Action useItem;

    private void Awake()
    {
        CharacterManager.Instance.Player = this;
        controller = GetComponent<PlayerController>();
        condition = GetComponent<PlayerCondition>();

        useItem = () =>
        {
            if (itemData == null || itemData.consumables == null) return;

            foreach (var consumable in itemData.consumables)
            {
                switch (consumable.type)
                {
                    case ConsumableType.Health:
                        condition.Heal(consumable.value);
                        break;

                    case ConsumableType.SpeedUp:
                        StartCoroutine(SpeedUp(consumable.value));
                        break;
                }
            }
        };
    }

    private IEnumerator SpeedUp(float value)
    {
        float originalSpeed = controller.moveSpeed;
        controller.moveSpeed += value;

        yield return new WaitForSeconds(5f);

        controller.moveSpeed = originalSpeed;
    }
}
