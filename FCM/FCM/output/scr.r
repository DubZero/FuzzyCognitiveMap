c<-read.csv("C://Downloads/Done")# � �������� ��������� ������� ���� �� ����� .csv
# col = c(rep... ����� ������� ����� ��� ����� � ������� (����,���������� ����� ������ �����)
ts.plot(c,col=c(rep("blue",1),rep("red",1),rep("black",1),rep("green",1),rep("orange",1),rep("purple",1),rep("pink",1),rep("gray",1),rep("yellow",1),rep("violet",1)))
# "bottomright" - ������������ �������, legend=�(... �������� ��������� �� �������
legend("bottomright", legend=c("�1", "C2", "C4", "C5", "C6", "C7", "C8", "C9", "C10"), 
# ����� ����� �� ������� ��������������
col=c('red','black','green','orange','purple','pink','gray','yellow','violet'), lty=1,lwd=1.5) 


