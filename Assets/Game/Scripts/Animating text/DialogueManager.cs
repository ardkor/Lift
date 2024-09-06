using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private TMP_Text textBox;
    //[SerializeField] private TMP_Text testText;
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
   // private DialogueVertexAnimator dialogueVertexAnimator_test;
    void Awake() {
        dialogueVertexAnimator = new DialogueVertexAnimator(textBox, audioSourceGroup);
        //dialogueVertexAnimator_test = new DialogueVertexAnimator(testText, audioSourceGroup);
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
    /*private static readonly Vector3 vecZero = Vector3.zero;
    public void ClearText()
    {
        *//*        TMP_TextInfo textInfo = testText.textInfo;
                for (int i = 0; i < textInfo.meshInfo.Length; i++) //Clear the mesh 
                {
                    TMP_MeshInfo meshInfer = textInfo.meshInfo[i];
                    if (meshInfer.vertices != null)
                    {
                        for (int j = 0; j < meshInfer.vertices.Length; j++)
                        {
                            meshInfer.vertices[j] = vecZero;
                        }
                    }
                }*//*
        //TMP_TextInfo textInfo = testText.textInfo;
        testText.textInfo.Clear();
*//*        for (int i = 0; i < testText.textInfo.meshInfo.Length; i++) //Clear the mesh 
        {
            //TMP_MeshInfo meshInfer = testText.textInfo.meshInfo[i];
            if (testText.textInfo.meshInfo[i].vertices != null)
            {
                for (int j = 0; j < testText.textInfo.meshInfo[i].vertices.Length; j++)
                {
                    testText.textInfo.meshInfo[i].vertices[j] = vecZero;
                }
            }
        }*//*
        testText.ForceMeshUpdate();
    }
    public void PlayTestDialogue(string message)
    {
        this.EnsureCoroutineStopped(ref typeRoutine);
        dialogueVertexAnimator_test.textAnimating = false;
        List<DialogueCommand> commands = DialogueUtility.ProcessInputString(message, out string totalTextMessage);
        typeRoutine = StartCoroutine(dialogueVertexAnimator_test.AnimateTextIn(commands, totalTextMessage, typingClip, null));
    }*/
    public void PlayMyDialogue(string message)
    {
        this.EnsureCoroutineStopped(ref typeRoutine);
        dialogueVertexAnimator.textAnimating = false;
        List<DialogueCommand> commands = DialogueUtility.ProcessInputString(message, out string totalTextMessage);
        typeRoutine = StartCoroutine(dialogueVertexAnimator.AnimateTextIn(commands, totalTextMessage, typingClip, null));
    }
}
