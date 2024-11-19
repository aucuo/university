#1 При помощи функции ggplot() или boxplot() постройте график boxplot, используя встроенные в R данные airquality. По оси x отложите номер месяца, по оси y — значения переменной Ozone.

if (!require("ggplot2")) install.packages("ggplot2", dependencies = TRUE)
library(ggplot2)

data("airquality")

airquality$Month <- as.factor(airquality$Month)

p <- ggplot(airquality, aes(x = Month, y = Ozone)) +
  geom_boxplot() +
  geom_jitter(width = 0.2, alpha = 0.5) +
  theme_minimal() +
  labs(title = "Boxplot of Ozone Levels by Month", x = "Month", y = "Ozone Levels")

print(p)

count_outliers <- function(data, month) {
  month_data <- subset(data, Month == month)
  
  Q1 <- quantile(month_data$Ozone, 0.25, na.rm = TRUE)
  Q3 <- quantile(month_data$Ozone, 0.75, na.rm = TRUE)
  IQR <- Q3 - Q1
  
  lower_bound <- Q1 - 1.5 * IQR
  upper_bound <- Q3 + 1.5 * IQR
  
  outliers <- sum(month_data$Ozone < lower_bound | month_data$Ozone > upper_bound, na.rm = TRUE)
  return(outliers)
}

outliers_september <- count_outliers(airquality, "9")

print(outliers_september)


#2 Укажите, при помощи какого варианта кода мы можем построить следующий график по данным iris
library(ggplot2)

ggplot(iris, aes(Sepal.Length)) + geom_histogram(aes(fill = Species))
# или ggplot(iris, aes(Sepal.Length, fill = Species)) + geom_histogram()
