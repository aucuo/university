# 1
dat <- read.csv(url('https://stepic.org/media/attachments/lesson/11504/lekarstva.csv'))
t.test(dat$Pressure_before,dat$Pressure_after, paired = T)[[1]]

# 2 Сравнение двух групп
dat <- read.table("dataset_11504_16.txt")
t_test <- t.test(dat$V1, dat$V2, var.equal = T)
ifelse(t.test(dat$V1, dat$V2)[[3]] < 0.05, 
    print(c(t_test[[3]],t_test$estimate[[1]],t_test$estimate[[2]])),
    print("The difference is not significant"))