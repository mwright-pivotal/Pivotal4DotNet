# Pivotal4DotNet

This project is intended to illustrate numerous Pivotal technologies that support .NET, with special emphasis on Pivotal CLoud Foundry.   To use this project, you will need access to a Pivotal Cloud Foundry environment that is deployed with Diego and diego enabled Windows.   See http://docs.pivotal.io/pivotalcf/opsguide/deploying-diego.html

The application has 3 service dependencies:
1. Pivotal Gemfire
2. Redis
3. RabbitMQ

(all Pivotal led open-source projects)

TODO: Setup Instructions
1. Publish app from VS to C:\Temp
2. C:\Temp\MyRestService>cf push p4dotnet -m 2g -s windows2012R2 -b https://github.com/ryandotsmith/null-buildpack.git --no-
start -p .
3. cf cs p-rabbitmq standard java-dotnet-messaging
4. cf bs p4dotnet java-dotnet-messaging
5. cf enable-diego p4dotnet                                (note this plugin doesn't exist for Windows 32bit)
6. cf start p4dotnet
