#include<arpa/inet.h>
#include<string.h>
#include<stdio.h>
#include<unistd.h>
#include<sys/socket.h>
#include<sys/types.h>
#include<netinet/in.h>
#include<fcntl.h>
#include<sys/stat.h>
#include<stdlib.h>
#define MAX 50
int main()
{
	int sockfd,retval;
	int rcdbytes,sentbytes;
	socklen_t actuallen;
	struct sockaddr_in saddr,caddr;
	size_t mbytes;
	char buff[MAX];
	sockfd=socket(AF_INET,SOCK_DGRAM,0);
	if(sockfd==-1)
	{
		printf("\nSOCKET CREATION ERROR");
		exit(0);
	}
	saddr.sin_family=AF_INET;
	saddr.sin_port=htons(3389);
	saddr.sin_addr.s_addr=inet_addr("127.0.0.1");
	caddr.sin_family=AF_INET;
	caddr.sin_port=htons(3388);
	caddr.sin_addr.s_addr=inet_addr("127.0.0.1");
	actuallen=sizeof(saddr);
	retval=bind(sockfd,(struct sockaddr *)&caddr,sizeof(caddr));
	if(retval==-1)
	{
		printf("\nBinding Error");
		exit(0);
	}
	while(1)
	{
		gets(buff);
		mbytes=(sizeof(buff));
		sentbytes=sendto(sockfd,buff,mbytes,0,(struct sockaddr *)&saddr,actuallen);
		if(strcmp(buff,"stop")==0)	
			break;
		rcdbytes=recvfrom(sockfd,buff,mbytes,0,(struct sockaddr *)&saddr,&actuallen);
		if(strcmp(buff,"stop")==0)	
			break;
		else puts(buff);
	}
	close(sockfd);
	exit(0);
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  