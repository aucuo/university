import math

class Circle:
    def __init__(self, radius):
        self.radius = radius
    
    def calculate_area(self):
        return math.pi * (self.radius ** 2)
    
    def calculate_perimeter(self):
        return 2 * math.pi * self.radius

circle = Circle(5)
print(f"Площадь круга: {circle.calculate_area():.2f}")
print(f"Периметр круга: {circle.calculate_perimeter():.2f}")
