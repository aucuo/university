class Person:
    def __init__(self, name, age):
        self.name = name
        self.age = age
    
    def display_info(self):
        print(f"Имя: {self.name}, Возраст: {self.age}")

person = Person("Алексей", 30)
person.display_info()