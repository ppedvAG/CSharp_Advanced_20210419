using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAndEventHandler
{

    public delegate void Notify();

    public delegate void InProcessing(int processBarValue);

    public class ProcessBusinessLogic
    {
        public event Notify ProcessCompleted; ///Event
        public event InProcessing ProcessInWorking; 


        public void StartProcess()
        {
            Console.WriteLine("Process ist gestartet");

            for (int i = 0; i <= 100; i++)
            {
                OnInProcessing(i);
            }


            OnProcessCompleted();
        }
        
        protected virtual void OnInProcessing(int value)
        {
            ProcessInWorking?.Invoke(value);
        }


        protected virtual void OnProcessCompleted()
        {
            ProcessCompleted?.Invoke();
        }
    }
}
