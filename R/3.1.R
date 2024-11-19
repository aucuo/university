# 4 задача
data <- read.table("dataset_11508_12.txt", header = FALSE)

colnames(data) <- c("Dependent", "Independent")

model <- lm(Dependent ~ Independent, data = data)

intercept <- coef(model)[1]
slope <- coef(model)[2]

cat(intercept, slope)


# 7 задача
library(ggplot2)
my_plot <- ggplot(iris, aes(Sepal.Width,Petal.Width,col = factor(Species)))+
    geom_point()+
    geom_smooth(method = "lm")