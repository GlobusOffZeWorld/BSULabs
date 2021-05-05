#include <iostream>
#include <deque>
#include <vector>
#include <algorithm>
#include <fstream>

class comparator {
 public:
  bool operator()(double a, double b) {
    return std::abs(a) < std::abs(b);
  }
};

int main() {

  std::ifstream in("Container.IN");
  std::ofstream out("Container.OUT");

  if (!in.is_open()) {
    return 1;
  }
  if (in.peek() == std::ifstream::traits_type::eof()) {
    return 2;
  }

  std::deque<double> example
      {}; //1.5, -5, 10, -0.6, 14, 14.2, 16, -10, 9, -85, -48, -50, 73, -4, 3, -28, -68, 8, 24, 30, -72, 0, -49, -83, 57, 75 ,84, -78, 97, 81 ,-49, -36, 48,-32, 14 ,-45, 23, -54

  while (!in.eof()) {
    double number;
    in >> number;
    example.push_back(number);
  }

  if (example.size() < 30) {
    return 3;
  }

  int required_number_of_elements = 5;

  std::vector<double> vect(required_number_of_elements);

  comparator comp;
  std::sort(example.begin(), example.end(), comp);
  std::copy(example.begin(), example.begin() + required_number_of_elements, vect.begin());

  for (double i : vect) {
    out << i << " ";
  }

  return 0;
}
