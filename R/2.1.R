# 1 Напишите число зеленоглазых женщин в наборе данных HairEyeColor
data("HairEyeColor")

green_eyed_women <- HairEyeColor["Green", "Female" ]

total_green_eyed_women <- sum(green_eyed_women)

total_green_eyed_women

# 2 На основе таблицы HairEyeColor создайте ещё одну таблицу, в которой хранится информация о распределении цвета глаз у женщин-шатенок (Hair = 'Brown').
chisq.test(HairEyeColor["Brown", ,"Female"])