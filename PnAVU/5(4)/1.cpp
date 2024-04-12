#include <iostream>
#include <cstring>
using namespace std;

struct AEROFLOT {
    char place[15];
	int num;
    char type[15];
};

int main(){
	static int N = 7;
	AEROFLOT *fly = new AEROFLOT[N];
	int i;
	for (i = 0; i < N; i++){
		cout << "\ninput number of flight: "; cin >> fly[i].num;
		cout << "\ninput type of a plane: "; cin >> fly[i].type;
		cout << "\ninput place of arrival: "; cin >> fly[i].place;
	}
    char cur[15];
    for(i=0;i<N-1;i++)
        for(int j=i+1;j<N;j++)
            if(strcmp(fly[i].place ,fly[j].place)>0)
            {   strcpy(cur,fly[i].place );
                strcpy(fly[i].place ,fly[j].place );
                strcpy(fly[j].place ,cur);
            }
    cout << "\n егорегорегорегорегорегорегорегорегорегорегорегорегорегор\n";
    for (i = 0; i < N ; i++){
        cout << fly[i].place << "    " << fly[i].num << "    " << fly[i].type <<endl;

    }
    cout << "\n егорегорегорегорегорегорегорегорегорегорегорегорегорегор\n";
    char temp[15];
    int count;
    while (strcmp(temp, "exit")){
        cout << "\nEnter the desired type of aircraft: "; cin >> temp;
        count = 0;
        for (i = 0; i < N; i++){
            if (strcmp(fly[i].type , temp) == 0 ) {
                cout << endl << fly[i].place << "    "<< fly[i].num<< endl;
                count++;
            }
        }
        if (count == 0) cout << endl << " There are no such flights\n";
   }

}


