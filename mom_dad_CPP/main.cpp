#include <iostream>
#include <string>
#include <thread>
#include <chrono>
#include <mutex>

class TaskOutput {
 public:
  static int count_of_messages_;

  TaskOutput(const std::string &message, int repeat_count, int delay) {
    message_ = message;
    repeat_count_ = repeat_count;
    delay_ = delay;
  }

  void outputFunc() {
    std::mutex mtx;
    for (size_t i = 0; i < repeat_count_; ++i) {
      if (count_of_messages_ == 0) {
        break;
      }
      mtx.lock();
      --count_of_messages_;
      mtx.unlock();

      std::cout << message_;
      std::this_thread::sleep_for(std::chrono::milliseconds(delay_));
    }
  }

  void operator()() {
    outputFunc();
  }

 private:
  std::string message_;
  int repeat_count_;
  int delay_;

};

int TaskOutput::count_of_messages_ = 10;


int main() {

  TaskOutput out1 = TaskOutput("Hi mom\n", 10, 2000);
  TaskOutput out2 = TaskOutput("Hi dad\n", 20, 200);
  TaskOutput out3 = TaskOutput("Hi kid\n", 10, 150);

  std::thread t1(&TaskOutput::outputFunc, out1);
  std::thread t2(out2);
  std::thread t3(out3);

  t1.join();
  t2.join();
  t3.join();

  return 0;
}
