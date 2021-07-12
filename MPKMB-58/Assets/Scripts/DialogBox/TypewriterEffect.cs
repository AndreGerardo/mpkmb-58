using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TypewriterEffect : MonoBehaviour
{
    [SerializeField] private float typewriterSpeed = 75f;

    public bool IsRunning { get; set; }

    private readonly List<Punctutation> punctuations = new List<Punctutation>
    {
        new Punctutation(new HashSet<char>(){'.', '!', '?'}, 0.6f),
        new Punctutation(new HashSet<char>(){',', ';', ':'}, 0.3f),
    };

    private Coroutine typingCoroutine;

    //Jalanin efek
    public void Run(string textToType, TMP_Text textLabel)
    {
        typingCoroutine =  StartCoroutine(TypeText(textToType, textLabel));
    }

    public void Stop()
    {
        StopCoroutine(typingCoroutine);
        IsRunning = false;
    }

    //Loop huruf yang keluar tiap index
    private IEnumerator TypeText(string textToType, TMP_Text textLabel)
    {
        IsRunning = true;
        textLabel.text = string.Empty;

        float t = 0;
        int charIndex = 0;
        while(charIndex < textToType.Length)
        {
            int lastCharIndex = charIndex;

            t += Time.deltaTime * typewriterSpeed;
            charIndex = Mathf.FloorToInt(t);
            charIndex = Mathf.Clamp(charIndex, 0, textToType.Length);

            for (int i = lastCharIndex; i < charIndex; i++)
            {
                bool IsLast = i >= textToType.Length - 1;

                textLabel.text = textToType.Substring(0, i + 1);

                if(IsPunctuation(textToType[i], out float waitTime) && !IsLast && !IsPunctuation(textToType[i + 1], out _))
                {
                    yield return new WaitForSeconds(waitTime);
                }
            }

            yield return null;
        }

        IsRunning = false;
    }

    private bool IsPunctuation(char character, out float waitTime)
    {
        foreach(Punctutation punctuationCategory in punctuations)
        {
            if (punctuationCategory.Punctuations.Contains(character))
            {
                waitTime = punctuationCategory.WaitTime;
                return true;
            }
        }

        waitTime = default;
        return false;
    }

    private readonly struct Punctutation
    {
        public readonly HashSet<char> Punctuations;
        public readonly float WaitTime;

        public Punctutation(HashSet<char> punctuations, float waitTime)
        {
            Punctuations = punctuations;
            WaitTime = waitTime;
        }
    }
}









































