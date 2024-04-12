function iterateArray(arr, variant) {
    arr.forEach((num, index) => {
        if (num === variant) {
            console.error(`Элемент ${num}`);
        } else {
            console.log(`Элемент ${num}`);
        }
    });
}
const myArray = [1, 2, 3, 4, 5];
const myVariant = 3;

iterateArray(myArray, myVariant);

function askForDate() {
    let userInput;

    do {
        userInput = prompt("Введите строку:");
        if (userInput === "Дата") {
            const currentDate = new Date();
            console.log(`Текущая дата: ${currentDate}`);
        } else {
            console.log(`Вы ввели: ${userInput}. Попробуйте еще раз!`);
        }
    } while (userInput !== "Дата");
}

function printArrayWithDelay(N) {
    const arr = new Array(N).fill().map((_, index) => index);

    arr.forEach((num, index) => {
        setTimeout(() => {
            console.log(num);
        }, 3000 * index);
    });
}
