#include <stdio.h>

int main(){
/* length: 927 bytes */
unsigned char shellcode[] = "";
    char key[] = "aeyp^cc9boQEoHdq";
    int keySize = sizeof(key);
    int i;
    for (i = 0; i < sizeof(shellcode); i++){
        shellcode[i] = shellcode[i] ^ key[i % keySize];
        printf("\\x%02X", shellcode[i] & 0xff);
    }
}
