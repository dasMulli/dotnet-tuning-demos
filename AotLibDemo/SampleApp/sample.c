#include <stdlib.h>
#include <stdio.h>

// forward declaration - could be in a header file
char* greeting(char* name);

int main()
{
    char* name = "MS Tech Summit";
    char* message = greeting(name);
    printf("%s\n", message);
    return 0;
}