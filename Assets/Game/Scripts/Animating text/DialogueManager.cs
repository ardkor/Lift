using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private TMP_Text textBox;
    [SerializeField] private AudioClip typingClip;
    [SerializeField] private AudioSourceGroup audioSourceGroup;

    //public Button playDialogue1Button;
/*    public Button playDialogue2Button;
    public Button playDialogue3Button;*/
/*    [TextArea]
    public string dialogue1;*/
/*
    [TextArea]
    public string dialogue2;
    [TextArea]
    public string dialogue3;*/

    private DialogueVertexAnimator dialogueVertexAnimator;
    void Awake() {
        dialogueVertexAnimator = new DialogueVertexAnimator(textBox, audioSourceGroup);
       // playDialogue1Button.onClick.AddListener(delegate { PlayDialogue1(); });
/*        playDialogue1Button.onClick.AddListener(delegate { PlayDialogue1(); });
        playDialogue3Button.onClick.AddListener(delegate { PlayDialogue3(); });*/
    }
    /* private void PlayDialogue1() {
            PlayDialogue(dialogue1);
        }

        private void PlayDialogue2() {
            PlayDialogue(dialogue2);
        }

        private void PlayDialogue3() {
            PlayDialogue(dialogue3);
        }*/
/*
    private void PlayDialogue1()
    {
        PlayMyDialogue(dialogue1);
    }*/

    private Coroutine typeRoutine = null;
/*    void PlayDialogue(string message) {
        this.EnsureCoroutineStopped(ref typeRoutine);
        dialogueVertexAnimator.textAnimating = false;
        List<DialogueCommand> commands = DialogueUtility.ProcessInputString(message, out string totalTextMessage);
        typeRoutine = StartCoroutine(dialogueVertexAnimator.AnimateTextIn(commands, totalTextMessage, typingClip, null));
    }*/

    public void PlayMyDialogue(string message)
    {
        this.EnsureCoroutineStopped(ref typeRoutine);
        dialogueVertexAnimator.textAnimating = false;
        List<DialogueCommand> commands = DialogueUtility.ProcessInputString(message, out string totalTextMessage);
        typeRoutine = StartCoroutine(dialogueVertexAnimator.AnimateTextIn(commands, totalTextMessage, typingClip, null));
    }
}
