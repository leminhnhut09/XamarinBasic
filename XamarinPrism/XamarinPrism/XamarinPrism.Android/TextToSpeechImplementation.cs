using Android.Speech.Tts;
using Xamarin.Forms;
using XamarinPrism.Droid;

[assembly:Dependency(typeof(TextToSpeechImplementation))]
namespace XamarinPrism.Droid
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