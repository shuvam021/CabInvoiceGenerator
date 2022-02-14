test:
	dotnet test Tests

run: test
	dotnet run -p Cab-Invoice-Generator
