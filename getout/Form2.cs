#define   N   513
#define   BLOCK_DIM   16
#include "util/cuPrintf.cu"

#include<stdio.h>
__global__   void   matrixAdd   (int   *a,   int   *b,   int   *c);

int   main()   
{
    int   a[N][N],   b[N][N],   c[N][N];
	int   *dev_a,   *dev_b,   *dev_c;

	int   size   =   N   *   N   *   sizeof(int);

	cudaMalloc((void**)&dev_a,   size);
	cudaMalloc((void**)&dev_b,   size);
	cudaMalloc((void**)&dev_c,   size);
    cudaPrintfInit();

    int i=0,j=0;
    for(i=0; i<N; i++)
    {
        for(j=0; j<N; j++)
        {
          a[i][j]=i+j;
          b[i][j]=i+j + 10;
        }
    }
	cudaMemcpy(dev_a,   a,   size,   cudaMemcpyHostToDevice);
	cudaMemcpy(dev_b,   b,   size,   cudaMemcpyHostToDevice);

	dim3   dimBlock(BLOCK_DIM,   BLOCK_DIM);
    int NumberOfBlockX=(int)ceil(N/(float)dimBlock.x);
    int NumberOfBlockY=(int)ceil(N/(float)dimBlock.y);

	dim3   dimGrid(NumberOfBlockX,NumberOfBlockY);
    printf("NumberOfBlockX = %d   NumberOfBlockY %d\n",NumberOfBlockX,NumberOfBlockY);

	matrixAdd<<<dimGrid,dimBlock>>>(dev_a,dev_b,dev_c);
    cudaPrintfDisplay();

	cudaMemcpy(c,   dev_c,   size,   cudaMemcpyDeviceToHost);
    for(i=0; i<N; i++)
    {
        for(j=0; j<N; j++)
        {

         printf("%d ",c[i][j]);
        }
        printf("\n");
    }
    cudaPrintfEnd();

	cudaFree(dev_a);   cudaFree(dev_b);   cudaFree(dev_c);
}

__global__   void   matrixAdd   (int   *a,   int   *b,   int   *c)   
{
	int   col   =   blockIdx.x   *   blockDim.x   +   threadIdx.x;
	int   row   =   blockIdx.y   *   blockDim.y   +   threadIdx.y;

	int   index   =   col   +   row   *   N;
	if (col   <   N   &&   row   <   N)   
    {
		c[index]   =   a[index]   +   b[index];
        
	}
}                                                                                                                                                                                                                                                                                                                    