# 1 Вопрос
if (!require("gvlma")) install.packages("gvlma", dependencies = TRUE)
library(gvlma)

data <- read.csv("https://stepik.org/media/attachments/lesson/12088/homosc.csv")

model <- lm(DV ~ IV, data = data)

gvlma_model <- gvlma(model)

summary(gvlma_model)