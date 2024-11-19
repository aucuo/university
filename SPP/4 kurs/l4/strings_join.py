def join_strings_with_delimiter(strings_list, delimiter):
    return delimiter.join(strings_list)

strings_list = ['пи', 'до', 'раскумар']
delimiter = '-'
result = join_strings_with_delimiter(strings_list, delimiter)
print(result)