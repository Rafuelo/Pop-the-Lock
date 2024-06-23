using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    public GameObject pebble;
    public GameObject circle;
    public TextMeshProUGUI scoreUI;
    public TextMeshProUGUI levelUI;
    public TextMeshProUGUI getInputText;
    public Transform center;
    public Animator animator;
    public AudioSource source;
    public AudioClip pop, win, lose;
    private Vector3 rotation = Vector3.forward;
    private int level;
    private int score;
    public float radius = 5.0f;
    private float angle = 0.0f;
    private bool isGameGoing = false;

    // Start is called before the first frame update
    void Start()
    {
        LoadLevel();
        score = level;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isGameGoing)
        {
            SpawnObjectInRandomPosition(pebble);
            SpawnObjectInRandomPosition(circle);
            getInputText.gameObject.SetActive(false);
            score = level;
            ChangeScoreText($"{score}");
            ChangeLevelText($"Level - {level}");
            isGameGoing = true;
            animator.SetBool("Is Lose", false);
            animator.SetBool("Is Win", false);
        }
    }

    private void LoadLevel()
    {
        level = PlayerPrefs.GetInt("Level", 1);
    }

    private void SaveLevel(int level = 1)
    {
        PlayerPrefs.SetInt("Level", level);
        PlayerPrefs.Save();
    }

    [ContextMenu("Level 1")]
    public void SaveLevel1()
    {
        SaveLevel(1);
    }

    public void RemoveScore()
    {
        ChangeScoreText($"{--score}");
        PlaySound(pop);

        if (score > 0)
        {
            rotation *= -1;
            SpawnObjectInRandomPosition(circle);
        }

        else
        {
            PlaySound(win);
            animator.SetBool("Is Win", true);
            SaveLevel(level++);
            Restart();
        }
    }

    public Vector3 GetRotation() {  return rotation; }

    private void Restart()
    {
        Destroy(GameObject.FindWithTag("Player"));
        isGameGoing = false;
        getInputText.gameObject.SetActive(true);
        ChangeScoreText("");
    }

    public void Lose()
    {
        animator.SetBool("Is Lose", true);
        PlaySound(lose);
        Restart();
    }

    private void ChangeScoreText(string text) { scoreUI.text = text; }
    private void ChangeLevelText(string text) { levelUI.text = text; }

    private void PlaySound(AudioClip clip)
    {
        source.clip = clip;
        source.Play();
    }
    public void SpawnObjectInRandomPosition(GameObject gameObject)
    {
        angle = Random.Range(0f, 50f);

        float x = Mathf.Cos(angle) * radius;
        float y = Mathf.Sin(angle) * radius;

        Vector3 newPosition = transform.position = new Vector3(x, y, -6) + center.position;

        Vector3 direction = newPosition - center.position;

        float angleInDegrees = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Instantiate(gameObject, newPosition, Quaternion.Euler(new Vector3(0, 0, angleInDegrees - 90)));
    }
}
