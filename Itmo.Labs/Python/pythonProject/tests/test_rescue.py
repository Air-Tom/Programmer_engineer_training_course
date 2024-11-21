import unittest
import math
from main import yards_to_feet, mph_to_fts, calculate_x, calculate_L1, calculate_L2, calculate_t

class TestRescueCalculations(unittest.TestCase):

    def test_yards_to_feet(self):
        self.assertEqual(yards_to_feet(1), 3)
        self.assertEqual(yards_to_feet(0), 0)
        self.assertEqual(yards_to_feet(5), 15)

    def test_mph_to_fts(self):
        self.assertAlmostEqual(mph_to_fts(1), 1.46667, places=5)
        self.assertAlmostEqual(mph_to_fts(0), 0)
        self.assertAlmostEqual(mph_to_fts(60), 88.0, places=5)

    def test_calculate_x(self):
        self.assertAlmostEqual(calculate_x(10, math.radians(45)), 10)
        self.assertAlmostEqual(calculate_x(20, math.radians(30)), 11.547005383792515)

    def test_calculate_L1(self):
        self.assertAlmostEqual(calculate_L1(10, 20), math.sqrt(10**2 + 20**2))
        self.assertAlmostEqual(calculate_L1(0, 0), 0)

    def test_calculate_L2(self):
        self.assertAlmostEqual(calculate_L2(3, 10, 4), math.sqrt((3 - 10)**2 + 4**2))
        self.assertAlmostEqual(calculate_L2(0, 0, 0), 0)

    def test_calculate_t(self):
        self.assertAlmostEqual(calculate_t(10, 20, 5, 2), (10 + 2 * 20) / 5)
        self.assertAlmostEqual(calculate_t(0, 0, 1, 1), 0)

if __name__ == '__main__':
    greet_user()
    
    # Запуск тестов
    unittest.main()