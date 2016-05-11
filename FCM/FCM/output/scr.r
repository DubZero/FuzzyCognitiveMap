c<-read.csv("C://Downloads/Done")# в качестве аргумента функции путь до файла .csv
# col = c(rep... здесь указать цвета для линий в формате (цвет,количество линий такого цвета)
ts.plot(c,col=c(rep("blue",1),rep("red",1),rep("black",1),rep("green",1),rep("orange",1),rep("purple",1),rep("pink",1),rep("gray",1),rep("yellow",1),rep("violet",1)))
# "bottomright" - расположение легенды, legend=с(... название концептов на легенде
legend("bottomright", legend=c("С1", "C2", "C4", "C5", "C6", "C7", "C8", "C9", "C10"), 
# цвета линий на легенде соответственно
col=c('red','black','green','orange','purple','pink','gray','yellow','violet'), lty=1,lwd=1.5) 


