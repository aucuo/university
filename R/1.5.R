# 1 Примените функцию describeBy к количественным переменным данных airquality, группируя наблюдения по переменной Month.  Чему равен коэффициент асимметрии (skew) переменной Wind в восьмом месяце?
if (!require("psych")) install.packages("psych", dependencies = TRUE)
library(psych)

data("airquality")

august_data <- subset(airquality, Month == 8)

wind_description_august <- describe(august_data$Wind)

skew_wind_august <- wind_description_august$skew

print(skew_wind_august)


# 2 Обратимся к встроенным данным iris. Соотнесите значения стандартного отклонения переменных.
data("iris")

sd_sepal_length <- sd(iris$Sepal.Length)  # 0.76
sd_sepal_width <- sd(iris$Sepal.Width)    # 0.43
sd_petal_length <- sd(iris$Petal.Length)  # 1.77
sd_petal_width <- sd(iris$Petal.Width)    # 0.76

sd_sepal_length
sd_sepal_width
sd_petal_length
sd_petal_width

# 3 В данных iris расположите по убыванию значения медиан количественных переменных в группе virginica.

data("iris")

virginica_data <- subset(iris, Species == "virginica")

median_sepal_length <- median(virginica_data$Sepal.Length)
median_sepal_width <- median(virginica_data$Sepal.Width)
median_petal_length <- median(virginica_data$Petal.Length)
median_petal_width <- median(virginica_data$Petal.Width)

medians <- c(median_sepal_length, median_sepal_width, median_petal_length, median_petal_width)
names(medians) <- c("Sepal.Length", "Sepal.Width", "Petal.Length", "Petal.Width")

sorted_medians <- sort(medians, decreasing = TRUE)

sorted_medians
