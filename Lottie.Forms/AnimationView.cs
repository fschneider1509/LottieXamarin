using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Lottie.Forms
{
    public class AnimationView : View
    {
        public static readonly BindableProperty ProgressProperty = BindableProperty.Create(nameof(Progress),
            typeof(float), typeof(AnimationView), default(float));

        public static readonly BindableProperty LoopProperty = BindableProperty.Create(nameof(Loop), typeof(bool),
            typeof(AnimationView), default(bool));

        public static readonly BindableProperty IsPlayingProperty = BindableProperty.Create(nameof(IsPlaying),
            typeof(bool), typeof(AnimationView), default(bool));

        public static readonly BindableProperty DurationProperty = BindableProperty.Create(nameof(Duration),
            typeof(TimeSpan), typeof(AnimationView), default(TimeSpan));

        public static readonly BindableProperty AnimationProperty = BindableProperty.Create(nameof(Animation),
            typeof(string), typeof(AnimationView), default(string));

        public static readonly BindableProperty AutoPlayProperty = BindableProperty.Create(nameof(AutoPlay),
            typeof(bool), typeof(AnimationView), default(bool));
        
        public static readonly BindableProperty SpeedProperty = BindableProperty.Create(nameof(Speed),
            typeof(float), typeof(AnimationView), default(float));

        public static readonly BindableProperty PlayingCommandProperty = BindableProperty.Create(nameof(PlayingCommand),
            typeof(ICommand), typeof(AnimationView));

        public static readonly BindableProperty FinishedCommandProperty = BindableProperty.Create(nameof(FinishedCommand), 
            typeof(ICommand), typeof(AnimationView));

        public float Progress
        {
            get { return (float) GetValue(ProgressProperty); }

            set { SetValue(ProgressProperty, value); }
        }

        public string Animation
        {
            get { return (string) GetValue(AnimationProperty); }

            set { SetValue(AnimationProperty, value); }
        }

        public TimeSpan Duration
        {
            get { return (TimeSpan) GetValue(DurationProperty); }

            set { SetValue(DurationProperty, value); }
        }

        public bool Loop
        {
            get { return (bool) GetValue(LoopProperty); }

            set { SetValue(LoopProperty, value); }
        }

        public bool AutoPlay
        {
            get { return (bool)GetValue(AutoPlayProperty); }

            set { SetValue(AutoPlayProperty, value); }
        }

        public bool IsPlaying
        {
            get { return (bool) GetValue(IsPlayingProperty); }

            set { SetValue(IsPlayingProperty, value); }
        }
        
        public float Speed
        {
            get { return (float) GetValue(SpeedProperty); }

            set { SetValue(SpeedProperty, value); }
        }

        public ICommand PlayingCommand
        {
            get { return (ICommand)GetValue(PlayingCommandProperty); }

            set { SetValue(PlayingCommandProperty, value); }
        }

        public ICommand FinishedCommand
        {
            get { return (ICommand)GetValue(FinishedCommandProperty); }

            set { SetValue(FinishedCommandProperty, value); }
        }

        public event EventHandler OnPlay;

        public void Play()
        {
            OnPlay?.Invoke(this, new EventArgs());

            ExecuteCommandIfPossible(PlayingCommand);
        }

        public event EventHandler OnPause;

        public void Pause()
        {
            OnPause?.Invoke(this, new EventArgs());
        }

        public event EventHandler OnFinish;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void FireOnFinish()
        {
            OnFinish?.Invoke(this, EventArgs.Empty);

            ExecuteCommandIfPossible(FinishedCommand);
        }

        private void ExecuteCommandIfPossible(ICommand command)
        {
            if (command != null && command.CanExecute(null))
            {
                command.Execute(null);
            }
        }
    }
}