using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace NickAc.LightPOS.Backend.Utils
{
    public class Animation : IDisposable
    {
        internal int hitCount;
        internal int executionLimit;
        internal Action<Animation> timerAction;
        internal readonly Timer internalTimer;
        public Animation()
        {
            internalTimer = new Timer(5)
            {
                AutoReset = true
            };
            internalTimer.Elapsed += (s, e) => {
                if (executionLimit > 0) {
                    if (hitCount > executionLimit) {
                        Stop();
                        return;
                    }
                    hitCount++;
                }
                timerAction?.Invoke(this);

            };
        }

        public Animation WithDisposal(System.Windows.Forms.Control disposable)
        {
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

        public void Dispose()
        {
            timerAction = null;
            internalTimer.Stop();
            internalTimer.Dispose();

        }

        ~Animation()
        {
            Dispose();
        }
    }
}
