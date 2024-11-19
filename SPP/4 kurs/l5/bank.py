class BankAccount:
    def __init__(self, initial_balance=0):
        self.balance = initial_balance
    
    def deposit(self, amount):
        self.balance += amount
        print(f"Внесено: {amount}. Текущий баланс: {self.balance}")
    
    def withdraw(self, amount):
        if amount > self.balance:
            print("Недостаточно средств!")
        else:
            self.balance -= amount
            print(f"Снято: {amount}. Текущий баланс: {self.balance}")

account = BankAccount(100)
account.deposit(50)
account.withdraw(30)
account.withdraw(150)
