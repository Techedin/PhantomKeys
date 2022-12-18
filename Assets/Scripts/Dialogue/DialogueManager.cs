using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueManager : MonoBehaviour
{
    public static DialogueManager dialogueManager;

    private Queue<string> sentences;

    public AudioSource textSound;

    public Text nameText;
    public Text dialogueText;

    public Animator animator;
    public float typingSpeed;

    public Text killCounter;
    //Singleton
    public void Awake()
    {
        if (dialogueManager == null)
        {
            dialogueManager = this;
            DontDestroyOnLoad(dialogueManager);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {

        //Create a Queue for my sentences
        sentences = new Queue<string>();
    }

    //This is called in out DialogueTigger script or its children
    public void StartDialogue(Dialogue dialogue)
    {
        GameManager.gameManager.activePlayer.GetComponentInChildren<Text>();
        animator.SetBool("isOpen", true);
        nameText.text = dialogue.name;

        //Clear previous sentences
        sentences.Clear();
        //Grab all of the sentences from our dialogue object then put them into the Queue
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        //Check to see if there is anymore sentences
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        //Display next sentence in queue
        string sentence = sentences.Dequeue();
        //Start Coroutines and Stop any active ones(allows for skipping of animating text)
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    // Allow for text to appear on at a time
    //IEnumerator is the basic way to indicate a coroutine
    //All coroutines require a return
    //yield is basically the pause button
    //yeild return new means that the coroutine will be continued after whatever is called
    //yeild return null stops the coroutine until coroutine is called again.
    IEnumerator TypeSentence(string sentence)
    {
        //make the text empty
        dialogueText.text = "";

        //add a character every typingSpeed(seconds) to give the look of animating text(Gonna add options for text speed eventually)
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            textSound.Play();
            yield return new WaitForSecondsRealtime(typingSpeed);
        }

    }

    public void EndDialogue()
    {
        StopAllCoroutines();
        sentences.Clear();
        animator.SetBool("isOpen", false);
        Debug.Log("End Of Dialogue");
    }
}
