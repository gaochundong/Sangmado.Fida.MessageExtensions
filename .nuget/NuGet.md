Commands
------------
nuget setApiKey xxx-xxx-xxxx-xxxx

nuget pack ..\Sangmado.Fida.MessageExtensions\Sangmado.Fida.MessageExtensions.csproj -IncludeReferencedProjects -Symbols -Build -Prop Configuration=Release -OutputDirectory ".\packages"

nuget push .\packages\Sangmado.Fida.MessageExtensions.1.0.0.0.nupkg

