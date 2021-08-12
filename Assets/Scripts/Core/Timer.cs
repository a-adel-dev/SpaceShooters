namespace Core
{
    public class Timer
    {
        private float _time;
        public bool Finished { get; private set; }
        private bool _started;

        public void StartTimer(float time)
        {
            _time = time;
            _started = true;
        }

        public void PauseTimer()
        {
            _started = false;
        }

        public void ResumeTimer()
        {
            _started = true;
        }

        public void ResetTimer(float time)
        {
            _time = time;
            _started = true;
            Finished = false;
        }

        public void Tick(float timeFraction)
        {
            if (_started)
            {
                _time -= timeFraction;
            }

            if (_time <= 0)
            {
                Finished = true;
            }
        }

    }
}