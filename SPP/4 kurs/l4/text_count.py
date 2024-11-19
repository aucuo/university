def count_text_properties(text):
    num_chars = len(text)
    num_words = len(text.split())
    num_sentences = text.count('.') + text.count('!') + text.count('?')
    
    return num_chars, num_words, num_sentences

text = input("Введите текст: ")
chars, words, sentences = count_text_properties(text)
print(f"Количество символов: {chars}")
print(f"Количество слов: {words}")
print(f"Количество предложений: {sentences}")
