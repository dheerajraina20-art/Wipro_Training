using System;
using System.Speech.Synthesis;

namespace TextToSpeechApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SpeechSynthesizer speaker = new SpeechSynthesizer();

            speaker.Speak("Hello Dheeraj! Welcome to Text to Speech in C sharp.");

            Console.WriteLine("Speech completed.");
            Console.ReadLine();
        }
    }
}
