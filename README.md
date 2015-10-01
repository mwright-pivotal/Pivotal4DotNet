# Pivotal4DotNet
<br>
This project is intended to illustrate numerous Pivotal technologies that support .NET, with special emphasis on Pivotal CLoud Foundry.   To use this project, you will need access to a Pivotal Cloud Foundry environment that is deployed with Diego and diego enabled Windows.   See http://docs.pivotal.io/pivotalcf/opsguide/deploying-diego.html
<br>
The application has 3 service dependencies:<br>
1. Pivotal Gemfire<br>
2. Redis<br>
3. RabbitMQ<br>
<br>
(all Pivotal led open-source projects)
<br>
TODO: Setup Instructions<br>
1. Publish app from VS to C:\Temp<br>
2. C:\Temp\MyRestService>cf push p4dotnet -m 2g -s windows2012R2 -b https://github.com/ryandotsmith/null-buildpack.git --no-
start -p .<br>
3. cf cs p-rabbitmq standard java-dotnet-messaging<br>
4. cf bs p4dotnet java-dotnet-messaging<br>
5. cf enable-diego p4dotnet                                (note this plugin doesn't exist for Windows 32bit)<br>
6. cf start p4dotnet<br>
