using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogManager : MonoBehaviour
{
    private Queue<string> sentences;
    public Text nameText;
    public Text dialogueText;
    public Text xd;
    public Image backGround;

    void Start()
    {
        backGround.enabled = false;
        nameText.enabled = false;
        dialogueText.enabled = false;
        xd.enabled = false;
        sentences = new Queue<string>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) DisplayNextSentence();
    }
    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("Starting conversation with" + dialogue.name);
        backGround.enabled = true;
        nameText.enabled = true;
        dialogueText.enabled = true;
        xd.enabled = true;
        Cursor.lockState = CursorLockMode.None;
        sentences.Clear();
        nameText.text = dialogue.name;
        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }
    public void DisplayNextSentence()
    { 
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }
    public void EndDialogue()
    {
        backGround.enabled = false;
        nameText.enabled = false;
        dialogueText.enabled = false;
        xd.enabled = false;
        Cursor.lockState = CursorLockMode.Locked;
        Debug.Log("End of conversation");
    }

}
