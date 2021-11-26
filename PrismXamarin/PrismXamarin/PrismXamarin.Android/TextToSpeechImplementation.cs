using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Speech.Tts;
using Android.Views;
using Android.Widget;
using PrismXamarin;
using PrismXamarin.Droid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

[assembly:Dependency(typeof(TextToSpeechImplementation))]
namespace PrismXamarin.Droid
{
    public class TextToSpeechImplementation : Java.Lang.Object, ITextToSpeech, TextToSpeech.IOnInitListener
    {

        TextToSpeech _speaker;
        string _toSpeak;
        public void Speak(string text)
        {
            _toSpeak = text;
            if (_speaker == null)
            {
                _speaker = new TextToSpeech(Forms.Context, this);
            }
            else
            {
                _speaker.Speak(_toSpeak, QueueMode.Flush, null, null);
            }
        }
        public void OnInit(OperationResult status)
        {
            if (status.Equals(OperationResult.Success))
            {

                _speaker.Speak(_toSpeak, QueueMode.Flush, null, null);
            }
        }
    }
}