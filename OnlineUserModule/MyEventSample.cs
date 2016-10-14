using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineUserModule
{

    //http://www.cnblogs.com/DebugLZQ
    //自定义事件步骤的示例代码

    //0.定义事件传递的参数
    class AlarmEventArgs : EventArgs
    {
        public int numberOfThief;
        public AlarmEventArgs(int n)
        {
            numberOfThief = n;
        }
    }
    //事件的发出者
    class Dog
    {
        //1.声明事件的委托
        public delegate void AlarmEventHandler(Object sender, AlarmEventArgs e);
        //2.声明事件
        public event AlarmEventHandler Alarm;
        //3.引发事件的函数
        public void OnAlarm(AlarmEventArgs e)
        {
            if (this.Alarm != null)
            {
                Console.WriteLine("The dog is Wangwang...");
                this.Alarm(this, e);
            }
        }
    }
    //事件的订阅者
    class Host
    {
        //4.订阅事件
        public Host(Dog dog)
        {
            dog.Alarm += new Dog.AlarmEventHandler(HostHandleEvent);
        }
        //5.事件处理程序
        public void HostHandleEvent(Object sender, AlarmEventArgs e)
        {
            Console.WriteLine("Host caught the thief! The sum is " + e.numberOfThief);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Program is running...");

            Dog dog = new Dog();
            Host host = new Host(dog);

            Console.WriteLine("Someone is coming...");
            //6.在合适的时候引发事件
            AlarmEventArgs alarmEventArgs = new AlarmEventArgs(3);
            dog.OnAlarm(alarmEventArgs);

            Console.ReadKey();
        }
    }
}