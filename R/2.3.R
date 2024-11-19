# 2
summary(aov(yield ~ N * P, npk))

# 3
summary(aov(yield ~ N + P + K, npk))

# 4 
TukeyHSD(aov(Sepal.Width ~ Species, iris))

# 5
dat <- read.csv(url('https://stepic.org/media/attachments/lesson/11505/Pillulkin.csv'))
summary(aov(temperature ~ pill + Error(factor(patient)/pill),dat))
