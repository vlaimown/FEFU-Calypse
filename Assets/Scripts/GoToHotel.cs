using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToHotel : MonoBehaviour
{
    public Transform hotelPoint;

    public CircleCollider2D heroCircleCollider;

    public PlayerController player;
    public Animator anim;

    public Vector2 TriggerPoint = new Vector2();
    private void FixedUpdate()
    {
    if ((Vector2.Distance(player.hero.transform.position, TriggerPoint) <= 5f) && player.moveToHotelFlag == 1)
    {
            heroCircleCollider.enabled = false;

            anim.Play("HeroMovement");

            Vector3 scaler = player.character.transform.localScale;
                if (scaler.y > 0.26f)
                {
                    scaler.y -= Time.fixedDeltaTime;
                    if (scaler.x >= -0.26f)
                    {
                        scaler.x -= Time.fixedDeltaTime;
                    }
                    else if (scaler.x <= 0.26f)
                    {
                        scaler.x += Time.fixedDeltaTime;
                    }
                    player.character.transform.localScale = scaler;
                }

                //player.character.LookAt(hotelPoint);
                player.hero.transform.position = Vector2.MoveTowards(player.hero.transform.position, hotelPoint.position, player.speed * Time.deltaTime);

            if (Vector2.Distance(player.character.position, hotelPoint.position) < 0.06f)
            {
                    heroCircleCollider.enabled = true;
                    SceneManager.LoadScene(1);
                }
            }
        }
    }