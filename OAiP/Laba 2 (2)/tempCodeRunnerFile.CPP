char lowCaseRus (char str) {
    for (i = 0; i < str.length(); i++) {
        if (str[i] >= 192 && str[i] <= 223) str[i] += 32;
    }

    return str;
}