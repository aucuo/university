#include <stdio.h>

using namespace std;

int main(int argc, char *argv[])
{
    char str[51];

    printf("Text input: ");
    gets(str);

    int pos=0,min=0;

    for(int j=0;str[j]!=0;j++) if(str[0]==str[j])min++;

    for(int i=0;str[i]!=0;i++) {
        int count=0;

        for(int j=0;str[j]!=0;j++)if(str[i]==str[j]) count++;

        if(min>count) {
            min=count;
            pos=i;
        }
    }

    printf("The result: %c\n",str[pos]);

    return 0;
}