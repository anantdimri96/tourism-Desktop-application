// This example demonstrates parallel floating point vector
// addition with a simple __global__ function.

#include <stdlib.h>
#include <stdio.h>
#include <math.h>
#include <time.h>
#include <sys/time.h>

// this kernel computes the vector sum c = a + b
// each thread performs one pair-wise addition
__global__ void vector_add(const float *a,
                           const float *b,
                           float *c,
                           const size_t n)
{
  // compute the global element index this thread should process
  unsigned int i = threadIdx.x + blockDim.x * blockIdx.x;

  // avoid accessing out of bounds elements
  if(i < n)
  {
    // sum elements
    //c[i] = a[i] + b[i];
    c[i]=a[i];
    c[i+n]=b[i];
  }
}

/* Return 1 if the difference is negative, otherwise 0.  */
int timeval_subtract(stru