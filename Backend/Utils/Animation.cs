using System;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace NickAc.LightPOS.Backend.Utils
{
    public class Animation : IDisposable
    {
        internal readonly Timer internalTimer;
        internal int executionLimit;
        internal int hitCount;
        internal Action<Animation> timerAction;

        public Animation()
        {
            internalTimer = new Timer(5)
            {
                AutoReset = true
            };
            internalTimer.Elapsed += (s, e) =>
            {
                if (executionLimit > 0)
                {
                    if (hitCount > executionLimit)
                    {
                        Stop();
                        return;
                    }

                    hitCount++;
                }

                timerAction?.Invoke(this);
            };
        }

        public void Dispose()
        {
            timerAction = null;
            internalTimer.Stop();
            internalTimer.Dispose();
        }

        public Animation WithDisposal(Form disposable)
        {
            disposable.FormClosing += (s, e) => Dispose();
            disposable.Disposed += (s, e) => Dispose();

            return this;
        }

        public Animation WithAction(Action<Animation> action)
        {
            timerAction = action;
            return this;
        }

        public Animation WithLimit(int limit)
        {
            executionLimit = limit;
            return this;
        }

        public Animation Start()
        {
            internalTimer.Start();
            return this;
        }

        public Animation Stop()
        {
            internalTimer.Stop();
            return this;
        }
        

        ~Animation()
        {
            Dispose();
        }
    }
}