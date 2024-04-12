import requests

def fetch_users():
    response = requests.get("https://jsonplaceholder.typicode.com/users")
    if response.status_code == 200:
        users = response.json()
        return users
    else:
        return f"Error: Unable to fetch users. Status code: {response.status_code}"

def display_users(users):
    for user in users:
        print(f"ID: {user['id']}, Name: {user['name']}, Email: {user['email']}")

def main():
    users = fetch_users()
    if isinstance(users, list):
        display_users(users)
    else:
        print(users)

if __name__ == "__main__":
    main()
