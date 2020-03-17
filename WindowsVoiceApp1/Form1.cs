using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Speech;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Speech.AudioFormat;
using System.Threading;
using System.IO;
using System.IO.Ports;


namespace WindowsVoiceApp1
{
    class KeyHandle
    {
        private static Int32 WM_KEYDOWN = 0x100;
        private static Int32 WM_KEYUP = 0x101;

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool PostMessage(int Msg, System.Windows.Forms.Keys wParam, int lParam);

        public static void SendKeyUp(System.Windows.Forms.Keys key)
        {
            PostMessage(WM_KEYUP, key, 0);
        }

        public static void SendKeyDown(System.Windows.Forms.Keys key)
        {
            PostMessage(WM_KEYDOWN, key, 0);
        }
    }
    public partial class Form1 : Form
    {
        // Form Declarations
        SpeechSynthesizer ss = new SpeechSynthesizer();
        PromptBuilder pb = new PromptBuilder();
        SpeechRecognitionEngine sre = new SpeechRecognitionEngine();
        Choices clist = new Choices();
        SerialPort ardo = new SerialPort();
        WMPLib.WindowsMediaPlayer mplayer = new WMPLib.WindowsMediaPlayer();
        [DllImport("user32")]
        public static extern bool ExitWindowsEx(uint uFlags, uint dwReason);
        [DllImport("PowrProf.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool SetSuspendState(bool hiberate, bool forceCritical, bool disableWakeEvent);

        public Form1()
        {
            InitializeComponent();
        }
		

        private void buttonStart_Click(object sender, EventArgs e)
        {
            // Start Button Click
			label3.Visible = false;
			label1.Visible = true;
			label2.Visible = false;
			label4.Visible = true;
            buttonStart.Enabled = false;
            buttonStop.Enabled = true;
            clist.Add(new string[] { "hello","mia"," hi","exit","how are you","o mad","i want to shop","good morning","good afternoon","good evening","good day","good night",
 "fuck you","what is the time", "i want to search", "thank you", "you can go", "will you suck my dick","be quiet","good girl","open netflix",
 "What is the weather", "which languages do you speak?", "open youtube", "open C M D", "play some music", "open vlc", "pause the music" ,
 "open note pad", "open wordpad pad", "i want to draw", "i want to code", "mia i want to type", "i want to see a movie", "mia i am lost", "open google map",
"continue playing the music", "play some coldplay", "switch light on", "switch light off", "shut down the pc", "Restart the computer", "show email",
"i am going out", "Put the computer to sleep", "Scroll Up", "scroll down","find my ip","i love you","tell me how to use you", "who made you","what are you running on"});

            Grammar gr = new Grammar(new GrammarBuilder(clist));
            // ardo = new SerialPort();
            ardo.PortName = "COM6";
            ardo.BaudRate = 9600;

            // Configure the audio input.
            sre.SetInputToDefaultAudioDevice();
            // Configure the audio output. 
            ss.SetOutputToDefaultAudioDevice();

            //See the Voices Installed
            // seeInstalledVoices(ss);

            // Set a Voice
            //ss.SelectVoiceByHints(VoiceGender.male, VoiceAge.Adult);
            ss.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Child);

            try
            {
                // Speak a string.
                ss.Speak("Hello boss, I'm mia you're Smart Assistant.");
                // ss.Speak("Hope you are doing fine today, How may I assist you?");
                sre.RequestRecognizerUpdate();
                sre.LoadGrammar(gr);
                sre.SpeechRecognized += sre_SpeechRecognized;
                sre.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }



        }

        void sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            //If Selected Functions Keywords were Recognized
            switch(e.Result.Text.ToString())
            {
				 case "be quiet":
                    {
                        ss.SpeakAsync("as you wish boss");

						label3.Visible =true;
					label1.Visible = false;
					label2.Visible = true;
					label4.Visible = false;
            // Button Stop Functions
            sre.RecognizeAsyncStop();
            buttonStart.Enabled = true;
            buttonStop.Enabled = false;
                        break;
                    }
				 case "o mad":
                    {
                        ss.SpeakAsync("you are really funny sir");
                        break;
                    }
					 case "good girl":
                    {
                        ss.SpeakAsync("ha ha ha funny bone");
                        
                        break;
						}
					 case "good night":
                    {
                        ss.SpeakAsync("do have a wonderfull night boss");
                        
                        break;
						}
					 case "good day":
                    {
                        ss.SpeakAsync("good day boss");
                        
                        break;
						}
					 case "good evening":
                    {
                        ss.SpeakAsync("good evening");
                        
                        break;
						}
					 case "good afternoon":
                    {
                        ss.SpeakAsync("good afternoon boss, how is your day going");
                        
                        break;
						}
					   case "good morning":
                    {
                        ss.SpeakAsync("good morning boss. Do have a lovely day");
                        
                        break;
                    }
				   case "mia":
                    {
                        ss.SpeakAsync("yes boss?");
                        
                        break;
                    }
				   case "fuck you":
                    {
                        ss.SpeakAsync("fuck you too");
                        break;
                    }
				     case "hi":
                    {
                        ss.SpeakAsync("hello Sir");
                        break;
                    }
                case "hello":
                    {
                        ss.SpeakAsync("hello boss");
                        break;
                    }
                case "how are you":
                    {
                        ss.SpeakAsync("I'm doing Great");
                        break;
                    }
                case "what is the time":
                    {
                        ss.SpeakAsync("Current Time is" + DateTime.Now.ToLongTimeString());
                        break;
                    }
					
					 case "open word pad":
                    {
                        ss.SpeakAsync("sure boss");
                        Process.Start("wordpad.exe");
                        break;
                    }
					 case "open note pad":
                    {
                        ss.SpeakAsync("sure");
                        Process.Start("notepad.exe");
                        break;
                    }
					 case "what are you running on":
                    {
                        ss.SpeakAsync("i'll bring out a list of my system hardware in a second");
                        Process.Start("dxdiag");
                        break;
                    }

			
					 case "mia i want to type":
                    {
                        ss.SpeakAsync("openning wordpad");
                        Process.Start("wordpad.exe");
                        break;
                    }

					  case "open netflix":
                    {
                        ss.SpeakAsync("Yes rightaway boss");
                        Process.Start("chrome.exe","http:\\www.netflix.com");
                        break;
                    }
					
					 case "i want to code":
                    {
                        ss.SpeakAsync("openning notepad");
                        Process.Start("notepad.exe");
                        break;
                    }

					
					 case "mia i am lost":
                    {
                        ss.SpeakAsync("openning google map");
                        Process.Start("chrome.exe","http:\\www.google.com/map");
                        break;
                    }

					 case "open google map":
                    {
                        ss.SpeakAsync("openning google map");
                        Process.Start("chrome.exe","http:\\www.google.com/map");
                        break;
                    }
					
					 case "i want to see a movie":
                    {
                        ss.SpeakAsync("openning vlc");
                        Process.Start("vlc.exe");
                        break;
                    }

					 case "i want to draw":
                    {
                        ss.SpeakAsync("openning paint");
                        Process.Start("paint.exe");
                        break;
                    }

					 case "open C M D":
                    {
                        ss.SpeakAsync("Yes rightaway Sir");
                        Process.Start("cmd.exe");
                        break;
                    }

					 case "i love you":
                    {
                        ss.SpeakAsync("ha ha ha i love you too");
                        MessageBox.Show("♥");
                        break;
                    }

						 case "who made you":
                    {
                        ss.SpeakAsync("Richard Nwonah made me for cyborg");
                     
                        break;
                    }

					 case "tell me how to use you":
                    {
                        ss.SpeakAsync("i was downloaded with a list of simple commands to help us get along");
                       
                        break;
                    }

					 case "i want to shop":
                    {
                        ss.SpeakAsync("i have access to amazon, openning");
                     
                        Process.Start("chrome.exe", "http:\\www.amazon.com");
                        break;
                    }
                case "i want to search":
                    {
                        ss.SpeakAsync("Yes rightaway Sir");
                        Process.Start("chrome.exe","http:\\www.google.com");
                        break;
                    }
                case "Scroll Up":
                    {
                        ss.SpeakAsync("Yes Sir");
                        KeyHandle.SendKeyUp(Keys.PageUp);
                        break;
                    }
                case "scroll down":
                    {
                        ss.SpeakAsync("Yes Sir");
                        KeyHandle.SendKeyDown(Keys.PageDown);
                        break;
                    }
					     case "show email":
                    {
                        ss.SpeakAsync("Yes rightaway Sir");
                        Process.Start("chrome.exe", "http:\\www.gmail.com");
                        break;
                    }
                case "open youtube":
                    {
                        ss.SpeakAsync("Yes rightaway Sir");
                        Process.Start("chrome.exe", "http:\\www.youtube.com");
                        break;
                    }
					  case "find my ip":
                    {
                        ss.SpeakAsync("this feature has been removed from this version of the app, but you can open cmd and	type ipconfig without space to view your ip");
                     
                        break;
                    }
                case "switch light on":
                    {
                        string status = "1";
                        ss.SpeakAsync("Light is on");
                        ardo.Open();
                        ardo.Write(status);
                        ardo.Close();
                        break;
                    }
                case "switch light off":
                    {
                        ss.SpeakAsync("Light is off");
                        ardo.Open();
                        ardo.Write("0");
                        ardo.Close();
                        break;
                    }
                case "play some music":
                    {
                        /* ss.SpeakAsync("Yes I have just the right thing for you");
                        Thread.Sleep(2000);
                        Process.Start(@"C:\Program Files (x86)\VideoLAN\VLC\vlc.exe", @"D:\Songs\Apologize.mp3");
                        break; */
                        // music = new Microsoft.DirectX.AudioVideoPlayback.Audio(D:\Songs\Apologize.mp3);
                        // music.Play();
                        // WMPLib.WindowsMediaPlayer mplayer = new WMPLib.WindowsMediaPlayer();
                        mplayer.URL = @"D:\Songs\Apologize.mp3";
                        mplayer.controls.play();
                        break;
                    }
                case "play some coldplay":
                    {
                        ss.SpeakAsync("Yes Sir");
                        Process.Start(@"C:\Program Files (x86)\VideoLAN\VLC\vlc.exe", @"D:\Songs\Coldplay-Fix_You.mp3");
                        break;
                    }
                case "pause the music":
                    {
                        // WMPLib.WindowsMediaPlayer mplayer = new WMPLib.WindowsMediaPlayer();
                        // mplayer.URL = @"D:\Songs\Apologize.mp3";
                        mplayer.controls.pause();
                        break;
                    }
                case "continue playing the music":
                    {
                        // WMPLib.WindowsMediaPlayer mplayer = new WMPLib.WindowsMediaPlayer();
                        // mplayer.URL = @"D:\Songs\Apologize.mp3";
                        mplayer.controls.play();
                        break;
                    }
                case "open vlc":
                    {
                        ss.SpeakAsync("Yes rightaway Sir");
                        Process.Start("vlc.exe");
                        break;
                    }
                case "thank you":
                    {
                        ss.SpeakAsync("No problem");
                        break;
                    }
                case "you can go":
                    {
                        ss.SpeakAsync("Okay Sir");
                        Application.Exit();
                        break;
                    }
					   case "exit":
                    {
                        ss.SpeakAsync("Okay Sir");
                        Application.Exit();
                        break;
                    }
                case "will you suck my dick":
                    {
                        ss.SpeakAsync("I would glady Sir,     but unfortunately I don't have a mouth");
                        break;
                    }
                case "What is the weather":
                    {
                        ss.SpeakAsync("It's pretty hot outside.");
                        break;
                    }
                case "which languages do you speak?":
                    {
                        ss.SpeakAsync("Presently I only understand and speak English.");
                        break;
                    }
                case "i am going out":
                    {
                        ss.SpeakAsync("Logging off the System");
                        ExitWindowsEx(0, 0);
                        break;
                    }
                case "Put the computer to sleep":
                    {
                        ss.SpeakAsync("Putting the computer to sleep");
                        SetSuspendState(false, true, true);
                        break;
                    }
                case "shut down the pc":
                    {
                        ss.SpeakAsync("Doing a System Shut Down");
                        Application.Exit();
                        Process.Start("shutdown", "/s /t 0");
                        break;
                    }
                case "Restart the computer":
                    {
                        ss.SpeakAsync("Doing a System Restart");
                        Application.Exit();
                        Process.Start("shutdown", "/r /t 0");
                        break;
                    }
            }
            textBox1.Text = e.Result.Text.ToString() + Environment.NewLine;
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
			label3.Visible =true;
			label1.Visible = false;
				label2.Visible = true;
			label4.Visible = false;
            // Button Stop Functions
            sre.RecognizeAsyncStop();
            buttonStart.Enabled = true;
            buttonStop.Enabled = false;
        }

        public void seeInstalledVoices(SpeechSynthesizer synth)
        {
            // Output information about all of the installed voices. 
            textBox1.Text = "Installed voices -";
            foreach (InstalledVoice voice in synth.GetInstalledVoices())
            {
                VoiceInfo info = voice.VoiceInfo;
                string AudioFormats = "";
                foreach (SpeechAudioFormatInfo fmt in info.SupportedAudioFormats)
                {
                    AudioFormats += String.Format("{0}\n",
                    fmt.EncodingFormat.ToString());
                }

                textBox1.AppendText(" Name:          " + info.Name);
                textBox1.AppendText(" Culture:       " + info.Culture);
                textBox1.AppendText(" Age:           " + info.Age);
                textBox1.AppendText(" Gender:        " + info.Gender);
                textBox1.AppendText(" Description:   " + info.Description);
                textBox1.AppendText(" ID:            " + info.Id);
                textBox1.AppendText(" Enabled:       " + voice.Enabled);
                if (info.SupportedAudioFormats.Count != 0)
                {
                    textBox1.AppendText(" Audio formats: " + AudioFormats);
                }
                else
                {
                    textBox1.AppendText(" No supported audio formats found");
                }

                string AdditionalInfo = "";
                foreach (string key in info.AdditionalInfo.Keys)
                {
                    AdditionalInfo += String.Format("  {0}: {1}\n", key, info.AdditionalInfo[key]);
                }

                textBox1.AppendText(" Additional Info - " + AdditionalInfo);
                textBox1.AppendText("/n");
            }
        }
    }
}
