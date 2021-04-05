using System;
using System.Threading;

namespace mom_and_dad {
  public class TaskOutput {
    public static int CountOfMessages = 30;

    public static object lo = new object();

    private string _message;
    private int _repeatCount;
    private int _delay;

    public TaskOutput(string message, int repeatCount, int delay) {
      _message = message;
      _repeatCount = repeatCount;
      _delay = delay;
    }

    public string Message {
      get => _message;
    }

    public int RepeatCount {
      get => _repeatCount;
    }

    public int Delay {
      get => _delay;
    }

    public void OutputFunc() {
      for (int i = 0; i < RepeatCount; ++i) {
        if (CountOfMessages == 0) {
          break;
        }

        lock (lo) {
          --CountOfMessages;
        }

        Console.WriteLine(Message);
        Thread.Sleep(Delay);
      }
    }
  }

  internal class Program {
    public static void Main(string[] args) {
      TaskOutput out1 = new TaskOutput("Hi mom", 100, 2000);
      TaskOutput out2 = new TaskOutput("Hi dad", 50, 200);
      TaskOutput out3 = new TaskOutput("Hi kid", 10, 100);

      Thread t1 = new Thread(out1.OutputFunc);
      t1.Start();
      Thread t2 = new Thread(out2.OutputFunc);
      t2.Start();
      Thread t3 = new Thread(out3.OutputFunc);
      t3.Start();

      t1.Join();
      t2.Join();
      t3.Join();
    }
  }
}