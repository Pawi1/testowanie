from subprocess import run

run(["dotnet", "build"], cwd="Testowanie")
run(["dotnet", "build"], cwd="Testowanie.Tests")
