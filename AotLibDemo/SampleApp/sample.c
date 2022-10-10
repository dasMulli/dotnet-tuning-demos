#include <stdlib.h>
#include <stdio.h>

// forward declaration - could be in a header file
char const* greeting(const char* name);

int main()
{
    char const* name = "NDC Sydney";
    char const* message = greeting(name);
    printf("%s\n", message);
    return 0;
}